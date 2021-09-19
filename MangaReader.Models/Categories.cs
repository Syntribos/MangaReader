using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using MangaReader.Utilities;

namespace MangaReader.Models
{
    public class Categories
    {
        private readonly IDictionary<string, int> _categories = new Dictionary<string, int>();

        public IEnumerable<string> CategoryNames => _categories.Keys;

        public int GetCategoryIndexByName(string category)
        {
            return _categories.GetValueOrDefault(category, 0);
        }
    }
}