dotnet test --collect:"Xplat Code Coverage"

reportgenerator -reports:"../**/coverage.cobertura.xml" -targetdir:"./coverage_report" -reporttypes:"html"

start coverage_report/index.html

pause