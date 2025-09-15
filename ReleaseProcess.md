### Release Process

##### Checklist for Initial Deploy:

* install nuget locally: https://dist.nuget.org/win-x86-commandline/latest/nuget.exe
* add to bash echo $PATH at /usr/bin ( or /C/Program Files/Git/usr/bin )
* add to echo %PATH% at C:\Program Files\bin\
* this should function with local scripts

https://learn.microsoft.com/en-us/nuget/nuget-org/publish-a-package
Microsoft will let you publish via API, but it looks like you need an API Key that expires after a year.

There is also a web portal, that does not appear to need the API key.


#####  Checklist for Version Release.

* 