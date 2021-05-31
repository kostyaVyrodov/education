# Glossary of terms

## General terms

**Reliability** describes a system's ability to cope with faults to be able to continue working. Reliable system is *fault tolerant* and *resilient*.

**Scalability** describes a system’s ability to cope with increased load. 

**Maintainability** describes the ease with which a product can be maintained in order to: correct defects or their cause, repair or replace faulty or worn-out components without having to replace still working parts.

**BASE** - Basically Available (the system does guarantee availability, in terms of the CAP theorem), Soft state (the state of the system may change over time, even without input), Eventual consistency (the system will become consistent over time, given that the system doesn't receive input during that time)

## SLA vs SLO vs SLI

**SLA** (service level agreement) is an agreement between provider and client about measurable metrics like uptime, responsiveness, and responsibilities. 

**SLO** (service level objective) is an agreement within an SLA about a specific metric like uptime or response time. The objectives your team must meat to hit SLA.

**SLI** (service level indicator) measures compliance with an SLO (service level objective). So, for example, if your SLA specifies that your systems will be available 99.95% of the time, your SLO is likely 99.95% uptime and your SLI is the actual measurement of your uptime.

SLI -> SLO -> SLA 

## Response time vs Latency

**Response time** - what the client sees: besides the actual time to process the request (the service time), it includes network delays and queueing delays.

**Latency** is the duration that a request is waiting to be handled.

Response time might be represented as percentiles and it's better sometimes. It's when you have a list of all requests and defines what's percentage is finished less then 100ms.

> Amazon observed that a 100 ms increase in response time reduces sales by 1%, and others report that a 1-second slowdown reduces a customer satisfaction metric by 16%


