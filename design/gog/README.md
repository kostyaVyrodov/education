# Design patterns of gang of four

Design patterns are typical solutions to commonly occurring problems in software design

Patterns of gang of four are separated on three groups: creation, structural and behavioral patterns

**Behavioral** patterns take care of effective communication and the assignment of responsibilities between objects

## Table of content

1. Creational patterns
1. Structural patterns
1. Behavioral patterns

## Creational patterns

Creational patterns provide object creation mechanisms that increase flexibility and reuse of existing code

### Factory

**Explanation:** factory creates an instance for a client without exposing any instantiation logic to the client

**Use case (problem):** when creation of an object involves some logic. You can move creational code to a separate class and reuse the factory class across whole solution

**Benefit:** allows to reduce code duplication, simplifies code base, single responsibility principle, open-clise principle

**Members:**

- AbstractCreator - contract of a creator. It's responsible for creating objects
- ConcreteCreator - one of implementations of a creator contract
- AbstractProduct - contract of a product. It's responsible for behavior
- ConcreteProduct - one of implementations of a product contract

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

![Abstract factory](./images/abstract-factory.png);

### Builder

**Explanation:** builder allows to create different flavors of an object avoiding constructor pollution

**Use case:** when there is a type with many parameters that has to be initialized with constructor. For example, there's a builder of a server when you create ASP.NET Core app

**Benefit:** allows to avoid 'Long Parameter List' in client's code smell

**Members:**

- Builder - a builder that knows how to initialize a type;
- Product - a type with many params;
- Director - conducts of building an object;

![Builder](./images/builder.png);

### Prototype

**Explanation:** creates a clone of an existing object

**Use case:** when you have an object with many parameters and you need to a get another one with the same state

**Benefit:** allows a client easily create a copy of the same type

**Members:**

- Prototype - a type that implements a clone() method

![Prototype](./images/prototype.png);

### Singleton

**Explanation:** makes sure that only one instance of a class is created

**Use case:** when you need to have only 1 instance of an object across whole application

**Benefit:** you are sure that you have only one instance

**Members:**

- Singleton - a type that creates itself and always the same reference

![Singleton](./images/singleton.png);

## Structural patterns

Structural patterns explain how to compose objects and classes into larger structures and keep the structures flexible

### Adapter

**Explanation:** a wrapper that binds two incompatible types

**Use case:** your app works with json. One of types can produce only XML. It's possible to write an adapter to convert XML to JSON

**Benefit:** ensures single responsibility and open closed principles

**Members:**

- IncompatibleService - a service that can't work directly with your types;
- Adapter - an object that adapts IncompatibleService;
- Client - your application that exposes required interface. Adapter adapts the IncompatibleService

![Adapter](./images/adapter.png);
