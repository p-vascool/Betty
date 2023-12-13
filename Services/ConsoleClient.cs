using Betty.Models.Results;
using Betty.Services.Contracts;

namespace Betty.Services
{
    public class ConsoleClient : IClient
    {
        private string _initialMessage = $"Welcome to Betty platform!{Environment.NewLine}" +
            $"Enjoy your experience!" +
            $"{Environment.NewLine}";

        private string _actionMessage = "Please, submit action:";
        public ConsoleClient()
        {
            InitialMessage();
        }

        private void InitialMessage()
           => Console.WriteLine(_initialMessage);


        public string GetUserInput()
        {
            Console.WriteLine(_actionMessage);
            var userInput = Console.ReadLine();
            return userInput!;
        }

        public void ReturnResult(ICommandResult result)
        {
            Console.WriteLine(result.Message);
            Console.WriteLine();
        }
    }
}
