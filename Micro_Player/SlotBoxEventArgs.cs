using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Micro_Player
{
    public class SlotBoxEventArgs
    {
        public Slot? slot { get; private set; }
        public SlotBoxEventArgs(Slot slot)
        {
            this.slot = slot;
        }
    }
}
