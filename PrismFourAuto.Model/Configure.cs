using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using PrismFourAuto.Model.Migrations;
using PrismFourAuto.Model.Models;

namespace PrismFourAuto.Model
{
    public class Configure : IConfigure
    {
        /// <summary>
        /// Initialize the Database
        /// </summary>
        public void InitializeDatabase()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SchoolTestContext, Configuration>());
        }
    }
}
