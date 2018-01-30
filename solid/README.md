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

    // What does MessageRead do here?
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

```
public string Read(int id)
{
    var path = GetFileName(id);
    var msg = File.ReadAllText(path);
    return msg;
}
```

Read method can return null or string. A class user has to go to the implementation fo read method to understand it. 
It's bad because our design forces developers to waste time by reading our code instead of just checking implementation and fastly figure out how to work with our types.

How to avoid returning null?
- Add an bool Exists(int id) method (not thread safe); 
- bool TryRead(int id, out string message) (not convenient);
