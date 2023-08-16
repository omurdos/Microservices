# Microservices

Project to get more practice and hands one with microservices and DevOps, the two projects I used here are just fictionary project from my day to day activity.
at my current job dealing with Handheld devices. 
The first application (built with .Net Core) is a POS Management system for managing the POS terminals, and the other system (built with Spring boot) is an application
is for the repairing workshop that manages the POS terminal that needs to be repaired.

---

## Architecture
![Architecture](./imgs/architecture.svg)

### How it works

In POSMS all the pos devices details are saved in the database, once any of the devices flag `SendToRepair` is updated to true by sending a PUT request to `http://127.0.0.1/api/devices/{id}`, once the update is saved in the database successfully POSMS will push a message through RabbitMQ that a device has been updated. POS Repair is listening on the same queue it will pickup the message and process it, by sending a request to POSMS system to retreive the device that need to be repaired and save it on the database, to view the list of devices in the POS Repair application you can acess it through sending a GET request to `http://127.0.0.1:8080/api/v1/device` end point

---
## Technologies I used in this project 🧑‍💻
- POS Management
  - .Net Core 6.
  - EF Core.
  - SQL Server
  - Automapper.
  - gRPC.
  - RabbitMQ.
  - Jenkins
- POS Repair
  - Spring Boot 3.
  - Spring Data JPA.
  - Maven.
  - RabbitMQ
  - gRPC
  - Jenkins
  
---
## 💻 Try it out 
I maintained two branches in this repo Master for the applications with docker compose file to run the apps on docker.

1. Download and Install docker [Docker](https://www.docker.com/products/docker-desktop/).
2. Run `docker-compose up` to bring up all the containers.