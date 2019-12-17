# Apache Kafka

Kafka is stream processing software for storing events

Use cases: Messaging, Website Activity Tracking, Metrics, Log Aggregation, Stream Processing, Event Sourcing, Commit Log

## Overview

Communication between in Kafka is done with TCP protocol

Main concepts:

- kafka is run as a cluster on one or more servers that can span multiple datacenters;
- the kafka cluster stores streams of records in categories called topics;
- each record has a key, a value and a timestamp

Core APIs:

- Producer API that allows an app to publish a stream of records to a Kafka topic;
- Consumer API that allows to subscribe to one or more topics to process the stream of records;
- Streams API that allows an app to act as a stream processor. An app can input stream from one or more topics and produce an output stream to one or more output topics;
- Connector API that allows, for example, to connect to a relation database and capture every change in database;


### About topics, partitions and records

A record is a message that published to a topic

A topic is a stream of records. A topic is always multi-subscriber. A topic can have zero, one or many consumers. Each topic consists of partitions. And a topic looks like this: 

```
A topic: [
    Partition1 [0, 1, 2, 3, 4, 5, 6, 7, ...]
    Partition2 [0, 1, 2, 3, 4, ...]
    Partition2 [0, 1, 2, 3, 4, 5, 6, ...]
]
```

Each partition is ordered and immutable sequence of records. Each record in the partition has sequential id number called `offset`. An offset allows to identify a record in partition

Kafka persists all published records, but it also has resistance policy. For example, it's possible to specify how long the kafka will store records

### Distribution

Kafka partitions are distributed over the servers in the Kafka cluster where each server handles own data and requests for a share of partition. Each partition is replicated to provider fault tolerance

Each partition has a `leader` server and `follower` servers. A `leader` allows read and write, a `follower` just replicate data from `leader`. If a `leader` fails, then one of `follower` becomes a leader

### Geo-Replication, Producers and Consumers

Kafka provides geo-replication support with `KafkaMaker` tool. It allows to replicate messages across multiple data centers or cloud region

A `Producer` publishes data to a Kafka instance. The `Producer` must prepare a record to publish and assign it concrete partition inside a topic. 

`Consumers` label them selves with a 'consumer group' name. Each message is delivered to one of service of a 'consumer group'. Each group is composed of many consumer instances for scalability and fault tolerance.

Kafka provides a total order over records within a partition, not between different partition in a topic

Messaging traditionally has two models: queuing and publish-subscribe:

- In a queue model, a pool of consumers may read from a server and each record goe to one of them;
- In publish-subscribe model goes to each subscriber;

Queuing model scales better, but it's not possible to notify other listeners. For the publish-subscribe model it's vise versa. To combine both approaches the Kafka has consumer groups. A consumer group contains set of listeners that can subscribe to specific partition

### Guarantees

1. Sent messages will be appended in the order they are sent;
1. A consumer instance sees records in the order they are stored in the log;
1. Kafka will tolerate up to n-1 server failures for a topic replication factor N;
