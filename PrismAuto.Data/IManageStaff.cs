using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrismAuto.Model.Models;

namespace PrismAuto.Data
{ 
    public interface IManageStaff
    {
        /// <summary>
        /// Gets designation collection
        /// </summary>
        /// <returns>returns list of designations</returns>
        IQueryable<Staff> GetStaffs();

        /// <summary>
        /// Gets designation collection
        /// </summary>
        /// <returns>returns list of designations</returns>
        IEnumerable<Staff> GetStaffsTest();

        /// <summary>
        /// Get one staff
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Staff GetStaff(int id);

        /// <summary>
        /// Remove Staff
        /// </summary>
        /// <param name="id"></param>
        void DeleteStaff(int id);

        /// <summary>
        /// Add Staff
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Staff AddStaff(Staff item);

        /// <summary>
        /// Update Staff
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        bool UpdateStaff(Staff item);

        /// <summary>
        /// IsValidate
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        bool IsValidate(string UserName, string Password);

    }
}
