using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snowman
{
    public class Words
    {
        readonly Random rand = new Random();
        private readonly List<string> WordList; // Private list ensures it isn't accidentally altered.
        private int index;
        public Words()
        {
            WordList = new List<string>() // Word list contains 5 words each of 4, 5, 6, 7, 8, 9, and 10-letter words.
            {
                "DARK", "CRAB", "SILT", "BUZZ", "MEAN",
                "OILED", "BREAD", "NEXUS", "BARON", "GUARD",
                "CREATE", "MIXING", "ORIGIN", "DERIVE", "OCTANE",
                "DESTINY", "CAUTION", "FANCIED", "WORRIES", "ESTUARY",
                "REACTION", "WIELDING", "COMPUTER", "RESTLESS", "DEVIATED",
                "PHYSICIAN", "MAXIMIZED", "OXIDIZING", "GRIZZLIES", "CARJACKED",
                "PUZZLEMENT", "JACKHAMMER", "KICKBOXING", "EXORCIZING", "BACKPACKER",
            };
        }

        public string NewWord() // Returns a random word from the list.
        {
            index = rand.Next(WordList.Count);
            return WordList[index]; 
        }
    }
}
