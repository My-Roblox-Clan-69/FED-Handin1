using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CarWorkshopApp.Data;

namespace CarWorkshopApp.Services
{
    public class BookingService
    {
        private readonly CarWorkshopDbContext _context;

        public BookingService(CarWorkshopDbContext context)
        {
            _context = context;
        }

        // Get all bookings
        public async Task<List<Booking>> GetBookingsAsync()
        {
            return await _context.Bookings.ToListAsync();
        }

        // Add a new booking
        public async Task AddBookingAsync(Booking booking)
        {
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
        }

        // Delete a booking
        public async Task DeleteBookingAsync(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking != null)
            {
                _context.Bookings.Remove(booking);
                await _context.SaveChangesAsync();
            }
        }
        public async Task SeedTestData()
        {
            if (!_context.Bookings.Any())
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

                _context.Bookings.Add(testBooking);
                await _context.SaveChangesAsync();
            }
        }
    }
}
