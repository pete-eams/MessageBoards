using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectMessageBoards.DomainModels;

namespace ProjectMessageBoards.Results
{
    class WallQueryResult
    {
        private readonly List<MessageBoardEvent> _events;

        public WallQueryResult(IEnumerable<MessageBoardEvent> events)
        {
            _events = events.OrderByDescending(e => e.MillisecondsSinceCreation).ToList();
        }

        public override string ToString()
        {
            var strBuilder = new StringBuilder();
            foreach (var @event in _events)
            {
                strBuilder.AppendLine($"{@event.ProjectName} - {@event.User}: " +
                                  $"{@event.Message} ({@event.MinuteSinceCreation} " +
                                  $"minute{(@event.MinuteSinceCreation == 1 ? "" : "s")} ago)");
            }

            return strBuilder.ToString();
        }

    }
}
