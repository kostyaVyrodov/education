# Go

Notes about Go lang. Based on 'go-fundamentals' course.

Go is created in Google by Robert Griesemer, Rob Pike and Ken Thompson. It's open-source language. 
Work was started 2007 and first release was in 2009. The language was designed for low-level stuff, like development OS and so on.

The language has about 25 keywords ant it's compiled language without virtual runtime environment.

## Project structure

The Go need 3 specific folders for storing source code, packages, and any compiled binaries.

`package main` tells that code is executable module, not a shared library

## Constants and variables

- Go passes arguments by value. Arguments of functions are copied;
- & gets memory address;
- * gets value of memory address;
- = assign a value to an existing variable;
- := init a new value;
- module 'os' allows set and get environment variables;
- Go supports type inference;
- const, var - on module level;
- := - on function level
