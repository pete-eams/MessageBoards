using System;
using System.Threading;
using ProjectMessageBoards.Commands;
using ProjectMessageBoards.DomainModels;
using ProjectMessageBoards.Queries;
using Xunit;

namespace ProjectMessageBoardsTests
{
    public class MessageBoardsTests
    {
        private readonly MessageBoards _messageBoards;
        public MessageBoardsTests()
        {
            _messageBoards = new MessageBoards();
        }

        [Fact]
        public void CanPostAndQueryMessageBoard()
        {
            // Given
            var expectation = $"Alice\nI'm working on the login screen (0 minutes ago)\r\n";

            // When
            _messageBoards.Post(new PostCommand("Alice", "Moonshot", "I'm working on the login screen"));

            // Then 
            var result = _messageBoards.Read(new ReadQuery("Moonshot")).ToString();
            Assert.Equal(expectation, result);
        }

        [Fact]
        public void CanPostMultipleTimesAndQueryMessageBoard()
        {
            // Given
            var expectation = $"Alice\nI'm working on the login screen (0 minutes ago)\r\n" +
                              $"Bob\nAwesome, I'll start on the forgotten password screen (0 minutes ago)\r\n" +
                              $"I'll give you the link to put on the log on screen shortly Alice (0 minutes ago)\r\n";

            // When
            _messageBoards.Post(new PostCommand("Alice", "Moonshot", "I'm working on the login screen"));
            _messageBoards.Post(new PostCommand("Bob", "Moonshot", "Awesome, I'll start on the forgotten password screen"));
            _messageBoards.Post(new PostCommand("Bob", "Moonshot", "I'll give you the link to put on the log on screen shortly Alice"));

            // Then 
            var result = _messageBoards.Read(new ReadQuery("Moonshot")).ToString();
            Assert.Equal(expectation, result);
        }

        [Fact]
        public void CanFollowASingleBoardAndViewWall()
        {
            // Given
            _messageBoards.Post(new PostCommand("Bob", "Apollo", "Has anyone thought about the next release demo?"));
            var expectation = $"Apollo - Bob: Has anyone thought about the next release demo? (0 minutes ago)\r\n";

            // When
            _messageBoards.Follow(new FollowCommand("Charlie", "Apollo"));

            // Then 
            var result = _messageBoards.Wall(new WallQuery("Charlie")).ToString();
            Assert.Equal(expectation, result);
        }

        [Fact]
        public void CanFollowMultipleBoardsAndViewWall()
        {
            // Given
            _messageBoards.Post(new PostCommand("Alice", "Moonshot", "I'm working on the log on screen"));
            // Sort is precise to the millisecond, added some delay to simulate people taking their time to type...
            // Alternative is to mock out time provider, ie. ITimeService but probably overkill in this case.
            Thread.Sleep(1); 
            _messageBoards.Post(new PostCommand("Bob", "Moonshot", "Awesome, I'll start on the forgotten password screen"));
            Thread.Sleep(1);
            _messageBoards.Post(new PostCommand("Bob", "Apollo", "Has anyone thought about the next release demo?"));
            Thread.Sleep(1);
            _messageBoards.Post(new PostCommand("Bob", "Moonshot", "I'll give you the link to put on the log on screen shortly Alice"));

            var expectation = $"Moonshot - Alice: I'm working on the log on screen (0 minutes ago)\r\n" +
                              $"Moonshot - Bob: Awesome, I'll start on the forgotten password screen (0 minutes ago)\r\n" +
                              $"Apollo - Bob: Has anyone thought about the next release demo? (0 minutes ago)\r\n" +
                              $"Moonshot - Bob: I'll give you the link to put on the log on screen shortly Alice (0 minutes ago)\r\n";

            // When
            _messageBoards.Follow(new FollowCommand("Charlie", "Apollo"));
            _messageBoards.Follow(new FollowCommand("Charlie", "Moonshot"));

            // Then 
            var result = _messageBoards.Wall(new WallQuery("Charlie")).ToString();
            Assert.Equal(expectation, result);
        }
    }
}
