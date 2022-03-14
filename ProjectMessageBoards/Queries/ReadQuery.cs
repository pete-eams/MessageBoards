using System.Text.RegularExpressions;

namespace ProjectMessageBoards.Queries
{
    class ReadQuery
    {
        private static readonly Regex ReadQueryRegex 
            = new(@"^(?<projectName>\w+)$");

        public ReadQuery(string projectName)
        {
            ProjectName = projectName;
        }
        
        public string ProjectName { get; }

        public static ReadQuery FromString(string str)
        {
            var matchGroups = ReadQueryRegex.Match(str).Groups;
            return new ReadQuery(matchGroups["projectName"].Value);
        }
        
        public static bool IsValid(string str)
            => ReadQueryRegex.Match(str).Success;
    }
}
