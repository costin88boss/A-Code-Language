using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SentenceLang.Compiler
{
    internal class Compiler
    {
        internal static bool CompileLine(string? lineStatement)
        {
            Token.PrepareTokens();
            if (lineStatement != null && lineStatement.Trim() != "")
            {
                if (!Lexer.Tokenize(lineStatement))
                {
                    return false;
                }
            }
            else
            {
                Errors.EmptyLineError();
                return false;
            }
            Parser.Parse(Lexer.GetTokens());

            return true;
        }
    }
}
