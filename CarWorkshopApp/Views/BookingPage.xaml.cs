using Microsoft.Maui.Controls;
using System;

namespace CarWorkshopApp.Views
{
    public partial class BookingPage : ContentPage
    {
        public BookingPage()
        {
            InitializeComponent();
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
            string selectedDate = datePicker.Date.ToShortDateString();
            string selectedTime = timePicker.Time.ToString(@"hh\:mm");

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

            // Show booking confirmation
            string message = $"Booking for {name} at {address}\n" +
                             $"Car: {brand} {model} ({registration})\n" +
                             $"Service: {serviceTask}\n" +
                             $"Date: {selectedDate} at {selectedTime}";

            await DisplayAlert("Booking Confirmed", message, "OK");
        }
    }
}
