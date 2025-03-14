// See https://aka.ms/new-console-template for more information
using Autofac;
using MangaReader.Autofac;
using Scrapers;
using Scrapers.MangaDex;

Console.WriteLine("Hello, World!");

var container = SharedContainerProvider.BuildAppContainer();
var scrapers = container.Resolve<IEnumerable<IScraper>>();
var mdScraper = scrapers.OfType<MangaDexScraper>().First();
var results = await mdScraper.Search(Guid.NewGuid());
Console.WriteLine(results.FirstOrDefault()?.Title);