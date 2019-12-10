# Kubernetes

Kubernetes is popular container orchestrator that allows to many servers act like one. Release by Google in 2015. It runs on top of Docker as a set of APIs in containers. Provides API/CLI to manage containers across server

Terms:

- **kubernetes** is whole orchestration system;
- **kubectl** is CLI to configure and manage apps;
- **node** is a single service in the kubernetes cluster;
- **kubelet** is agent running on nodes (slave nodes);
- **control plane** is set of container that manage the cluster (master nodes). Includes API server, scheduler, controller manager, etcd and more;
- **pod** is one or more containers running together on one node. It's a basic unit of deployment. Containers are always in pods;
- **controller** is an object used for creating\updating pods and other objects. You manipulate the pods via controllers, not directly;
- **service** is network endpoint to connect to a pod;
- **namespace** is filtered group of objects in cluster;

Base commands:

- `kubectl run` change to be only for pod creation (similar to docker run);
- `kubectl create` create some resources via CLI or YAML (similar to docker create);
- `kubectl run` create or update anything via YAML (similar to docker stack deploy);

## Kubernetes vs Swarm

Both solutions are orchestration tools. Swarm is easier to deploy and manage, but kubernetes has more flexibility

Swarm:

- comes with Docker, single vendor container platform;
- easiest orchestrator to deploy/manage yourself;
- follows 80/20 rule, 20% of features for 80% of use case;
- runs anywhere Docker does: local, cloud, data center, arm, Windows, 32 bit;
- secure by default;
- easier to troubleshoot;

Kubernetes: 

- it's very popular on clouds, so it will be there out of box;
- covers widest set of use cases;

## Kubernetes services

**Exposing containers** 
