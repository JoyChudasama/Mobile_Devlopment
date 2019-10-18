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
    class Contact
    {
        public string Fees{get; set;}
      

        public Contact(string fees)
        {
            Fees = fees;
           
        }
        public override string ToString()
        {
            return (Fees);
        }
    }
}