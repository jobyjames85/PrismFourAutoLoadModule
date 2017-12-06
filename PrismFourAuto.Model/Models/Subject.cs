using System;
using System.Collections.Generic;

namespace PrismFourAuto.Model.Models
{
    public partial class Subject
    {
        public Subject()
        {
            this.ClassSubjects = new List<ClassSubject>();
            this.ScoreCards = new List<ScoreCard>();
            this.Subjects1 = new List<Subject>();
        }

        public long ID { get; set; }
        public string SubjectDescription { get; set; }
        public string SubjectName { get; set; }
        public string IP { get; set; }
        public Nullable<long> Subject_ID { get; set; }
        public virtual ICollection<ClassSubject> ClassSubjects { get; set; }
        public virtual ICollection<ScoreCard> ScoreCards { get; set; }
        public virtual ICollection<Subject> Subjects1 { get; set; }
        public virtual Subject Subject1 { get; set; }
    }
}
