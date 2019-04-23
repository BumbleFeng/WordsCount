using System.Collections.Generic;
using System.Threading.Tasks;
using WordsCount.Models;
using Microsoft.AspNetCore.Mvc;

namespace WordsCount.ViewComponents
{
    public class WordListViewComponent: ViewComponent
    {
        public WordListViewComponent()
        {
        }

        public async Task<IViewComponentResult> InvokeAsync(int language, int limit)
        {
            var words = await GetWordsAsync(language, limit);
            return View(words);
        }

        private Task<IEnumerable<Word>> GetWordsAsync(int language, int limit)
        {
            return Task.FromResult(GetWords(language, limit));
        }

        private IEnumerable<Word> GetWords(int language, int limit)
        {
            switch (language) {
                case 1: 
                    return Counter.GetEnglish(limit);
                case 2: 
                    return Counter.GetChinese(limit);
                case 3: 
                    return Counter.GetHindi(limit);
                default:
                    return Counter.GetEnglish(limit);
            }

        }
    }
}
