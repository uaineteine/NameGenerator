# NameGenerator

A C# name generator library that returns either town names, place names or prefix titles based on CSV documents supplied.

## Getting Started

Compling yourself: Use Visual Studio and the project file to create either a new project to be modified or add to a solution for use as a DLL.

### Requires:

This project is target for .NET standard 2.0. It should be compliant with earlier versions of course, however when compiling with VS, one will have to change the project settings.

### Built With

* [CSVHandler](https://bitbucket.org/uaineteinestudio/csvhandler) by [UaineTeine](https://bitbucket.org/uaineteinestudio/) - The CSV reader required to import the namelists from which to generate a full name randomly

### Installing

##### Building with Windows:

Use Visual Studio to build the project file into an executable, deploy to the working directory of any future project you are making.

##### Building with Linux:

Open terminal/cmd and use .NET core to build with:

```
dotnet publish -c release -r ubuntu.16.04-x64 --self-contained
```

For either platform the built app into your working directory. Git creditional storing is required in that project folder. Set with:
```
git config credential.helper store
```

## Authors

* **Daniel Stamer-Squair** - *UaineTeine*

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details