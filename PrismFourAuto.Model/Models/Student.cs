using System;
using System.Collections.Generic;

namespace PrismFourAuto.Model.Models
{
    public partial class Student
    {
        public Student()
        {
            this.Attendances = new List<Attendance>();
            this.ClassStudents = new List<ClassStudent>();
            this.ScoreCards = new List<ScoreCard>();
            this.StudentFees = new List<StudentFee>();
        }

        public long PropleID { get; set; }
        public Nullable<System.DateTime> AppoimentDate { get; set; }
        public bool CertificateAttached { get; set; }
        public Nullable<double> Donation { get; set; }
        public string FatherName { get; set; }
        public string FormNumber { get; set; }
        public Nullable<int> LastMark { get; set; }
        public Nullable<bool> LastResult { get; set; }
        public string lastSchool { get; set; }
        public string MotherName { get; set; }
        public string Recommendation { get; set; }
        public string RecommendationDetails { get; set; }
        public bool Sports { get; set; }
        public bool Status { get; set; }
        public string TransferReason { get; set; }
        public long ClassStandardID { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }
        public virtual ClassStandard ClassStandard { get; set; }
        public virtual ICollection<ClassStudent> ClassStudents { get; set; }
        public virtual People People { get; set; }
        public virtual ICollection<ScoreCard> ScoreCards { get; set; }
        public virtual ICollection<StudentFee> StudentFees { get; set; }
    }
}
