using HalloweenController_v0._0._1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace HalloweenController_v0._0._1.DAL
{

        public class PanelContext : DbContext
        {
            public PanelContext()
                : base("PanelContext")
            {
            }

            public DbSet<Button> Buttons { get; set; }
           

            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            }
        }

}