package com.murdos.pos_repair.device;

import com.murdos.pos_repair.GreetingServiceClient;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class DeviceService {
    @Autowired
    private DeviceRepository deviceRepository;
    @Autowired
    private GreetingServiceClient greetingServiceClient;
    @Autowired
    private DeviceServiceClient deviceServiceClient;
    public DeviceService(){

    }
    
    public List<Device> getAllDevices(){
        return  deviceRepository.findAll();
    }
}
