using System.Collections.Generic;
using System.Linq;

namespace ProjectMessageBoards
{
    class MessageBoard
    {
        private readonly string _projectName;
        private readonly List<MessageBoardEvent> _events;

        public MessageBoard(string projectName)
        {
            _projectName = projectName;
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
