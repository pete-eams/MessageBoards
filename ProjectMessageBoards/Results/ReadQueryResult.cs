using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectMessageBoards.DomainModels;

namespace ProjectMessageBoards.Results
{
    public class ReadQueryResult
    {
        private readonly List<MessageBoardEvent> _events;

        public ReadQueryResult(IEnumerable<MessageBoardEvent> events)
        {
            _events = events.OrderByDescending(e => e.MillisecondsSinceCreation).ToList();
        }

        public override string ToString()
        {
            var strBuilder = new StringBuilder();
            var lastUser = "";
            foreach (var @event in _events)
            {
                if (lastUser != @event.User)
                {
                    strBuilder.Append($"{@event.User}\n");
                    lastUser = @event.User;
                }

                strBuilder.AppendLine($"{@event.Message} ({@event.MinuteSinceCreation} " +
                                      $"minute{(@event.MinuteSinceCreation == 1 ? "" : "s")} ago)");
            }

            return strBuilder.ToString();
        }
    }
}
