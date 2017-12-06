using System;
using System.Collections.Generic;

namespace PrismFourAuto.Model.Models
{
    public partial class Exam
    {
        public Exam()
        {
            this.ScoreCards = new List<ScoreCard>();
        }

        public long ID { get; set; }
        public string ExamDescription { get; set; }
        public string ExamName { get; set; }
        public string IP { get; set; }
        public virtual ICollection<ScoreCard> ScoreCards { get; set; }
    }
}
