using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ProjectMessageBoards
{
    class PostCommand
    {
        private static readonly Regex PostCommandRegex 
            = new(@"^(?<username>\w+(\d|\w)*) -> @(?<projectName>\w+) (?<message>.*)$");

        public PostCommand(
            string username, 
            string projectName, 
            string message)
        {
            Message = message;
            Username = username;
            ProjectName = projectName;
        }
        
        public string Username { get; }

        public string ProjectName { get; }

        public string Message { get; }

        public static PostCommand FromString(string str)
        {
            var matchGroups = PostCommandRegex.Match(str).Groups;
            return new PostCommand(
                matchGroups["username"].Value,
                matchGroups["projectName"].Value,
                matchGroups["message"].Value);
        }

        public static bool IsValid(string str)
            => PostCommandRegex.Match(str).Success;
    }
}
