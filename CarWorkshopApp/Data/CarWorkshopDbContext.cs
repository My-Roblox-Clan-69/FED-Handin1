using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace CarWorkshopApp.Data
{
    public class CarWorkshopDbContext
    {
        private readonly SQLiteAsyncConnection _database;

        public CarWorkshopDbContext(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Booking>().Wait();  // ✅ Ensure table is created
        }

        // Get all bookings
        public Task<List<Booking>> GetBookingsAsync()
        {
            return _database.Table<Booking>().ToListAsync();
        }

        // Add a new booking
        public Task<int> AddBookingAsync(Booking booking)
        {
            return _database.InsertAsync(booking);
        }

        // Delete a booking
        public Task<int> DeleteBookingAsync(int id)
        {
            return _database.DeleteAsync<Booking>(id);
        }
    }

    // Booking Model
    public class Booking
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerAddress { get; set; }
        public string? CarBrand { get; set; }
        public string? CarModel { get; set; }
        public string? CarRegistration { get; set; }
        public DateTime SelectedDate { get; set; }
        public string? ServiceDescription { get; set; }
    }
}
