# The complete networking fundamental course. Your CCNA start

These are notes written during watching [this course](https://www.udemy.com/course/complete-networking-fundamentals-course-ccna-start/)

## Networks basic

Characteristic of a Network:

- topology (bus, ring, star, mesh);
- speed (amount of data that a network can transfer);
- cost;
- security;
- availability;
- scalability and reliability;

OSI layers:
7. Application
6. Presentation
5. Session
4. Transport (sgements)
3. Network (packets)
2. Datalink (frames)
1. Physical (bits)

TCP layers:
4. Application
3. Transport
2. Network
1. Network access

Benefits of layering: a higher level developer doesn't need to know about details of what happening in the lower level

### Terms

**Network interface card** (NIC) is hardware that connects a PC to a computer network. Other names: network interface controller, network adapter, LAN adapter, physical network interface

**Computer network** is a connected via wire computers that can share information with each other

**Network protocol** is a set of rules that governs the communication between devices connected to a computer network

**Router** is a device that move data or information from one interface to another interface based on some kind of decision criteria

**IP address** is numer ic address assigned to each device connected to a network

**Dynamic host configuration protocol (DHCP)** allows dynamically allocate an IP address to a device connected to a network

**Physical network components** are used to create a physical topology explaining a set of physical devices connected to each other. Physical components are set of wires and concrete hardware

**Logical network components** are used to crate a logical topology of a network. Logical components explains how hardware is organized or how it transfers data across network

**DMZ** is a physical or logical subnetwork that contains and exposes an organization's external-facing services to an untrusted, usually larger, network such as the Internet.a

## Tools

`ping <dns name>` is a tool allowing to test if a particular host is reachable

`tracert <dns name>` is a tool showing details about the path that packet takes from the computer you are on to a destination you specify

`ipconfing /all` show details of network configuration
