using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
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

        public App()
        {
            InitializeComponent();

            InitializeVariables();

        }
        private async Task InitializeVariables()
        {
            await LoadConfiguration();

            MainPage = new MainTabbedPage();
            /*  MainPage = new NavigationPage(new MainTabbedPage());*/

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
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}