namespace back.Services.Interfaces
{
    public interface IWordFilterService
    {
        public bool ContainsBadWord(String word);

        public string ReplaceWord(String word);

        public string TestAndReplace(string sequence);
    }
}
