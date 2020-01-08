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

- Decomposition by business capability - define services corresponding to business capabilities
- Decomposition by a subdomain - define services corresponding to DDD subdomains
- Self-contained service -  design services to handle synchronous requests without waiting for other services to respond
- Service per team

## Data management

- DB per service - each service has its own private database
- Shared db - services share a database
- Saga (single business process) - use sagas, which a sequences of local transactions, to maintain data consistency across services
- API composition (join across several microservices) - implement queries by invoking the services that own the data and performing an in-memory join
- CQRS (command query responsibility segregation) - implement queries by maintaining one or more materialized views that can be efficiently queried
- Domain event - publish an event whenever data changes
- Event sourcing - persist aggregates as a sequence of events

## Transaction messaging

- Transactional outbox
- Transaction log tailing
- Polling publisher

## Testing

- Consumer-driven contract test - a test suite for a service that is written by the developers of another service that consumes it
- Consumer-side contract test - a test suite for a service client (e.g. another service) that verifies that it can communicate with the service
- Service component sest - a test suite that tests a service in isolation using test doubles for any services that it invokes

## Cross cutting concerns

- Microservice chassis - a framework that handles cross-cutting concerns and simplifies the development of services
- Externalized configuration - externalize all configuration such as database location and credentials

## Communication patterns

### Styles

Which communication mechanisms do services use to communicate with each other and their external clients?

- Remote Procedure Invocation - use an RPI-based protocol for inter-service communication
- Messaging - use asynchronous messaging for inter-service communication
- Domain-specific protocol - use a domain-specific protocol

### External API

- API gateway - a service that provides each client with unified interface to services
- Backend for front-end - a separate API gateway for each kind of client

### Service discovery

- Client-side discovery - client queries a service registry to discover the locations of service instances
- Server-side discovery - router queries a service registry to discover the locations of service instances
- Service registry - a database of service instance locations
- Self registration - service instance registers itself with the service registry
- 3rd party registration - a 3rd party registers a service instance with the service registry

### Reliability

- Circuit Breaker - invoke a remote service via a proxy that fails immediately when the failure rate of the remote call exceeds a threshold

### Security

- Access Token - a token that securely stores information about user that is exchanged between services

## Observability

- Log aggregation - aggregate application logs
- Application metrics - instrument a service’s code to gather statistics about operations
- Audit logging - record user activity in a database
- Distributed tracing - instrument services with code that assigns each external request an unique identifier that is passed between services. Record information (e.g. start time, end time) about the work (e.g. service requests) performed when handling the external request in a centralized service
- Exception tracking - report all exceptions to a centralized exception tracking service that aggregates and tracks exceptions and notifies developers.
- Health check API - service API (e.g. HTTP endpoint) that returns the health of the service and can be pinged, for example, by a monitoring service
- Log deployments and changes
