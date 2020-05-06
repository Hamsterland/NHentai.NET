[![Build Status](https://dev.azure.com/matthewtrip2/NHentai.NET/_apis/build/status/Hamsterland.NHentai.NET?branchName=master)](https://dev.azure.com/matthewtrip2/NHentai.NET/_build/latest?definitionId=7&branchName=master)
![Nuget](https://img.shields.io/nuget/v/NHentai.NET)
[![CodeFactor](https://www.codefactor.io/repository/github/hamsterland/nhentai.net/badge)](https://www.codefactor.io/repository/github/hamsterland/nhentai.net)

# Introduction
NHentai.NET is an nhentai API Wrapper written in C#. This project uses the in-built Json serializer System.Text.Json instead of Newtonsoft.Json. Therefore, it only targets .NET Core 3.0 and .NET Standard 2.0 projects and above. 

## Installation
You can install the latest build from [NuGet](https://www.nuget.org/packages/NHentai.NET/1.2.0) or through the .NET CLI using the command
```
dotnet add package NHentai.NET --version 1.2.0
```

## Examples
```cs
// Create a new instance of IHentaiClient.
var client = new IHentaiClient();

// Search for a book by its Id.
Book book = client.SearchBook(177013);

// Get the book Id. 
int id = book.JsonId.GetInt32();

// Get the book English title.
string title = book.Title.English;

// Get all the book image Urls.
List<string> images = client.GetAllBookPages(id);
```

## Dependency Injection
```cs
private void ConfigureServices(IServiceCollection services)
{
    // Call this method on your collection.
    services.AddHentaiClient();
}
```