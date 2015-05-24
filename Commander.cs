using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commander
{
    public class Commander
    {
        public static List<Command> commands;
        public static void init(List<Command> lc)
        {
            commands = lc;
        }
    }
}
