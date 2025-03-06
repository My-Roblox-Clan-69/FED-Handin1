using CarWorkshopApp.ViewModels;
using Microsoft.Maui.Controls;

namespace CarWorkshopApp.Views
{
    public partial class OverviewPage : ContentPage
    {
        private readonly OverviewViewModel _viewModel;

        public OverviewPage(OverviewViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = _viewModel = viewModel; // ✅ Set the ViewModel as BindingContext
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (_viewModel == null)
            {
                await DisplayAlert("Error", "ViewModel is not initialized!", "OK");
                return;
            }

            try
            {
                await _viewModel.LoadBookingsAsync();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Something went wrong: {ex.Message}", "OK");
            }
        }

    }
}
