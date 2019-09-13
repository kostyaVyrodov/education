# TypeScript

## Understanding TypeScript

Video course [here](https://www.udemy.com/course/understanding-typescript).

### How to run the project
1. Install ts ```$ npm install -g typescript```
1. Compile the project ```$ tsc --target es5 ./index.ts```;
1. Open ```index.html``` in a browser;

### Types

1. String;
1. Numbers. TS doesn't distinguish difference between int, double and etc;
1. Boolean. TS doesn't allow to set 1 or 0 to a boolean variable;
1. Any. Allows to assign any type to a variable. This is the most flexible type in TS; 
1. Arrays; This is a main collection in TS. There are different npm package that provides other collections;
1. Tuples. Tuple is an array with predefined length and types of every item. Order of an item is very important.
1. Enum;
1. Void. Type that returns a function;
1. Function type. Allows to specify type of a function that can be assigned to a variable;
1. Object type. It's possible to define a type to a single object without defining a class;
1. Union. Allows the same variable to have different types;
1. Never. Means that a function never returns a value. It can throw an exception or work forever;

strictNullChecks allows to prevent setting null to a number. To allow a null to a variable you should use union type.

### ES6 Features

1. ```let``` and ```const``` is a declaration of a variable in scope of a block { }. ```var``` is a declaration of a variable in scope of a function;
1. Arrow functions. Arrow functions don't have their own this or arguments binding. These functions can't be called with ```new``` they don't use ```this``` and ```arguments```;

### Classes features

1. Access modifiers: private, public (by default), protected;
1. ```get``` and ```set``` exist;
1. ```static``` properties and methods;
1. ```abstract``` class for defining a base type and not instantiable type;
1. ```readonly``` keyword for a not mutable properties;

### Namespaces and modules
