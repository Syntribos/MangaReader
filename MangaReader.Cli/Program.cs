using Autofac;
using MangaReader.Cli.Autofac;
using Scrapers;
using Scrapers.MangaDex;

var mdScraper = CliContainerProvider.BuildCliContainer().Resolve<IScraperProvider>().GetByKey(nameof(MangaDexScraper));
var results = await mdScraper.Search(Guid.NewGuid());
Console.WriteLine($"The first result on MangaDex at the moment is {results.FirstOrDefault()?.Title ?? "ERROR"}");
