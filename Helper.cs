using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Commander
{

#region Interface----------------------------------------------------\\
    public interface INewCommandRecognized
    {
        void commandRecognized(Command com);
    }
#endregion _____________________________________//

    public class Helper
    {
        public static Match findNumber(string text)
        {
            string pattern = @"[0-9]+";
            Regex r = new Regex(pattern);
            return r.Match(text);
        }
    }
}
