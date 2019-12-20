# Design patterns of gang of four

Design patterns are typical solutions to commonly occurring problems in software design

Patterns of gang of four are separated on three groups: creation, structural and behavioral patterns

**Structural** patterns explain how to assemble objects and classes into larger structures, while keeping the structures flexible and efficient

**Behavioral** patterns take care of effective communication and the assignment of responsibilities between objects

## Table of content

1. Creational patterns
1. Structural patterns
1. Behavioral patterns

## Creational patterns

**Creational** patterns provide object creation mechanisms that increase flexibility and reuse of existing code

### Factory

**Explanation:** factory creates an instance for a client without exposing any instantiation logic to the client

**Use case (problem):** when creation of an object involves some logic. You can move creational code to a separate class and reuse the factory class across whole solution

**Benefit:** allows to reduce code duplication, simplifies code base, single responsibility principle, open-clise principle

**Members:**
- AbstractCreator - contract of a creator. It's responsible for creating objects
- ConcreteCreator - one of implementations of a creator contract
- AbstractProduct - contract of a product. It's responsible for behavior
- ConcreteProduct - one of implementations of a product contract
- Client - type using factory

![Factory](./images/factory.png);

### Abstract factory

**Explanation:** abstract factory groups related factories to produce related products

**Use case (problem):** when you need to hide several factories for creation of a group of related objects

**Benefit:** simplifies code base, single responsibility principle, open-clise principle

**Members:**
- Different AbstractProducts - contracts of products behavior
- Different ConcreteProducts - implementation of corresponding AbstractProducts
- Different AbstractFactories - contracts of factories producing concrete product
- Different ConcreteFactories - implementation of an abstract product
- AbstractFactory - contains logic create concrete related to each other products
- Client - a type using abstract factory to produce products

![Abstract factory](./images/abstract-factory.png);

### Builder

**Explanation:**

**Use case:**

**Benefit:**

**Members:**

![Builder](./images/);

### Prototype

**Explanation:**

**Use case:**

**Benefit:**

**Members:**

![Prototype](./images/);

### Singleton

**Explanation:**

**Use case:**

**Benefit:**

**Members:**

![Singleton](./images/);

