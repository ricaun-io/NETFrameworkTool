# NETFrameworkTool

[![Visual Studio 2022](https://img.shields.io/badge/Visual%20Studio-2022-blue)](../..)
[![Nuke](https://img.shields.io/badge/Nuke-Build-blue)](https://nuke.build/)
[![License MIT](https://img.shields.io/badge/License-MIT-blue.svg)](LICENSE)
[![Build](../../actions/workflows/Build.yml/badge.svg)](../../actions)

Tool to install/unistall Microsoft .NET Frameworks references assemblies. 

The references assemblies are downloaded from the Nuget package [Microsoft.NETFramework.ReferenceAssemblies](https://www.nuget.org/packages?q=Microsoft.NETFramework.ReferenceAssemblies) and copy to the Reference Assemblies Microsoft folder.

## Install Tool
```bash
dotnet tool install --global NETFrameworkTool
```

## Tool Commands
### List
The command `-l` or `--list` is used to show the .NET Framework versions installed and available.
```bash
NETFrameworkTool --list
```
Example output:
```
NETFrameworkTool available:
  .NETFramework 4.0     Installed
  .NETFramework 4.5     Installed
  .NETFramework 4.5.1
  .NETFramework 4.5.2
  .NETFramework 4.6     Installed
  .NETFramework 4.6.1
  .NETFramework 4.7     Installed
  .NETFramework 4.7.2   Installed
  .NETFramework 4.8     Installed
```
### Net
The command `-n` or `--net` is used to specify the .NET Framework version to install/unistall.
```bash
NETFrameworkTool --net 4.0
```
### Install
The command `-i` or `--install` is used to install the .NET Framework version. *(Administrator Permission Required)*
```bash
NETFrameworkTool --net 4.0 --install
```
### Uninstall
The command `-u` or `--uninstall` is used to uninstall the .NET Framework version. *(Administrator Permission Required)*
```bash
NETFrameworkTool --net 4.0 --uninstall
```
### Force Reinstall
The command `-f` or `--force` is used to force to reinstall the .NET Framework version. *(Administrator Permission Required)*
```bash
NETFrameworkTool --net 4.0 --install --force
```
### Help
The command `-help` is used to show the help.
```bash
NETFrameworkTool --help
```

## Release

* [Latest release](../../releases/latest)

## License

This project is [licensed](LICENSE) under the [MIT License](https://en.wikipedia.org/wiki/MIT_License).

---

Do you like this project? Please [star this project on GitHub](../../stargazers)!