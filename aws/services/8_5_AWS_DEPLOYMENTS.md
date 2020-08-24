# Deployment

## Elastic Beanstalk

- PaaS that allows to manage code without huge admin overhead. Similar to CloudFormation, but no need to know deep details
- application is base entity of beanstalk
- application -> environments. 1 App may have multiple environments

Use case:
- to provision env with little admin overhead
- you use 1 of the supported languages and can add EB-specific config
- when using a supported runtime

Not use case:
- you need low level control of infrastructure
- you need Chef support

**Deployment options:**

- All at once: single version of app deployed to all instances. Not recommended for prod
- Rolling: split instances into batches and deploy app to batch at a time
- Rolling with additional batch: create a new batch, test it and deploy instead
- Blue\Green: deploy a new instance and swap CNAME

## OpsWorks

- Chef11 - Linux based
- Chef12 - Linux + Windows
- cookbooks require a repository
- Chef recipes handle tasks such as installing packages on instances, deploying apps and running scripts.
- uses IAM permissions to interact with different components of AWS
- Unlike CloudFormation, stacks are configured and not created by templates.
