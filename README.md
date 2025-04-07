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

## List Creation Guide
Here is a base for a bunch of mods. Pygmy requires all of these, see the next example for optional items you can add.
```json
[
    {
        "name": "Mod",
        "author": "Author",
        "group": "Mod", // can be anything, it will be created when adding mods
        "git_path": "user/repo", // git repo for source code
        "link": "https://github.com/user/repo/releases/myfile.dll" // link to download latest release (the .dll itself, not the release page)
    }
]
```

If you need to define a custom place to install the mod or it has dependencies, define them like this.
```json
[
    {
        "name": "Mod",
        "author": "Author",
        "group": "Mod",
        "installLocation": "", // eg. "" = game install folder, "BepInEx/plugins" = plugins folder
        "dependencies": [
            "Utilla"
        ],
        "git_path": "user/repo",
        "link": "https://github.com/user/repo/releases/myfile.dll"
    }
]
```

It is based on the MMM `ReleaseInfo` class but slightly modified to remove stuff it doesn't actually need.