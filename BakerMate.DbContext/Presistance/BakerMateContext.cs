using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
namespace BakerMate.DbContext.Presistance

{
    public class BakerMateContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public BakerMateContext(DbContextOptions Options) : base(Options)
        {

        }
        protected  override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

    }
}