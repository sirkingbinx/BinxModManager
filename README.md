# Binx's Mod Manager ![downloads](https://img.shields.io/github/downloads/sirkingbinx/BinxModManager/total)
This is my own personal mod manager thing that reads from MonkeModManager info lists.
It is pretty configurable and comes with a couple baked in tools:

- **Text Editor**: Mostly used for editing mod configs, but can also edit the text++ config files that I use
- **Source Manager**: You can change what and how many sources you want. You can add custom lists of mods.

It also uses the GitHub API to get the latest release of any mod, so nobody has to update a list for your mod for it to update :+1:

> [!NOTE]
> Updating from github is based on docs found [here](https://docs.github.com/en/rest/releases/releases?apiVersion=2022-11-28). Works given you provide a ``git_path`` in your release info.

## Install
### From Releases
Download the latest release from [here](https://github.com/sirkingbinx/BinxModManager/releases/latest).
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
Here is a base for a bunch of mods. You can choose to add either a ``git_path`` or a ``link``, you must have at least one of them.
```json
[
    {
        "name": "Mod",
        "author": "Author",
        "group": "Mod", // can be anything, it will be created when adding mods

        // use one of these two (one or the other)
        "git_path": "user/repo", // git repo for source code
        // NOTE: IF YOU HAVE MULTIPLE GIT RELEASES, IT WILL CHOOSE THE FIRST DLL!
        // If you want it to download a specific one, set "link" instead and remove "git_path".

        "link": "https://github.com/user/repo/releases/myfile.dll" // link to download latest release (the .dll itself, not the release page)
    }
]
```

It is based on the MMM `ReleaseInfo` class but slightly modified to remove stuff it doesn't actually need.
