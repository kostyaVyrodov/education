# Non relational databases

Non-relational database is a database that does not use the tabular schema of rows and columns found in most traditional database systems. Instead, non-relational databases use a storage model that is optimized for the specific requirements of the type of data being stored.

Non-relational databases implement 'Eventual consistency' pattern of 'Consistency' patterns.

## Table of content

1. BASE

## BASE

BASE is abbreviation explaining properties of NoSQL databases:

- Basically available - the system guarantees availability.
- Soft state - the state of the system may change over time, even without input.
- Eventual consistency - the system will become consistent over a period of time, given that the system doesn't receive input during that period.

## Key-value

> Abstraction: hash table

Example: Redis

A key-value store generally allows for O(1) reads and writes and is often backed by memory or SSD.

Key-value stores provide high performance and are often used for simple data models or for rapidly-changing data, such as an in-memory cache layer. Key-value store they offer only a limited set of operations, complexity is shifted to the application layer if additional operations are needed.

## Document store

> Abstraction: key-value store with documents stored as values

Example: MongoDB (SOLR is a search engin, MongoDB is a general purpose database)

A document store is centered around documents (XML, JSON, binary, etc), where a document stores all information for a given object.

## Wide column store

> Abstraction: nested map ColumnFamily<RowKey, Columns<ColKey, Value, Timestamp>>

Example: Cassandra

A wide column store's basic unit of data is a column (name/value pair). A column can be grouped in column families (analogous to a SQL table). Super column families further group column families. You can access each column independently with a row key, and columns with the same row key form a row. Wide column stores offer high availability and high scalability. They are often used for very large data sets.
