@ECHO OFF
dotnet tool uninstall --global NETFrameworkTool
dotnet tool install --global --add-source ./bin/Release NETFrameworkTool --version *-*
timeout 5