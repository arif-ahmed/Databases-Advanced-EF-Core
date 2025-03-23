using Newtonsoft.Json;
using TravelAgency.Data;
using TravelAgency.Models;

namespace TravelAgency.DataProcessor;
public class Deserializer
{
    private readonly TravelAgencyDbContext _context;
    public Deserializer(TravelAgencyDbContext context)
    {
        _context = context;
    }

    public void ImportCustomers(string path)
    {
        string jsonString = File.ReadAllText(path);
        List<Booking> customers = JsonConvert.DeserializeObject<List<Booking>>(jsonString) ?? new();

        foreach (Booking customer in customers) 
        {
            // validate the customer
            _context.AddAsync(customer);
        }

        // _context.SaveChangesAsync();
    }
}
