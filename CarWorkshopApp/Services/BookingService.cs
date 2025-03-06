using System.Collections.Generic;
using System.Threading.Tasks;
using CarWorkshopApp.Data;

namespace CarWorkshopApp.Services
{
    public class BookingService
    {
        private readonly CarWorkshopDbContext _dbContext;

        public BookingService(CarWorkshopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Get all bookings
        public async Task<List<Booking>> GetBookingsAsync()
        {
            return await _dbContext.GetBookingsAsync();
        }

        // Add a new booking
        public async Task AddBookingAsync(Booking booking)
        {
            await _dbContext.AddBookingAsync(booking);
        }

        // Delete a booking
        public async Task DeleteBookingAsync(int id)
        {
            await _dbContext.DeleteBookingAsync(id);
        }

        // Seed Test Data (Optional)
        public async Task SeedTestData()
        {
            var existingBookings = await _dbContext.GetBookingsAsync();
            if (existingBookings.Count == 0)
            {
                var testBooking = new Booking
                {
                    CustomerName = "John Doe",
                    CustomerAddress = "123 Main St",
                    CarBrand = "Toyota",
                    CarModel = "Camry",
                    CarRegistration = "AB123CD",
                    SelectedDate = DateTime.Today.AddHours(14),
                    ServiceDescription = "Oil Change"
                };

                await _dbContext.AddBookingAsync(testBooking);
            }
        }
        public async Task DebugPrintAllBookings()
        {
            var allBookings = await _dbContext.GetBookingsAsync();
            Console.WriteLine("📌 All Bookings in Database:");
            foreach (var booking in allBookings)
            {
                Console.WriteLine($"- {booking.Id}: {booking.CustomerName}, {booking.SelectedDate}");
            }
        }

    }
}
