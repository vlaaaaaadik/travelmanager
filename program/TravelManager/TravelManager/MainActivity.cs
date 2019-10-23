using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;


namespace TravelManager
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Button signIn;
        EditText mail;
        EditText password;
        DatabaseHandler data;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            data = new DatabaseHandler();
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            signIn = FindViewById<Button>(Resource.Id.enter);
            mail = FindViewById<EditText>(Resource.Id.mail);
            password = FindViewById<EditText>(Resource.Id.password);
            signIn.Click += (s, e) =>
            {
                if(mail.Text.Contains('@') && mail.Text != null && password.Text != null)
                {
                    data.connection.Insert(new User(mail.Text, password.Text));
                }
            };

        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}