package com.murdos.pos_repair.dto;


import com.fasterxml.jackson.annotation.JsonProperty;

public class DeviceRepairDTO {
    @JsonProperty(value = "Id")
    private String id;
    @JsonProperty(value = "Event")
    private String event;

    public DeviceRepairDTO() {
    }

    public DeviceRepairDTO(String id, String event) {
        this.id = id;
        this.event = event;
    }

    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }

    public String getEvent() {
        return event;
    }

    public void setEvent(String event) {
        this.event = event;
    }
}
