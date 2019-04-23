using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace WordsCount.Models
{
    public static class Counter
    {
        private static readonly WordList english = new WordList();
        private static readonly WordList chinese = new WordList();
        private static readonly WordList hindi = new WordList();

        public static bool Any(string value, UnicodeCategory category) =>
            !string.IsNullOrWhiteSpace(value)
            && value.Any(@char => char.GetUnicodeCategory(@char) == category);

        public static void Add(string context) {
            var sb = new StringBuilder();

            foreach (char c in context)
            {
                if (char.IsLetter(c))
                    if (c >= 0x4E00 && c <= 0x9FEF)
                        chinese.AddWord(c.ToString());
                    else
                        sb.Append(c);
                else
                    sb.Append(' ');
            }

            context = sb.ToString();
            string[] list = context.Split(' ');

            foreach (string word in list)
            {
                if (word == " " || word == "")
                    continue;

                if (Any(word, UnicodeCategory.OtherLetter))
                {
                    hindi.AddWord(word);
                } else {
                    string w = word.ToLower();
                    english.AddWord(w);
                }
            }
        }

        public static IEnumerable<Word> GetEnglish(int limit) {
            return english.GetWords(limit);
        }

        public static IEnumerable<Word> GetChinese(int limit)
        {
            return chinese.GetWords(limit);
        }

        public static IEnumerable<Word> GetHindi(int limit)
        {
            return hindi.GetWords(limit);
        }

    }
}
