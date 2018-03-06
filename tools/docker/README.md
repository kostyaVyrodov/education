# Docker

What's Docker?
Docker is a container management service. The keywords of Docker are develop, ship and run anywhere.

## Terms

**Docker Engine:** "Docker engine is the part of Docker which creates and runs Docker containers.

**Docker Hub:** SaaS service for sharing and managing application stacks.

**Docker Compose:** Docker Compose is a tool for defining and running multi-container Docker applications. It uses Yaml files to configure the application's services and performs the creation and start-up process of all the containers with a single command.

Using Compose is basically a three-step process.

1. Define your app's environment with a Dockerfile so it can be reproduced anywhere.
2. Define the services that make up your app in docker-compose.yml so they can be run together in an isolated environment.
3. Lastly, run docker-compose up and Compose will start and run your entire app.

**Docker Image:** In Docker, everything is based on Images.

**Docker file:** The Dockerfile is essentially the build instructions to build the image.

**Docker-compose.yml:** Config. Application’s services.

## Docker composition

- Client - terminal where you enter commands;
- Docker-host - a daemon which accepts commands and handles them (manages containers and images);
- Register(docker-hub) - places where images are stored;

- Images - read-only template of container. (It's a class if to compare it with classes and objects)
- Container is instance of an image. It likes a directory and every container is isolated.