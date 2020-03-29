# Languages

There are 2 characteristics of languages: strong or weak typing and dynamic or static typing

## Typing
- Static/Dynamic Typing is about when type information is acquired (Either at compile time or at runtime)

```js
// Dynamic typing (JS, Python). Type checking during runtime
// Less code, easier to write unit tests but less safety
var x = 10;

// Static typing (C#, C++). Type checking during compilation
// Less bugs, more code, easy documentation
int x = 10;
```

- Strong/Weak Typing is about how strictly types are distinguished (e.g. whether the language tries to do an implicit conversion from strings to numbers

```js
// Week typing
var x = 'a';
x += 1; // returns 'a1'

// Strong typing
string x = "a";
x += 1; // gives an error
```
