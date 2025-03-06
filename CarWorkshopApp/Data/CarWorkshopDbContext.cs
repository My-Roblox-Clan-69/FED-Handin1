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
    public string? CustomerName { get; set; }
    public string? CustomerAddress { get; set; }
    public string? CarBrand { get; set; }
    public string? CarModel { get; set; }
    public string? CarRegistration { get; set; }
    public DateTime? SelectedDate { get; set; }
    public string? ServiceDescription { get; set; }
}
}
