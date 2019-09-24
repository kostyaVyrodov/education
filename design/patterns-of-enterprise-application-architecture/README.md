# Patterns of Enterprise Application Architecture

Notes written during reading the book 'Patterns of Enterprise Application Architecture' - Martin Fowler.

This book is about how you decompose an enterprise application into layers and how these layers work together

Architecture - the highest-level breakdown of a system into its parts or decisions that are hard to change. Commonly this shared understanding is in the form of the major components of the system and how they interact.

Indications of Enterprise application:

- persistent data. This data needs to live a lot of time;
- a lot of data;
- access data concurrently;
- a lot of user interfaces;
- integrate with other applications;

Performance terms:

- Response time is the amount of time it takes for the system to process a request from the outside.
- Responsiveness is about how quickly the system acknowledges a request as opposed to processing it.
- Latency is the minimum time required to get any form of response, even if the work to be done is nonexistent.
- Throughput is how much stuff you can do in a given amount of time.
- Scalability is a measure of how adding resources (usually hardware) affects performance.
- Vertical scalability means adding more power to a single server, such as more memory.
- Horizontal scalability, or scaling out, means adding more servers.

## The narratives

**Layering** is a technic that's used to break apart a complicated software system.

Benefits:

- You can understand a single layer as a coherent whole without knowing much about the other layers;
- You can substitute layers with alternative implementations of the same basic services;
- You minimize dependencies between layers. If the cable company changes its physical transmission system, providing they make IP work, we don’t have to alter our FTP service;

Downsides:

- Extra layers can harm performance. At every layer things typically need to be transformed from one representation to another;
- Layers doesn't encapsulate everything. The classic example of this in a layered enter- prise application is adding a field that needs to display on the UI, must be in the database, and thus must be added to every layer in between.

Main layers:

1. Presentation
1. Domain
1. Data source

## Organizing business logic

Patterns:

- Transaction Script. **Transaction Script is a procedure** that takes the input from the presentation, processes it with validations and calculations, stores data in the database, and invokes any operations from other systems. It then replies with more data to the presentation, perhaps doing more calculation to help organize and format the reply;
- Domain Model. **Domain Model is an object** model of the domain that incorporates both behavior and data;
- Table Module. A Table Module organizes domain logic with one class per table in the database, and a single instance of a class contains the various procedures that will act on the data. The primary distinction with Domain Model is that, if you have many orders, a Domain Model will have one order object per order while a Table Module will have one object to handle all orders.
