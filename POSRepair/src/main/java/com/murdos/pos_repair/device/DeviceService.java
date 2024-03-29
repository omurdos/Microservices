package com.murdos.pos_repair.device;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class DeviceService {
    @Autowired
    private DeviceRepository deviceRepository;
    @Autowired
    private DeviceServiceClient deviceServiceClient;
    public DeviceService(){

    }

    public List<Device> getAllDevices(){
        return  deviceRepository.findAll();
    }
}
