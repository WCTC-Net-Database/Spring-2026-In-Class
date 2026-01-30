using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w2_parsing
{
    public class Parser
    {
        public static string[] ParseLine(string inputLine)
        {
            string name = "";
            string profession = "";
            string level = "";
            string health = "";
            string equipment = "";

            // parse name
            if (inputLine.StartsWith("\""))
            {
                int closingQuote = inputLine.IndexOf("\"", 1);
                name = inputLine.Substring(1, closingQuote - 1);
                var restOfLine = inputLine.Substring(closingQuote + 2); // skip closing quote and comma

                var lines = restOfLine.Split(',');
                profession = lines[0];
                level = lines[1];
                health = lines[2];
                equipment = lines[3];

            }
            else
            {
                var lines = inputLine.Split(',');
                name = lines[0];
                profession = lines[1];
                level = lines[2];
                health = lines[3];
                equipment = lines[4];

            }
            return new string[] { name, profession, level, health, equipment };
        }
    }
}
