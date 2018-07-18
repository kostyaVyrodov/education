### Setting up a DB cluster

Infrastructure: 2 nodes with db and a node with client (DBMS)

Propagating types: async (sync all nodes after update with delay) and sync (sync all nodes after update immediately)
Slave lag is a time difference that's necessary to replicate data between nodes
