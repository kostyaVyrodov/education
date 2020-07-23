# AWS essentials

Notes for [Linux Academy AWS Essentials YouTube playlist](https://www.youtube.com/watch?v=BDBvHOaaKHo&list=PLv2a_5pNAko0Mijc6mnv04xeOut443Wnk&index=1)

## Identity and Access Management (IAM)

IAM is where you manage your AWS users and their access to AWS accounts and services.

The common use of IAM is to manage:
- Users
- Groups
- IAM Access Policies
- Roles

Note: The user created when you created the AWS account is called "root" user. Be default it has full administrative rights and access

By default all new users you create in AWS account don't have any access to any other services. It's necessary to give manually permissions  to new users.

**Security of best practices**
1. Delete your root keys
1. Activate MFA on root account
1. Create an individual IAM users and create a user for yourself that you're going to use on daily basis
1. Use groups to assign permissions
1. Apply IAM password policy

**Roles** like groups for users that allows to provide access to the other AWS services

## Virtual Private Cloud (VPC)

AWS Regions: 
- a grouping of AWS resources located in a specific geographical location;
- Designed to service AWS (or your users) that are located closest to a region;
- **Regions** are comprised of multiple **availability zones**;

AWS Availability zones:
- geographically isolated zones within a region that house AWS resources;
- Availability Zones are where separate, physical AWS data centers are located;
- Multiple AZs in each Region provide redundancy for AWS resources in that region

This approach means that when you create an S3 bucket in a region, the S3 will be copied between several Availability Zone (data centers). If there's a fire in AZ then your d ata will be available in other AZ.

VPC is a private subsection of AWS that you control, in which you can place AWS resources (such as EC2 instances and databases). You have FULL control over who has access to the AWS resources that you can place inside VPC.

Complete control over your virtual networking environment: 
- selection of your own IP address range
- creation of subnets
- configuration of route table and network gateways

**Internet gateway** is analogue of a modem
**Route table** is analogue of a router
**Network Access Control List (NACL)** is analogue of firewall
**AWS service** is analogue of a device

When you create an AWS account, a "default" VPC is created for you. Standard components: IGW (internet gateway), a route table, a network access control list, subnets to provision AWS resources.

### IGW (Internet Gateway)

**Modem**

IGW is a combination of hardware and software that provides your private network with a route to the Internet of the VPC. (Analogue is modem)

Only one IGW can be attached to VPC at a time. IGW can't be detached if VPC has any active AWS resources

### RTs (Route tables)

**Router**

A route table contains a set of rules, called routes, that are used to determine where network traffic is directed.

Each VPC has a default route table

### NACL (Network Access Control Lists)

**Firewall**

A NACL is an optional layer of security for your VPC that acts as a firewall for controlling traffic in and out of one or more subnets

1. Rules are evaluated from lowest to highest based on "rule #"
1. The first rule fond that apples to the traffic type is immediately applied, regardless of any rules come after it
1. The "default" NACL allows all traffic to the default subnets
1. Any new NACLs you create DENY all traffic be default
1. A subnet can only be associated one NACL as a time.
1. An NACL allows or denies from entering a subnet. Once inside the subnet, other AWS resources (i.e. EC2 instances) may have an additional layer of security (security group)

By default all subnets automatically associated with default RT. If a subnet is associated with other RT, then it doesn't belong to a default RT. Each subnet belongs to only one RT.

### Subnets

Subnet is a sub-section of a network. When you create a VPC, it spans all of the Availability Zones in the region. After creating a VPC, you can add one or more subnets in each Available Zone. Each subnet must reside entirely within one Availability Zone and cannot span zones.

- A subnet is located in one specific availability zone.
- Subnets must be associated with a route table.
- A private subnet doesn't have route to the Internet.
- A public subnet has a route to the Internet.

Route tables redirect traffics between subnets (availability zones) 

### Availability zone

Any AWS resources that you launch like (EC2/RDS) must be places in a VPC subnet. Any given subnet must be located in an Availability Zone. You can (and should) utilize multiple AZ to create redundancy in your architecture. This is what allows for High Availability and Fault Tolerant systems.

High Availability: Creating your architecture in such a way that your "system" is always available (ro has the least amount of downtime as possible).

High Availability sounds like: 
- I can always access my data in the cloud
- My website never crashes and is always available to my customers

Fault Tolerant: The ability of your "system" to withstand failures in one of its components and still remain available.

Fault Tolerant sound like:
- One of my web servers failed, but my backup server immediately took over
- if something in my system fails, it can repair itself

**Network devices:**
- Hub - broadcasts packets to all connected devices (doesn't read IP address)
- Switch - sends packets to the concrete device. Reduce unnecessary traffic over network and they are more secure (doesn't read IP address). Switch works with mac addresses
Both hub and switch are used for creating a local network without ability to send data to internet
- Router sends data between networks. It inspects if the data can be handled within the local network or not. If no then it sends data to appropriate router. Router know the address of its network and accepts messages only for the appropriate network. Each network must have a router

Switches and Hubs are used to create a network. Routers are used to connect networks

- Modem transforms data from digital to analogue and vice versa

## S3 (Simple Storage Service)

An online, bulk storage service that you can access from almost any device.

S3 = simple storage service. It's AWS's primary storage. You can store any type of file in S3.

**S3 buckets** are root level folders in S3
**S3 folders** are sub folders in S3
**S3 objects** are files

Regions:
1. When you create a bucket, you must select a specific region for it to exist. This means that any data you upload to the S3 bucket will be physically located in a data center in that region
1. Best practices is to select the region that's physically closest to you or to your customers, to reduce transfer latency.

NOTE: Some AWS services only communicate with each other if they are in the same AWS region.

**Object durability** specifies how long my file will be stored and what chance that it will be lost or corrupted.

**Object availability** specifies what's period of time the object is available for other users.

### Storage classes

**Standard:**
- Designed for general, all-purpose storage. Good for files that you access daily
- It's default storage option
- 99.999999999% durability
- 99.99% availability
- The most **expensive** storage class

**Reduced Redundancy Storage (RRS):**
- Designed for non-critical, reproducible objects. Good for backups. If the backup is corrupted you can get the file from standard 
- 99.99% durability <--- LESS
- 99.99% availability
- Less expensive than the standard storage class

**Infrequent Access (S3-IA):**
- Designed for objects that you don't access frequently but must be immediately available when accessed. Good for files that you access once a week or month.
- 99.999999999% durability
- 99.90% availability <- LESS
- Less expensive than the standard/RSS storage  class

**Glacier**
- Designed for long-term archival storage
- May take several hours for object stored in Glacier to be retrieved
- 99.999999999% object durability
- the cheapest S3 storage class (very low cost)
- Use case: archive of medical information

All files by default has "Standard storage" class.

### Object lifecycle
