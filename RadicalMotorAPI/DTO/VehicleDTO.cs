﻿public class VehicleDTO
{
    public string ChassisNumber { get; set; }
    public string VehicleName { get; set; }
    public DateTime EntryDate { get; set; }
    public string Price { get; set; }
    public string Version { get; set; }
    public string VehicleTypeId { get; set; }
	public string VehicleType { get; set; }
	public List<string> ImageUrls { get; set; }
}
