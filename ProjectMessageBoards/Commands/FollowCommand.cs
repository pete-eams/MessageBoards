using System.Text.RegularExpressions;

namespace ProjectMessageBoards.Commands
{
    public class FollowCommand
    {
        private static readonly Regex FollowCommandRegex 
            = new(@"^(?<username>\w+(\d|\w)*) follows (?<projectName>\w+)$");
        
        public FollowCommand(
            string username, 
            string projectName)
        {
            Username = username;
            ProjectName = projectName;
        }
        
        public string Username { get; }

        public string ProjectName { get; }

        public static FollowCommand FromString(string str)
        {
            var matchGroups = FollowCommandRegex.Match(str).Groups;
            return new FollowCommand(
                matchGroups["username"].Value,
                matchGroups["projectName"].Value);
        }

        public static bool IsValid(string str)
            => FollowCommandRegex.Match(str).Success;
    }
}
