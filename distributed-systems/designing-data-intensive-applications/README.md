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

Scalability - as the system growth (data volume, traffic volume, or complexity), there's a reasonable way to handle it

Maintainability - many people should work with the app productively adapting new features and maintaining the current behavior
