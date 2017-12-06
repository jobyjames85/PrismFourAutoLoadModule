using System;
using System.Collections.Generic;

namespace PrismFourAuto.Model.Models
{
    public partial class StudentFee
    {
        public long ID { get; set; }
        public double Amount { get; set; }
        public double Discount { get; set; }
        public double DiscountReason { get; set; }
        public long MasterFeeID { get; set; }
        public long StudentID { get; set; }
        public string IP { get; set; }
        public virtual MasterFee MasterFee { get; set; }
        public virtual Student Student { get; set; }
    }
}
