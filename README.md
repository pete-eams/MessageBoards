# MessageBoards coding challenge from Inlogik

## Pre-requisites
1. .Net 5.0 SDK needs to be installed
    * Confirm that you have it installed by running: `dotnet --version`, you should see: `5.0.XXX`

## Running the tests
1. From root directory run `dotnet test`
```
C:\Users\po-ea\source\repos\ProjectMessageBoards>dotnet test
  Determining projects to restore...
  All projects are up-to-date for restore.
  ProjectMessageBoards -> C:\Users\po-ea\source\repos\ProjectMessageBoards\ProjectMessageBoards\bin\Debug\net5.0\ProjectMessageBoards.dll
  ProjectMessageBoardsTests -> C:\Users\po-ea\source\repos\ProjectMessageBoards\ProjectMessageBoardsTests\bin\Debug\net5.0\ProjectMessageBoardsTests.dll
Test run for C:\Users\po-ea\source\repos\ProjectMessageBoards\ProjectMessageBoardsTests\bin\Debug\net5.0\ProjectMessageBoardsTests.dll (.NETCoreApp,Version=v5.0)
Microsoft (R) Test Execution Command Line Tool Version 16.11.0
Copyright (c) Microsoft Corporation.  All rights reserved.

Starting test execution, please wait...
A total of 1 test files matched the specified pattern.

Passed!  - Failed:     0, Passed:     4, Skipped:     0, Total:     4, Duration: 2 ms - ProjectMessageBoardsTests.dll (net5.0)
```

## Running the solution
1. Run via dotnet command directly
    * From root directory, navigate to the `ProjectMessageBoards` directory
    * run: `dotnet run`
2. Publish and run via executable
    * run: `dotnet publish -c Release -o dist`
    * navigate to: `dist`
    * execute ProjectMessageBoards.exe
3. Build and run from your IDE of choice (Microsoft Visual Studio/JetBrains Rider)


## Running the solution, Example:

```
C:\Users\po-ea\source\repos\ProjectMessageBoards\ProjectMessageBoards>dotnet run

 ██████╗██╗     ██╗    ███╗   ███╗███████╗███████╗███████╗ █████╗  ██████╗ ███████╗
██╔════╝██║     ██║    ████╗ ████║██╔════╝██╔════╝██╔════╝██╔══██╗██╔════╝ ██╔════╝
██║     ██║     ██║    ██╔████╔██║█████╗  ███████╗███████╗███████║██║  ███╗█████╗
██║     ██║     ██║    ██║╚██╔╝██║██╔══╝  ╚════██║╚════██║██╔══██║██║   ██║██╔══╝
╚██████╗███████╗██║    ██║ ╚═╝ ██║███████╗███████║███████║██║  ██║╚██████╔╝███████╗
 ╚═════╝╚══════╝╚═╝    ╚═╝     ╚═╝╚══════╝╚══════╝╚══════╝╚═╝  ╚═╝ ╚═════╝ ╚══════╝

██████╗  ██████╗  █████╗ ██████╗ ██████╗ ███████╗
██╔══██╗██╔═══██╗██╔══██╗██╔══██╗██╔══██╗██╔════╝
██████╔╝██║   ██║███████║██████╔╝██║  ██║███████╗
██╔══██╗██║   ██║██╔══██║██╔══██╗██║  ██║╚════██║
██████╔╝╚██████╔╝██║  ██║██║  ██║██████╔╝███████║
╚═════╝  ╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═╝╚═════╝ ╚══════╝

Enter your commands, leave blank to exit:
> Alice -> @Moonshot I'm working on the log on screen
> Bob -> @Moonshot Awesome, I'll start on the forgotten password screen
> Bob -> @Apollo Has anyone thought about the next release demo?
> Bob -> @Moonshot I'll give you the link to put on the log on screen shortly Alice
> Moonshot
Alice
I'm working on the log on screen (0 minutes ago)
Bob
Awesome, I'll start on the forgotten password screen (0 minutes ago)
I'll give you the link to put on the log on screen shortly Alice (0 minutes ago)

> Charlie follows Apollo
>  Charlie wall
Apollo - Bob: Has anyone thought about the next release demo? (0 minutes ago)

> Charlie follows Moonshot
> Charlie wall
Moonshot - Alice: I'm working on the log on screen (0 minutes ago)
Moonshot - Bob: Awesome, I'll start on the forgotten password screen (0 minutes ago)
Apollo - Bob: Has anyone thought about the next release demo? (0 minutes ago)
Moonshot - Bob: I'll give you the link to put on the log on screen shortly Alice (0 minutes ago)

>
Exiting...
```
