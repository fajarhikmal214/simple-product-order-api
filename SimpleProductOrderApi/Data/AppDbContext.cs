using Microsoft.EntityFrameworkCore;

namespace SimpleProductOrderApi.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
 
    }
}