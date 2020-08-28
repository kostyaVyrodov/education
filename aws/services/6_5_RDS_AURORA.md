# RDS Aurora

## Essentials

- aurora is compatible with both Postgre and MySQL
- uses a base config of a "cluster". It means that you operate whole cluster, instead of concrete RDS instances
- cluster provides a cluster shared storage (volume)
- aurora replicates data 6 times, across 3 AZ
- storage is autohealing
- Storage scales automatically. Starts from 10 GB and grows up to 64TB
- You're billed for storage you use, not storage you allocate. But if you used 10 GB and then use 5GB, you'll be billed for 10GB (highest watermark)
- cluster contains a 1 primary instances and 0-Many read replicas (15 max)
- aurora has only 1 write node that writes across all AZs
- 1 write node writes to all storages of a cluster
- replica is a read node that capable to fetch information from shared storage
- you can choose db instance size for aurora db
- **failover priority** allows to identify which instance should be taken after failover (0 - higher priority than 15)
- 5x better over RDS MySQL and 3x better over RDS Postgres
- aurora recovery faster then multi az and read replica of mysql because aurora use shared data cluster
- improve writing - scaling up (more resources to write instance), improve reading - scaling out
- point directly to a write, or to a read instance
- **backtrack** allows you to roll the database back into a previous state. Other DBs have only recovery from a backup. Maximum amount of time storing the backups is 72 hours
- **backtracking** makes whole cluster offline
- aurora **backups**: manual, automatic
- cluster volume is based on SSD
- reads and writes use the cluster endpoint

### High level approach

1 master write to shared volume. Read replicas read data from the shared volume. A volume is shared and replicated across 3 regions, each region has 2 AZs.

![aurora-high-level](./images/aurora-high-level.png)

## Parallel queries and Global Aurora

**Parallel queries** allow queries to be executed across all nodes in aurora cluster at the same time. Good for fetching large amount of data across all nodes.

**Global Aurora** is a mode allowing to replicate data across regions with a latency less 1 sec. Global databases can't use burstable databases. Additional regions are read only.

## Aurora serverless essentials

- Same features sa a traditional aurora but without admin overhead
- You specifies minimum and maximum amount of instances and you the exposed API
- No need to manage own VMs and all admin things
- charges when you run queries (per second for your usage) for the ACUs (Aurora Capacity Units) 
- Aurora capacity unit (ACU) - abstracted unit of compute in memory
- when services are stopped, you're charged only for db storage you use
- aurora has a pool of instances. It allows to spin up them very quickly
- aurora cluster exists in a single AZ
- aurora serverless is good for dev testing
- private link allows to place endpoints inside of the VPC to access remote services
- aurora serverless allows to utilize query editor that can execute queries editor via **DataAPI** (it's a standard API and only for aurora serverless)

**Use case:**
- when an application uses a database and has random surges of traffic
- when you want to remove the complexity of managing database instances
- when you want automatically scaling database instances
- when deploying an application and have unpredictable database usage patterns

**Limitations:**
- slightly longer loading time when a database cluster is paused.
- slower failure switchover than Aurora Provisioned (serverless launches warm instances into the database cluster = more time for a switchover. Provisioned has db ready in its cluster = reduces time for switchover)
- Not accessible via a VPN or an inter-region VPC peer.

**Characteristic:**
- Serverless should be used when workloads are intermittent and unpredictable
- the master exists in one Availability Zone
- capable of rapid scaling because it uses proxy fleets to route the workload to "warm" resources that are always ready to service requests
- slower failover time than Aurora Provisioned
- automatically scales
