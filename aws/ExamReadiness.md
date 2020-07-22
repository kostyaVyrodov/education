# Exam readiness

Notes for [the Exam Readiness: AWS Certified Solutions Architect – Associate (Digital) course](https://www.aws.training/Details/Curriculum?id=20685)

## Exam overview

Questions allocation
1. Design Resilient Architecture - 34%
1. Define Performant Solutions - 24%
1. Specify Secure Applications and Architectures - 26%
1. Design Cost-optimized Architecture - 10%
1. Define Operationally Excellent - 6% 

65 questions and 130 mins

## Design Resilient Architectures

1. Chose reliable/resilient storage. Storage is reliable and resilient is that way even a disaster you don't loose your data or state
1. Determine how to design decoupling mechanism using AWS services. Decouples ensures that even one tier or component fails the others are not impacted
1. Determine how to design a multi-tier architecture solution
1. Determine how to design high availability and/or fault tolerant solutions

## Storages

This section provides overview of different types of storages in AWS

### ES2 (Elastic Compute) Instance Store

Properties of the storage:
- ephemeral volumes. If service stops the data is lost
- only certain EC2 instances
- fixed capacity
- disk type and capacity depends on EC2 instance type
- application-level durability

Generally EC2 is used for caching or for storing other temporary data

### Elastic Block Store (also connected to EC2 instance)

[EBS](https://www.youtube.com/watch?v=77qLAl-lRpo) is 

Properties of the storage:
- different types
- encryption
- snapshots
- provisioned capacity
- independent lifecycle than EC2 instance
- multiple volumes striped to create large volumes
- one EC2 can have several EBS. Several EBS2 allows to use RAID0

EBS can be hosted on SSD or HDD

HDD is good for sequential access to data. Reading chunks of data or reading sequential access. SSD is good for random access.

**Comparison of storages**

![Comparison of storages](./images/ebs-comparison.png)

- Cold HDD - the slowest one and the cheapest one. Good for infrequently accessed large data;
- Throughput optimized HDD - good for log processing; big data; data warehouses; streaming workloads requiring consistent, fast throughput at a low price;
- General purpose SSD - recommended for most of workloads, virtual desktops, dev and test envs, low-latency interactive apps;
- Provisioned IOPS SSD (io1) - critical business application 

HDD can be a boot volume, but SSD can

