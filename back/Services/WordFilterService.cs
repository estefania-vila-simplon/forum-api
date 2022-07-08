using back.Services.Interfaces;
using System.Text.RegularExpressions;

namespace back.Services
{
    public class WordFilterService : IWordFilterService
    {
        static String[] banWords = new string[150];

        private static readonly string FILE_TO_LOAD = "c:/users/gloriaestefania.lope/Desktop/FORUM/back/Properties/insults.txt";

        static WordFilterService()
        {
            ThreadPool.QueueUserWorkItem(state => InitBanWords());
            InitBanWords();
        }

        public bool ContainsBadWord(String word)
        {
            return banWords.ToList().Find(str =>
            {
                if(str != null)
                {
                    var regex = new Regex(str);

                    return regex.IsMatch(word);
                }
                return false;
            }) != null;
        }

        public string ReplaceWord(string word)
        {
            bool mustSearch = true;
            string finalString = word;

            while(mustSearch)
            {
                var wordToReplace = banWords.ToList().Find(str =>
                {
                    if (str != null)
                    {
                        var regex = new Regex(str);

                        return regex.IsMatch(finalString);
                    }
                    return false;
                });

                if(wordToReplace == null)
                {
                    mustSearch = false;
                    break;
                }

                char firstLetter = wordToReplace.First();
                char lastLetter = wordToReplace.Last();
                int length = wordToReplace.Length;
                int lastIndexOfChar = wordToReplace.LastIndexOf(lastLetter);

                string correctedWord = ""+firstLetter;

                for(int i = 1; i < length-1; i++)
                {
                    correctedWord = correctedWord+'*';
                }

                correctedWord = correctedWord+lastLetter;

                var regex = new Regex(wordToReplace);
                finalString = regex.Replace(finalString, correctedWord);
            }

            return finalString;
        }


        public string TestAndReplace(string sequence)
        {
            return ContainsBadWord(sequence) ? ReplaceWord(sequence) : sequence;
        }



        private static void InitBanWords()
        {
            var file = File.OpenText(FILE_TO_LOAD);

            string line = "";

            int indexArr = 0;

            String[] tempArr;
            List<string> tmpValue = new List<string>();

            while ((line = file.ReadLine()) != null)
            {
                tmpValue.Add(line);
            }

            banWords = tmpValue.ToArray();
        }
    }
}
