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
    [Activity(Label = "thirdpage")]
    public class thirdpage : Activity
    {
        TextView ShowTotal, Name, TotalFees,TotalHours;
        Button Total;
        CheckBox Acco, Trans, Books;
        ListView radha;
        private List<string> rrr;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.thirdpage);
            // Create your application here
            Name = FindViewById<TextView>(Resource.Id.Name);
            ShowTotal = FindViewById<TextView>(Resource.Id.showtotal);
            Total = FindViewById<Button>(Resource.Id.total);
            Acco = FindViewById<CheckBox>(Resource.Id.accommodation);
            Trans = FindViewById<CheckBox>(Resource.Id.transportation);
            Books = FindViewById<CheckBox>(Resource.Id.books);
            TotalFees = FindViewById<TextView>(Resource.Id.totalfees);
            TotalHours = FindViewById<TextView>(Resource.Id.totalhours);
            radha = FindViewById<ListView>(Resource.Id.listView1);
            string rr = Intent.GetStringExtra("r");
            //TotalFees.Text = rr;

            string rr2 = Intent.GetStringExtra("ok2");
            TotalHours.Text = rr2;

            string fees = Intent.GetStringExtra("fees");
            TotalFees.Text = fees;
            Total.Click += Total_Click;
            string name = Intent.GetStringExtra("name");
            Name.Text =name;

            rrr = new List<string>();
            rrr.Add(rr);
            ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, rrr);
            radha.Adapter = adapter;


        }

        private void Total_Click(object sender, EventArgs e)
        {
            double tfees = double.Parse(TotalFees.Text);

            if (Acco.Checked && Trans.Checked && Books.Checked)
                tfees += 4600;
            else if (Acco.Checked && Trans.Checked)
                tfees += 4000;
            else if (Acco.Checked && Books.Checked)
                tfees += 3600;
            else if (Trans.Checked && Books.Checked)
                tfees += 1600;
            else if (Acco.Checked)
                tfees += 3000;
            else if (Trans.Checked)
                tfees += 1000;
            else if (Books.Checked)
                tfees += 600;
            ShowTotal.Text = tfees.ToString();

        }
    }
}