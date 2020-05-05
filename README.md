# Introduction
NHentai.NET is an nhentai API Wrapper written in C#. This project uses the in-built Json serializer System.Text.Json instead of Newtonsoft.Json. Therefore, it only targets projects .NET Core 3.0 and above. 

## Example
```cs
// Create a new instance of IHentaiClient.
var client = new IHentaiClient();

// Search for a book by its Id.
var book = client.SearchBook(177013);
```