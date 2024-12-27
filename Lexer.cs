using System.Net.Mime;
using System.Text;

namespace programmingLanguage;

public enum TokenType
{
    Number,
    Identifier
}

public class Lexer
{
    public struct Token
    {
        public Token(TokenType type, string value)
        {
            this.type = type;
            this.value = value;
        }
        
        public TokenType type;
        public string value;
    }
    
    private List<Token> tokens = new();

    public List<Token> Tokenize(string str)
    {
        int i = 0;
        while(i < str.Length)
        {
            char c = str[i];
            
            if(c == '\n' || c == '\r' || c == '\t' || c == ' ') continue;

            if (char.IsNumber(c))
            {
                string num = "";
                while (i < str.Length && char.IsNumber(str[i]))
                {
                    num += str[i];
                    i++;
                }
                tokens.Add(new Token(TokenType.Number, num.ToString()));
            }
            
            // this goes last
            if (char.IsLetter(c))
            {
                string identifier = "";
                while (i < str.Length && char.IsLetter(str[i]))
                {
                    identifier += str[i];
                    i++;
                }
                tokens.Add(new Token(TokenType.Identifier, identifier.ToString()));
            }

            i++;
        }
        
        return tokens;
    }
}