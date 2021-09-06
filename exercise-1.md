# Create a console application simulating ordering a pizza

## What to install

- Use Visual Studio Code, not Visual Studio
- https://github.com/dotnet/installer and download the nightly build of .NET SDK 6 Preview6 for Windows x64.

## Requirements

- Create a console based pizza ordering application.
- Use https://github.com/spectreconsole/spectre.console.
- Allow user to order multiple pizzas with their toppings.
- Store the possible configuration of pizzas and their toppings in a JSON file. Read this file and use it in the application.
- Once you order your pizza order, allow user to write it in a JSON file format. 

## Note

- Pick a partner or two. There's no need to figure this out alone. Use [Live Share](https://code.visualstudio.com/learn/collaboration/live-share).
- Use C# 9 or C# 10 pictures.
- .NET Core 6 has Hot Reload features. Use them. Just use `dotnet watch run`.
- Don't forget to set `global.json` to match the .NET 6 preview SDK you are using e.g. like [this](https://github.com/dodyg/practical-aspnetcore/blob/net5.0/projects/net6/map-4/global.json) 
- You can use this project file

``` xml
<Project Sdk="Microsoft.NET.Sdk">  
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net6.0</TargetFramework>
  </PropertyGroup>  
  <ItemGroup>
    <PackageReference Include="Spectre.Console" Version="0.40.1-preview.0.22" />
  </ItemGroup>
</Project>
```



