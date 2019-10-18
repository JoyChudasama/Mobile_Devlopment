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

namespace International_College
{
    [Activity(Label = "firstpage")]
    public class firstpage : Activity
    {
        TextView Showname,ShowAge;
        EditText Address, Number;
        SeekBar Age;
        RadioButton Graduated, Continued;
        Button Nextone;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.firstpage);
            // Create your application here
            Showname = FindViewById<TextView>(Resource.Id.showname);
            ShowAge = FindViewById<TextView>(Resource.Id.showage);
            Nextone = FindViewById<Button>(Resource.Id.nextone);
            Age = FindViewById<SeekBar>(Resource.Id.agenum);
            Address = FindViewById<EditText>(Resource.Id.address);
            Number = FindViewById<EditText>(Resource.Id.number);
            Graduated = FindViewById<RadioButton>(Resource.Id.graduated);
            Continued = FindViewById<RadioButton>(Resource.Id.continued);
            Nextone.Click += Nextone_Click;
            string name = Intent.GetStringExtra("name");
            Showname.Text = "Welcome " +name;
            Age.ProgressChanged += Age_ProgressChanged;
        }

        private void Age_ProgressChanged(object sender, SeekBar.ProgressChangedEventArgs e)
        {
            ShowAge.Text = Age.Progress.ToString();
        }

        private void Nextone_Click(object sender, EventArgs e)
        {
            Intent i = new Intent(this, typeof(secondpage));
            i.PutExtra("name", Showname.Text.ToString());
            StartActivity(i);
        }
    }
}