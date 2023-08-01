package com.murdos.pos_repair.device;

import jakarta.persistence.*;

@Entity
@Table
public class Device {
    @Id
    private String id;
    private String manufacturer;
    private String model;
    private String serialNumber;
    private String imei;
    private boolean sendToRepair;

    public Device(){};
    public Device(String id, String manufacturer, String model, String serialNumber, String imei, boolean sendToRepair) {
        this.id = id;
        this.manufacturer = manufacturer;
        this.model = model;
        this.serialNumber = serialNumber;
        this.imei = imei;
        this.sendToRepair = sendToRepair;
    }

    public Device(String manufacturer, String model, String serialNumber, String imei, boolean sendToRepair) {
        this.manufacturer = manufacturer;
        this.model = model;
        this.serialNumber = serialNumber;
        this.imei = imei;
        this.sendToRepair = sendToRepair;
    }

    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }

    public String getManufacturer() {
        return manufacturer;
    }

    public void setManufacturer(String manufacturer) {
        this.manufacturer = manufacturer;
    }

    public String getModel() {
        return model;
    }

    public void setModel(String model) {
        this.model = model;
    }

    public String getSerialNumber() {
        return serialNumber;
    }

    public void setSerialNumber(String serialNumber) {
        this.serialNumber = serialNumber;
    }

    public String getImei() {
        return imei;
    }

    public void setImei(String imei) {
        this.imei = imei;
    }

    public boolean isSendToRepair() {
        return sendToRepair;
    }

    public void setSendToRepair(boolean sendToRepair) {
        this.sendToRepair = sendToRepair;
    }
}
