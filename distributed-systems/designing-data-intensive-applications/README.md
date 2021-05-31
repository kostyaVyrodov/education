# Notes written during reading the "Designing Data Intensive Applications" book

**Scalability** is ability of a system to scale up and down cost-efficiently without changing user experience depending on load. It's ability to handle more requests, users, clients, data transfer.

Scalability is usually defined by:
- more data (DB -> more capacity, read\writes)
- higher concurrency levels (CPU -> more threads, synchronization)
- higher interaction rates. Web site: a page each 15-60 sec; Computer game: multiple messages each second. Challenge - reduce latency

**Scalability vs Performance**

Scalability - how much we can grow or shrink

Performance - how long it takes to process a request

> Example: 100 concurrent users sending requests every 5 secs. Throughput is 20 req 1s. *Performance* - how much requirement you need to serve these 20 req per sec. *Scalability* - how many more users we can handle and how many more requests it's possible to send without degrading performance.

> Tip: Avoid full application rewrites at all costs,45 especially if you work in a startup. Rewrites always take much longer than you initially expect and are much more difficult than initially anticipated. Based on my experience, you end up with a similar mess just two years later.

**Scaling: vertical vs horizontal**

Vertical - CPU and RAM.

Horizontal - more instances. Horizontal is more difficult to achieve. Easier to scale: cache and server. More difficult: DBs and persistent storages.

**Data-intensive app blocks**

- store data so that they, or another app, can find it again later (databases)
- remember the result of an expensive operation, to speed up reads (caches)
- allow users to search data by keyword or filter it in various ways (search indexes)
- send a message to other processes, to be handled later (stream processing)
- periodically crunch a large amount of accumulated data (batch processing)

## Primary concerts

Reliability - work correctly (performance + features) even in case of faults (hardware, software, human faults)

Scalability is the term we use to describe a system’s ability to cope with increased load (data volume, traffic volume, or complexity).

Maintainability - many people should work with the app productively adapting new features and maintaining the current behavior

### Reliability

**Fault** when something goes wrong. A system that can anticipate it is **fault-tolerant** and **resilient**.

We can not handle all types of faults so it only makes sense to talk about tolerating certain types of faults.

**Fault** is when a component of a system stops working. **Failure** is when whole system stops working.

Types of faults:
- hardware
- software
- human errors

### Scalability

Some load parameters: 
- requests per seconds
- the ratio of reads to writes in a database
- the number of simultaneously active users in a chat room
- the hit rate on a cache

The choice of load parameters depends on a concrete case.

#### Scalability example from Twitter

Operations:
- Post tweet - A user can publish a new message to their followers (4.6k requests/sec on aver‐ age, over 12k requests/sec at peak)
- Home timeline - A user can view tweets posted by the people they follow (300k requests/sec)

**Post tweet problems\solution**

Problem: Each user follows many users. The user is followed by other many users. 

Solution 1. Insert a tweet into a global solution (table). Query all users who you follow and join their posts. Sort by time. (Request -> DB + Join)

Solution 2. Maintain a cache (queue\mailbox) of user's timelines. When somebody posts, put a post to subscriber's queue. (Request -> cache)

> The first version of Twitter used approach 1, but the systems struggled to keep up with the load of home timeline queries, so the company switched to approach 2. Downside is a lot of extra work.

1 user might have 30 million of users. 1 post should be delivered to 30M users. Twitter tries to do it in 5 sec.

> The final twist of the Twitter anecdote: now that approach 2 is robustly implemented, Twitter is moving to a hybrid of both approaches. Many followers -> mailbox. An average user - db.

#### Describing performance

The questions when load is increasing:
- When load is increased and resources are not changed, how is performance affected?
- When load is increased, how much resources is necessary to add to keep performance?

Different systems different accents:
- Hadoop (batch processing) - throughput (the number of records we can process per second)
- WebApp - response time (that is, the time between a client sending a request and receiving a response)


### Maintainability

Maintainability has many facets, but in essence it’s about making life better for the engineering and operations teams who need to work with the system.

Properties of maintainability:
- Operability - make it easy for operations teams to keep the system running smoothly. Logging, monitoring, easy to update and etc.
- Simplicity - make it easy for new engineers to understand the system, by removing as much complexity as possible from the system. 
- Evolvability - make it easy for engineers to make changes to the system in the future


## Data Models and Query Languages

### History of relational and document model

- relational model in 1970. Edgar Codd suggested to organize data into relations (tables), where each relation (table) has a collection of tuples (rows)
- relational model became popular due to business data processing. Transactions (entering bank or airlines sales) and batches (reporting, payrolls)
- goal of relational dbs - hide implementation detail behind a cleaner interface. Other DBs for that moment didn't provide it.
- In the 2010s, NoSQL is the latest attempt to overthrow the relational model’s dominance
- NoSQL drivers: greater scalability than relational databases, widespread preference for free and open source software, a desire for a more
dynamic data model

### Relation vs Document

### NoSQL types

Key value

Wide Column Stores

Document databases 

Graph databases
