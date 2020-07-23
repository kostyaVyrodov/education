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

**Network devices:**
- Hub - broadcasts packets to all connected devices (doesn't read IP address)
- Switch - sends packets to the concrete device. Reduce unnecessary traffic over network and they are more secure (doesn't read IP address). Switch works with mac addresses
Both hub and switch are used for creating a local network without ability to send data to internet
- Router sends data between networks. It inspects if the data can be handled within the local network or not. If no then it sends data to appropriate router. Router know the address of its network and accepts messages only for the appropriate network. Each network must have a router

Switches and Hubs are used to create a network. Routers are used to connect networks

- Modem transforms data from digital to analogue and vice versa
