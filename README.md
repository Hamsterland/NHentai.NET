[![Build Status](https://dev.azure.com/matthewtrip2/NHentai.NET/_apis/build/status/Hamsterland.NHentai.NET?branchName=master)](https://dev.azure.com/matthewtrip2/NHentai.NET/_build/latest?definitionId=7&branchName=master)

# Introduction
NHentai.NET is an nhentai API Wrapper written in C#. This project uses the in-built Json serializer System.Text.Json instead of Newtonsoft.Json. Therefore, it only targets .NET Core 3.0 projects and above. 

## Example
```cs
// Create a new instance of IHentaiClient.
var client = new IHentaiClient();

// Search for a book by its Id.
var book = client.SearchBook(177013);
```