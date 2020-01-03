# Microservices

Benefits: 
- allows the continuous delivery and deployment of large, complex app;
- each microservice is relatively small;
- eliminates any long-term commitment to a technology stack;
- improved fault isolation;

Drawbacks:
- developers must deal with the additional complexity of creating a distributed system;
- deployment complexity;
- increased memory consumption;

Microservices must be: 
- cohesive (implement a small set of strongly related functions)
- loosely coupled (encapsulates own implementation so it can be changed with minimal affecting clients)
- testable
- small enough to be developed by a "two pizza" team

Each team owning a service must be autonomous

## Decomposition

- By business capability
- By a subdomain
- Service per team
- self-contained service

## Data management

- db per service
- shared db
- saga (single business process)
- API composition (join across several microservices)
- CQRS (command query responsibility segregation)
- domain event 
- event sourcing

## Transaction messaging
