<!--
  260910_code
  260617_documentation
-->

[❰ Back to DVN repository](../../README.md)

<div align="center">

  <img src="../../.github/logo/dvn-Logo-384x184.png" alt="Tingen Web Service">

  ![RELEASE](https://img.shields.io/badge/version-1.3-teal)&nbsp;

  <h1>Manual</h1>

</div>

---

| CONTENTS                                |
|-----------------------------------------|
| [About DVN](#about-dvn)                 |
| [Installing](#installing)               |
| [Configuring](#configuring)             |
| [The manifest file](#the-manifest-file) |
| [Usage](#usage)                         |

# About DVN

**DVN** is a command-line utility for managing development environments.

# Installing

> [!IMPORTANT]
> DVN requires the [.NET 10 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/10.0)!

**DVN** is a portable application, so "installing" is simple:

1. Download the [latest release](https://github.com/APrettyCoolProgram/dvn/releases).
2. Extract the contents of the downloaded file to a folder of your choice.

You'll notice that the folder you extracted to contains a single item: `dvn.exe`

## Creating the DVN framework

The **DVN *framework*** is comprised of the files and folders that are required by **DVN**. This framework doesn't exist yet, so we need to create it.

To create the **DVN** framework:

1. Open a terminal in the the folder that contains `dvn.exe`
2. Type

```bash
$ dvn
```

Since this is the first time you are executing **DVN**, you will see a message letting you know that the **DVN framework** will be created.

# Configuring

The `.\.dvn\configs\dvn.config` file contains the configuration settings for **DVN**.

Currently this file only contains a list of files and folders that are ignored when the data backup functionality is enabled (to keep file sizes are kept to a minimum), so there isn't much to configure.

# The manifest file

When you start an environment by typing...

```bash
$ dvn myproj
```

...**DVN** looks for a manifest file named `.\.dvn\mnfst\myproj.mnfst`, which contains all of the information **DVN** needs to start the environment.

If the file does not exist, it is created using the default settings, which you will need to modify.

> [!IMPORTANT]
> Any `\` characters need to be escaped as `\\`!

## The default manifest

When a new manifest file is created, it looks like this:

```json
{
  "DevelopmentEnvironment": {
    "Name": "myproj",
    "Description": "The MyProject project.",
    "BackupEnabled": false,
    "BackupSources": null,
    "BackupLocation": null
  },
  "EnvironmentApplications": [
    {
      "Name": null,
      "Description": null,
      "FileName": null,
      "Arguments": null,
      "WorkingDirectory": null
    }
  ],
  "WebBrowser": {
    "BrowserPages": {
      "Chrome": {},
      "IExplore": {},
      "Firefox": {}
    }
  }
}
```

## Manifest components

Manifest files contain the following components:

* `Name`  
The name of the environment (e.g., "myproj").

* `Description`  
The description of the environment (e.g., "The MyProject project").

* `BackupEnabled`  
Determines if the data backup functionality is *enabled* ("true"), or *disabled* ("false").

* `BackupSources`  
Absolute paths to data that will be backed up, if the data backup functionality is enabled.  

* `BackupLocation`  
The absolute path where backups are created.

* `EnvironmentApplication`  
Each application that will be launched by **DVN** has it's own block with the following data:

  * `Name`  
  The name of the application

  * `Description`  
  Description of the application

  * `FileName`  
  The application file name

  * `Arguments`  
  Any command-line arguments

  * `WorkingDirectory`  
  The application working directory

* `WebBrowser`  
A list of webpages to be opened in specific web browsers

## A completed manifest file

This is what a completed manifest file looks like:

```json
{
  "DevelopmentEnvironment": {
    "Name": "myproj",
    "Description": "The MyProject project",
    "BackupEnabled": true,
    "BackupSources": [
      "C:\\repositories\\MyProject",
      "C:\\data\\reports"
    ],
    "BackupLocation": "C:\\backups",
  },
  "EnvironmentApplications": [
    {
      "Name": "Visual Studio - MyProject",
      "Description": "MyProject solution",
      "FileName": "MyProject.sln",
      "Arguments": null,
      "WorkingDirectory": "C:\\repositories\\MyProject\\src"
    },
    {
    "Name": "Visual Studio Code - MyProject documentation",
    "Description": "MyProject documentation",
    "FileName": "Code.exe",
    "Arguments": "MyProject-documentation.code-workspace | exit /b",
    "WorkingDirectory": "\\path\\to\\VisualStudioCode"
    },
    {
    "Name": "Visual Studio Code - Other documentation",
    "Description": "Other documentation",
    "FileName": "Code.exe",
    "Arguments": "Other-documentation.code-workspace | exit /b",
    "WorkingDirectory": "\\path\\to\\VisualStudioCode"
    },
    {
      "Name": "GitHub Desktop",
      "Description": "GitHub Desktop",
      "FileName": "GitHubDesktop.exe",
      "Arguments": null,
      "WorkingDirectory": "C:\\Users\\JaneSmith\\AppData\\Local\\GitHubDesktop"
    }
  ],
  "WebBrowser":
  {
    "BrowserPages":
    {
	  "Chrome":
      {
        "Wikipedia": "https://www.google.com",
        "Weather.com": "https://www.weather.com"
      },
	  "Firefox":
      {
	      "Firefox": "https://www.firefox.com",
        "Wikipedia": "https://www.wikipedia.com"
      },
      "IExplore":
      {
        "Microsoft": "https://www.microsoft.com",
		    "Xbox": "https://xbox.com"
      }
    }
  }
}
```

The above manifest file will:

1. Start the "**myproj**" development environment
2. Backup the "**C:\repositories\MyProject**" and "**C:\data\reports**" to "**C:\backups**"
3. Start the "**MyProject**" solution in Visual Studio
4. Start the "**MyProject-Documentation**" workspace in Visual Studio Code
5. Start the "**Other-Documentation**" workspace in Visual Studio Code
6. Start the "**GitHub Desktop**" application
7. Open various web pages in various web browsers

# Usage

This is the **DVN** syntax:

```bash
dvn <command> [-option01 -option02 ...]
```

## Commands

**DVN** *requires* that you pass a valid `command`.

In general, you'll use the `%environment%` command, which will start the specified development environment (or create a blank [manifest file](#the-manifest-file), if one doesn't exist).

For example, to start/create the `myproj` environment, you would type:

```bash
$ dvn myproj
```

To get a list of valid commands, type:

```bash
$ dvn help
```

## Options

**DVN** also accepts `options`, which are...optional

Options:

* Must be a single character
* Start with the `-` (dash) character
* Are separated by a space

For example, you can force the data for the `myproj` environment to be backed up by typing:

```bash
$ dvn myproj -b
```

To get a list of valid options, type:

```bash
$ dvn help
```

***

[❰ Back to DVN repository](../../README.md)
