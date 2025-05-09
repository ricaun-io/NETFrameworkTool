# NETFrameworkTool

[![Visual Studio 2022](https://img.shields.io/badge/Visual%20Studio-2022-blue)](https://github.com/ricaun-io/NETFrameworkTool)
[![Nuke](https://img.shields.io/badge/Nuke-Build-blue)](https://nuke.build/)
[![License MIT](https://img.shields.io/badge/License-MIT-blue.svg)](LICENSE)
[![Build](https://github.com/ricaun-io/NETFrameworkTool/actions/workflows/Build.yml/badge.svg)](https://github.com/ricaun-io/NETFrameworkTool/actions)
[![Release](https://img.shields.io/nuget/v/NETFrameworkTool?logo=nuget&label=release&color=blue)](https://www.nuget.org/packages/NETFrameworkTool)

Tool to install/uninstall Microsoft .NET Frameworks references assemblies. 

The references assemblies are downloaded from the NuGet package [Microsoft.NETFramework.ReferenceAssemblies](https://www.nuget.org/packages?q=Microsoft.NETFramework.ReferenceAssemblies) and copy to the Reference Assemblies Microsoft folder.

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
The command `-n` or `--net` is used to specify the .NET Framework version to install/uninstall.
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

### Github Actions

The `windows-2022` does not have the .NET Framework 4.0 and 4.5 installed by default. 

You can use the `NETFrameworkTool` to install the .NET Framework 4.0 and 4.5.

To use the `NETFrameworkTool` in a GitHub Actions workflow, you can use the following example with [setup-dotnet](https://github.com/actions/setup-dotnet):

```yaml
steps:
- uses: actions/checkout@v4
- uses: actions/setup-dotnet@v4
  with:
    dotnet-version: '8.x'
- run: dotnet tool install --global NETFrameworkTool
- run: NETFrameworkTool --net 4.0 --install
- run: NETFrameworkTool --net 4.5 --install
```

## Release

* [Latest release](https://github.com/ricaun-io/NETFrameworkTool/releases/latest)

## License

This project is [licensed](LICENSE) under the [MIT License](https://en.wikipedia.org/wiki/MIT_License).

---

Do you like this project? Please [star this project on GitHub](https://github.com/ricaun-io/NETFrameworkTool/stargazers)!