#
# Build stage
#
FROM maven:3.9.3-amazoncorretto-17-debian AS build
COPY src /home/app/src
COPY pom.xml /home/app
RUN mvn -f /home/app/pom.xml clean package

#
# Package stage
#
FROM unitfinance/jdk17-sbt-scala
COPY --from=build /home/app/target/POSRepair-0.0.1-SNAPSHOT.jar /usr/local/lib/POSRepair.jar
EXPOSE 8080
EXPOSE 9090
ENTRYPOINT ["java","-jar","/usr/local/lib/POSRepair.jar"]