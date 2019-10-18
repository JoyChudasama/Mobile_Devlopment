using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Util;

namespace International_College
{
    [Activity(Label = "secondpage")]
    public class secondpage : Activity
    {
        Spinner spinner;
        TextView Fees, Hours,Name,Ok,Ok2;
        
        Button Add, NextTwo;
        ListView item;
        Double[] Fee = {0, 900, 1200, 1100, 1500,1200,900,1100,1000,1200,1300 };
        Double[] Hour = {0, 3, 4, 5, 6 ,4,5,3,4,6,5};
        private List<string> itemlist;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.secondpage);
            spinner = FindViewById<Spinner>(Resource.Id.spinner1);
            Hours = FindViewById<TextView>(Resource.Id.showhours);
            Fees = FindViewById<TextView>(Resource.Id.showfees);
            Ok = FindViewById<TextView>(Resource.Id.ok);
            Ok2 = FindViewById<TextView>(Resource.Id.ok2);
            Name = FindViewById<TextView>(Resource.Id.textView1);
            
            Add = FindViewById<Button>(Resource.Id.add);
            item = FindViewById<ListView>(Resource.Id.listView1);
            NextTwo = FindViewById<Button>(Resource.Id.nexttwo);
            Add.Click += Add_Click;
            NextTwo.Click += NextTwo_Click1;
            spinner.ItemSelected += Spinner_ItemSelected;
            itemlist = new List<string>();


            string name = Intent.GetStringExtra("name");
            Name.Text =  name;
            // Create your application here
        }




        

        private void NextTwo_Click1(object sender, EventArgs e)
        {
            Intent intent = new Intent(this, typeof(thirdpage));
            intent.PutExtra("r", item.Adapter.ToString());
            intent.PutExtra("fees", Ok.Text.ToString());
            intent.PutExtra("ok2", Ok2.Text.ToString());
            intent.PutExtra("name", Name.Text.ToString());
            StartActivity(intent);
            
        }



        private void Spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
                  Fees.Text=Fee[spinner.SelectedItemId].ToString();
                  Hours.Text=Hour[spinner.SelectedItemId].ToString();
            
        }

        private void Add_Click(object sender, EventArgs e)
        {
            itemlist.Add(Fees.Text + Hours.Text);
            ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, itemlist);
            item.Adapter=adapter;


            
            double a = double.Parse(Fees.Text); 
            Ok.Text += a.ToString();

            double b= double.Parse(Hours.Text);
            Ok2.Text += b;

            //var localContacts = Application.Context.GetSharedPreferences("MyContacts", FileCreationMode.Private);
            //var contactEdit = localContacts.Edit();
            //contactEdit.PutString("name1", a.ToString());

            //contactEdit.Commit();
            //Toast.MakeText(this, "item Added", ToastLength.Short).Show();
        }
    }
}