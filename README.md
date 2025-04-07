# PygmyModManager
PygmyModManager is a fast and simple mod manager for Gorilla Tag (or most BepInEx-based games) that reads from MonkeModManager info lists.
It is pretty configurable and comes with a couple baked in tools:

- **Text Editor**: Mostly used for editing mod configs
- **Source Manager**: You can change what and how many sources you want. You can add custom lists of mods.

## Install
### From Releases
Download the latest relase from [here](https://github.com/sirkingbinx/PygmyModManager/releases/latest).
### From Source
- Requires Visual Studio 2022
Download source from latest release or from the master branch and build it with ``dotnet build``.

## Settings
### Sources
- **Sources / All Sources**: A checklist of all the sources you have added. Uncheck any you don't want and click ``Close`` to remove them.
- **Sources / Add**: Adds a source of your choice to the list.
- **Sources / Load Mods on Startup**: You can remove loading the mods on startup if you want.

### Gorilla Tag
- **Gorilla Tag / Prefered Install**: Choose which version of Gorilla Tag you want to use.
- **Gorilla Tag / Path**: The current path the game is using.

### Appearance
- **Appearance / Display Name**: Replaces `PygmyModManager` in the titlebar, about page, and most other places it shows up.
