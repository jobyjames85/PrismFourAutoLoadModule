using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PrismFourAuto.Model.Models;

namespace PrismFourAuto.Model
{
    public interface IUnitOfWork
    {

        /// <summary>
        /// Gets the designation repository
        /// </summary>
        IRepository<Staff> StaffRepository { get; }

        /// <summary>
        /// Saves changes in the unit of work
        /// </summary>
        void Save();
    }
}
