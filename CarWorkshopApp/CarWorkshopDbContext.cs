using Microsoft.EntityFrameworkCore;

namespace CarWorkshopApp.Data
{
    public class CarWorkshopDbContext : DbContext
    {
        public DbSet<Booking> Bookings { get; set; }

        public CarWorkshopDbContext(DbContextOptions<CarWorkshopDbContext> options) : base(options) { }
    }

    public class Booking
    {
        public int Id { get; set; }
        public string customerName { get; set; }
        public string customerAddress { get; set; }
        public string carBrand { get; set; }
        public string carModel { get; set; }
        public string carRegistration { get; set; }
        public DateTime selectedDate { get; set; }
        public string serviceDescription { get; set; }
    }
}
