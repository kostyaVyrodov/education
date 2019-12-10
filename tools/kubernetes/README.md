# Kubernetes

Kubernetes is popular container orchestrator that allows to many servers act like one. Release by Google in 2015. It runs on top of Docker as a set of APIs in containers. Provides API/CLI to manage containers across server

Terms:

- **kubernetes** is whole orchestration system;
- **kubectl** is CLI to configure and manage apps;
- **kubelet** is agent running on nodes (slave nodes);
- **node** is a single service in the kubernetes cluster;
- **control plane** is set of container that manage the cluster (master nodes). Includes API server, scheduler, controller manager, etcd and more;
- **pod** is one or more containers running together on one node. It's a basic unit of deployment. Containers are always in pods;
- **controller** is an object used for creating\updating pods and other objects. You manipulate the pods via controllers, not directly;
- **service** is network endpoint to connect to a pod;
- **namespace** is filtered group of objects in cluster;

Base commands:

- `kubectl run` change to be only for pod creation (similar to docker run);
- `kubectl create` create some resources via CLI or YAML (similar to docker create);
- `kubectl apply` create or update anything via YAML (similar to docker stack deploy);

### Commands

`kubectl run <name> --image nginx` run a pod of nginx web service. Under hood it's create a pod, replica set and deployment

`kubectl get pods` show list of pods

`kubectl get all` show all objects including pods, controllers and replica set

`kubectl delete deployment <name>` remove deployment

`kubectl scale deploy/<name> --replicas 2` scale pods

`kubectl describe pod/<pod-fullname1> pod/<pod-fullname2>`

`kubectl expose` create a service for existing pod. It's a stable address for pod(s), so if we want to connect to pod(s), we need a service

`kubectl expose <deployment-name> --port 8888` create clusterIP service

`kubectl expose <deployment-name> --port 8888 --name <name-of-service> --type NodePort` create NodePort service

`kubectl run --generator=run-pod/v1 tmp-shell --rm -it --image <image-name> -- bash` create pod and stay inside there

### Pods, Controllers, ReplicaSet and Services

A Pod wraps a docker containers. Controllers wrap pods via a ReplicaSet and controller manages replicas using ReplicaSet

Types of services:

- ClusterIP (default). Allow nodes and other pods to access each other inside the cluster, but it's not possible to talk to pods outside cluster
- NodePort. NodePort creates ClusterIP under the hood.
- LoadBalancer. LoadBalancer creates NodePort under the hood.
- ExternalName

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
