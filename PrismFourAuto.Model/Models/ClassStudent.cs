using System;
using System.Collections.Generic;

namespace PrismFourAuto.Model.Models
{
    public partial class ClassStudent
    {
        public long ID { get; set; }
        public int ClassRollNo { get; set; }
        public int ClassStandardID { get; set; }
        public System.DateTime FromYear { get; set; }
        public string PreiousYear { get; set; }
        public int StaffID { get; set; }
        public int StudentID { get; set; }
        public System.DateTime ToDate { get; set; }
        public string IP { get; set; }
        public Nullable<long> ClassStandard_ID { get; set; }
        public Nullable<long> Student_ID { get; set; }
        public Nullable<long> Staff_ID { get; set; }
        public virtual ClassStandard ClassStandard { get; set; }
        public virtual Staff Staff { get; set; }
        public virtual Student Student { get; set; }
    }
}
