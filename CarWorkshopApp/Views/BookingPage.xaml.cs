using CarWorkshopApp.Data;
using CarWorkshopApp.Services;
using Microsoft.Maui.Controls;
using System;

namespace CarWorkshopApp.Views
{
    public partial class BookingPage : ContentPage
    {
        private readonly BookingService _bookingService;

        public BookingPage(BookingService bookingService)
        {
            InitializeComponent();
            _bookingService = bookingService; // ✅ Inject BookingService
        }

        private async void ConfirmBooking(object sender, EventArgs e)
        {
            // Get user inputs
            string name = customerName.Text;
            string address = customerAddress.Text;
            string brand = carBrand.Text;
            string model = carModel.Text;
            string registration = carRegistration.Text;
            string serviceTask = serviceDescription.Text;
            DateTime selectedDateTime = datePicker.Date.Add(timePicker.Time); // ✅ Combine Date & Time

            // Validate inputs
            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(address) ||
                string.IsNullOrWhiteSpace(brand) ||
                string.IsNullOrWhiteSpace(model) ||
                string.IsNullOrWhiteSpace(registration) ||
                string.IsNullOrWhiteSpace(serviceTask))
            {
                await DisplayAlert("Missing Information", "Please fill in all fields before booking.", "OK");
                return;
            }

            // Create new booking
            var newBooking = new Booking
            {
                CustomerName = name,
                CustomerAddress = address,
                CarBrand = brand,
                CarModel = model,
                CarRegistration = registration,
                SelectedDate = selectedDateTime,
                ServiceDescription = serviceTask
            };

            // ✅ Save to database
            await _bookingService.AddBookingAsync(newBooking);
            await DisplayAlert("Booking Confirmed", "Your service has been booked successfully!", "OK");

            // ✅ Print all saved bookings for debugging
            await _bookingService.DebugPrintAllBookings();
        }
    }
}
