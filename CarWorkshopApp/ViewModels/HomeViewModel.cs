using CommunityToolkit.Mvvm.ComponentModel;

namespace CarWorkshopApp.ViewModels
{
    public partial class HomeViewModel : ObservableObject
    {
        public string WelcomeMessage { get; set; } = "Welcome to Car Workshop!";
    }
}
