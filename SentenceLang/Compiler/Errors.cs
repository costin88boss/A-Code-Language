using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SentenceLang.Compiler
{
    internal class Errors
    {
        internal static void UnknownTokenError(int line, int column, string token)
        {
            Console.WriteLine("Error: Unknown token '{0}' at line {1}, column {2}", token, line, column);
        }

        internal static void EmptyLineError()
        {
            Console.WriteLine();
        }
    }
}
