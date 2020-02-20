using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Conversor.Context.Context
{
   public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { 
        
        
        }

        protected override void OnModelCreating(ModelBuilder builder) {

            base.OnModelCreating(builder);

        
        }

    }
}
