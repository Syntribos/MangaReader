﻿using System.Text.RegularExpressions;

namespace Scrapers;

public interface IScraper : IEquatable<IScraper>
{
    string Key { get; }
    
    Regex UrlPattern { get; }

    public bool AddManga(string url);
}