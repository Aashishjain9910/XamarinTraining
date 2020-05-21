using Android.Support.V4.View;
using Android.Support.V7.App;
using Android.Support.Design.Widget;
using V4Fragment = Android.Support.V4.App.Fragment;
using V4FragmentManager = Android.Support.V4.App.FragmentManager;
using System.Collections.Generic;
using Android.App;
using Android.OS;
using System;
using XamarinAndroidTraining.Resources.layout;
using XamarinAndroidTraining.Fragment;

namespace XamarinAndroidTraining.Activities
{
    [Activity(Label = "TabbedFragmentActivity")]
    public class TabbedFragmentActivity : AppCompatActivity
    {
        TabLayout tabLayout;
        ViewPager viewPager;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.TabbedFragmentLayout);
            tabLayout = FindViewById<TabLayout>(Resource.Id.tabLayout);
            viewPager = FindViewById<ViewPager>(Resource.Id.viewPager1);
            tabLayout.SetupWithViewPager(viewPager);
            if (viewPager.Adapter == null)
            {
                setupViewPager(viewPager);
            }
            else
            {
                viewPager.Adapter.NotifyDataSetChanged();
            }

            tabLayout.SetupWithViewPager(viewPager);
        }
        void setupViewPager(Android.Support.V4.View.ViewPager viewPager)
        {
            var adapter = new Adapter(SupportFragmentManager);
            adapter.AddFragment(new FirstFragment(), "First Fragment");
            adapter.AddFragment(new SecondFragment(), "Second Fragment");
            adapter.AddFragment(new ThirdFragment(), "Third Fragment");
            adapter.AddFragment(new FourthFragment(), "Fourth Fragment");
            viewPager.Adapter = adapter;
            viewPager.Adapter.NotifyDataSetChanged();
        }
    }
    class Adapter : Android.Support.V4.App.FragmentPagerAdapter
        {
            List<V4Fragment> fragments = new List<V4Fragment>();
            List<string> fragmentTitles = new List<string>();
            public Adapter(V4FragmentManager fm) : base(fm) { }
            public void AddFragment(V4Fragment fragment, String title)
            {
                fragments.Add(fragment);
                fragmentTitles.Add(title);
            }
            public override V4Fragment GetItem(int position)
            {
                return fragments[position];
            }
            public override int Count
            {
                get
                {
                    return fragments.Count;
                }
            }
            public override Java.Lang.ICharSequence GetPageTitleFormatted(int position)
            {
                return new Java.Lang.String(fragmentTitles[position]);
            }
        }

    }
