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

## Primary concepts

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

Primary data models: hierarchical, relational, document and graph.

### Relational data model

History:
- Edgar Codd in 1970 proposed a relational model data is organized into *relations* (tables) and each relation is an unordered collection of tuples (rows)
- Relational model became popular due to business data processing. Transactions (entering bank or airlines sales) and batches (reporting, payrolls)
- Over years, other models competed to the relational model. Most promising ones were network and hierarchical, but relational model remained the most popular one.

Pros:
- The normalization is available due to joins. So it's possible to remove duplicated data.
- Good support of 1-M and M-M (using associate table)
- To delete a column - just write a migration removing the column

Cons:
- Object relational mismatch. Most programming languages are different from relational model, so it's necessary to implement a data translation layer for it. ORMs come to solve this problem. So instead of manipulation objects, you manipulate columns and rows.
- migrating of schema is slow and requires downtime
- joins usually requires more time because data is split in different tables that might be in RAM and in disk

Notes:
- relational dbs store data is a sequence of tuples
- relational databases like mysql, psql support working with JSON\XML documents. Possible: modify, query properties from documents
- SQL follows the structure of relational algebra

### Document data models

History:
- In the 2010s is the latest attempt to overthrow relational model by document
- Drivers: need for greater scalability (with larger volume and larger write throughput), widespread preference for free and open source software, a desire for a more dynamic data model

Pros:
- schema flexibility (no migrations), better performance (locality), data is closer to app schema
- Good for data with 1-1 relation
- to add a new column - just add a property to object
- when you read an object it's usually inside 1 place on a disk

Cons:
- document DB doesn't support joins well. So one-many relationship is difficult in such DBs. In this case you need write joins in your code
- can't refer to a nested item of a document. First, fully read Nth item, and then access to it property.
- absence of normalization requires excessive number of write operations

Notes:
- a document is usually stored as a long string encoded as JSON\XMl
- MapReduce is a programming model for processing large amounts of data in bulk across many machines, popularized by Google
- MapReduce is neither a declarative query language nor a fully imperative query API. It's somewhere in between. Query expressed by code snippets.
- MapReduce is a fairly low-level programming model for distributed execution on a cluster of machines.

```js
db.observations.mapReduce(
    function map() { // 2
        // Call each time when family is 'shark'
        var year = this.observationTimestamp.getFullYear();
        var month = this.observationTimestamp.getMonth() + 1;
        emit(year + "-" + month, this.numAnimals); // 3
    },
    function reduce(key, values) { // 4
        // Called once
        return Array.sum(values); // 5
    },
    {
        query: { family: "Sharks" }, // 1
        out: "monthlySharkReport" // 6
    }
);

// 1. The filter to consider only shark species can be specified declaratively (this is a MongoDB-specific extension to MapReduce).
// 2. The JavaScript function map is called once for every document that matches query, with this set to the document object.
// 3. The map function emits a key (a string consisting of year and month, such as "2013-12" or "2014-1") and a value (the number of animals in that observation).
// 4. The key-value pairs emitted by map are grouped by key. For all key-value pairs with the same key (i.e., the same month and year), the reduce function is called once.
// 5. The reduce function adds up the number of animals from all observations in a particular month.
// 6. The final output is written to the collection monthlySharkReport.

// Same in mongo but using declarative way
db.observations.aggregate([
    { $match: { family: "Sharks" } },
    { $group: {
            _id: {
                year:  { $year:  "$observationTimestamp" },
                month: { $month: "$observationTimestamp" }
            },
            totalAnimals: { $sum: "$numAnimals" } 
        }
    }
]);
```

### Graph data model

- Many to Many is not good for document db. Graph based dbs are good for it.
- A graph db consists of vertices (nodes) and edge (relationship)
    - Social graph. Vertices - people. Edge - which people know each other.
    - Web graph. Vertices - web pages. Edge - links to other html pages.
    - Road\rail network. Vertices - junctions. Edge - a road.
- Types of data organization in graph oriented databases: property graph and triple stores

#### Property graph

Each vertex consist of:
- a unique identifier
- a set of outgoing edges
- a set of incoming edges
- a collection of properties

Each edge consists of:
- A unique identifier
- The vertex at which the edge starts
- The vertex at which the edge ends 
- A label to describe the kind of relationship between the two vertices
- A collection of properties

> You can think of a graph store as consisting of two relational tables, one for vertices and one for edges

No schema restriction:

- any vertex is connected to any vertex
- from any vertex you can find outgoing and incoming edges. As well you can traverse
- labels for edges allow to store different types of relationships between entities (lives_in, born_in)

An appropriate schema in the db:

```sql
CREATE TABLE vertices (
    vertex_id integerPRIMARYKEY, properties json
);

CREATE TABLE edges (
    edge_id integer PRIMARY KEY,
    tail_vertex integer REFERENCES vertices (vertex_id), head_vertex integer REFERENCES vertices (vertex_id), label text,
    properties json
);

CREATE INDEX edges_tails ON edges (tail_vertex);

CREATE INDEX edges_heads ON edges (head_vertex);
```

#### Triple store

Triple-store stores data as a three-part statement: subject, predicate, object. Example: Jim likes bananas

Resource Description Framework (RDF) is a data formate intended to organize websites to publish data in a consistent format, allowing data from different websites to be automatically combined into a web of data—a kind of internet-wide "database of everything." It's one of possible data formats for representing triple store.

SPARQL is a query language for triple-stores using the RDF data model

### Network data model

- Each row might have 1+ parent. Accessing different rows ~ going through paths. Problem: need to get an item -> go through a path link in a linked list
- links between records were not foreign keys, but more like pointers in a programming language. way accessing a record - follow from a root record along these chains of links
- M-M: several path might lead to the same edge. A developer has keep the track of them.

### Other notes

- A hybrid of the relational and document models is a good route for databases to take in the future
- Imperative way -> specifies each step. Declarative -> specifies pattern. You don't specify HOW to achieve the goal. SQL is declarative.
- declarative is easier to parallel. Because it doesn't use concrete steps.
- Imperative code is very hard to parallelize across multiple cores and multiple machines, because it specifies instructions that must be performed in a particular order.
- some document dbs supports joins (RethinkDB) and some relational dbs supports storing of objects

#### Network DB vs Graph DB

- In the network model, the database had a schema that specified which record type could be nested within which other record type. In a graph database, there is no such restriction: any vertex can have an edge to any other vertex. This gives much greater flexibility for applications to adapt to changing requirements.
- In the network model, the only way to reach a particular record was to traverse one of the access paths to it. In a graph database, you can refer directly to any vertex by its unique ID, or you can use an index to find vertices with a particular value.
- In the network model, the children of a record were an ordered set, so the database had to maintain that ordering (which had consequences for the storage layout) and applications that inserted new records into the database had to worry about the positions of the new records in these sets. In a graph database, vertices and edges are not ordered (you can only sort the results when making a query).
- In the network model, all queries were imperative, difficult to write and easily broken by changes in the schema. In a graph database, you can write your traversal in imperative code if you want to, but most graph databases also support high-level, declarative query languages such as Cypher or SPARQL.

Initially we had a hierarchial data model. After this relational model was created. After relational is document, which leads to graph oriented dbs.

## Storage and retrieval

Simplest DB:

```sh
# Put by key
# Just append to a log data. A log is an abstraction to which we always add data
db_set () {
    echo "$1,$2" >> database
}

# Get by key
# Complexity O(N) because it's necessary to read whole file
db_get () {
    grep "^$1," database | sed -e "s/^$1,//" | tail -n 1
}
```

- reading: O(N) complexity is not good for reading because it's pure performance for reading. Indexes and other stuff helps.
- writing: O(1) just append to the end

**Indexes** 

- index is a thing that keeps metadata on the side, which acts as a signpost and helps you to locate the data you want.
- 1 index - 1 way to search data.
- an index must be maintained on writes. Do a write -> do update of an index -> slower performance on writes
- db usually doesn't index everything. A developer should choose right index

### Hash indexes

Based on key we know the place where to find data. It's fast.

**Log structure hash-table:**
- when you add - you append. When you read - you know offset and you can quickly find necessary data. `key-valueKey`, `value: bytes offset`
- add -> write to file -> receive offset -> update value in hash table
- data stored in segments (logs)
- in memory hash table. in disk data. Data is broken down into log segments. Data is written into a segment. If a segment is too big - write to another.
- each segment has its own in-memory hash table, mapping keys to file offsets.
- look up process: we first check the most recent segment’s hash map; if the key is not present we check the second-most-recent segment, and so on
- problem: somebody hits a like button - need to count a number of likes. Each we add a new row, which leads to memory overrun. Solution: compaction. Find duplicates and keep only the latest value. Compaction is done within 1 log.
- during compaction, it's also possible to merge logs. Merge logs - merge MULTIPLE logs (data segments)

**Important questions:**
- File format. CSV is not good. Binary is better: length of string in bytes + raw string.
- Deleting a key. Add a tombstone label. During merging the value will be discard.
- Crash recovery. Hash map is stored in memory, and in case of restart it will be lost. Restoring approach: read whole log and generate hash-map. But it will be too long for long logs. Optimization: save snapshots and load them.
- Partially written records. Crash anytime, even during writing. Add checksums to detect corrupted rows and ignore them.
- Concurrency control. Append only - 1 writer thread. Many read threads.

**Wny not to overwrite?**
- Appending and segment merging are sequential write operations, which are generally much faster than random writes. Especially on magnetic spinning-hard drives.
- Simple concurrency and crash reporting. No case when data overwritten partially because of crash
- Merges avoid fragmentation.

**Limitations**
- The hash table must fit in memory. A lot of keys - sorry :). Storing on disk leads to a lot of random I\O, hash collisions (some data in RAM, some on Disk) require fiddly logic.
- Range queries are not efficient. Can't easily scan over all keys between kitty00000 and kitty99999—you’d have to look up each key individually in the hash maps

### SSTables and LSM-Trees

**SSM** - Sorted String Tables 
**LSM-Trees** - Log-Structured Merge-Tree

The things above are data segments sorted by a key. Each key must appear only once within each merge segment.

**SSTables advantages:**
- merging is simple - use merge sort. When merge save the most recent value.
- read is quick because we know that a key might be somewhere between 2 keys
- possible not to keep all keys in memory. Because you can find range in hash table and find the key inside a segment.
- B-Trees helps to keep data sorted. So it's easy to add a new item and then transform into a SSTable and save it to disk
- Examples for B-Trees: red-black, AVL trees.

**Implementation of storage engine:**
- Write into an in-memory tree (keeps keys sorted). Sometimes the tree is called memtable
- When the tree is too big -> convert to SSTable and save to disk
- Tree is already sorted, and it's newer version of a index. It's necessary to just overwrite the existing one.
- Serving read: go to a memtable, go to a data segment
- From time to time, run merging + compaction.

If DB crashes during read, restore using a log of operations.

- The basic idea of **LSM-trees** — keeping a cascade of SSTables that are merged in the background
- LSM storages are based on this principle of merging and compacting sorted files

Types of compaction:
- size-tiered - newer and smaller SSTables are successively merged into older and larger SSTables
- leveled compaction - the key range is split up into smaller SSTables and older data is moved into separate “levels,” which allows the compaction to proceed more incrementally and use less disk space

### B-Trees

- B-trees are more common indexes. It's a tree. 
- B-tree breaks down into fixed-size blocks or pages, traditionally 4 KB in size. 
- Each page is identified via an address, which allows one page to refer to another—similar to a pointer, but on disk instead of in memory.
- 1 page is a root of the B-tree; whenever you want to look up a key in the index, you start here
- Update a key: O(NLogN). Find a leaf, update it.
- Insert\Remove a new item: find right spot and balance tree to keep O(NLogN). Overwrite doesn't change the location of a page -> all references to that page remains the same
- To make DB resilient to crashes, it uses WAL (write ahead log) from which it's possible to restore the db
- possible write improvement: overwrite whole page when write data. Like pure function -> copy whole state with updated thing

> Most DB can fit into a B-tree that is 3 or 4 levels deep, so you don’t need to follow many page references to find the page you are looking for. (A four-level tree of 4 KB pages with a branching factor of 500 can store up to 256 TB

**B-trees vs Log-structured index**

Difference:
- The log-structured indexes break the database down into variable-size segments, typically **several megabytes**, and always write a segment sequentially.
- The B-trees break the database down into fixed-size blocks or pages, traditionally 4 KB in size (sometimes bigger), and read or write one page at a time. The design in closed to hardware design.

Common: keep key-value pairs sorted by key, which allows efficient key- value lookups and range queries. 

**B-trees vs LSM-trees**

- LSM-trees - faster for writes.
    - Reads are slower due to checking different data structures and SSTables at different stages of compaction
    - Log-structured indexes rewrite data multiple times due to repeated compaction and merging of SSTables
- B-trees - faster for reads

- in heave write apps, the bottleneck might be rate at which the db can write to disk -> LSM usually can handle more then B-trees. LSM writes sequentially (good for HDD)
- LSM-trees can be compressed better, and thus often produce smaller files on disk than B-trees. 
- B-trees sometime unused space due to fragmentation. LSM-trees fragment disk less due to compaction and merging 
- Compaction process of LSM-trees sometimes can interfere with the performance of ongoing writes and reads
- LSM-trees requires saving to disk log, data segment and sometime compaction with merging. It overuses throughput of disk

### Other notes

- primary index - clustered index. Created for PK of a table. Doesn't have duplicates in keys. Value is data.
- secondary index - non clustered index. Created for other columns of a table. MIGHT have duplicates in keys. Value is reference.
- A clustered index organizes data. An item of index contains data;
- A non clustered index points to concrete data. An item of index has a link to data;
- The key in an index is the thing that queries search for, but the value can be one of two things: the actual row (document, vertex) in question, or a reference to the row stored elsewhere.
- place for values of secondary index is called heap file. It stores data without a particular order. Heap file is common because allows to avoid duplicating of data between 2 different indexes.
- A compromise between a clustered index and a nonclustered - covering index or index with included columns. Part of value is refer and part is data 
- Multi-column indexes (concatenated indexes) allow to query data from multiple columns in an index instead of key-value
- Full-text search and fuzzy indexes allow to find data based on misspelled words. Lucene is a good example.
- These days RAM is quite affordable, so sometimes it's better to keep a db in memory.
- today's in memory DBs can handle more data than RAM's volume. The mechanism is similar to virtual memory
