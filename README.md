# poy-template-mod
![Code size](https://img.shields.io/github/languages/code-size/Kaden5480/poy-template-mod?color=5c85d6)
![Open issues](https://img.shields.io/github/issues/Kaden5480/poy-template-mod?color=d65c5c)
![License](https://img.shields.io/github/license/Kaden5480/poy-template-mod?color=a35cd6)

A template mod for
[Peaks of Yore](https://store.steampowered.com/app/2236070/).

# Overview
- [Features](#features)
- [Installing](#installing)
    - [BepInEx](#bepinex)
    - [MelonLoader](#melonloader)
- [Building from source](#building-from-source)
    - [Dotnet](#dotnet-build)
    - [Visual Studio](#visual-studio-build)
    - [Custom game locations](#custom-game-locations)

# Features
This is just a template.

# Installing
## BepInEx
### Installing BepInEx
- Download the latest stable win_x64 version of BepInEx
[here](https://github.com/BepInEx/BepInEx/releases).
- Find the Peaks of Yore game directory, this is most easily done by going to the game in steam,
  pressing the settings for the game (⚙️), selecting "Manage", then "Browse local files".
- Extract the contents of `BepInEx_win_x64_<version>.zip` into your Peaks of Yore game directory.
- You should now have files/directories such as `BepInEx` and `winhttp.dll`
  in the same place as `Peaks of Yore.exe` and `UnityPlayer.dll`.
- Start the game so BepInEx can generate other necessary files for modding.
- Close the game.

### Installing this mod
- Download the latest BepInEx release
[here](https://github.com/Kaden5480/poy-template-mod/releases).
- The compressed zip will contain a `patchers` and `plugins` directory.
- Copy the files in `patchers` to `BepInEx/patchers` in your game directory.
- Copy the files in `plugins` to `BepInEx/plugins` in your game directory.

## MelonLoader
### MLPatcherPlugin
Follow the install instructions for MLPatcherPlugin, if you haven't installed already:<br>
https://github.com/Kaden5480/ml-patcher-plugin

### This mod
- Download the latest release
[here](https://github.com/Kaden5480/poy-template-mod/releases).
- The compressed zip file will contain a `Mods` and `Plugins` directory.
- Copy the files from `Mods` to `Mods` in your game directory.
- Copy the files from `Plugins` to `Plugins` in your game directory.

# Building from source
Whichever approach you use for building from source, the resulting
patcher and plugin can be found in `bin/`.

The following configurations are supported:
- Debug-BepInEx
- Release-BepInEx
- Debug-MelonLoader
- Release-MelonLoader

## Dotnet build
To build with dotnet, run the following command, replacing
<configuration> with the desired value:
```sh
dotnet build -c <configuration>
```

## Visual Studio build
To build with Visual Studio, open TemplateMod.sln and build by pressing ctrl + shift + b,
or by selecting Build -> Build Solution.

## Custom game locations
If you installed Peaks of Yore in a custom game location, you may require
an extra file to configure the build so it knows where to find the Peaks of Yore game
libraries.

The file must be in the root of this repository and must be called "GamePath.props".

Below gives an example where Peaks of Yore is installed on the F drive:
```xml
<Project>
  <PropertyGroup>
    <GamePath>F:\Games\Peaks of Yore</GamePath>
  </PropertyGroup>
</Project>
```
