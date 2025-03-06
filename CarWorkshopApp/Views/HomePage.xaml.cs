using Microsoft.Maui.Controls;

namespace CarWorkshopApp.Views
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private async void GoToBookingPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BookingPage());
        }

        private async void GoToServicesPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ServicesPage());
        }

        private async void GoToAboutPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AboutPage());
        }
    }
}
