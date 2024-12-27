namespace programmingLanguage;

class Program
{
    static void Main(string[] args)
    {
        Lexer lexer = new Lexer();
        List<Lexer.Token> tokens = lexer.Tokenize("5654 hello");

        for(int i = 0; i < tokens.Count; i++)
        {
            Console.WriteLine($"[{tokens[i].type}, {tokens[i].value}]");
        }
    }
}