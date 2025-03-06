using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CarWorkshopApp.Models;

namespace CarWorkshopApp.ViewModels
{
    public partial class ServicesViewModel : ObservableObject
    {
        public ObservableCollection<Service> Services { get; set; }

        public ServicesViewModel()
        {
            Services = new ObservableCollection<Service>
            {
                new Service { Name = "Oil Change", Icon = "oil_icon.png" },
                new Service { Name = "Brake Inspection", Icon = "brake_icon.png" },
                new Service { Name = "Tire Rotation", Icon = "tire_icon.png" },
                new Service { Name = "Battery Check", Icon = "battery_icon.png" }
            };
        }
    }
}
