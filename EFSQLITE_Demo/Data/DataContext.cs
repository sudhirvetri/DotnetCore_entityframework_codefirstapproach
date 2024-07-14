using Microsoft.EntityFrameworkCore;

namespace EFSQLITE_Demo.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<RpgCharacter> rpgcharacter => Set<RpgCharacter>();
    }
}