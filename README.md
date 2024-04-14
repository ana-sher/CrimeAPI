# CrimeAPI
WEB API (on ASP.NET Core) for retrieving data of UK Police from their [open API](https://data.police.uk/docs/). 

## How to start the project
You need to have dotnet environment and [.NET 8.0 SDK (click here to download)](https://dotnet.microsoft.com/en-us/download/dotnet/8.0).
- ### To run from Visual Studio
Click on the https run button (button located in the same place where you run your other projects in VS, in the top toolbar).
- ### To run from command line
Navigate to the solution folder and run 
```bash
$ dotnet run --project CrimeAPI --launch-profile https
```
Then navigate to [https://localhost:7062/swagger](https://localhost:7062/swagger) (it is by default for https profile, to be compatible with front-end app stay on this port)