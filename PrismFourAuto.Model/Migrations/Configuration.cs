using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using PrismFourAuto.Model.Models;

namespace PrismFourAuto.Model.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<SchoolTestContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        public void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SchoolTestContext, Configuration>());
        }

        protected override void Seed(SchoolTestContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
