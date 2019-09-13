class Person {
  // Everything is public by default
  name: string;
  private type: string;
  protected age: number = 23;

  constructor(name: string, public userName: string) {
    // 'public userName: string' does the same the bellow
    this.name = name;
  }

  printAge() {
    console.log(this.age);
  }

  setType(type: string) {
    this.type = type;
    console.log(this.type);
  }
}

const person = new Person("Kostya", "kostya");
console.log(person.name, person.userName);

// Inheritance
class Kostya extends Person {
  constructor(userName: string) {
    super("Kostya", userName);
    this.age = 21;
  }
}

const kostya = new Kostya("kostya");
console.log(kostya);

// Getters & Setters
class Plant {
  private _species: string = "Default";

  get species() {
    return this._species;
  }

  set species(value: string) {
    if (value.length > 3) {
      this._species = value;
    } else {
      this._species = "Default";
    }
  }
}

let plant = new Plant();
console.log(plant.species);
plant.species = "AB";
console.log(plant.species);
plant.species = "Green plant";
console.log(plant.species);

// Static Properties & Methods
class Helpers {
  static PI: number = 3.14;
  static calcCircumference(diameter: number): number {
    return this.PI * diameter;
  }
}

console.log(2 * Helpers.calcCircumference(2));
console.log(Helpers.calcCircumference(2));

// Abstract Classes
abstract class Project {
  projectName: string = "Default";
  budget: number = 1000;

  abstract changeName(name: string): void;

  calcBudget() {
    return this.budget * 2;
  }
}

class ITProject extends Project {
  changeName(name: string): void {
    this.projectName = name;
  }
}

let newProject = new ITProject;
console.log(newProject);
newProject.changeName("Super IT Project");
console.log(newProject);
