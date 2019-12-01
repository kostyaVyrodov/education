# Object oriented design

## Cohesion (high) and coupling (low)

[Read more here](https://enterprisecraftsmanship.com/posts/cohesion-coupling-difference/)

**Cohesion** is how closely related everything is with one another.

Cohesion is the indication of the relationship within a module.

**Coupling** is how much one component (a class or a function) knows about the inner workings or inner elements of another one, i.e. how much knowledge it has of the other component.

Coupling is the indication of the relationships between modules.

Rule: all code that does a thing should be as close as possible and shouldn't know details of other parts of solution.

## Base entity class

[Base entity should be an abstract class](https://enterprisecraftsmanship.com/posts/entity-base-class/) providing reference equality, identifier equality and logical equality

An interface is bad idea:
- it's not possible to implement base functionality there, so you'll have to implement in every child, which itself is heavy violation of DRY principle;
- interface doesn't show relationship between the domain entities.

> When a class implements an interface it makes a promise about some functionality, and that’s it. Two classes implementing the same interface don’t give any promises about their relationship, they can belong to entirely unconnected hierarchies. In other words, IEntity interface introduces a “can do” relation (according to Bertrand Meyer’s classification), whereas domain entities should be connected to the base entity by “is a” relation. Every domain class not only has the Id property, but itself is an entity.

```
public interface IEntity
{
    int Id { get; }
}
```

### Base class as a base entity


## Useful links

https://sourcemaking.com/
https://refactoring.guru
