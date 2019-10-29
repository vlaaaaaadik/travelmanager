using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System.Linq;


namespace TravelManager
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Button signUp;
        Button enter;
        EditText mail;
        EditText password;
        DatabaseHandler data;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            data = new DatabaseHandler();
            
            data.database.CreateTable<User>();
            
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            SetContentView(Resource.Layout.activity_main);
            signUp = FindViewById<Button>(Resource.Id.signUp);
            mail = FindViewById<EditText>(Resource.Id.mail);
            password = FindViewById<EditText>(Resource.Id.password);
            enter = FindViewById<Button>(Resource.Id.enter);
            
            enter.Click += (s, e) =>
            {
                //TODO: перенести цей код в кнопку для реєстрації коли буде форма
                //var users = data.database.Table<User>();
                //var table = from i in users
                //            select i;
                //table.First().generateToken();
            };
            signUp.Click += (s, e) =>
            {
                data.database.DeleteAll<User>();
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