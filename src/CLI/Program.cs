using BLL;
using CLI.ConsoleTypeSession;
using CLI.FileTypeSession;
using CLI.Model;
using CLI.Session;
using Microsoft.Extensions.Configuration;
using System;

namespace CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator(new MathAlgorithm());

            var configuration = AppConfiguration.UseConfigSettings();
            var userDialog = configuration.GetSection("UserDialog").Get<UserDialogConfig>();
            var bracketsType = configuration.GetSection("Brackets").Get<BracketsConfig>();
            var mathOperation = configuration.GetSection("MathOperation").Get<MathOperationConfig>();

            bool repeatAgain;
            do
            {
                repeatAgain=false;
                SessionType typeSession = TypeSession.SetTypeSession(userDialog.SetTypeSession);
                switch (typeSession)
                {
                    case SessionType.FileLoad:
                        FileSession.SetFileSession(calculator, userDialog);
                        break;
                    case SessionType.ConsolePrint:
                        string mathPhrase = ConsoleEntrance.StrartConsoleSession(userDialog.SetMathPhrase);
                        Console.WriteLine($"{mathPhrase} = {calculator.Count(mathPhrase)}");
                        break;
                    default:
                        Console.WriteLine(userDialog.ErrorMessage);
                        repeatAgain =TypeSession.RepeatInput(userDialog.RepeatInput);
                        break;
                }
            } while (repeatAgain);

            Console.ReadKey();
        }
    }
}
