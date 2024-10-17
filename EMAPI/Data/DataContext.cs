using EMAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EMAPI.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {






        }



        public DbSet<ProductModels>Products { get; set; }





    }
}
