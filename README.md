[![Build Status](https://dev.azure.com/matthewtrip2/NHentai.NET/_apis/build/status/Hamsterland.NHentai.NET?branchName=master)](https://dev.azure.com/matthewtrip2/NHentai.NET/_build/latest?definitionId=7&branchName=master)
![Nuget](https://img.shields.io/nuget/v/NHentai.NET)
[![CodeFactor](https://www.codefactor.io/repository/github/hamsterland/nhentai.net/badge)](https://www.codefactor.io/repository/github/hamsterland/nhentai.net)

# Introduction
NHentai.NET is an asynchronous api wrapper written in C# for the public nhentai.net API. This wrapper makes it easy for you to search and retrieve data from nhentai without having to make precarious Http requests yourself.

## Support
This project utilizes the System.Text.Json namespace instead of the popular alternative Newtonsoft.Json. Therefore, NHentai.NET only supports projects that target .NET Core 3.0 and .NET Standard 2.0 and above.

## Installation
You can install the latest builds from [NuGet](https://www.nuget.org/packages/NHentai.NET/3.0.0) or GitHub [packages](https://github.com/Hamsterland/NHentai.NET/packages).

### NuGet (stable)
This source contains the latest stable builds.
```
dotnet add package NHentai.NET --version 3.0.0
```
### GitHub (unstable)
This source contains the all the latest builds. This is unstable and may not work correctly, but may sometimes be even with the Stable source. This will be the case if the version numbers are the same.
## Examples
The following code shows how you can setup and get information about books.
```cs
// Create a new client.
var client = new HentaiClient();

// Search for a book by its Id.
Book book = await client.SearchBookAsync(177013);

// Get the book English title.
string title = book.Titles.English;

// Get all the book image Urls.
List<string> images = book.GetPages();

// Search for books on page 1 sorted by popular that contain the "yuri" tag but exclude "lolicon".
SearchResult result = await client.SearchQueryAsync(1, Sort.Popular, "yuri", "-lolicon");
```

## Dependency Injection
To configure this wrapper in your container, call the `AddHentaiClient()` method on your service collection.
```cs
private void ConfigureServices(IServiceCollection services)
{
    services.AddHentaiClient();
}
```


