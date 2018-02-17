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

## Conditions
- Idiomatic to return an error as the last return from functions and methods;
- nil value indicates success;
- error checking via if. No monads or staff like that;

## Arrays and slices
- Slice is part of array; It's a reference to array items;
- Making a slice doesn't return a new object; It's part of array;
- Always use slice in your code; It has flexible length and it's more convenient;

## Maps
- Maps are unordered collection;
- Maps are key-value pairs - it's a just hashtable;
- Syntax of map declaration: `map[keyType]valueType`;
- Go iterates maps randomly in `for range` loop;
- Map is reference type. Same as slices;
- It's unsafe for concurrency;

## Structs
- Struct is custom data type;
- Go doesn't support class, objects and inheritance;

## Concurrency
- Concurrency is creating composition of  independently executing processes, while parallelism is the simultaneous execution of (possibly related) computations. Concurrency is about dealing with lots of things at once. Parallelism is about doing lots of thing at once;
- Goroutine is special thread inside go runtime; It has lighter weight; Less switching (because it's on the level of golang runtime);
- Go implements and actor model;
- Channel is tool for communication of two goroutine.

## Methods
- ```func (p person) updateAge(newAge int)``` updates a new Person struct
- ```func (p *person) updateAge(newAge int)``` updates passed Person struct
