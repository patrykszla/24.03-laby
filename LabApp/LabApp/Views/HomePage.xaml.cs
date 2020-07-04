using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabApp.ViewModels;
using LabApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LabApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        private HomeViewModel ViewModel => BindingContext as HomeViewModel;

        public HomePage()
        {
            InitializeComponent();

            BindingContext = new HomeViewModel(Navigation);
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {

            ViewModel.GoToDetailsCommand.Execute(e.Item as Measurement);

        }
    }
}