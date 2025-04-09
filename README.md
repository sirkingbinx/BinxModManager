# Binx's Mod Manager
Binx's Mod Manager is a fast and simple mod manager for Gorilla Tag (or most BepInEx-based games) that reads from MonkeModManager info lists.
It is pretty configurable and comes with a couple baked in tools:

- **Text Editor**: Mostly used for editing mod configs
- **Source Manager**: You can change what and how many sources you want. You can add custom lists of mods.

It also uses the GitHub API to get the latest release of any mod, so nobody has to update a list for your mod for it to update :+1:

> [!NOTE]
> Based on docs found [here](https://docs.github.com/en/rest/releases/releases?apiVersion=2022-11-28). Works given you provide a ``git_path`` in your release info.

## Install
### From Releases
Download the latest relase from [here](https://github.com/sirkingbinx/BinxModManager/releases/latest).
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
- **Appearance / Display Name**: Replaces `Binx's Mod Manager` in the titlebar, about page, and most other places it shows up.

## List Creation Guide
Here is a base for a bunch of mods. Source parsing requires all of these, see the next example for optional items you can add.
```json
[
    {
        "name": "Mod",
        "author": "Author",
        "group": "Mod", // can be anything, it will be created when adding mods

        // you MUST have either git_path, link, or both. when it sees git_path, it will prefer it at all times
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
