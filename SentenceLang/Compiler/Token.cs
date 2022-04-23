
namespace SentenceLang.Compiler
{
    
    public class Token
    {
        public readonly String[] names;
        public readonly TokenType type;
        public String value = "";

        private Token(String[] names, TokenType type)
        {
            this.type = type;
            this.names = names;
        }
        public Token(Token token, String value)
        {
            this.type = token.type;
            this.names = token.names;
            this.value = value;
        }

        internal static void PrepareTokens()
        {
            if(Tokens.Count == 0)
            {
                AddTokens();
            }
        }

        private readonly static List<Token> Tokens = new();
        internal static List<Token> GetTokens()
        {
            return Tokens;
        }

        private static void AddTokens()
        {
            Tokens.Clear();

            Tokens.Add(new Token(new string[] { "+" }, TokenType.ADD));
            Tokens.Add(new Token(new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" }, TokenType.NUMBER));
            Tokens.Add(Space);
        }

        internal static Token Space = new(new string[] { " " }, TokenType.SPACE);

    }
    public enum TokenType
    {
        SPACE,
        ADD,
        NUMBER
    }

}