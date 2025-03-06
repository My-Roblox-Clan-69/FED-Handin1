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
        private TimeSpan selectedTime = TimeSpan.FromHours(12); // ✅ Default time: 12:00 PM

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

            // ✅ Combine date and time before saving
            DateTime bookingDateTime = SelectedDate.Add(SelectedTime);

            var newBooking = new Booking
            {
                CustomerName = CustomerName,
                CustomerAddress = CustomerAddress,
                CarBrand = CarBrand,
                CarModel = CarModel,
                CarRegistration = CarRegistration,
                SelectedDate = bookingDateTime,  // ✅ Stores date & time
                ServiceDescription = ServiceDescription
            };

            // ✅ Save to database
            await _bookingService.AddBookingAsync(newBooking);

            // ✅ Print all bookings for debugging
            await _bookingService.DebugPrintAllBookings();

            // ✅ Show success message
            await Shell.Current.DisplayAlert("Success", "Booking saved to database!", "OK");

            // ✅ Reset form fields after saving
            ClearForm();
        }

        private void ClearForm()
        {
            CustomerName = string.Empty;
            CustomerAddress = string.Empty;
            CarBrand = string.Empty;
            CarModel = string.Empty;
            CarRegistration = string.Empty;
            ServiceDescription = string.Empty;
            SelectedDate = DateTime.Today;
            SelectedTime = TimeSpan.FromHours(12); // Reset to default time
        }
    }
}
