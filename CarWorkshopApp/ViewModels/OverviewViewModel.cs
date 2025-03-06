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
            LoadBookingsAsync();
        }


        partial void OnSelectedDateChanged(DateTime value)
        {
            LoadBookingsAsync(); // ✅ Reload bookings when date changes
            OnPropertyChanged(nameof(BookingsForSelectedDate)); // ✅ Ensure UI updates
        }

        public async Task LoadBookingsAsync()  // ✅ Change from private to public
        {
            if (_bookingService == null) return; // 🚨 Ensure service is not null

            var allBookings = await _bookingService.GetBookingsAsync();

            var filteredBookings = allBookings
                .Where(b => b.SelectedDate.HasValue && b.SelectedDate.Value.Date == SelectedDate.Date)
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
    }
}
