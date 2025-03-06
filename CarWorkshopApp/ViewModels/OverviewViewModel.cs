using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using CarWorkshopApp.Data;
using CarWorkshopApp.Services;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CarWorkshopApp.ViewModels
{
    public partial class OverviewViewModel : ObservableObject
    {
        private readonly BookingService _bookingService;

        [ObservableProperty]
        private DateTime selectedDate = DateTime.Today;

        public ObservableCollection<Booking> BookingsForSelectedDate { get; } = new();

        public DateTime MinDate { get; } = DateTime.Today.AddMonths(-6);
        public DateTime MaxDate { get; } = DateTime.Today.AddMonths(6);

        public OverviewViewModel(BookingService bookingService)
        {
            _bookingService = bookingService ?? throw new ArgumentNullException(nameof(bookingService));
            Task.Run(async () => await LoadBookingsAsync()); // ✅ Ensure async execution
        }

        partial void OnSelectedDateChanged(DateTime value)
        {
            Task.Run(async () => await LoadBookingsAsync()); // ✅ Ensure UI updates when date changes
        }

        public async Task LoadBookingsAsync()
        {
            if (_bookingService == null) return;

            try
            {
                var allBookings = await _bookingService.GetBookingsAsync();

                var filteredBookings = allBookings
                    .Where(b => b.SelectedDate.Date == SelectedDate.Date)
                    .ToList();

                // ✅ Update ObservableCollection on the main thread
                App.Current.Dispatcher.Dispatch(() =>
                {
                    BookingsForSelectedDate.Clear();
                    foreach (var booking in filteredBookings)
                    {
                        BookingsForSelectedDate.Add(booking);
                    }
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading bookings: {ex.Message}");
            }
        }
    }
}
