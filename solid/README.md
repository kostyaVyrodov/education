# SOLID course notes

### Course goal:
Learn how to write more maintainable and readable code.

### High cohesion and low coupling
**Cohesion** refers to the degree to which the elements of a module/class belong together, suggestion is all the related code should be close to each other, so we should strive for high cohesion and bind all related code together as far as possible. It has to do with the elements within the module/class.

**Coupling** refers to the degree to which the different modules/classes depend on each other, suggestion is all modules should be independent as far as possible, that's why low coupling. It has to do with the elements among different modules/classes.

### Encapsulation
What's encapsulation about?
The encapsulation describes how to write reusable code, reusable components where you can reuse them without fully understanding all implementation details.
Right encapsulation makes your code simpler. It allows other programmers to avoid wasting time on searching and figuring out with details of implementation.

##### A symptom of code smell
When you need to go to source code or read the documentation in order to understand what a code does.

##### Sample sucks code

```C#
public class FileStore 
{
    public string WorkingDirectory { get; set; }

    // Why does save return string? What is that string?
    public string Save(int id, string message);

    public event EventHandler<MessageEventArgs> MessageRead;

    // Why does read return void?
    public void Read(int id);
}
```

##### Negative side effects of sucks code?
- Reducing of long-term productivity (not years)
- Reducing of maintainability 

Fact: 
> Code is read more than written. 

Rule:
> Write for stupid programmers. Just KISS.

##### Classic definition of encapsulation
- Information hiding (private properties)
- Implementation hiding (user class -> arrays of passwords -> get a password = last item via property. It allow to make validation)
- Protection of invariants (checking precondition and guarantee post condition)

### Techniques that allows writing better code

##### CQS (command query separation)
Your operations should be commands or queries but not both.
This principle allow a programmer to trust a code
- Commands have side effects (mutate state; can invoke queries);
- Queries return data (returns something, can't invoke commands, idempotent - same result every time);

##### Postel's law
> 
