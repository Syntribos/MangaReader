﻿namespace MangaReader.Data;

public interface IConnectionStringProvider
{
    string DatabasePath { get; }

    string ConnectionString { get; }
}