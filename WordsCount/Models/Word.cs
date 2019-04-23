using System;
namespace WordsCount.Models
{
    public class Word : IComparable<Word>
    {
        public string key { get; }
        public int value { get; set; }

        public Word(string key)
        {
            this.key = key;
            this.value = 0;
        }

        public void Add()
        {
            this.value++;
        }

        public int CompareTo(Word other)
        {
            if (this.value == other.value)
                return string.Compare(this.key, other.key, StringComparison.Ordinal);
            else
                return other.value.CompareTo(this.value);
        }
    }
}
