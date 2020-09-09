# Topics for SA_C02

- Regional, AZs or HA?
- Backups
- Encryption


## EFS

- EFS - elastic file service. Amazon **managed** implementation of NFS
- Automatically provisions if the size grows
- EFS supports only linux. Amazon FSx is for windows.
- Backups slow down NFS
- **Several AZs** to store data
- Cheaper than EBS
- EFS has lifecycle, similar to S3. It has EFS IA.
- Support encryption in rest and in fly

## Amazon FSx for Windows Server

- FSx similar to NFS but for windows server
- Based on SMB (Server Message Block) protocol

## Amazon FSx for Lustre

- A distributed file system. Fully managed. Optimized for compute-intensive workloads
- Millions of IOPS, sub-milliseconds latency

## ENA and EFA

- EN - enhanced networking is free feature that provides single root of virtualization (SR-IOV). Provides higher I/O and lower CPU.
- EN implementations: ENA and VF (virtual function)
- ENA - elastic network adapter provides up to 100 Gbps
- VF - is up to 10 Gbps for older instances
- EFA - elastic fabric adapter - is special network  device attached to EC2. Accelerates HPC. Provide lower latency and higher throughout. Only for linux.

## AWS Parallel Cluster

- open source cluster management tool that makes it easy to deploy and manage High Performance Computing (HPC) clusters on AWS

## AWS DataSync

- move fast large data from on premises to S3, EFS, Amazon FSx for windows

## AWS Directory Service

- family of managed services for Microsoft technology like AD
- enables SSO for EC2
- AWS manages service implementing Active Directory things of microsoft
- Services that works with Directory Service and enables users authorization to AWS: AD Connector, Simple AD

## Amazon MQ

- similar to SQS but provides industry standard message queue
- stores data redundantly in several AZs
- preserves the order of messages sent by a single producer
