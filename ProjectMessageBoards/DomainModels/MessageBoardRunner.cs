using System;
using ProjectMessageBoards.Commands;
using ProjectMessageBoards.Queries;

namespace ProjectMessageBoards.DomainModels
{
    public class MessageBoardRunner
    {
        private readonly MessageBoards _messageBoards;
        public MessageBoardRunner()
        {
            _messageBoards = new MessageBoards();
        }

        public void Run()
        {
            PrintWelcomeBanner();
            Console.WriteLine("\nEnter your commands, leave blank to exit:");
            while (true)
            {
                try
                {
                    Console.Write("> ");
                    ValidateAndSubmitInput(Console.ReadLine()?.Trim());
                }
                catch (NoInputException)
                {
                    Console.WriteLine("Exiting...");
                    break;
                }
            }
        }

        private void ValidateAndSubmitInput(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new NoInputException();

            if (PostCommand.IsValid(input))
            {
                _messageBoards.Post(PostCommand.FromString(input));
            }
            else if (FollowCommand.IsValid(input))
            {
                _messageBoards.Follow(FollowCommand.FromString(input));
            }
            else if (WallQuery.IsValid(input))
            {
                var result = _messageBoards.Wall(WallQuery.FromString(input));
                Console.WriteLine(result);
            }
            else if (ReadQuery.IsValid(input))
            {
                var result = _messageBoards.Read(ReadQuery.FromString(input));
                Console.WriteLine(result);
            }
            else Console.WriteLine("Unknown Command!!");
        }

        private void PrintWelcomeBanner()
        {
            Console.WriteLine(@"
 ██████╗██╗     ██╗    ███╗   ███╗███████╗███████╗███████╗ █████╗  ██████╗ ███████╗
██╔════╝██║     ██║    ████╗ ████║██╔════╝██╔════╝██╔════╝██╔══██╗██╔════╝ ██╔════╝
██║     ██║     ██║    ██╔████╔██║█████╗  ███████╗███████╗███████║██║  ███╗█████╗  
██║     ██║     ██║    ██║╚██╔╝██║██╔══╝  ╚════██║╚════██║██╔══██║██║   ██║██╔══╝  
╚██████╗███████╗██║    ██║ ╚═╝ ██║███████╗███████║███████║██║  ██║╚██████╔╝███████╗
 ╚═════╝╚══════╝╚═╝    ╚═╝     ╚═╝╚══════╝╚══════╝╚══════╝╚═╝  ╚═╝ ╚═════╝ ╚══════╝
                                                                                   
██████╗  ██████╗  █████╗ ██████╗ ██████╗ ███████╗                                  
██╔══██╗██╔═══██╗██╔══██╗██╔══██╗██╔══██╗██╔════╝                                  
██████╔╝██║   ██║███████║██████╔╝██║  ██║███████╗                                  
██╔══██╗██║   ██║██╔══██║██╔══██╗██║  ██║╚════██║                                  
██████╔╝╚██████╔╝██║  ██║██║  ██║██████╔╝███████║                                  
╚═════╝  ╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═╝╚═════╝ ╚══════╝ ");
        }
    }
    
    class NoInputException : Exception {
    }
}
