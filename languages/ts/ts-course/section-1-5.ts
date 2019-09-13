// Strings
let myName: string = "Kostya";

// Numbers
let myAge: number = 28;

// Tuples
let tupleSample: [string, number] = ["Hello", 1];

// Enum
enum Color {
  Gray, // 0
  Green, // 1 Green = 100, => 101. Increment doesn't stop
  Blue // 2
}

let myColor: Color = Color.Gray;

// Functions
function returnMyName(): string {
  return myName;
}

// Function void
function printMyName(): void {
  console.log(myName);
}

// Argument types
function Multiply(value1: number, value2: number): number {
  return value1 * value2;
}

// Function types
let myFunction: (v1: number, v2: number) => number = Multiply;

// Object type
let userData: { name: string; age: number } = {
  name: "Kostya",
  age: 23
};

// Complex object and type aliases
type Complex = { data: number[]; output: (all: boolean) => number[] };

let complex: Complex = {
  data: [100, 3.99, 1],
  output: function(all: boolean): number[] {
    return this.data;
  }
};

// Union types
let myRealRealAge: string | number = "23";
myRealRealAge = 23;

// Check types
let finalString = "A string";

if (typeof finalString === "string") {
  console.log("this is a string");
}

// Never
function error(message: string): never {
  throw new Error(message);
}

// Arrow functions
const greet = () => {
  console.log("Hello!");
};

const greetFriend = friend => console.log(friend);

// Default Parameters
console.log("DEFAULT PARAMETERS");

const countDown = (start: number = 10): void => {
  while (start > 0) {
    start--;
  }

  console.log("Done!", start);
};

countDown();

console.log("REST & SPREAD");

const numbers = [1, 10, 99, -5];
console.log(Math.max(1, 10, 99, -5));
// Spread
console.log(Math.max(...numbers));

// Rest
function makeArray(...args: number[]) {
  return args;
}

console.log(makeArray(1, 2));

// Destructuring arrays
console.log("Destructuring");

const myHobbies = ["Cooking", "Sport"];
// const hobby1 = myHobbies[0];
// const hobby2 = myHobbies[1];

const [hobby1, hobby2] = myHobbies;

console.log(myHobbies[0], myHobbies[1]);

// Destructuring objects
const userData1 = { userName: "Kostya", age: 23 };
const { userName: theName, age: theAge } = userData1;

// Template Literals
const greeting = `This is a heading!
I'm ${theName}.
This is cool!`;
