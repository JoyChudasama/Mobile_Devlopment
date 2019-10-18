using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content;
using Android.Text;

namespace International_College
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme",Icon ="@mipmap/logo", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        EditText StudentName, Username, Password;
        Button SignIn;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            StudentName = FindViewById<EditText>(Resource.Id.stname);
            Username = FindViewById<EditText>(Resource.Id.username);
            Password = FindViewById<EditText>(Resource.Id.password);
            SignIn = FindViewById<Button>(Resource.Id.signin);
            SignIn.Click += SignIn_Click;
            
        }

       
            public void SignIn_Click(object sender, System.EventArgs e)
            {
                if (StudentName.Text == "" || Username.Text == "" || Password.Text == "")
                {

                    Toast.MakeText(this, "Please fill up required field", ToastLength.Long).Show();
                }
                else if ((Username.Text != "Romil") || (Password.Text != "1234"))
                {
                    Toast.MakeText(this, "Your username or password are wrong", ToastLength.Long).Show();
                }
                else if ((Username.Text == "Romil") && (Password.Text == "1234"))
                {
                    Toast.MakeText(this, "Your login successful", ToastLength.Long).Show();

                    Intent i = new Intent(this, typeof(firstpage));
                    i.PutExtra("name", StudentName.Text.ToString());
                    StartActivity(i);
                }
            }
        }
}
