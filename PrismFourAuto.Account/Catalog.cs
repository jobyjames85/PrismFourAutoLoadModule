using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrismFourAuto.Account
{
    public class Catalog : EntityBase
    {
        public IEnumerable<EntityBase> SubEntity { get; set; }
    }
}
