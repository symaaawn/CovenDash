#!/bin/bash

set -e

APP_NAME="CovenDash"
PROJECT_DIR="$(pwd)"
INSTALL_DIR="$HOME/.local/bin"
BINARY_DEST="$INSTALL_DIR/$APP_NAME"

echo "Building $APP_NAME in Release mode..."
dotnet publish "$PROJECT_DIR" -c Release -r linux-x64 --self-contained true \
    -p:PublishSingleFile=true -p:PublishTrimmed=true

PUBLISH_DIR="$PROJECT_DIR/bin/Release/net10.0/linux-x64/publish"
BINARY_SRC="$PUBLISH_DIR/$APP_NAME"

if [ ! -f "$BINARY_SRC" ]; then
    echo "Error: Binary not found at $BINARY_SRC"
    exit 1
fi

mkdir -p "$INSTALL_DIR"

cp "$BINARY_SRC" "$BINARY_DEST"
chmod +x "$BINARY_DEST"

echo "Binary installiert unter $BINARY_DEST"

if [ -n "$ZSH_VERSION" ]; then
    SHELL_RC="$HOME/.zshrc"
else
    SHELL_RC="$HOME/.bashrc"
fi

sed -i '/CovenDash/d' "$SHELL_RC"

grep -qxF "$BINARY_DEST" "$SHELL_RC" || echo "$BINARY_DEST" >> "$SHELL_RC"

echo "Startup-Hook in $SHELL_RC gesetzt. Das Dashboard startet nun bei jedem Terminalstart."
