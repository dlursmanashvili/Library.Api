using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Db;

public class ApplicationDbContext : DbContext
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
    }
}