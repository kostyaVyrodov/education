# Docker

What's Docker?
Docker is a container management service. The keywords of Docker are develop, ship and run anywhere.

## Terms

**Docker Engine** is the part of Docker which creates and runs Docker containers.

**Docker Hub** is a SaaS service for sharing and managing application stacks.

**Docker Compose** is a tool for defining and running multi-container Docker applications. It uses Yaml files to configure the application's services and performs the creation and start-up process of all the containers with a single command.

Using Compose is basically a three-step process.

1. Define your app's environment with a Dockerfile so it can be reproduced anywhere.
2. Define the services that make up your app in docker-compose.yml so they can be run together in an isolated environment.
3. Lastly, run docker-compose up and Compose will start and run your entire app.

**Docker Image** is template of a container. It's a package with all the dependencies and information needed to create a container. It's a file comprised of multiple layers, used to execute code in a Docker container

**Docker Container** is a runtime instance of an image--what the image becomes in memory when executed. A list of your running containers ```docker ps```. A container runs natively on Linux and shares the kernel of the host machine with other containers. It runs a discrete process, taking no more memory than any other executable, making it lightweight.

**Docker file** is a text file that contains instructions for how to build a Docker image.

**Build** is an action when docker gets a dockerfile and generates a docker image(package) for future containers.

**Docker-compose.yml** is a config that manages multiple docker images.

**Virtual machine manager** is a software that allows running another OS inside current OS. Example: Virtual box.

**Volumes** is a writable filesystem that the container can use.

## Virtual machine vs docker containers

Virtual machines include the application, the required libraries or binaries, and a full guest operating system. Full virtualization requires more resources than containerization.

Containers include the application and all its dependencies. However, they share the OS kernel with other containers, running as isolated processes in user space on the host operating system. (Except in Hyper-V containers, where each container runs inside of a special virtual machine per container.) Because containers require far fewer resources (for example, they don’t need a full OS), they’re easy to deploy and they start fast.

## .NET core vs classic .NET for docker

.NET core when: app is crossplatform, app is based on microservices.

Classic .NET when: app has already had strong dependency on Windows and packages that are not available for .NET core. When you need to use Windows API.

## Docker composition

- Client - terminal where you enter commands;
- Docker-host - a daemon which accepts commands and handles them (manages containers and images);
- Register(docker-hub) - places where images are stored;

- Images - read-only template of container. (It's a class if to compare it with classes and objects)
- Container is instance of an image. It likes a directory and every container is isolated. Containers work inside container engine, not inside os.

## Container design principles

- a container image instance represents a single process. A container can represent a long running job (like web server) or short running job (a batch operation).

## Docker commands
- ```docker -it ubuntu bash``` - download ubuntu image, run it and connect to it through terminal
