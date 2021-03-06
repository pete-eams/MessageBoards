using System.Collections.Generic;
using System.Linq;
using ProjectMessageBoards.Commands;
using ProjectMessageBoards.Queries;
using ProjectMessageBoards.Results;
using SD.Tools.Algorithmia.GeneralDataStructures;

namespace ProjectMessageBoards.DomainModels
{
    public class MessageBoards
    {
        private readonly Dictionary<string, MessageBoard> _messageBoards;
        private readonly MultiValueDictionary<string, string> _followedMap;
        public MessageBoards()
        {
            _messageBoards = new Dictionary<string, MessageBoard>();
            _followedMap = new MultiValueDictionary<string, string>();
        }

        public void Post(PostCommand postCommand)
        {
            if (!_messageBoards.ContainsKey(postCommand.ProjectName))
                _messageBoards[postCommand.ProjectName] = new MessageBoard();

            _messageBoards[postCommand.ProjectName].AddEvent(postCommand);
        }

        public ReadQueryResult Read(ReadQuery readQuery)
        {
            return !_messageBoards.ContainsKey(readQuery.ProjectName) 
                ? new ReadQueryResult(new List<MessageBoardEvent>()) 
                : new ReadQueryResult(_messageBoards[readQuery.ProjectName].GetEvents());
        }

        public void Follow(FollowCommand followCommand)
        {
            _followedMap.Add(followCommand.Username, followCommand.ProjectName);
        }

        public WallQueryResult Wall(WallQuery wallQuery)
        {
            var followedBoards = _followedMap.GetValues(wallQuery.Username, returnEmptySet: true);
            var allEvents = followedBoards.SelectMany(boardName => _messageBoards[boardName].GetEvents());

            return new WallQueryResult(allEvents);
        }
    }
}
