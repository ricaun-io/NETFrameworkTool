# NETFrameworkTool

[![Visual Studio 2022](https://img.shields.io/badge/Visual%20Studio-2022-blue)](../..)
[![Nuke](https://img.shields.io/badge/Nuke-Build-blue)](https://nuke.build/)
[![License MIT](https://img.shields.io/badge/License-MIT-blue.svg)](LICENSE)
[![Build](../../actions/workflows/Build.yml/badge.svg)](../../actions)

## Create a tool

This project is a sample based in the [Tutorial: Create a .NET tool using the .NET CLI](https://learn.microsoft.com/en-us/dotnet/core/tools/global-tools-how-to-create).

### Info Global Tool

```bash
dotnet tool list --global
```

or 

```bash
dotnet tool list -g
```

### Install Global Tool

```bash
dotnet tool install --global --add-source ./bin/Release NETFrameworkTool --version *-*
```

or

```bash
dotnet tool install --global NETFrameworkTool --version *-*
```

### Uninstall Global Tool
```bash
dotnet tool uninstall --global NETFrameworkTool
```

## Execute Tool
```bash
NETFrameworkTool
```
or
```bash
NETFrameworkTool -n 4.0
```

## Release

* [Latest release](../../releases/latest)

## License

This project is [licensed](LICENSE) under the [MIT License](https://en.wikipedia.org/wiki/MIT_License).

---

Do you like this project? Please [star this project on GitHub](../../stargazers)!