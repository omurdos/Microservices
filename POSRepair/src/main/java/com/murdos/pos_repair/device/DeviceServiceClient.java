package com.murdos.pos_repair.device;
import com.murdos.grpc.service.device.DeviceServiceGrpc;
import com.murdos.grpc.service.device.DeviceServiceOuterClass;
import io.grpc.ManagedChannel;
import io.grpc.ManagedChannelBuilder;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.core.env.Environment;
import org.springframework.stereotype.Service;

@Service
public class DeviceServiceClient {
    private  DeviceServiceGrpc.DeviceServiceBlockingStub deviceServiceBlockingStub;
    private  ManagedChannel channel;
    private Environment env;
    DeviceServiceClient(){}
    @Autowired
    DeviceServiceClient(Environment env){

        this.env = env;
         channel = ManagedChannelBuilder.forAddress(env.getProperty("grpc.server.address"),  Integer.parseInt(env.getProperty("grpc.server.port")))
                .usePlaintext()
                .build();
        deviceServiceBlockingStub = DeviceServiceGrpc.newBlockingStub(channel);
    }

    public Device getDeviceDetails(String id) {
        System.out.println("Sending a grpc request to get");
        DeviceServiceOuterClass.DeviceRequest request
                = DeviceServiceOuterClass.DeviceRequest.newBuilder().setId(id).build();
        DeviceServiceOuterClass.DeviceResponse response = deviceServiceBlockingStub.getDeviceDetails(request);

        System.out.println(response.getAllFields());
        var grpcDevice = response.getDevice();
        System.out.println(grpcDevice);

        return new Device(grpcDevice.getId(), grpcDevice.getManufacturer(), grpcDevice.getModel(), grpcDevice.getSerialNumber(), grpcDevice.getIMEI(), grpcDevice.getSendToRepair());
    }
}
