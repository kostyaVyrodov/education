# JS language notes

Note written basing on [Advanced JavaScript Concepts course](https://www.udemy.com/advanced-javascript-concepts)

## JavaScript environment foundation

**JS engine**

JS is interpreting and single threading languages using callbacks. JS engine is a mechanism that understands JS and tells PC what to do (similar to CLR). There are a lot of JS engines (ECMAScript engines). 

For example: 
- Chrome V8 engine is a JS engine developed by The Chromium Project for Google Chrome and Chromium browser. Also Node.JS uses Chrome V8 engine. V8 engine doesn't generate any intermediate code and compiles JS directly into machine code
- SpiderMonkey is developed by Brendan Eich and currently used by FireFox. This's the very first JS engine

ECMA is European Computer Manufacturer's Association is a non-profit organization that develops standards. 

The difference between ECMA script and JS is that JS is an implementation of the ECMAScript standard. For example ECMA Standard is standard for JavaScript (Netscape) and JScript (Microsoft)

Under the hood of JS engine does following:
1. JS file as input
1. Parser breaks the JS code on tokens. Each token explains what code trying to do
1. AST (astexplorer.net allows to see how JS is transformed into AST)
1. Interpreter () -> bytecode that can be executed by PC
1. Profiler takes bytecode and checks how it runs and finds ways to optimize it
1. Compiler
1. Optimized code

![Under the hood of JS engin](./images/V8-schema.png)

Babel + TS: Babel is compiler of js that takes modern js and translates it to a browser compatible JS

Compiler vs Interpreter:
- Interpreter allows to start executing of code faster but it becomes slow when it runs a lot of code
- Compiler can do optimizations so many lines of code is not a problem for compiler but it requires some time to execute program

JIT compiler is combination of compiler and interpreter and it provides cons from both compiler and interpreter worlds

Dangerous mechanisms\functions that my hurt performance of JS app:
- eval()
- arguments
- for in
- with
- delete
- hidden classes. A technique used by V8 to identify a type of objects. If you add a new property to a JS object then you V8 produces a new hidden class. Too many new properties for existing types = new hidden = worse performance;
- inline caching. Inline Cache can be treated as a fast path (shortcut) to the value/property

WebAssembly is standard binary executable format. It's a bytecode that can run on browsers. Many languages including C++ can be compiled to Web assembly.

Execution context is an abstract concept that holds information about the environment within which the current code is being executed.

Memory leaks: 
- Global variables;
- Adding new eventListeners without removing them;
- Using setInterval without clearing;

### JS garbage collector

JScript uses a nongenerational mark-and-sweep garbage collector. It works like this:

- Every variable which is "in scope" is called a "scavenger". A scavenger may refer to a number, an object, a string, whatever. We maintain a list of scavengers -- variables are moved on to the scav list when they come into scope and off the scav list when they go out of scope.
- Every now and then the garbage collector runs. First it puts a "mark" on every object, variable, string, etc – all the memory tracked by the GC. (JScript uses the VARIANT data structure internally and there are plenty of extra unused bits in that structure, so we just set one of them.)
- Second, it clears the mark on the scavengers and the transitive closure of scavenger references. So if a scavenger object references a nonscavenger object then we clear the bits on the nonscavenger, and on everything that it refers to. (I am using the word "closure" in a different sense than in my earlier post.)
- At this point we know that all the memory still marked is allocated memory which cannot be reached by any path from any in-scope variable. All of those objects are instructed to tear themselves down, which destroys any circular references.

### JS runtime and engine

JS is single threaded programming language. All single threaded programs have only one call stack. Also JS is synchronous.

JS runtime consists of:
- JS engine;
- Web browser API (DOM, fetch(), setTimeout());
- Event Loop with callback queue;

Event loop pushes callbacks to queue only when the main flow has been executed

![JS runtime](./images/js-runtime.png)

Runtime VS Engine:
- JS file is musician notes
- JS engine is a musician
- JS runtime is a musician + notes + a lot of other instruments

![JS engine vs runtime](./images/js-runtime-vs-engine.png)

Node.JS is js runtime

Example of runtime:

![Node.JS engine vs runtime](./images/nodejs-runtime.png)

Node.JS has a global API

## JavaScript executing environment

**Execution context**

Execution context is created for each method invocation. Initially JS creates a global execution context. All JS code is run in execution context

When JS creates a global execution context it gives you a global object and `this`. In browser global object is `window`. `window` === `this` is true. When a developer assigns a variable, the variable becomes a property of global object.

```js
var example = 'kostya';

window.example -> 'kostya'
```

The call stack is a collection of execution contexts. Execution context is kind of 'environment' of a function

![Global execution context](./images/global-execution-context.png)

**Lexical environment (scope)**

Lexical environment is where you write something. The term is related to compiling time where execution context is related to runtime.

Lexical environment vs Execution context:

- Execution contexts contain the current evaluation state of code, a reference to the code (function) itself, and possibly references to the current lexical environments.
- Execution contexts are managed in a stack.
- Lexical environments contain an environment record in which the variables are stored, and a reference to their parent environment (if any).
- Lexical environments build a tree structure.

Execution context tells which lexical environment is currently running

Lexical scope (available data + variables where the function was defined) determines our available variables. Not where the function is called (dynamic scope)

**Hoisting**

Hoisting is the behavior of moving the declarations of variables or functions to the top of their respective environments during compilation. It means that JS engine goes through file and allocates memory first for all resource. By default variables (with var keyword) are hoisted to the top of execution environment

![Execution context with hoisting](./images/execution-context-with-hoisting.png)

```js
console.log('1------');
// var teddy = undefined;
console.log(teddy);
var teddy = 'bear';
console.log(sing());
function sing() { // Functions are completely hoisted
    console.log('oh la la la');
}
```

No hoisting

```js
console.log('1------');
const teddy = 'bear'; // const or let is special ES syntax avoiding hoisting
(function sing() {    // () 
    console.log('oh la la la');
})
```

```js
// function expression
var x = function() { }

// function declaration
function t() { }
```

```js
var favoriteFood = 'grapes';

var foodThoughts = function() {
    console.log("original favorite food: " + favoriteFood);
    var favoriteFood = "sushi";
    console.log("new favorite food: " + favoriteFood);
}

foodThoughts();

// Output:
// original favorite food: undefined
// new favorite food: sushi 
```

**Function invocation**

Each function invocation creates an execution context with `this` and `arguments`. `arguments` is an object where key is number of parameter and a value is the value itself: `{ 0: 'hello' }`

```js
function helloWorld() { 
    console.log('hello world'); 
}

helloWorld() // new execution context

// arguments
function merry(person1, person2) {
    console.log(arguments) // -> { 0: person1Value, 1: person2Value }
    // How to get an array of arguments?
    // var args = Array.from(arguments);
    console.log(`${person1} marries ${person2}`);
}

// How to get an array of arguments?
function merry1(...args) {
    console.log(`${args[0]} marries ${args[1]}`);
}
```

Each function invocation creates an own variable environment. So variables from previous environments are not visible 

## FAQ

**What is 'use strict'?**

The "use strict" directive was new in ECMAScript version 5. It is not a statement, but a literal expression, ignored by earlier versions of JavaScript. The purpose of "use strict" is to indicate that the code should be executed in "strict mode". With strict mode, you can not, for example, use undeclared variables.

**Where does execution context live?**

Is JS engine or JS runtime? Most likely in JS engine.

**Global execution context vs Function execution context**

Global execution context creates an object with: this and window.

Function execution context creates an object with: this and arguments.
