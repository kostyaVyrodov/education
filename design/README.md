# Object oriented design

Useful links:
- https://sourcemaking.com/
- https://refactoring.guru

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

## About REST

REST (REpresentational State Transfer) is a design concept for managing state of information

The basic idea of REST is treating objects on the server-side (as in rows in a database table) as resources than can be created or destroyed. REST describes the location of something anywhere in the world from anywhere in the world.

> If we access a web page then we get a representation of a resource

**Terms:**
- Client - the client is the person or software who uses the API;
- Resource - a resource can be any of object the API can provide information about;

REST exposes information about information it has. It allows clients to take some actions on those resources

An identifiers of a resource is URL or endpoint. An operations is a HTTP method of verb

Properties of RESTful services:
- the request to the server hast include an ID;
- the response returns enough information to allow a client to modify the resource;
- The client and the server act independently;
- the interaction between them is only in the form of requests, initiated by the client only;
- servers don't send requests to client on its own;
- The server is stateless. It means the server does not remember anything about the user who uses the API;

### Idempotent REST APIs

REST API is called idempotent when making multiple identical requests has the same effect as making a single request

POST is NOT idempotent. It's used to create resources on a server. When you invoke the same POST request N times, you will have N new resources on the server.

GET, PUT, DELETE, HEAD, OPTIONS and TRACE are idempotent.

PUT and DELETE allows to modify a resource only once, unless DELETE looks like this ```/resourceId/last```

## OOP 

Encapsulation

**Abstraction** is hiding of complexity from a user. That's creating simple interfaces. Ideal abstraction: here your method. Don't worry about anything else.
