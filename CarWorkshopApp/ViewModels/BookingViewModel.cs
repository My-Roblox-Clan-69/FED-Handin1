using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace CarWorkshopApp.ViewModels
{
    public partial class BookingViewModel : ObservableObject
    {
        [ObservableProperty]
        private string customerName;

        [ObservableProperty]
        private string customerAddress;

        [ObservableProperty]
        private string carBrand;

        [ObservableProperty]
        private string carModel;

        [ObservableProperty]
        private string carRegistration;

        [ObservableProperty]
        private string serviceDescription;

        [ObservableProperty]
        private DateTime selectedDate = DateTime.Today;

        [ObservableProperty]
        private TimeSpan selectedTime = new TimeSpan(10, 0, 0);

        public ICommand ConfirmBookingCommand { get; }

        public BookingViewModel()
        {
            ConfirmBookingCommand = new RelayCommand(ConfirmBooking);
        }

        private async void ConfirmBooking()
        {
            if (string.IsNullOrWhiteSpace(CustomerName) ||
                string.IsNullOrWhiteSpace(CustomerAddress) ||
                string.IsNullOrWhiteSpace(CarBrand) ||
                string.IsNullOrWhiteSpace(CarModel) ||
                string.IsNullOrWhiteSpace(CarRegistration) ||
                string.IsNullOrWhiteSpace(ServiceDescription))
            {
                await Application.Current.MainPage.DisplayAlert("Missing Information", "Please fill in all fields before booking.", "OK");
                return;
            }

            string message = $"Booking for {CustomerName} at {CustomerAddress}\n" +
                             $"Car: {CarBrand} {CarModel} ({CarRegistration})\n" +
                             $"Service: {ServiceDescription}\n" +
                             $"Date: {SelectedDate:MMMM dd, yyyy} at {SelectedTime:hh\\:mm tt}";

            await Application.Current.MainPage.DisplayAlert("Booking Confirmed", message, "OK");
        }
    }
}
