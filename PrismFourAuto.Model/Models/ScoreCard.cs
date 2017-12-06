using System;
using System.Collections.Generic;

namespace PrismFourAuto.Model.Models
{
    public partial class ScoreCard
    {
        public long ID { get; set; }
        public long ClassStandardID { get; set; }
        public System.DateTime ExamDate { get; set; }
        public long ExamID { get; set; }
        public System.DateTime LastUpdated { get; set; }
        public long ReportedStaffID { get; set; }
        public long StudentID { get; set; }
        public long SubjectID { get; set; }
        public string IP { get; set; }
        public Nullable<long> ClassSubject_ID { get; set; }
        public virtual ClassStandard ClassStandard { get; set; }
        public virtual ClassSubject ClassSubject { get; set; }
        public virtual Exam Exam { get; set; }
        public virtual Staff Staff { get; set; }
        public virtual Student Student { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
