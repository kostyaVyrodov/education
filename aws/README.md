# AWS certified solutions architect associate

Notes for [AWS certified solutions architect associate](https://acloud.guru/learn/aws-certified-solutions-architect-associate) course.

Exam:

- 130 Minutes in length;
- 65 Questions
- Multiple Choice
- Results are between 100 - 1000 with a passing score of 720
- Aim for 70%

**Availability Zone** is one or many data centers. Each region consists of many AZs.

**Edge location** are endpoints for AWS which are used for caching content. Typically this consists of CloudFront, Amazon's Content, Delivery Network (CDN). There are many edge locations, more than Regions. Over 150 edge locations.

## Compute

## S3 Storage

S3 (Simple Service Storage) - secure, durable, highly-scalable object storage. Amazon S3 is easy to use, with simple web service interface to store and retrieve any amount of data from anywhere on the web.

Charges:

- Storage - more store more pay
- Requests - more requests more pay
- Storage Management Pricing
- Data Transfer Pricing
- Transfer Acceleration
- Cross Regin Replication (replication of buckets from one region to another)

### Storage classes of objects

![Storage pricing](./images/s3-pricing.png)

### Summary

- it's possible to upload a file from 0 bytes to 5 TB;
- there's unlimited storage;
- files are store in the buckets (bucket is a root folder);
- S3 is a universal namespace. That's, names must be unique globally;
- Not suitable to install OS;
- You can turn off MFA Delete;
- Successful uploads returns 200;
- Read after Write consistency for PUTS of new objects. Eventual Consistency for overwrite PUTS and DELETE (can take some time to propagate)

## Databases

## Network & Content Delivery

## Security, Identity & Compliance

IAM (Identity Access Management) allows to manage users and their level of access to the AWS Console.

Key Terminology for IAM:

- users;
- groups are set of users;
- roles are policies for AWS resources;
- policies are set of rules. Usually formatted in JSON format.
