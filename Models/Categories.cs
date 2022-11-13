using System.Collections.Generic;

using Utilities;

namespace Models
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