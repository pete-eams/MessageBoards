[![Build Status](https://app.travis-ci.com/pete-eams/MessageBoards.svg?branch=master)](https://app.travis-ci.com/pete-eams/MessageBoards)

# MessageBoards coding challenge from Inlogik

## Pre-requisites
1. .Net 5.0 SDK needs to be installed
    * Confirm that you have it installed by running: `dotnet --version`, you should see: `5.0.XXX`

## Running the tests
1. From root directory run `dotnet test`

## Running the solution
1. Run via dotnet command directly
    * From root directory, navigate to the `ProjectMessageBoards` directory
    * run: `dotnet run`
2. Publish and run via executable
    * run: `dotnet publish -c Release -o dist`
    * navigate to: `dist`
    * execute ProjectMessageBoards.exe
3. Build and run from your IDE of choice (Microsoft Visual Studio/JetBrains Rider)