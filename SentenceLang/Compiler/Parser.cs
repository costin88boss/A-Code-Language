using System.Linq.Expressions;

namespace SentenceLang.Compiler
{
    internal class Parser
    {
        internal static void Parse(List<Token> tokens)
        {
            
            for (int i = 0; i < tokens.Count; i++)
            {
                Console.WriteLine(tokens[i].type + ":" + tokens[i].value);
            }

        }
    }
}
