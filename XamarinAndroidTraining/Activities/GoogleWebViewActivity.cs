using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Webkit;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Gms.Common.Apis;
using Android.Gms.Common;
using Android.Gms.Plus;
using Android.Util;
using Android.Graphics;
using System.Net;
using System.IO;
using Android.Gms.Tasks;
using Android.Support.V7.App;
using Android.Gms.Auth.Api.SignIn;
using Android.Gms.Auth.Api;
using Firebase.Auth;
using Firebase;
using Java.Lang;

namespace XamarinAndroidTraining.Activities
{
    [Activity(Label = "GoogleWebViewActivity", MainLauncher =true)]
    public class GoogleWebViewActivity : Activity, IOnSuccessListener, IOnFailureListener    /* GoogleApiClient.IConnectionCallbacks, GoogleApiClient.IOnConnectionFailedListener*/
    {
        #region
        //GoogleApiClient mGoogleApiClient;
        //private ConnectionResult mConnectionResult;
        //SignInButton mGsignBtn;
        //TextView TxtName;
        //ImageView ImgProfile;
        //private bool mIntentInProgress;
        //private bool mSignInClicked;
        //private bool mInfoPopulated;
        //public string TAG
        //{
        //    get;
        //    private set;
        //}
        #endregion

        Button signinButton;
        TextView displayNameText;
        TextView emailText;
        TextView photourlText;

        GoogleSignInOptions gso;
        GoogleApiClient googleApiClient;

        FirebaseAuth firebaseAuth;




        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Google_WebView);

            #region
            //mGsignBtn = FindViewById<SignInButton>(Resource.Id.sign_in_button);
            //TxtName = FindViewById<TextView>(Resource.Id.TxtName);
            //ImgProfile = FindViewById<ImageView>(Resource.Id.ImgProfile);

            //mGsignBtn.Click += MGsignBtn_Click;

            //GoogleApiClient.Builder builder = new GoogleApiClient.Builder(this);
            //builder.AddConnectionCallbacks(this);
            //builder.AddOnConnectionFailedListener(this);
            //builder.AddApi(PlusClass.API);
            //builder.AddScope(PlusClass.ScopePlusProfile);
            //builder.AddScope(PlusClass.ScopePlusLogin);
            ////Build our IGoogleApiClient  
            //mGoogleApiClient = builder.Build();
            #endregion

            signinButton = (Button)FindViewById(Resource.Id.signinButton);
            displayNameText = (TextView)FindViewById(Resource.Id.displayNameText);
            emailText = (TextView)FindViewById(Resource.Id.emailText);
            signinButton.Click += SigninButton_Click;

            gso = new GoogleSignInOptions.Builder(GoogleSignInOptions.DefaultSignIn)
                .RequestIdToken("1037739809912-lujoj1fsmh5kdbk4qocbcqcge5csprm6.apps.googleusercontent.com")
                .RequestEmail()
                .Build();

            googleApiClient = new GoogleApiClient.Builder(this)
                .AddApi(Auth.GOOGLE_SIGN_IN_API, gso).Build();
            googleApiClient.Connect();

            firebaseAuth = GetFirebaseAuth();
            UpdateUI();

        }


        private FirebaseAuth GetFirebaseAuth()
        {
            var app = FirebaseApp.InitializeApp(this);
            FirebaseAuth mAuth;

            if (app == null)
            {
                var options = new FirebaseOptions.Builder()
                    .SetProjectId("xamarinandroidtraining-279113")
                    .SetApplicationId("xamarinandroidtraining-279113")
                    .SetApiKey("AIzaSyALH9EDGO6p0psNvu4cDz826IkYIeW33j4")
                    .SetDatabaseUrl("https://xamarinandroidtraining-279113.firebaseio.com")
                    .SetStorageBucket("xamarinandroidtraining-279113.appspot.com")
                    .Build();

                app = FirebaseApp.InitializeApp(this, options);
                mAuth = FirebaseAuth.Instance;
            }
            else
            {
                mAuth = FirebaseAuth.Instance;
            }
            return mAuth;
        }

        private void SigninButton_Click(object sender, System.EventArgs e)
        {
            UpdateUI();
            if (firebaseAuth.CurrentUser == null)
            {
                var intent = Auth.GoogleSignInApi.GetSignInIntent(googleApiClient);
                StartActivityForResult(intent, 1);
            }
            else
            {
                firebaseAuth.SignOut();
                UpdateUI();
            }

        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (requestCode == 1)
            {
                GoogleSignInResult result = Auth.GoogleSignInApi.GetSignInResultFromIntent(data);
                if (result.IsSuccess)
                {
                    GoogleSignInAccount account = result.SignInAccount;
                    LoginWithFirebase(account);
                }
            }
        }

        private void LoginWithFirebase(GoogleSignInAccount account)
        {
            var credentials = GoogleAuthProvider.GetCredential(account.IdToken, null);
            firebaseAuth.SignInWithCredential(credentials).AddOnSuccessListener(this)
                .AddOnFailureListener(this);
        }




        void IOnFailureListener.OnFailure(Java.Lang.Exception e)
        {
            Toast.MakeText(this, "Login Failed", ToastLength.Short).Show();
            UpdateUI();
        }

        void IOnSuccessListener.OnSuccess(Java.Lang.Object result)
        {
            displayNameText.Text = "Display Name: " + firebaseAuth.CurrentUser.DisplayName;
            emailText.Text = "Email: " + firebaseAuth.CurrentUser.Email;

            Toast.MakeText(this, "Login successful", ToastLength.Short).Show();
            UpdateUI();
        }

        void UpdateUI()
        {
            if (firebaseAuth.CurrentUser != null)
            {
                signinButton.Text = "Sign Out";
                
            }
            else
            {
                signinButton.Text = "Sign In With Google";
                displayNameText.Text = "Display Name: ";
                emailText.Text = "Email: ";
            }
        }




        //protected override void OnStart()
        //{
        //    base.OnStart();
        //    mGoogleApiClient.Connect();
        //}
        //protected override void OnStop()
        //{
        //    base.OnStop();
        //    if (mGoogleApiClient.IsConnected)
        //    {
        //        mGoogleApiClient.Disconnect();
        //    }
        //}
        //public void OnConnected(Bundle connectionHint)
        //{
        //    var person = PlusClass.PeopleApi.GetCurrentPerson(mGoogleApiClient);
        //    var name = string.Empty;
        //    if (person != null)
        //    {
        //        TxtName.Text = person.DisplayName;
        //        var Img = person.Image.Url;
        //        var imageBitmap = GetImageBitmapFromUrl(Img.Remove(Img.Length - 5));
        //        if (imageBitmap != null) ImgProfile.SetImageBitmap(imageBitmap);
        //    }
        //}


        //private void MGsignBtn_Click(object sender, EventArgs e)
        //{
        //    if (!mGoogleApiClient.IsConnecting)
        //    {
        //        mSignInClicked = true;
        //        ResolveSignInError();
        //    }
        //    //else if (mGoogleApiClient.IsConnected)
        //    //{
        //    //    PlusClass.AccountApi.ClearDefaultAccount(mGoogleApiClient);
        //    //    mGoogleApiClient.Disconnect();
        //    //}
        //}
        //private void ResolveSignInError()
        //{
        //    if (mGoogleApiClient.IsConnecting)
        //    {

        //        return;


        //    }
        //    if (mConnectionResult.HasResolution)
        //    {
        //        try
        //        {
        //            mIntentInProgress = true;
        //            StartIntentSenderForResult(mConnectionResult.Resolution.IntentSender, 0, null, 0, 0, 0);
        //        }
        //        catch (Android.Content.IntentSender.SendIntentException io)
        //        {
        //            mIntentInProgress = false;
        //            mGoogleApiClient.Connect();
        //        }
        //    }
        //}



        //private Bitmap GetImageBitmapFromUrl(String url)
        //{
        //    Bitmap imageBitmap = null;
        //    try
        //    {
        //        using (var webClient = new WebClient())
        //        {
        //            var imageBytes = webClient.DownloadData(url);
        //            if (imageBytes != null && imageBytes.Length > 0)
        //            {
        //                imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
        //            }
        //        }
        //        return imageBitmap;
        //    }
        //    catch (IOException e) { }
        //    return null;
        //}
        //protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        //{
        //    //base.OnActivityResult(requestCode, resultCode, data);
        //    //Log.Debug(TAG, "onActivityResult:" + requestCode + ":" + resultCode + ":" + data);
        //    if (requestCode == 0)
        //    {
        //        if (resultCode != Result.Ok)
        //        {
        //            mSignInClicked = false;
        //        }
        //        mIntentInProgress = false;
        //        if (!mGoogleApiClient.IsConnecting)
        //        {
        //            mGoogleApiClient.Connect();
        //        }
        //    }
        //}






        //public void OnConnectionFailed(ConnectionResult result)
        //{
        //    if (!mIntentInProgress)
        //    {
        //        mConnectionResult = result;
        //        if (mSignInClicked)
        //        {
        //            ResolveSignInError();
        //        }
        //    }
        //}
        //public void OnConnectionSuspended(int cause) 
        //{
        //    throw new NotImplementedException();
        //}


    }
}