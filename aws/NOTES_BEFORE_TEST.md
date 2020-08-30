# Notes before test

- Amazon ACM - amazon certificate manager
- IAM: Also there's resource policy that applied to all identities accessing a resource. Resource policy for bucket is bucket policy
- Resource access manager (RAM) - allows to share AWS resources between different accounts that belongs to the same organization
- Sharing resources via IAM - is difficult. It's better to use RAM
- AWS Control Tower is for set up and govern of new accounts
- AWS ParallelCluster allows to easy for you to deploy and manage High-Performance Computing (HPC) clusters on AWS
- AWS budget allows to specify and monitor your budgeting. Cost explorer visualize expenses, Payment history allows to see history of invoices,
- instance store-backed instances do not support the Stop action
- It's possible to bring your own IP address to AWS via Route Origin Authorization (ROA). This feature called bring your IP
- AMI is region based. If you need it in other region, you need to copy it manually.
- Shared AMI is available for everyone
- Transferring data from an EC2 instance to Amazon S3, Amazon Glacier, Amazon DynamoDB, Amazon SES, Amazon SQS, or Amazon SimpleDB in the same AWS Region has no cost at all. Refer to the Amazon EC2 Pricing on the link below for reference.
- AWS IoT Core is a service that lets connected devices easily and securely interact with cloud applications and other devices.
- NACL is executed from lowest to highest
- EBS is automatically replicated to other AZs to provide resilience, not in region
- EBS can be attached only to EC2 within the same AZs
- EBS allows to modify size, type, throughput of production instance without interruption
- **AWS System Manager Parameter Store** allows to store creds, encrypt them via KMS and pass to AWS services like lambda
- **AWS Secrets Manager** helps you rotate, manage, and retrieve all kinds of secrets like database credentials, API keys, and so on. Using Secrets Manager, you can secure, audit, and manage secrets used to access resources in the AWS Cloud, on third-party services, and on-premises. Generating password.
- **AWS Shield** - allows to protect against DDoS. Works on the layer above 4. Shield standard is available for all customers without cost
- **AWS WAF** (Web app firewall) monitors incoming traffic to the app and allows to block SQL injections and XSS attacks. Works on the level 7 and less
- **Amazon GuardDuty** is a managed threat detection service that continuously monitors for malicious or unauthorized behavior to help you protect your AWS accounts and workloads. It monitors for activity such as unusual API calls or potentially unauthorized deployments that indicate a possible account compromise.
- **AWS Firewall manager** is allow to manage security services like AWS shield and WAF from different accounts
- **AWS glue** simplifies preparation data for analytics
- **Amazon Data Lifecycle Manager** allows to manage creation, retention and deletion of backups and snapshot
- **AWS DataSync** makes it simple and fast to move large amounts of data online between on-premises storage and Amazon S3. It's for migration data, while AWS Storage Gateway allows to share data on-premises and in AWS
- Geolocation routing policy — Use when you want to route traffic based on the location of your users. Geoproximity routing policy — Use when you want to route traffic based on the location of your resources and, optionally, shift traffic from resources in one location to resources in another.
- Data Warehouse = redshift

Disaster recovery plan:
- Backup and restore
- Pilot light - a minimal version of an environment is always running in the cloud. keeps critical applications and data at the ready so that it can be quickly retrieved if needed.
- Warm Standby - scaled-down secondary system runs in the background of the primary system. Is more expensive
- Multi-Side solution - full copy of secondary solution

- **CloudFront Origin Access Identity** ensures that only CloudFront can serve S3 content
- **AWS AppSync** automatically updates the data in web and mobile applications in real time, and updates data for offline users as soon as they reconnect.
- **ENI** - Elastic Network Interface. A virtual network card. 1 EIP per PIP. 1 public IPV4, 1+ public IPV6
- **Enhanced Networking.** Uses single root I/O virtualization to provide high performance network capabilities on supported instance. Faster network without additional CPU utilization. It's free
- **ENA** - Elastic Network Adapter. Feature that should have EC2 to support ENI. VF (virtual function) is similar as ENA but slower
- **EFA** - Elastic Fabric Adapter. Is hardware that can be attached to EC2. It's used for ML and HPC. A network device that you can attach to your EC2 instance to accelerate high performance computing (HPC) and ML operation. EFA per EC2
- **S3 Select** allows to retrieve only a subset of data from an object by using simple SQL expressions
- **S3** doesn't provide file system access semantics (like EFS). The largest object that can be uploaded in a single PUT is 5GB
- **S3** action types: transition and expiration

**Placement groups:**
- Cluster - packs instances together inside 1 AZ. Goal: low latency for HPC
- Partition - group instances into partitions. Instances of different partitions don't share underlying hardware. Inside same AZs, but in different racks. Goal: casandra, kafka. 
- Spread - group of instances that are each placed on distinct racks, with each rack having its own network and power source. Goal: small number of critical instances that should be kept separate from each other.
- Partition is bigger group of instances. Spread is smaller group of instances.

- **SAN** Subject Alternative Name allows 1 certificate support many domain name. Each new subject name requires to reprovision whole certificate
- **ALB** supports uploading multiple SSL and distributing traffic belonging to concrete domain names
- Configure **CloudFront** to serve **HTTPS** requests using **dedicated IP addresses**, you incur an additional **monthly charge**.
- **Write** operations in **Aurora** should go to read only endpoint.
- **Aurora** cluster endpoint = writer endpoint
- **Aurora Parallel Query** allows to enable multiple instances to perform huge query, not load balancing
- gp2 maximum 16k IOPS
- **RDS** managed, **DynamoDB** fully managed
- Each subnet maps to a single Availability Zone.
- Every subnet that you create is automatically associated with the main route table for the VPC.
- Allowed CIDR between 16 and 28
- VPN provide private session with IP Security (IPSec) or TLS
- Simple Workflow Service (SWF) - managing multi-step and multi-decision checkout process of an e-commerce mobile app. Orchestrating the execution of distributed business process.
- **EC2 limit** per region for **vCPU-based on-demand**. It's possible to extend the limit.
- AWS Fargate is orchestrator of docker containers. It understand how many instances you need to launch on your demand
- CLB doesn't allow cross zone load balancing
- No need reserved instances can't be canceled via AWS contact. You can sell them via marketplace
- It's possible to assign Source in SG another SG to allow traffic
- AWS Terminates spot instances because of capacity requirements
- To ensure that SQS consumers don't process the same messages twice, you can use FIFO queue
- **AWS Global Accelerator** allows to move user's traffic through edge instances to the distention via amazon backbone
- AWS transit gateway allows customers to connect Amazon Virtual Private Clouds (VPCs) and their on-premises networks to a single gateway
- **AWS Config** automates the evaluation of recorded configurations against desired configurations
- Enhanced monitoring for DB: OS Process, RDS Child Process
- Deny user access to encrypted resource via denying access to encrypting key
- **AWS X-Ray** to trace and analyze user requests as they travel through your Amazon API Gateway APIs to the underlying services
- AWS CloudCommit - VCS
- **AWS Lambda** doesn't allow to use serverless computing to coordinate multiple AWS services into serverless workflow
- **S3** doesn't provide low latency
- **Connection Draining** allows a load balancer complete in-flight requests made to instances that are de-registering or unhealthy
- **Redshift Spectrum** allows to execute SQL on exabytes of unstructured queries
- 1 launch config per Autoscaling group
- **Lambda@Edge** is a feature of Amazon CloudFront that lets you run code closer to users of your application, which improves performance and reduces latency.

What to refresh:
- Elastic IP for instances
- EBS properties like AZ, encrypting and etc.
- question #55, #56, #58, #61, #65 in Test3
- services for analytics and big data
- services for security
- what is AWS global accelerator
- retention, visibility timeouts in sqs. When resources are deleted?
- amazon mq vs sqs
- high availability and fault tolerance
- What is vault lock in s3 glacier
- is it possible to combine cloudFront with lambda edge
- read about Amazon SWF
- what is a virtual function?

Test4
11 - what is a public data set

