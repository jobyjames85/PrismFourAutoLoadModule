using System;
using System.Collections.Generic;

namespace PrismFourAuto.Model.Models
{
    public partial class Staff
    {
        public Staff()
        {
            this.Attendances = new List<Attendance>();
            this.ClassStudents = new List<ClassStudent>();
            this.ClassSubjects = new List<ClassSubject>();
            this.ScoreCards = new List<ScoreCard>();
        }

        public long PropleID { get; set; }
        public string HighestQualification { get; set; }
        public System.DateTime HireDate { get; set; }
        public string LastUpdated { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }
        public virtual ICollection<ClassStudent> ClassStudents { get; set; }
        public virtual ICollection<ClassSubject> ClassSubjects { get; set; }
        public virtual People People { get; set; }
        public virtual ICollection<ScoreCard> ScoreCards { get; set; }
    }
}
