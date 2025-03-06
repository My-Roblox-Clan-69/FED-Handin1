using Microsoft.Maui.Controls;
using System;

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
		await Shell.Current.GoToAsync("BookingPage");
	}

	private async void GoToOverviewPage(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("OverviewPage");
	}

    }
}
