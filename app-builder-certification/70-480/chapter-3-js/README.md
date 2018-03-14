# JS notes

```'use strict'``` disables deprecated JS features. 

IE9- ignore such directive and client's code which calls libraries can work incorrectly (Some of libraries are written without 'use strict')

## Lesson 1: Introducing JS

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

```typeOf``` returns a string that corresponds to the name of type

Difference between 'argument' and 'parameter': 
> Arguments represent the values you pass to the function, whereas the parameters represent the values received from the caller.

### Scoping
**Scoping** is the context within a program in which a variable is valid and can be used to access a data.
- for ```var``` variables a scope created by function, not by brackets ```{ }```. A variable is accessible in any part of the scope. It means that a variable A that's above of a variable B can access its value;
- for ```let``` and ```const``` variables a scope created by brackets ```{ }```; A variable is not lifted;
- a nested function has access to the variables of a parent function. It's also called as 'closure'

### Converting to different types
- ```Number``` function converts an object to number;
- ```String``` function converts anything to string.

> Tip: if a variable has a value then it's not false (use if(aVar) instead of if(aVar === null || aVar undefined))

```aVar || "It's a default value that will replace undefined or null"```

JS 'features':
```null == undefined; false == 0; '' == 0; '123' == 123```

```-, /, *``` + string with number => number

```+``` string with number => string

#### ToString
```String(null)``` => ```'null'```

```String(undefined)``` => ```'undefined'```

#### ToNumber
```+'123'``` => ```123```
```+undefined``` => ```NaN```
```+null``` => ```0```
```+true``` => ```````
```+false``` => ```0```
```+'\n 123  '``` => ```123``` and ```+'\n 123x  '``` => ```NaN```

Comparing different types is equal transforming to a Number:
```"1" == true``` => ```true```

```NaN == null```

### Loops

- ```while``` is used when you have a conditional expression that indicates when the loop should stop;
- ```do\while``` is used in the same way as 'while' AND when you need to execute it at least once;
- ```for``` is used when you know length of a collection and you need to iterate through it.

## Lesson 2: Debugging JS

> The <script> element can define a JavaScript code block or load an external JavaScript file, but not both.
```<script src="some-script.js" />``` or ```<script></script>``` but not both.

```<script async>``` - the script is executed asynchronously while the page continues the parsing.

```<script defer>``` - the script is executed after the page has finished parsing.

```<noscript>The text</noscript>``` is shown when a browser doesn't support JS.

> Tip: 
> For best performance, place the <script> elements at the bottom of the HTML document, before the </body> tag

## Lesson 3: Working with objects

### Creating array

Creating and populating array 
- inserting with the index: ```const arr = new Array(); arr[0] = 1;```  and etc;
- inserting via ctor: ```const arr = new Array(1, 2, 3)```;
- literal array: ```const arr = [1, 2, 3]```;

### Array functions

- ```pop()``` returns the last item and removes it from the array;
- ```push()``` returns new length and adds new item to the end of an array;

## Troubleshooting 

- JS string are immutable;
- the ```-``` casts string to numbers;
- ```navigator``` allows to check which browser is used by a user;