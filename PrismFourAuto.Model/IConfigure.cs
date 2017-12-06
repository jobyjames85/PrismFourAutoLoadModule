using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrismFourAuto.Model
{
    public interface IConfigure
    {
        /// <summary>
        /// Initialize the database
        /// </summary>
        void InitializeDatabase();
    }
}
