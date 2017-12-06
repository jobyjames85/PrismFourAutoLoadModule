using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PrismFourAuto.Model;
using PrismFourAuto.Model.Models;

namespace PrismFourAuto.Data
{
    public class ManageStaff : IManageStaff, IDisposable
    {
        #region Private Fields

        /// <summary> 
        /// Unit of work
        /// </summary>
        private readonly IUnitOfWork unitOfWork;

        /// <summary>
        /// Specifies whether the object is disposed 
        /// </summary>
        private bool isDisposed = false;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ManageDesignation"/> class.
        /// </summary>       
        public ManageStaff()
        {
            this.unitOfWork = new UnitOfWork();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ManageDesignation"/> class.
        /// </summary>
        /// <param name="uWork">the unit of work</param>
        public ManageStaff(IUnitOfWork uWork)
        {
            this.unitOfWork = uWork;
        }

        #endregion

        #region Destructor

        /// <summary>
        /// Finalizes an instance of the <see cref="ManageDesignation"/> class for disposing of object in destructor
        /// </summary>
        ~ManageStaff()
        {
            this.Dispose(false);
        }

        #endregion

        #region Method

        /// <summary>
        /// Gets designation collection
        /// </summary>
        /// <returns>returns list of designations</returns>
        public IQueryable<Staff> GetStaffs()
        {
            return this.unitOfWork.StaffRepository.GetQuery(null);
            ////.Select(x =>
            ////new StaffEntity()
            ////{
            ////    StaffId = x.StaffId,
            ////    StaffName = x.Name,
            ////    Description = x.Description
            ////});
        }

        public Staff GetStaff(int id)
        {
            return this.unitOfWork.StaffRepository.GetQuery(x => x.PropleID == id).FirstOrDefault();
        }


        /// <summary>
        /// Gets designation collection
        /// </summary>
        /// <returns>returns list of designations</returns>
        public IEnumerable<Staff> GetStaffsTest()
        {
            var items = this.unitOfWork.StaffRepository.GetQuery(null).Select(x => x).ToList();
            return items;
            //.Select(x =>
            //new StaffEntity()
            //{
            //    StaffId = x.DescriptionId,
            //    StaffName = x.Name,
            //    Description = x.Description
            //}).ToList();
        }

        #endregion

        #region IDisposible pattern implementation

        /// <summary>
        /// Implement disposable pattern to dispose manage designation
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
        }

        /// <summary>
        /// Implement disposable pattern to dispose the manage designation
        /// </summary>
        /// <param name="isDisposing">parameter specifies whether we want to dispose the resources</param>
        protected virtual void Dispose(bool isDisposing)
        {
            if (!this.isDisposed)
            {
                if (isDisposing)
                {
                    GC.WaitForFullGCComplete();
                    GC.SuppressFinalize(this);
                }

                // Sets to true to specify that the resource is disposed after disposing the resource
                this.isDisposed = true;
            }
        }
        #endregion

        public void DeleteStaff(int id)
        {
            this.unitOfWork.StaffRepository.Delete(id);
            this.unitOfWork.Save();
        }

        public Staff AddStaff(Staff item)
        {
            Staff staff = item;
            this.unitOfWork.StaffRepository.Insert(staff);
            this.unitOfWork.Save();
            var id = staff.PropleID;
            return this.unitOfWork.StaffRepository.GetQuery(x => x.PropleID == id).FirstOrDefault();
        }

        public bool UpdateStaff(Staff item)
        {
            if (item == null)
            {
                return false;
            }

            Staff index = this.unitOfWork.StaffRepository.GetByID(item.PropleID);
            if (index == null)
            {
                return false;
            }

            this.unitOfWork.StaffRepository.Update(item);
            return true;
        }

        public bool IsValidate(string UserName, string Password)
        {
            return this.unitOfWork.StaffRepository.GetQuery(x => x.Username == UserName).Any();
        }
    }
}
