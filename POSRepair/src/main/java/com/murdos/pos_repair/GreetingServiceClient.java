package com.murdos.pos_repair;

import greet.Greet;
import greet.GreeterGrpc;
import io.grpc.ManagedChannel;
import io.grpc.ManagedChannelBuilder;
import org.springframework.stereotype.Service;

@Service
public class GreetingServiceClient {

    private final GreeterGrpc.GreeterBlockingStub greeterStub;

    public GreetingServiceClient() {
        ManagedChannel channel = ManagedChannelBuilder.forAddress("localhost", 9090)
                .usePlaintext()
                .build();

        greeterStub = GreeterGrpc.newBlockingStub(channel);
    }

    public String sayHello(String name) {
        System.out.println("Sending hello request");
        Greet.HelloRequest request = Greet.HelloRequest.newBuilder().setName(name).build();
        Greet.HelloReply response = greeterStub.sayHello(request);
        System.out.println(response.getAllFields());
        return response.getMessage();
    }
}
