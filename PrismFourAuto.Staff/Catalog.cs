using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrismFourAuto.Staff
{
    public class Catalog : EntityBase
    {
        public IEnumerable<EntityBase> SubEntity { get; set; }
    }
}
