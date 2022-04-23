using SentenceLang.Compiler;

Console.WriteLine("Please type your statement to be executed.");

while (true)
{
    String? lineStatement = Console.ReadLine();

    Compiler.CompileLine(lineStatement);
}