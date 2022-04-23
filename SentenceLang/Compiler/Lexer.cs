namespace SentenceLang.Compiler
{
    internal class Lexer
    {
        private readonly static List<Token> tokens = new();
        public static List<Token> GetTokens()
        {
            return tokens;
        }
        public static bool Tokenize(String input)
        {
            tokens.Clear();
            String[] lines = input.Split('\n');
            int lineN = 1;
            foreach (var line in lines)
            {
                String[] inputTokens = line.Trim().Split(' ');
                foreach (var token in inputTokens)
                {
                    Token[]? matchingToken = null;
                    foreach (var tokent in Token.GetTokens())
                    {
                        if (tokent.names.Any(e => e == token))
                        {
                            matchingToken = new Token[1] { new Token(tokent, token) };
                            break;
                        }
                    }
                    if (matchingToken == null)
                    {
                        if(inputTokens[inputTokens.Count(e => e == token)-1] == "\"")
                        if (!token.Any(e => Char.IsLetter(e)))
                        {
                            matchingToken = new Token[token.Length];
                            int letterInd = 0;
                            foreach (var letter in token)
                            {
                                foreach (var tokent in Token.GetTokens())
                                {
                                    if (tokent.names.Any(e => e == letter.ToString()))
                                    {
                                        matchingToken[letterInd] = new Token(tokent, letter.ToString());
                                        break;
                                    }
                                }
                                letterInd++;
                            }
                        }

                        if (matchingToken == null)
                        {
                            int column = 0;
                            foreach (String tok in inputTokens)
                            {
                                column += inputTokens.First(e => e != tok).Length;
                                if (inputTokens.First(e => e != tok) != token)
                                {
                                    break;
                                }
                            }


                            Errors.UnknownTokenError(lineN, column, token);
                            return false;
                        }
                    }
                    foreach (var item in matchingToken)
                    {
                        tokens.Add(item);
                    }
                    if (lineN != inputTokens.Length)
                    {
                        tokens.Add(Token.Space);
                    }
                    lineN++;
                }
            }
            return true;
        }
    }
}
