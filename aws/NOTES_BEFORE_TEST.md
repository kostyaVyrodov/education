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
