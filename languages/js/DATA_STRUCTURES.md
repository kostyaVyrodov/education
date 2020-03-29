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
