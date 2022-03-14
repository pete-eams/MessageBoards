using System;

namespace ProjectMessageBoards.DomainModels
{
    class MessageBoardEvent
    {
        private readonly DateTime _createdTime;
        
        public MessageBoardEvent(string projectName, string username, string message)
        {
            User = username;
            Message = message;
            ProjectName = projectName;
            _createdTime = DateTime.Now;
        }

        public string ProjectName { get;  }
        
        public string Message { get; }
        
        public string User { get; }
        
        public int MinuteSinceCreation
            => (int)(DateTime.Now - _createdTime).TotalMinutes;

        public int MillisecondsSinceCreation
            => (int)(DateTime.Now - _createdTime).TotalMilliseconds;
    }
}
