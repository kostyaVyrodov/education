# JS notes

## Introducing JS

JS defines a value as an object, function or primitive type.

Primitive types:
- **undefined** is a value that's not assigned,
- **null** means that a value is empty or unknown;
- **boolean** represents a true/false value;
- **number** represents a float/int number (64 bit). NaN is value of a number. It means 'calculation error'. Infinity is also value of a number;
- **string** represent a unicode string.

Build-in object types: 
- global object;
- the Object object;
- the Function object;
- the Array object;
- the String object;
- the RegExp object;
- and other.

Difference between 'argument' and 'parameter': 
> Arguments represent the values you pass to the function, whereas the parameters represent the values received from the caller.

**Scoping** is the context within a program in which a variable is valid and can be used to access a data.
- for ```var``` variables a scope created by function, not by brackets ```{ }```. A variable is accessible in any part of the scope. It means that a variable A that's above of a variable B can access its value;
- for ```let``` and ```const``` variables a scope created by brackets ```{ }```; A variable is not lifted;
