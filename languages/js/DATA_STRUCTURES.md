# Built in data structures in JS

## Primitives

All primitives are immutable. All of them are value type

- number - integers, floats
- bigInt - big integer (-2^54 2^54)
- string
- boolean
- null
- symbol - a unique value that's not equal to any other value
- undefined


## Objects

Objects are mutable and can be passed as reference

- Object
- Array
- Function
- String
- RegExp
- Map
- Set

### Object

Instance methods:
- hasOwnProperty('propertyName') - true if object has a property
- isPrototypeOf(obj) - returns true if the type is prototype of object
- isPropertyEnumerable('propertyName') - true if the property enumerable

Class methods:
Object.create(obj) - creates an empty object where 'obj' is prototype

## Proxy and reflect

**Proxy** object is used to define custom behavior for fundamental operations (e.g. property lookup, assignment, enumeration, function invocation, etc).

**Reflect** is a built-in object that provides methods for interceptable JavaScript operations. The methods are the same as those of proxy handlers.

Proxy is a special type that's a wrapper around a `target` object. This wrapper like a decorator that allows to add extra logic for the target object

Traps:
- get
- set
- deleteProperty
- ownKeys

```js
let numbers = [0, 1, 2];

numbers = new Proxy(numbers, {
  get(target, prop) {
    if (prop in target) {
      return target[prop];
    } else {
      return 0; // default value
    }
  }
  set(target, prop, val) { // для перехвата записи свойства
    if (typeof val == 'number') {
      target[prop] = val;
      return true;
    } else {
      return false;
    }
  }
});
```

## Useful things

`typeof` operator returns a string representing name of type. `typeof null` returns 'object'. It's mistake in the language

### Type coercion

```js
// the s is primitive and has no methods or properties
let s = 'a string';

// in this case the js engine creates a temp String object for the primitive
// this allows to use properties of the object
let strLength = s.length;
```

### Tricks

```js
const func = (x, y, z) => {
    y = y || 10; // assign default value with ||

    // use && to do shorter if statement
    z && console.log(x, y, z)

    console.log(x, y);
}

const toNum = +'123';

const toStr = '' + 123;
```

### parseInt, parseFloat vs Number

`parseInt('123asd')` returns `123`

`Number('123asd')` return `NaN`

### Object enhancement

```js
function (x, y, z) {
    return {
        // simplified creation of object is obj enhancement
        x,
        y,
        z
    }
}
```

### Default, rest, spread

```js
// b = 2 is default operator
const aFunc = (a, b = 2) => {
    return a + b; 
}

// ... is rest operator. Converts passed variables into single array with data
const sum = (...numbers) => {
    var result = 0;
    numbers.forEach(function (number) {
        result += number;
    });
    return result;
}

var args = [1, 2];
// spread operator is extracting data
console.log(sum(…args, 3)); 
```
