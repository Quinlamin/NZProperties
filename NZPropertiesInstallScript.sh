#!/bin/bash
if [[ $UID != 0 ]]; then
    echo "Please run this script with sudo:"
    echo "sudo $0 $*"
    exit 1
fi
echo "Installing Dotnet Runtime..."
sudo dnf install -y -q dotnet-runtime-10.0
echo "Installing ASPNETCORE Runtime..."
sudo dnf install -y -q aspnetcore-runtime-10.0
echo "Installing Firefox..."
sudo dnf install -y -q firefox
echo "Downloading NZProperties from github..."
sudo wget https://github.com/Quinlamin/NZProperties/releases/download/Web-1.0.1/PropertyFrontend.1
mkdir NZProperties
unzip PropertyFrontend.1.0.1.linux-x86.zip -d NZProperties
chmod -R +x NZProperties
echo "Installation Complete"