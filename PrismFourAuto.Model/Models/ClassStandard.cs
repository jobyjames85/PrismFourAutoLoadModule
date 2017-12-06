using System;
using System.Collections.Generic;

namespace PrismFourAuto.Model.Models
{
    public partial class ClassStandard
    {
        public ClassStandard()
        {
            this.ClassStudents = new List<ClassStudent>();
            this.ClassSubjects = new List<ClassSubject>();
            this.ScoreCards = new List<ScoreCard>();
            this.Students = new List<Student>();
        }

        public long ID { get; set; }
        public string Description { get; set; }
        public string StandardDivision { get; set; }
        public int StandardName { get; set; }
        public string IP { get; set; }
        public virtual ICollection<ClassStudent> ClassStudents { get; set; }
        public virtual ICollection<ClassSubject> ClassSubjects { get; set; }
        public virtual ICollection<ScoreCard> ScoreCards { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
