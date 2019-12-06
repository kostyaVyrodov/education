# Docker Mastery: with Kubernetes + Swarm from a Docker Captain

Notes written during [this course](https://www.udemy.com/course/docker-mastery/)

**Why do we need a docker?**

Docker allows to deploy an application to various different environments easily. It allows to prevent wasting time for maintenance and solving issues related to specific OS

![The matrix from hell](./images/the-matrix-from-hell.png)

## Commands

Docker command line structure:
- old: `docker <command> (options)`
- new: `docker <command> <sub-command> (option)`

`docker version` allows to verify if cli can talk to engine

`docker info` returns most values of engine

`docker exec <container_id> <command>` runs specified command

### Container commands

`docker container run <image>` runs an image

    - `--publish 80:80` - exposes ports
    - `--detach` - prevents blocking of terminal
    - `--name` - specifies name of container
    - `-t pseudo-tty` - simulates a real terminal, like what ssh does
    - `-i interactive` - keep STDIN open even if not attached

`docker container ls` returns a list of running container

`docker container stop <container_id>` stops a container with specified id

`docker container run <image_name>` always starts a new container

`docker container start <container_id>` starts an existing stopped container

`docket container top <container_name>` list of started processes inside container

`docket container rm <container_id>` remove a container
    - `--force` - allows to rm a running container

`docker container logs <container_id>` returns logs from stdout of a container

`docker container inspect <container_id>` returns detailed information 

`docker container stats` returns performance stats for all containers

`docker container port <container>` returns a list of opened container 

### Network commands

`docker network ls` - show networks
    - `host` network skips virtual network of docker, but sacrifices security of container model
    - `none` removes eth0 and only leaves you with localhost interface in container
    - `bridge` built-in or 3rd party extensions that give you virtual network features

`docker network inspect` inspect a network

`docker network create --driver` create a network

`docker network connect` attach a network to container

`docker network disconnect` detach a network from container

### Image commands

`docker image history <image-tag>` allows to see history of each layer in image

`docker image inspect <image-tag>` returns JSON metadata about the image

`docker image tag <source-image-tag> <target-image-tag>` assigns one or more tags to an image

`docker build -f <dockerfile-path>` build a specific docker file

### Prune

`docker image prune` to clean up just "dangling" images

`docker system prune` will clean up everything

`docker image prune -a` will remove all images you're not using

`docker system df` to see space usage

## Image vs Container

An image is the application we want to run (similar to exe file)

A container is a running instance of image (like a process)

When a developer runs `docker container run`

1. Looks for that image locally in image cache, doesn't find anything
1. Then looks in remote image repository (default to Docker Hub)
1. Downloads the latest version (nginx:latest by default)
1. Creates a new container based on that image and prepares to start
1. Gives it a virtual IP on a private network inside docker engine
1. Start container by using the commands in the image

A container is just process running on a machine. They limited to what resources they can ac cess.

## Image

Image is app binaries and dependencies of your app. Also it contains metadata about the image data and how to run the image 

A docker image consists of layers containing changes. It means, that docker doesn't store an information twice. If one layer used for 2 other images, then base layer exists in file system only as a single copy.

> When you log in to docker hub on someone's machine, then your token is stored in the local docker profile of that machine. Don't forget to log out if you don't trust that machine

### Dockerfile

`FROM` specify base image

`ENV` specify environment variable

`RUN` execute a command inside container itself

`EXPOSE` expose a port on the docker virtual network. It doesn't forward ports to the host

`CMD` is the last command that will be used to launch a container. It's   required

`WORKDIR` change working dir to root of a webhost. Using WORKDIR is preferred to using 'RUN cd /some/path'

> Tip: Combine several related to each other shell commands in a single command inside Dockerfile to prevent creating not useful layers and etc.

> Tip: Less changeable commands should be in the top inside Dockerfile

## Networks

Networks configuration of docker: bridge, 

### Bridge


> Tip: Static IP's and using IP's for talking to containers is an anti-pattern. Do your best to avoid it. IP can be changed

> Tip: Default DNS name of a container is the name of the container
