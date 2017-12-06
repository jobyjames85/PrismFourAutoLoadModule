using System;
using System.Collections.Generic;

namespace PrismFourAuto.Model.Models
{
    public partial class Attendance
    {
        public long ID { get; set; }
        public System.DateTime LeaveDate { get; set; }
        public string LeaveReason { get; set; }
        public int LeaveType { get; set; }
        public long StaffID { get; set; }
        public long StudentID { get; set; }
        public string IP { get; set; }
        public virtual Staff Staff { get; set; }
        public virtual Student Student { get; set; }
    }
}
