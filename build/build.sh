#!/usr/bin/env bash

set -xe

cd ../

MOD_NAME="TemplateMod"
VERSION="$(git describe --abbrev=0 | tr -d  "v")"

BP_NAME="$MOD_NAME-$VERSION-BepInEx"
ML_NAME="$MOD_NAME-$VERSION-MelonLoader"
BP_DIR="build/$BP_NAME"
ML_DIR="build/$ML_NAME"


dotnet build -c Release-BepInEx
dotnet build -c Release-MelonLoader

mkdir -p "$BP_DIR"/{patchers,plugins}
mkdir -p "$ML_DIR"/{Mods,Plugins}

# BepInEx
cp bin/patcher/release-bepinex/net472/${MOD_NAME}Patcher.dll \
    "$BP_DIR/patchers/"
cp bin/plugin/release-bepinex/net472/${MOD_NAME}Plugin.dll \
    "$BP_DIR/plugins/"
cp build/README-BepInEx.txt "$BP_DIR/README.txt"

# MelonLoader
cp bin/patcher/release-melonloader/net472/${MOD_NAME}Patcher.dll \
    "$ML_DIR/Plugins/"
cp bin/plugin/release-melonloader/net472/${MOD_NAME}Plugin.dll \
    "$ML_DIR/Mods/"
cp build/README-MelonLoader.txt "$ML_DIR/README.txt"

# Zip everything
pushd "$BP_DIR"
zip -r ../"$BP_NAME.zip" .
popd

pushd "$ML_DIR"
zip -r ../"$ML_NAME.zip" .
popd

# Remove directories
rm -rf "$BP_DIR" "$ML_DIR"
