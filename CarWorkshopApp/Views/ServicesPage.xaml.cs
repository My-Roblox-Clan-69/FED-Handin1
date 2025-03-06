using Microsoft.Maui.Controls;
using CarWorkshopApp.ViewModels;

namespace CarWorkshopApp.Views
{
    public partial class ServicesPage : ContentPage
    {
        public ServicesPage()
        {
            InitializeComponent();
            BindingContext = new ServicesViewModel(); // Attach ViewModel
        }
    }
}
