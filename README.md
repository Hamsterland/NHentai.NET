[![Build Status](https://dev.azure.com/matthewtrip2/NHentai.NET/_apis/build/status/Hamsterland.NHentai.NET?branchName=master)](https://dev.azure.com/matthewtrip2/NHentai.NET/_build/latest?definitionId=7&branchName=master)
![Nuget](https://img.shields.io/nuget/v/NHentai.NET)
[![CodeFactor](https://www.codefactor.io/repository/github/hamsterland/nhentai.net/badge)](https://www.codefactor.io/repository/github/hamsterland/nhentai.net)

# Introduction
NHentai.NET is an api wrapper written in C# for the public nhentai.net API. This wrapper makes it easy for you to search and retrieve data from nhentai without having to make precarious Http requests yourself.

## Support
This project utilizes the System.Text.Json namespace instead of the popular alternative Newtonsoft.Json. Therefore, NHentai.NET only supports projects that target .NET Core 3.0 and .NET Standard 2.0 and above.

## Installation
You can install the latest build from [NuGet](https://www.nuget.org/packages/NHentai.NET/2.0.0) or through the .NET CLI using the command
```
dotnet add package NHentai.NET --version 2.0.0
```

## Examples
```cs
// Create a new client.
var client = new IHentaiClient();

// Search for a book by its Id.
Book book = await client.SearchBook(177013);

// Get the book English title.
string title = book.Title.English;

// Get all the book image Urls.
List<string> images = book.GetPages();

// Search for books that contain the "Yuri" tag but exclude "Lolicon".
SearchResult result = await client.SearchQuery("yuri", "-lolicon");
```

## Dependency Injection
```cs
private void ConfigureServices(IServiceCollection services)
{
    // Call this method on your service collection.
    services.AddHentaiClient();
}
```