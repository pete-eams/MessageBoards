using System.Text.RegularExpressions;

namespace ProjectMessageBoards.Queries
{
    class WallQuery
    {
        private static readonly Regex WallQueryRegex 
            = new(@"^(?<username>\w+(\d|\w)*) wall$");

        public WallQuery(string username)
        {
            Username = username;
        }

        public string Username { get; }

        public static WallQuery FromString(string str)
        {
            var matchGroups = WallQueryRegex.Match(str).Groups;
            return new WallQuery(matchGroups["username"].Value);
        }

        public static bool IsValid(string str)
            => WallQueryRegex.Match(str).Success;
    }
}
