using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commander
{
    public class Command
    {
        public int id;
        public bool stop;
        public bool executable;
        public Limits limits;
        public string name;
        public List<string> names;
        public List<Command> commands;
    }
    public class Limits
    {
        public int minValue;
        public int maxValue;
    }
}
