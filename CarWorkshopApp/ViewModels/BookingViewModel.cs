using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CarWorkshopApp.Data;
using CarWorkshopApp.Services;
using System;
using System.Threading.Tasks;

namespace CarWorkshopApp.ViewModels
{
    public partial class BookingViewModel : ObservableObject
    {
        private readonly BookingService _bookingService;

        [ObservableProperty]
        private string? customerName;

        [ObservableProperty]
        private string? customerAddress;

        [ObservableProperty]
        private string? carBrand;

        [ObservableProperty]
        private string? carModel;

        [ObservableProperty]
        private string? carRegistration;

        [ObservableProperty]
        private DateTime selectedDate = DateTime.Today;

        [ObservableProperty]
        private string? serviceDescription;

        public IRelayCommand ConfirmBookingCommand { get; }

        public BookingViewModel(BookingService bookingService)
        {
            _bookingService = bookingService;
            ConfirmBookingCommand = new RelayCommand(async () => await ConfirmBooking());
        }

        private async Task ConfirmBooking()
        {
            if (string.IsNullOrWhiteSpace(CustomerName) ||
                string.IsNullOrWhiteSpace(CustomerAddress) ||
                string.IsNullOrWhiteSpace(CarBrand) ||
                string.IsNullOrWhiteSpace(CarModel) ||
                string.IsNullOrWhiteSpace(CarRegistration) ||
                string.IsNullOrWhiteSpace(ServiceDescription))
            {
                await Shell.Current.DisplayAlert("Missing Information", "Please fill in all fields before booking.", "OK");
                return;
            }

            var newBooking = new Booking
            {
                CustomerName = CustomerName,
                CustomerAddress = CustomerAddress,
                CarBrand = CarBrand,
                CarModel = CarModel,
                CarRegistration = CarRegistration,
                SelectedDate = SelectedDate,
                ServiceDescription = ServiceDescription
            };

            await _bookingService.AddBookingAsync(newBooking);

            await Shell.Current.DisplayAlert("Success", "Booking saved to database!", "OK");
        }
    }
}
