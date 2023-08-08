# Microservices
Project to get more practice and hands one with microservices and DevOps, the two projects I used here are just fictionary project from my day to day activity.
at my current job dealing with Handheld devices. 
The first application (built with .Net Core) is a POS Management system for managing the POS terminals, and the other system (built with Spring boot) is an application
is for the repairing workshop that manages the POS terminal that needs to be repaired.

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

###Run it on docker
1. Download and Install docker [Docker](https://www.docker.com/products/docker-desktop/) 
2. Clone master repo or download as zip file.
3. navigate to any of the projects folder where the docker-compose.yml reside, POSMS or POSRepair directory. 
4. run `docker-compose up` and **walah!🥳** it's running.

###Run it on Kubernetes (K8s) using Minikube.
---
1. Download and Install docker [Docker](https://www.docker.com/products/docker-desktop/) 
2. Install Minikube & kubectl from [Minikube get started](https://minikube.sigs.k8s.io/docs/start/).
3. Navigate to **K8S** directory.
4. Let's deploy:
   1. First we start with the databases
      - from terminal run `kubectl apply -f MSSQL-Deployment.yml`.
      - from terminal run `kubectl apply -f MSSQL-CIP.yml`.
      -  from terminal run `kubectl apply -f Postegresql-Deployment.yml`.
      -  from terminal run `kubectl apply -f Postegresql-CIP.yml`.
    2. Now let deploy our message broker
      -  from terminal run `kubectl apply -f RabbitMQ-Deployment.yml`.
      -  from terminal run `kubectl apply -f RabbitMQ-CIP.yml`.
    3. Deploying the applications
      -  from terminal run `kubectl apply -f POSMS-Deployment.yml`.
      -  from terminal run `kubectl apply -f POSMS-LoadBalancer.yml`.
      -  from terminal run `kubectl apply -f POSRepair-Deployment.yml`.
      -  from terminal run `kubectl apply -f POSRepair-LoadBalancer.yml`.
5. to access any of the application:
   1. Run `Kubectl get services` in the terminal to see the names of the applications services.
   2. run `minikube service posrepairlb --url` to access POSRepair Application.
   3. run `minikube service posms-loadbalancer --url` to access POSMS Application.
  


