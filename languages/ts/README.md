# TypeScript

## Understanding TypeScript

Video course [here](https://www.udemy.com/course/understanding-typescript).

### Types

1. String;
2. Numbers. TS doesn't distinguish difference between int, double and etc;
3. Boolean. TS doesn't allow to set 1 or 0 to a boolean variable;
4. Any. Allows to assign any type to a variable. This is the most flexible type in TS; 
5. Arrays; This is a main collection in TS. There are different npm package that provides other collections;
6. Tuples. Tuple is an array with predefined length and types of every item. Order of an item is very important.
7. Enum;
8. Void. Type that returns a function;
9. Function type. Allows to specify type of a function that can be assigned to a variable;
10. Object type. It's possible to define a type to a single object without defining a class;
11. Union. Allows the same variable to have different types;
12. Never. Means that a function never returns a value. It can throw an exception or work forever;

strictNullChecks allows to prevent setting null to a number. To allow a null to a variable you should use union type.
