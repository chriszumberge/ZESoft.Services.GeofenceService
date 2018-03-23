# ZESoft.Services.GeofenceService
Service for implementing geofencing and enter/exit event handling

## Documentation
Get started by reading through the [Geofence Service Documentation](docs/README.md)

## NuGet
Available on NuGet: (Coming soon)

## Builds and Tests
### Master Branch
Build Status

Codacy Badge

CI NuGet Feed

### Develop Branch
Build Status

### Platform Support
|Platform       | Version  |
|---------------|:--------:|
|.Net           |   4.5+   |
|.Net Core      |   1.0+   |
|.Net Standard  |   2.0+   |
|Xamarin.iOS    |  iOS 7+  |
|Xamarin.Android|  API 14+ |

## Setup
Install into PCL/.Net project
- Available on NuGet
- Download NuGet package in distribution (dist) folder
- Download project and reference the .csproj

## API Usage
[ZESoft.Services.GeofenceService API Documentation](docs/ApiDocumentation.md)

### Developer Tips

## Contribute
The library is open source so pull requests are encouraged.
- Report bugs by opening an issue
- Submit feature requests by opening an issue
- Fix bugs or add features by sending a pull request

### ToDos 

### Project Roadmap

### Coding Conventions
In general, follow the style used by the [.Net Foundation](https://github.com/dotnet/corefx/blob/master/Documentation/coding-guidelines/coding-style.md)
with the following exceptions:
- Preference to use [expression bodied functions](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/expression-bodied-members#methods)
and [properties](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/expression-bodied-members#property-get-statements)
where applicable
- Do not use the ```private``` keyword as it is the default accessibility level
- Hard tabs over spaces, *always*

Taking special note of:
- [Allman style](https://en.wikipedia.org/wiki/Indent_style#Allman_style) braces
- Use _camelCase for internal/private fields
- Use ```readonly``` where possible
- Prefix instance fields with ```_```
- Static fields start with ```s_```
- Fields should be specified at the top within type declarations
- Use ```nameof(...)``` whenever possible
- Avoid ```this.``` whenever possible
- Only use ```var``` when it's obvious what the variable type is
- Use PascalCasing to name constant variables and fields

### Architecture Conventions
- All services must implement an IService interface for both dependency injection and easier testing
- Where possible, services should have a configuration interface that a developer can implement to customize the service
- Where possible, projects should target as many platforms as possible (via .Net Standard or PCL)

### Project Conventions
- Sort and remove all assembly references