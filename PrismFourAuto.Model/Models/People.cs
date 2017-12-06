using System;
using System.Collections.Generic;

namespace PrismFourAuto.Model.Models
{
    public partial class People
    {
        public long PropleID { get; set; }
        public System.DateTime AddedDate { get; set; }
        public string Address { get; set; }
        public string Cast { get; set; }
        public System.DateTime DOB { get; set; }
        public string EmailID { get; set; }
        public string FirstName { get; set; }
        public string IPAddress { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public long MobileNumber { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public int PhoneNumber { get; set; }
        public string Photo { get; set; }
        public string Religion { get; set; }
        public bool Sex { get; set; }
        public virtual Staff Staff { get; set; }
        public virtual Student Student { get; set; }
    }
}
