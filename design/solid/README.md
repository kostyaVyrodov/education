# SOLID course notes

Course goal: Learn how to write more maintainable and readable code.

## High cohesion and low coupling

**Cohesion** refers to the degree to which the elements of a module/class belong together, suggestion is all the related code should be close to each other, so we should strive for high cohesion and bind all related code together as far as possible. It has to do with the elements within the module/class.

**Coupling** refers to the degree to which the different modules/classes depend on each other, suggestion is all modules should be independent as far as possible, that's why low coupling. It has to do with the elements among different modules/classes.

> Abstraction is the elimination of the irrelevant and the amplification of the essential (R. Martin)

## Encapsulation

What's encapsulation about?

- The encapsulation describes how to write reusable code, reusable components where you can reuse them without fully understanding all implementation details.
- Right encapsulation makes your code simpler. It allows other programmers to avoid wasting time on searching and figuring out with details of implementation.

### A symptom of code smell

When you need to go to source code or read the documentation in order to understand what a code does.

### Sample sucks code

```C#
public class FileStore
{
    public string WorkingDirectory { get; set; }

    // Why does save return string? What is that string?
    public string Save(int id, string message);

    // What does MessageRead do here?
    public event EventHandler<MessageEventArgs> MessageRead;

    // Why does read return void?
    public void Read(int id);
}
```

### Negative side effects of sucks code?

- Reducing of long-term productivity (not years)
- Reducing of maintainability

**Fact:**
> Code is read more than written.

**Rule:**
> Write for stupid programmers. Just KISS.

### Classic definition of encapsulation

- Information hiding (private properties)
- Implementation hiding (user class -> arrays of passwords -> get a password = last item via property. It allow to make validation)
- Protection of invariants (checking precondition and guarantee post condition)

### Techniques that allows writing better code

Programmers spend a lot of time reading the code and trying to figure out what it does.
Good code base allows to read less and write more.

##### CQS (command query separation)

Your operations should be commands or queries but not both.

This principle allow a programmer to trust a code

- Commands have side effects (mutate state; can invoke queries);
- Queries return data (returns something, can't invoke commands, idempotent - same result every time).

CQS should have clear boundaries and whole team should understand them. It will increase trusting to your code.
Because the main goal is not to use CSQ, the main goal is increase productivity.\

##### Postel's law

You should be very conservative in what you send, but you should be liberal in what you accept.

1. Check everything that you accept;
2. Try to accept even extreme arguments. If argument is not valid return informative response;
3. Return only expected value;

Invariant is property of programs state that always is true.
> For instance, a binary search tree might have the invariant that for every node, the key of the node's left child is less than the node's own key. A correctly written insertion function for this tree will maintain that invariant.

##### Returning null

> Null reference is my billion-dollar mistake - Tony Hoare

Read method can return null or string. A class user has to go to the implementation fo read method to understand it.
It's bad because our design forces developers to waste time by reading our code instead of just checking implementation and fastly figure out how to work with our types.

```
public string Read(int id)
{
    var path = GetFileName(id);
    var msg = File.ReadAllText(path);
    return msg;
}
```

How to avoid returning null?

- Add an bool Exists(int id) method (not thread safe); 
- bool TryRead(int id, out string message) (not convenient);
- 'Maybe'.

**Summary:**

- We spend more time reading then writing -> make code easier to read;
- It's okay to make types public if they protect invariants;
- Fail fast when something goes wrong, but only with noticeable message;
- Never return null;
- Don't forget about Postel's law and CQS;
- Write for stupid programmers.

## SOLID

Why do we need SOLID?
To write maintainable code
Soft should adaptable for new requirements, because it always changes

What's solid? It's acronym of design principles.
- **S**ingle Responsibility Principle - every type should have only one responsibility;
- **O**pen Close Principle - class should be opened for extensibility but closed for modification;
- **L**iskov Substitution Principle - explains how to polymorphism should work;
- **I**nterface Segregation Principle - describes how to interface should be design;
- **D**ependency Inversion Principle - describes the relationships between abstractions and concrete types.

**What solid is not:**

- Not a framework or library, not a specific technology;
- It's not a goal;
- Not a pattern.

> If you write code using object oriented language it doesn't mean that code is written in OO styles. In most cases it's written in procedural style.
> SOLID principles lift your code to OO style.

The purpose of SOLID is to make code more productive, by making your code more maintainable through decomposition and decoupling.

**Design smells:**

- Rigidity. Means that design is difficult to change;
- Fragility. The design is easy to break;
- Immobility. The design is difficult to reuse;
- Viscosity. It's difficult to do the right thing;
- Needless complexity. Overdesign.

> Abstraction is not designed, it's discovered. 
Try to implement concrete behavior and then discover common abstraction.
Follow to the rule of three. 

### Objects, function and closures
- Object are data with behavior;
- Functions are pure behavior;
- Closures are behavior with data.

### Single responsibility principle

> A type should do only on thing and do it well.

How to define single responsibility?
> A class should have only one reason to change.

How to process every 'reason for change'? 
> It should be extracted into separate type.
Example: extracting of logging, storing and caching into separate classes.
You'll get 4 classes: 3 specific and 1 class-manager.

> Developer have a tendency to attempt to solve specific problems with general solution.

### Open Closed Principle

> A type should be opened for extensibility and closed for modification.

This principle was discovered basing on inheritance. If you want to extend a type derive it.

Inheritance way to open class for extensibility is to add `virtual` keyword.

> Programmers create, read, update, delete code. According to the OCP a developer can only read or create code.

### Liskov Substitution Principle

> Subtypes must be substitutable for their base types.

A client should consume any implementation without changing the correctness of the system.

**Signs of LSP violation:**
- NotSupportedException. Sample: ICollection<T> - Support all List<T>, Add, Remove, Clear are not supported ReadOnlyCollection<T>;
- A lot of downcasts;
- Extracting of interface.

Implementation of type should work on one level of abstraction.

```
public virtual string ReadAllText(string path)
{
    return File.ReadAllText(path);
}

public virtual FileInfo GetFileInfo(int id, string workingDir)
{
    return new FileInfo(Path.Combine(workingDir, id + ".txt"));
}
```

```ReadAllText``` works with a 'path' and the ```GetFileInfo``` works with id;

### Interface Segregation Principle

> Clients should not be forced to depend on methods they do not use

Clients are owners of interfaces. They define what they need, so an interface is defined by a class that will use interface.

> Favour Role Interface over Header Interfaces

Header interface is extracted from a class and has useless members for other clients. It's just a big interface with a lot of members.

ISP helps you to resolve LSP issues.

Smell of ISP: When you have a client that uses an interface and there are some unused members from the interface. It's violation of ISP.

Contract of type may help you to find an abstraction not a name of type or type members.

### Dependency Inversion Principle

High-level modules should not depend on low-level modules. Both should depend on abstractions.
Abstraction should not depend upon details. Details should depend upon abstractions.

Dependency Injection and Inversion of Control are not DIP Implementations.

The DIP is neither dependency injection (**DI**) nor inversion of control (**IoC**). Even so, they all work great together.

**DI** is about making software components to explicitly declare their dependencies or collaborators through their APIs, instead of acquiring them by themselves.

With **DI**, the responsibility of providing the component dependencies and wiring object graphs is transferred from the components to the underlying injection framework. From that perspective, DI is just a way to achieve **IoC**.

**IoC** is a pattern in which the control of the flow of an application is reversed. With traditional programming methodologies, our custom code has the control of the flow of an application. Conversely, with **IoC**, the control is transferred to an external framework or container. The framework is an extendable codebase, which defines hook points for plugging in our own code.

In turn, the framework calls back our code through one or more specialized subclasses, using interfaces' implementations, and via annotations. The ASP.NET framework is a nice example of this last approach.
