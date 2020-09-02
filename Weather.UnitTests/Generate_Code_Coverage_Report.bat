dotnet tool install -g dotnet-reportgenerator-globaltool

dotnet test ../Weather.sln /p:CollectCoverage=true /p:CoverletOutputFormat=cobertura /p:CoverletOutput="TestResults\\Coverage\\Weather"

reportgenerator "-reports:TestResults\Coverage\Weather.cobertura.xml" "-targetdir:TestResults\Coverage" -reporttypes:HTML

start TestResults\Coverage\index.htm
PAUSE