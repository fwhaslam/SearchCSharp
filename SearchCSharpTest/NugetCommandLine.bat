REM
REM !!IMPORTANT!! this file needs to 'save as' US-ASCII so it will function, default of UTF-8 will make it un-runnnable.
REM
REM NOTE: this is part of the Test project for two reasons:
REM       1) this guarantees that the nuget package has been created
REM       2) this guarantees that tests have passed
REM 
REM NOTE: Add to PostBuild Events as:
REM       VerboseDeployNugetPackage.bat $(Version) $(ProjectKey)
REM
echo     Trying to deploy nuget package to repository.

dir

echo     Starting Up

Install-Package SearchCSharp -source C:\Users\Fred\Workspace\_StarPuzzleProject\SearchCSharp\SearchCSharp\bin\Debug\SearchCSharp.0.0.1.nupkg

REM Install-Package C:\Users\Fred\Workspace\_StarPuzzleProject\SearchCSharp\SearchCSharp\bin\Debug\SearchCSharp.0.0.1.nupkg -source c:/dev/nuget/packages

echo     All Done
