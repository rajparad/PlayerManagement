using Microsoft.EntityFrameworkCore;
using DKR_Final.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DKR_Final.DataAccess
{
   public class DKR_Final_DB : DbContext
    {
        public DbSet<Player> Players { get; set; }

        public DbSet<Team> Teams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(

                "Data Source = (LocalDB)\\MSSQLLocalDB; Initial Catalog = DKR_Final_TestDbase4"

                );
        }
    }


}
