# Linux Academy Course

Notes for the [AWS Certified Solutions Architect – Associate Level](https://linuxacademy.com/course/aws-certified-solutions-architect-associate-level/)

**Security responsibilities**

Customer responsible for security **in** cloud. Amazon responsible for security **of** cloud.

**Service models:**

- IaaS - EC2. Responsibilities: Data, Applications, Runtime, OS (Updates)
- PaaS - Heroku. Responsibilities: Data, Applications.
- SaaS - gmail, netflix, outlook and etc. Responsibilities: Data.

**Highly Availability** is hardware, software, and configuration allowing a system **to recover quickly** in the event of failure. Example: get flat tier in a car. You change a wheel and continue driving. It's okay to stop and change the wheel.

**Fault Tolerant** is a system designed **to operate through a failure** with **no user impact**. More complex to achieve. Example: broken engine in a plane. A plane can't stop and fix the broken engine, that's why it usually has 2 engines.

**Disaster recovering:** RPO (Recovery Point Objective) and RTO (Recovery Time Objective).

RPO is how much business can tolerate to lose, expressed in time. The maximum time between a failure and the last successful backup.

RTO is the maximum amount of time a system can be down. How long a solution takes to recover.

**Types of encryption**

- Encryption at rest. When data is encrypted during storing (Encrypted hard drive)
- Encryption in transit. When data is encrypted during transition (HTTPS)

Some other terms:
- Application session state is data representing what customers do, what they have chosen, or what they have configured. If a server stores any data about user, it's a stateful server. For example, the server can store session.
- Undifferentiated heavy lifting: A part of an application, system or platform that's not specific your bushiness.

**Region** is a group of availability zones (AZ). An **AZ** is a data center. **Edge locations** are small pockets of AWS compute, storage, and networking close ot major populations and are generally used for edge computing and content delivery.

**CloudFormation** is an Infrastructure as Service tool you can create, manage and remove infrastructure using JSON or YAML. **Stack**(Docker image) is a mechanism containing logical resource based on Template (Docker file).

Stack creates\updates\deletes physical AWS resources based on its logical resources, which are based on the contents of a **template**.

CloudFormation notes:

- a template can create up to 200 resources;
- if a **stack** is **deleted**, then, by default, any **resources** it has created are also **deleted**;
- a stack can be **updated** by **uploading a new version** of template;
- **new logical resources** cause **new physical resources**;
- **removed** logical resources cause the stack to **delete** physical resources;
- **changed** logical resources **update** with **some disruption** or **replace** physical resources;

It's better not to specify the name of resources in a template because it can be reusable.

Ways of affecting resource in CloudFormation:
- updated without any disruption. Happens when changes minor configuration options;
- updated with some disruption. Example: changing ec2 instances size. In this case the instance must be reboot;
- replacement. Resources id deleted and created again

## IAM (Identity and Access Management)

IAM controls access to AWS services via policies that can be attached to users, groups and roles. IAM denies any permissions unless explicitly granted.

### Terms

**Resources** - the user, group, role, policy, and identity provider objects that are stored in IAM.

**Identities** are the IAM resource objects that are used to identify and group. You can attach a policy to an IAM identity. These include users and roles.

**Principals** - a person or application that uses the AWS account root user, an IAM user, or an IAM role to sign in and make requests to AWS.

### IAM Policy

A policy is a JSON document containing AWS permissions that you assign to to a group, a role or a user.

A **managed policy** is a policy managed by AWS or customer.

An **inline policy** is a policy that's embedded in an IAM identity (a user, group, or role). That is, the policy is an inherent part of the identity. You can create a policy and embed it in a identity, either when you create the identity or later.

Policy is a set of "actions" that can be done on specific "resource". Resource is an AWS service like EC2.

Policy tips:
- if a request isn't implicitly allowed, it's implicitly (**default**) denied.
- if a request is explicitly denied, it **overrides everything else**.
- if a request is explicitly allowed, it's allowed unless denied by an explicit deny.
- Remember: DENY -> ALLOW -> DENY.
- Only attached policies you can any impact.
- When evaluating policies all policies are merged (all identity: user, group, role and any resource policy). 

### IAM User

IAM user is a type of IAM identity suitable for long-term access for known entity (human, service, application)

AWS allows to set boundaries for users. It means that if you allow a user to have access only to S3, a user won't be able to go beyond these permissions, even if you set other policies.

User tips:
- Hard limit of 5000 IAM users per account - this is important, as it can impact architecture
- 10 groups memberships per IAM user
- Default maximum of 10 managed policies per user
- No inline limit, but you cannot exceed 2048 characters for all inline policies on a IAM user
- 1 MFA user per user
- 2 access keys per user

Access Keys are not needed to be updated after assigning new permissions ot a user.

### IAM Groups

IAM group is a collection of IAM users. Group allow easier adminstration over steps of IAM users. Groups are not a true identity - they can't be the principal in a policy, so they can't be used in resource policies.

Groups notes:
- Groups are not **"true"** identities and they can't be referenced from the resource policies.
- Groups have **no** credentials.

ARN (Amazon Resource Name) is unique identifier of any resource in any account, any region, anywhere inside Amazon.


### IAM Roles

An IAM role is an IAM identity that you can create in your account that has specific permissions. Security Token Service (STS) generates a time-limited set of access keys (temporary credentials). These access keys have permissions defined in permission policy. IAM roles don't have long term credentials. However, instead of being uniquely associated with one person, a role is intended to be assumable by anyone who needs it.

It's not possible to log in via group. That's why it's not an identity.

A role has a **permission policy** and **trust policy**. Permission policy specifies what the role can do. Trust policy specifies who can assume the role. STS generates a temporary creds for the allowed identity that needs to assume the role.

Role can't be used when you need to log in into AWS console. Roles don't have user&passwords and any access keys.

Role can be used to provide extra access rights to an identity (a user for example) in case of emergency. 

You can create a generic role that can be assumed by another AWS account. If somebody will need to get access right of the role, he can assume the role and get access into your account. When role is assumed the STS generates a short living access token for the identity.

![IAM roles](./images/iam-roles.png)

Roles notes:
- IAM roles have no long term credentials
- The role can be assumed by IAM users, AWS services, External accounts, Web Identities
- Temporary access token is generate by Security Token Service
- Trust policy controls who can assume the role
- Permissions policy defines the permissions provided
- Temporary credentials expire
- Example scenarios: company manager, aws service access, "Break-glass" style, cross account access, web identity federation


### AWS Organizations

It's a service for managing multiple accounts within a single business. Rather than managing many accounts with many isolated sets of logins and individual bills, organizations allows consolidation. 

All accounts with AWS organization can consolidate bills. Organization can share bulk discount.

Organization can have only 1 master account. A master account is created from a root user. Master account is responsible for billing.

![Master account](./images/master-account.png)

![AWS organization](./images/aws-organization.png)

**Role switching** is a method of **accessing one account from another** using only one set of credentials. It's used both within AWS organization and between two unconnected accounts.

The only one way to restrict accounts under other organization units inside your organization is to enable Service control policies on root level. After it you can assign a policy to a sub organization.

## EC2

EC2 is a virtual machine shared between several customers on a host. Each AWS account create a default VPC. Each EC2 instance belongs to a single AZ.

Each EC2 is capable to use 2 types of storage:
- Instance Store Volume is a physical storage devices that are attached to EC2. If the instance fails, you'll all data on the storage. Usually used for temp high performance data that's can be lost.
- Elastic Block Storage is an attachable storage. You can attach it across different EC2 instances.

Security group is a firewall that specifies rules which allow or deny traffic to the instance.

CloudWatch monitors EC2 instances. It does health checks each 5 minutes. It's possible to reduce the interval with additional cost.
The status checks of EC2 instance checks the hardware and the instance state. 

EC2 instance states:
- Running
- Stopped
- Pending
- Stopping

When you stop instance you stop virtual hardware, when you stop a guest OS you actually shut it down. When EC2 instance is stopped or any other state except running you're not charged. You get charged each minute. EBS volumes incur charges. You need to terminate EC2 instance and delete EBS to 100% prevent charging. 

When you **start EC2** instance **again** you can be on **another host** with **other Instance Storage Volume**. Also you get new IP address but you'll have the same DNS.

When you **stop EC2** in VM you free resources on the host. It means that **EC2 get detached from the hardware**.

![EC-2-volumes](./images/ec2-volumes.png)

Stop "hibernate" - remembers the state of an instance and then run it in the same state.

When to use EC2:
- it need a traditional OS;
- something running and consuming CPU constantly;
- it's a monolithic app;
- app need a server to host;
- when something needs 

### Instance types and sizes

EC2 families (groups (Like a vehicle type: car, bus, motorcycle)): 
- general purpose - well balanced. Good CPU, good RAM, good storage. **Use case:** average microservices, backend, small and mid databases, dev. env., code repositories, virtual desktop. 
- computing optimized - best CPU available. **Use case:** high performance backend, microservices, MMO gaming, video encoding, high performance science and eng. apps, machine/deep learning *inference*.
- memory optimized - not bad or good CPU but really nice memory. **Use case:** high performance databases, distributed web scale in-memory caches, mid-size in-memory databases, real time big data analytics.
- storage optimized - provides super fast storage, (good for NO SQL DB). **Use case:** NoSQL databases (e.g. Cassandra, MongoDB, Redis), in-memory databases (e.g. SAP HANA, Aerospike), scale-out transactional databases, distributed file systems, data warehousing, Elasticsearch, analytics workloads.
- accelerated computing - very very specific hardware for specific task. **Use case:** machine learning,

Instance types:
- **T2** and **T3** - low-cost that provides burst capability;
- **M5** - for general workloads
- **C4** - more capable CPU
- **X1** and **R4** - optimize **large amount** of **fast memory**
- **I3** - fast **IO**
- **P2**, **P3**, **F1** - **GPU** and **FPGAs**

Instance sizes: nano, micro, small, medium, large, x.large, 2x.large, and larger

Special cases:
- "a": AMP CPU
- "A": ARM based
- "n": higher speed networking
- "d": NVMe storage

### Storage architecture

Elastic Block Storage (EBS) - a storage service that creates and manages volumes based on four underlying storage types. Volumes are **persistent**, can be **attached** and **removed** from EC2 instances and are **replicated** within a single AZ.

**EBS must be in the same AZ as EC2 instance.**

Volume types:
- sc1 (hdd, Cold HDD) - lowest cost, the slowest one, infrequent access, can't be a boot volume;
- st1 (hdd, Throughput optimized HDD) - low cost, throughput intensive, can't be a boot volume, good for log processing; big data; data warehouses; streaming workloads requiring consistent, fast throughput at a low price;
- gp2 (ssd, general purpose) - default, ballance of IOPS & MiB/s - burst pool IOPS per GB, recommended for most of workloads, virtual desktops, dev and test envs, low-latency interactive apps;
- io1 (ssd, Provisioned IOPS) - highest performance, can adjust size and IOPS separately, critical business application ;
- magnetic is deprecated

![Comparison of storages](./images/ebs-comparison.png)

![ebs comparison](./images/ebs-comparison-la.png)

HDD can be a boot volume, but SSD can.

**IOPS** - Input/Output Operations per Second. It measures amount of data that can be read or written per second


To protect against AZ failure, EBS snapshots (to S3) can be used.
Data is replicated across AZs in the region and optionally internationally.
