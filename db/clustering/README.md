# DB clustering

## Terminology

- Database cluster is a group of computers working to build a data layer of your app;
- Node is an instance of database. A node doesn't correspond to one computer. Several instances of db can be installed in one computer, so there are 2 nodes;

### Topology

Topology describes an infrastructure of your db cluster. There are 2 main types of it: master-master and master-slave;

master node - you can read\write;
salve node - you can read;

Slave node just copies a data from the master node;
When someone writes to master node it begins propagating data to other nodes and they write data

### Setting up a DB cluster

Infrastructure: 2 nodes with db and a node with client (DBMS)

Propagating types: async (sync all nodes after update with delay) and sync (sync all nodes after update immediately)
Slave lag is a time difference that's necessary to replicate data between nodes

