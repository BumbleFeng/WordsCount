using System.Collections.Generic;
using System.Linq;

namespace WordsCount.Models
{
    public class WordList
    {
        private Dictionary<string, Word> dictionary = new Dictionary<string, Word>();

        public void AddWord(string w)
        {
            Word word = dictionary.GetValueOrDefault<string, Word>(w, new Word(w));
            word.Add();
            dictionary[w] = word;
        }

        public List<Word> GetWords(int limit)
        {
            List<Word> words = dictionary.Values.ToList();
            words.Sort();
            if (limit == 0)
                return words;
            else
                return words.Take(limit).ToList();
        }
    }
}
