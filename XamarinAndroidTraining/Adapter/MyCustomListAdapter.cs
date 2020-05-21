using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using XamarinAndroidTraining.models;

namespace XamarinAndroidTraining.Adapter
{
    class MyCustomListAdapter : BaseAdapter<User>
    {
        List<User> users;

        public MyCustomListAdapter(List<User> users)
        {
            this.users = users;
        }

        public override User this[int position]
        {
            get
            {
                return users[position];
            }
        }

        public override int Count
        {
            get
            {
                return users.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;

            if (view == null)
            {
                view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.UserRowCellLayout, parent, false);


                var changesMode = view.FindViewById<TextView>(Resource.Id.changesMode);
                var statusDate = view.FindViewById<TextView>(Resource.Id.statusDate);
                var statusChanged = view.FindViewById<TextView>(Resource.Id.statusChanged);
                var byWillSmith = view.FindViewById<TextView>(Resource.Id.byWillSmith);
                var updateTime = view.FindViewById<TextView>(Resource.Id.updateTime);

                view.Tag = new MyCustomListAdapterViewHolder()
                {
                    ChangesMode = changesMode,
                    StatusDate = statusDate,
                    StatusChanged = statusChanged,
                    ByWillSmith = byWillSmith,
                    UpdateTime = updateTime
                };
            }
            
            var holder = (MyCustomListAdapterViewHolder)view.Tag;

            holder.ChangesMode.Text = users[position].ChangesMode;
            holder.StatusDate.Text = users[position].StatusDate;
            holder.StatusChanged.Text = users[position].StatusChanged;
            holder.ByWillSmith.Text = users[position].ByWillSmith;
            holder.UpdateTime.Text = users[position].UpdateTime;

            return view;
        }

        //Fill in cound here, currently 0


    }

    class MyCustomListAdapterViewHolder : Java.Lang.Object
    {
        public TextView ChangesMode { get; set; }
        public TextView StatusDate { get; set; }
        public TextView StatusChanged { get; set; }
        public TextView ByWillSmith { get; set; }
        public TextView UpdateTime { get; set; }
    }
}