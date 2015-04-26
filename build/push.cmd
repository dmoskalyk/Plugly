@echo on
for /f %%f in ('dir /b .\*.nupkg') do nuget push %%f
pause