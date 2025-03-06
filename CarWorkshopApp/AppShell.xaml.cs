using CarWorkshopApp.Views;

namespace CarWorkshopApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute("BookingPage", typeof(BookingPage));
		Routing.RegisterRoute("OverviewPage", typeof(OverviewPage));
	}
}
