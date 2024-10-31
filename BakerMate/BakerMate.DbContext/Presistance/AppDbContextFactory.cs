using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakerMate.DbContext.Presistance
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<BakerMateContext>
    {
        public BakerMateContext CreateDbContext(string[] args = null)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BakerMateContext>();
            optionsBuilder.UseSqlServer("Server=tcp:baker-mate-dev-db-derver.database.windows.net,1433;Initial Catalog=bakerMate;Persist Security Info=False;User ID=bakerMateDBAdmin;Password=VPZy8M8j8US$bA6;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;");
            return new BakerMateContext(optionsBuilder.Options);
        }
    }
}
