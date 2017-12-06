using System;
using System.Collections.Generic;

namespace PrismFourAuto.Model.Models
{
    public partial class MasterFee
    {
        public MasterFee()
        {
            this.StudentFees = new List<StudentFee>();
        }

        public long ID { get; set; }
        public string Description { get; set; }
        public string FeeName { get; set; }
        public string IP { get; set; }
        public virtual ICollection<StudentFee> StudentFees { get; set; }
    }
}
