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
            optionsBuilder.UseSqlite("data source= C:\\Users\\Administrator\\Desktop\\Work");
            return new BakerMateContext(optionsBuilder.Options);
        }
    }
}
