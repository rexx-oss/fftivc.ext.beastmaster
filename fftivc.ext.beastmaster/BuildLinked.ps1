# Set Working Directory
Split-Path $MyInvocation.MyCommand.Path | Push-Location
[Environment]::CurrentDirectory = $PWD

Remove-Item "$env:RELOADEDIIMODS/fftivc.ext.beastmaster/*" -Force -Recurse
dotnet publish "./fftivc.ext.beastmaster.csproj" -c Release -o "$env:RELOADEDIIMODS/fftivc.ext.beastmaster" /p:OutputPath="./bin/Release" /p:ReloadedILLink="true"

# Restore Working Directory
Pop-Location