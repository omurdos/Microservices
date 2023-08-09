package com.murdos.pos_repair.device;

import com.fasterxml.jackson.databind.ObjectMapper;
import com.murdos.pos_repair.dto.DeviceRepairDTO;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

import java.io.IOException;
import java.nio.charset.StandardCharsets;

@Component
public class Receiver {

    @Autowired
    private DeviceServiceClient deviceServiceClient;
    @Autowired
    private DeviceRepository deviceRepository;
    ObjectMapper objectMapper = new ObjectMapper();
    public void receiveMessage(byte[] message) throws IOException {
        var temp = new String(message, StandardCharsets.UTF_8);
        System.out.println("Received <" + temp + ">");
        DeviceRepairDTO dto = objectMapper.readValue(message, DeviceRepairDTO.class);
        var device = deviceServiceClient.getDeviceDetails(dto.getId());
        deviceRepository.save(device);
    }


}
