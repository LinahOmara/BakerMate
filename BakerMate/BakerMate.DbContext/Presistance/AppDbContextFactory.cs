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
            optionsBuilder.UseSqlServer("Server=LocalHost;Database=BakerMate;Trusted_Connection=True;");
            return new BakerMateContext(optionsBuilder.Options);
        }
    }
}
