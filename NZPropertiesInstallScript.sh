#!/bin/bash
set -euo pipefail

if [[ $EUID -ne 0 ]]; then
    echo "Please run this script with sudo:"
    echo "sudo bash $0"
    exit 1
fi

echo "Installing .NET Runtime..."
dnf install -y dotnet-runtime-10.0

echo "Installing ASP.NET Core Runtime..."
dnf install -y aspnetcore-runtime-10.0

echo "Installing Firefox..."
dnf install -y firefox

echo "Downloading NZProperties from GitHub..."
mkdir -p NZProperties
cd NZProperties

wget -O PropertyFrontend.zip \
  https://github.com/Quinlamin/NZProperties/releases/download/Web-1.0.1/PropertyFrontend.1.0.1.linux-x86.zip

echo "Extracting NZProperties..."
unzip PropertyFrontend.zip
chmod -R +x .

echo "Installation complete."
