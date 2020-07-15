using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabApp.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace LabApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class MapPage : ContentPage
    {
        private HomeViewModel viewModel => BindingContext as HomeViewModel;
        private bool loadedMapData = false;

        public MapPage()
        {
            InitializeComponent();

            MessagingCenter.Subscribe<Object>(this, "click_map_tab", (obj) =>
            {
                if (loadedMapData == false)
                {
                    BindingContext = new HomeViewModel(Navigation);
                    initPosition();
                    loadedMapData = true;
                }
            });


        }
        public async Task initPosition()
        {
            var locationMap = await viewModel.GetDeviceLocation();
            Position position = new Position(locationMap.Latitude, locationMap.Longitude);
            MapSpan mapSpan = MapSpan.FromCenterAndRadius(position, Distance.FromKilometers(3));
            this.map.MoveToRegion(mapSpan);
        }

        private void Pin_InfoWindowClicked(object sender, PinClickedEventArgs e)
        {
            viewModel.InfoWindowClickedCommand.Execute((sender as Xamarin.Forms.Maps.Pin).Address);

        }
    }
}