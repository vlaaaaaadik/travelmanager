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
        Button signUp;
        EditText mail;
        EditText password;
        DatabaseHandler data;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            data = new DatabaseHandler();
            data.database.CreateTable<User>();
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            signUp = FindViewById<Button>(Resource.Id.signUp);
            mail = FindViewById<EditText>(Resource.Id.mail);
            password = FindViewById<EditText>(Resource.Id.password);
            signUp.Click += (s, e) =>
            {
                if(mail.Text.Contains('@') && mail.Text != null && password.Text != null)
                {
                    data.database.Insert(new User(mail.Text, password.Text));
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