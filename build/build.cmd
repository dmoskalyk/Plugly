@echo off
set BuildProps=Configuration=Release;SignAssembly=true;DelaySign=false;AssemblyOriginatorKeyFile=..\..\..\lokiworld.snk
call nuget pack ..\src\Plugly\Plugly.csproj -Build -p %BuildProps%
call nuget pack ..\src\Plugly.Unity\Plugly.Unity.csproj -Build -p %BuildProps%
call nuget pack ..\src\Plugly.Autofac\Plugly.Autofac.csproj -Build -p %BuildProps%
pause