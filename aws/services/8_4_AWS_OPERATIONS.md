# AWS Events

## Cloud Watch Events

- sees events in real time which happening in AWS account (security group change and etc)
- similar to CloudTrail, but CloudWatch Events allows to do actions based on Events. CloudTrail is just auditing tool
- CloudWatch Events based on rules that allows to map data on your events
- Common use case: turn off EC2 in night to prevent charging money
- Cloud watch events monitors events and performs actions on targets
- Use cloud watch event to turn off or turn on something in time

## KMS Essentials

- KMS provides reginal key management, encryption\decryption services
- **FIPS 140-2 level 2** validated - it's about **KMS**
- **FIPS 140-2 level 3** validated - it's about **CloudHSM**
- KMS console allows to manage CMK (Customer Master Key)
- KMS is capable to perform encryption operation on data up to 4KB
- encrypted data has a link to the key encrypted this data, so you don't need to specify concrete key when you decrypt data
- KMS provides feature to re encrypt data. You provide a new key, it decrypts the data and encrypts it again with a new key and you don't see original data. It's possible to grant access to a user to only reencrypt data
- DEK - data encryption key allows to work with data larger than 4KB
- DEK provides 2 keys: in plain view and encrypted. Encrypted key can be stored near the data
- CoudHSM provides a dedicated host per customer. KMS shares the host between customers
- CMS -> DEK

CMK types:
- **AWS Managed CMK** aws creates a key and manages it
- **Customer Managed CMK** you create a key and manages it
- **AWS owned CMK** aws creates and manages these keys, but you don't see them

