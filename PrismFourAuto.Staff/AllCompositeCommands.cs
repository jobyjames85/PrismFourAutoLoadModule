using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.Commands;

namespace PrismFourAuto.Staff
{
    public static class AllCompositeCommands
    {
        public static CompositeCommand FireAllStaffCompositeCommand = new CompositeCommand();
    }

    public class AllCommandProxy
    {
        public virtual CompositeCommand FireCompositeCommand
        {
            get { return AllCompositeCommands.FireAllStaffCompositeCommand; }
        }
    }
}
