# AWS services overview

## Lambda 

Lambda is a compute service based amazon's infrastructure. Your code is a single function running in amazon cloud. All functions are stately

Benefits:
- No need to configure server;
- Autoscaled and always available;
- No need to manage server;
- Adapts to rate of incoming requests;

Can be connected with S3 or DynamoDB

Triggers of lambda function:
- Event based;
- Events from AWS services:
    - S3;
    - DynamoDB;

Pricing:
- Free tier available
    - 1M requests 
    - 3m seconds of compute time
- No usage = no costs!

A lambda function can be triggered by timer

## DynamoDB

DynamoDB is NoSQL database

## S3

S3 is an object storage (blob storage)

## API Gateway

