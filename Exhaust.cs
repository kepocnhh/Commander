using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Commander
{
    public class Exhaust : INewCommandRecognized
    {
        public static List<Command> allcommands;
        private static Command stopcommand;
        public static Command nowcommand;
        private static int? value = null;
        public static INewCommandRecognized newCommandRecognized;
        public static void init(List<Command> lc, INewCommandRecognized ncr)
        {
            newCommandRecognized = ncr;
            allcommands = lc;
            stopcommand = allcommands[0];
            nowcommand = allcommands[0];
        }
        public static int executeCommand(Command com)
        {
            switch (com.id)
            {
                case 11:
                    Shell32.clearBasket();
                    return 0;
                case 12:
                    if(value != null)
                    {
                        VolumeController.setvol( (int) value);
                    }
                    return 0;
                default:
                    return -1;
            }
        }
        public static void findNewCommand(Command com)
        {
            nowcommand = com;
            if (nowcommand.stop)
            {
                stopcommand = nowcommand;
            }
            if(nowcommand.executable &&
                (nowcommand.limits == null ||
                nowcommand.limits != null && value != null))
            {
                executeCommand(nowcommand);
                nowcommand = stopcommand;
            }
            newCommandRecognized.commandRecognized(nowcommand);
        }
        public static bool findCommand(string textCommand)
        {
            if (nowcommand.limits != null)
            {
                if(findNumber(nowcommand.limits, textCommand))
                {
                    executeCommand(nowcommand);
                    return true;
                }
            }
            for(int i=0; i<nowcommand.commands.Count; i++)
            {
                for(int j=0; j<nowcommand.commands[i].names.Count; j++)
                {
                    if (textCommand.Contains(nowcommand.commands[i].names[j]))
                    {
                        findNewCommand(nowcommand.commands[i]);
                        return true;
                    }
                }
            }
            return false;
        }
        private static bool findNumber(Limits limits, string textCommand)
        {
            Match m = Helper.findNumber(textCommand);
            while (m.Success)
            {
                int findValue =Int32.Parse(m.Value);
                if (findValue >= limits.minValue && findValue <= limits.maxValue)
                {
                    value = findValue;
                    return true;
                }
                m = m.NextMatch();
            }
            value = null;
            return false;
        }

#region NewCommandRecognizedListener------------------------\\

        public void commandRecognized(Command com)
        {

        }

#endregion _____________________________________//

    }
}