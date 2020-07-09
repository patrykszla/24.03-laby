using Newtonsoft.Json.Linq;
using SQLite;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using LabApp.Models;
using LabApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace LabApp
{
    public partial class App : Application
    {

        public static string ApiKey { get; private set; }
        public static string ApiUrl { get; private set; }
        public static string ApiMeasurementUrl { get; private set; }
        public static string ApiInstallationUrl { get; private set; }
        public static SQLiteConnection db { get; private set; }
        public static DatabaseHelper dbHelper { get; private set; }

        public App()
        {
            InitializeComponent();

            initializeVariables();

        }

        private async Task initializeVariables()
        {
            await LoadConfiguration();

            dbHelper = new DatabaseHelper();

            db = dbHelper.initDb();

            MainPage = new MainTabbedPage();

        }

        private static async Task LoadConfiguration()
        {
            var assembly = Assembly.GetAssembly(typeof(App));
            var resourceNames = assembly.GetManifestResourceNames();
            var configName = resourceNames.FirstOrDefault(s => s.Contains("config.json"));

            using (var stream = assembly.GetManifestResourceStream(configName))
            {
                using (var reader = new StreamReader(stream))
                {
                    var json = await reader.ReadToEndAsync();
                    var dynamicJson = JObject.Parse(json);

                    ApiKey = dynamicJson["ApiKey"].Value<string>();
                    ApiUrl = dynamicJson["ApiUrl"].Value<string>();
                    ApiMeasurementUrl = dynamicJson["ApiMeasurementUrl"].Value<string>();
                    ApiInstallationUrl = dynamicJson["ApiInstallationUrl"].Value<string>();
                }
            }
        }

        protected override void OnStart()
        {
            if (db == null)
            {
                dbHelper = new DatabaseHelper();

            }
            if (dbHelper == null)
            {
                db = dbHelper.initDb();
            }
        }

        protected override void OnSleep()
        {
            dbHelper.Dispose();
            db = null;
            dbHelper = null;
        }

        protected override void OnResume()
        {
            if (db == null)
            {
                dbHelper = new DatabaseHelper();

            }
            if (dbHelper == null)
            {
                db = dbHelper.initDb();
            }
        }
    }
}
