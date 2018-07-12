# dmcldll
DMCL .NET Integration for Documentum 

## Synopsis

This is a simple .NET Documentum DMCL Library that you can still use for accessing Documentum in a simple way from .NET.  The basis of DFC is DMCL a simple API scheme to acesss a Docbase.  This is a reference model https://robineast.files.wordpress.com/2007/02/dctm_tech_stack.GIF

You can also use Mono - but the project is VS 2017.   Mono can then be ported to Unix platforms.


## Code Example

There is a working example included however the basics are based on the Documentum API calls of 

APIGet
APIExec
APIGet
APISet

You can call these from .NET code - most popular is something like C#

The usage is based on how these calls are used natively - for example if you are using C++ then by binding in the correct Documentum library - you can call them.  Its the same idea for .NET - or any managed code.  

The simplest form is the docbase map which is usually called to see what Docbases are available

DMCL newSession = new DMCL(); 

Console.WriteLine("Current Directory : " + System.Environment.CurrentDirectory);
Console.WriteLine("Documentum/C# Integrtation with MONO!");
Console.WriteLine("Init Documentum system");

int resint = DMCL.dmAPIInit();

String map = DMCL.dmAPIGet("getdocbasemap,c");

Console.WriteLine("Map ID {0}", map);

## Motivation

Documentum is generally great but sometimes you just need something thats as FAF

## Installation

The code is a Visual Studio 2013 project - you will need VS.  You will also need the dmcl40.dll - which comes with Documentum for Windows.  

If you want this to work on Unix you will need to use a Unix library version with something like Mono - see this for more info: http://www.mono-project.com/docs/advanced/pinvoke/ - but you should be able to just grab dmcl.cs and modify it with the name of library.

## API Reference

The Documentum DMCL API reference is well published and documented.  Code written for Documentum Docbasic or native libs such as C can be used in the same way

## Tests

Demo code is provided in the VS solution

## License

This is free code - however you much have a licence to use the Documentum software.

  
