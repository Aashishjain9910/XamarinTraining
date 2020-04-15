using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamTraining.Models;

namespace XamTraining.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BlogsCollectionView : ContentPage
    {
        public BlogsCollectionView()
        {
            InitializeComponent();

            List<CollectionList> blogs = new List<CollectionList>()
            {
                new CollectionList
                {
                    BlogImage="Microservices.jpeg", BlogHeading="Microservices", BlogText="The world we live in is dynamic, in fact, the only sure-fire constant that you may find in it is the fact that change here, is a rather constant set of affairs."
                },
                new CollectionList
                {
                    BlogImage="QueuingtaskwithRedis.jpeg", BlogHeading="Queuing with Redis", BlogText="Redis is an open-source data structure that is used for in-memory storage and helps developers across the globe with the quick and efficient organization and utilization of data."
                },
                new CollectionList
                {
                    BlogImage="nodejsProgramme.jpg", BlogHeading="Nodejs Programme", BlogText="Although Node.js 13 may not be used by developers for production, it is still important when it comes to building and testing the latest features."
                },
                new CollectionList
                {
                    BlogImage="MobileAppideasJavaScript.jpeg", BlogHeading="Mobile App Ideas", BlogText="Hybrid apps merge components of the web and native applications. They are a mobile version of a website that runs on a web browser."
                },
                new CollectionList
                {
                    BlogImage="DevOpsFeatures.png", BlogHeading="DevOps Features", BlogText="Today, the top UX design firms are investing heavily in advanced technologies that can help them in the faster development and delivery of products."
                },
                new CollectionList
                {
                    BlogImage="IOT.jpeg", BlogHeading="Internet Of Things", BlogText="IoT has increased our efficiency and taken it off the chats in terms of saving of time, accuracy and precision."
                },
                new CollectionList
                {
                    BlogImage="Blockchain.png", BlogHeading="Blockchain", BlogText="Today, the top UX design firms are investing heavily in advanced technologies that can help them in the faster development and delivery of products."
                },
                new CollectionList
                {
                    BlogImage="DigitalTransformation.png", BlogHeading="Digital Transformation", BlogText="Today, the top UX design firms are investing heavily in advanced technologies that can help them in the faster development and delivery of products."
                },
                new CollectionList
                {
                    BlogImage="DroneTechnologies.jpg", BlogHeading="Drone Technologies", BlogText="Today, the top UX design firms are investing heavily in advanced technologies that can help them in the faster development and delivery of products."
                },
                new CollectionList
                {
                    BlogImage="EXtendedRealities.jpg", BlogHeading="EXtended Realities", BlogText="Today, the top UX design firms are investing heavily in advanced technologies that can help them in the faster development and delivery of products."
                },
                new CollectionList
                {
                    BlogImage="ReactVsXamarin.jpeg", BlogHeading="React Vs Xamarin", BlogText="Today, the top UX design firms are investing heavily in advanced technologies that can help them in the faster development and delivery of products."
                },
                new CollectionList
                {
                    BlogImage="Salesforce.jpeg", BlogHeading="Salesforce Billing", BlogText="Today, the top UX design firms are investing heavily in advanced technologies that can help them in the faster development and delivery of products."
                },
                new CollectionList
                {
                    BlogImage="SelfDrivingCars.png", BlogHeading="Self Driving Cars", BlogText="Today, the top UX design firms are investing heavily in advanced technologies that can help them in the faster development and delivery of products."
                },
                new CollectionList
                {
                    BlogImage="UpliftViaChatbots.png", BlogHeading="Chatbots", BlogText="Today, the top UX design firms are investing heavily in advanced technologies that can help them in the faster development and delivery of products."
                },
                new CollectionList
                {
                    BlogImage="VoiceTechnologies.jpeg", BlogHeading="Voice Technologies", BlogText="Today, the top UX design firms are investing heavily in advanced technologies that can help them in the faster development and delivery of products."
                },
                new CollectionList
                {
                    BlogImage="MangoPay.jpg", BlogHeading="Mango Pay", BlogText="Today, the top UX design firms are investing heavily in advanced technologies that can help them in the faster development and delivery of products."
                },
                new CollectionList
                {
                    BlogImage="ApacheCordova.jpeg", BlogHeading="Apache Cordova", BlogText="Today, the top UX design firms are investing heavily in advanced technologies that can help them in the faster development and delivery of products."
                }

            };
            collectionList.ItemsSource = blogs;
            
           

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            DisplayAlert(" ", "Items Saved", "OK");
        }
    }
}