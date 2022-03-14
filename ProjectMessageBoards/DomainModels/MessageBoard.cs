using System.Collections.Generic;
using System.Linq;
using ProjectMessageBoards.Commands;

namespace ProjectMessageBoards.DomainModels
{
    public class MessageBoard
    {
        private readonly List<MessageBoardEvent> _events;

        public MessageBoard()
        {
            _events = new List<MessageBoardEvent>();
        }

        public void AddEvent(PostCommand postCommand)
            => _events.Add(
                new MessageBoardEvent(
                    postCommand.ProjectName,
                    postCommand.Username, 
                    postCommand.Message));
        
        public List<MessageBoardEvent> GetEvents() 
            => _events.OrderByDescending(e => e.MillisecondsSinceCreation).ToList();
    }
}
