using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrismFourAuto.Account
{
    public class EntityBase
    {
        public int IDEntity { get; set; }
        public string Title { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }
        public EntityBase Parent { get; set; }
        public override string ToString()
        {
            if (string.IsNullOrEmpty(Description))
            {
                return Title;
            }
            else
            {
                return Description;
            }
        }
    }
}
