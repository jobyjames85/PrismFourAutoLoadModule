using System;
using System.Collections.Generic;

namespace PrismFourAuto.Model.Models
{
    public partial class ClassSubject
    {
        public ClassSubject()
        {
            this.ScoreCards = new List<ScoreCard>();
        }

        public long ID { get; set; }
        public long ClassStandardID { get; set; }
        public long StaffID { get; set; }
        public long SubjectID { get; set; }
        public string IP { get; set; }
        public virtual ClassStandard ClassStandard { get; set; }
        public virtual Staff Staff { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual ICollection<ScoreCard> ScoreCards { get; set; }
    }
}
