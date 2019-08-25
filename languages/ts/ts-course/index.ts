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

