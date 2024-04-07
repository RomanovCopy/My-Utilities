using OpenHardwareMonitor.Hardware;

Computer computer = new Computer();
computer.Open();
computer.CPUEnabled = true;
computer.GPUEnabled = true;
computer.RAMEnabled = true;
computer.HDDEnabled = true;
computer.MainboardEnabled = true;
foreach(var hardwareItem in computer.Hardware)
{
    hardwareItem.Update();
    Console.WriteLine(hardwareItem.Name);

    if(hardwareItem.HardwareType == HardwareType.CPU)
    {
        foreach(var sensor in hardwareItem.Sensors)
        {
            if(sensor.SensorType == SensorType.Temperature && sensor.Name == "CPU Package")
            {
                Console.WriteLine($"CPU Temperature: {sensor.Value.Value} °C");
            }
        }
    } else if(hardwareItem.HardwareType == HardwareType.GpuNvidia)
    {
        foreach(var sensor in hardwareItem.Sensors)
        {
            if(sensor.SensorType == SensorType.Temperature && sensor.Name == "GPU Core")
            {
                Console.WriteLine($"GPU Temperature: {sensor.Value.Value} °C");
            }
        }
    } else if(hardwareItem.HardwareType == HardwareType.RAM)
    {
        foreach(var sensor in hardwareItem.Sensors)
        {
            if(sensor.SensorType == SensorType.Temperature)
            {
                Console.WriteLine($"RAM Temperature: {sensor.Value.Value} °C");
            }
        }
    } else if(hardwareItem.HardwareType == HardwareType.HDD)
    {
        foreach(var sensor in hardwareItem.Sensors)
        {
            if(sensor.SensorType == SensorType.Temperature)
            {
                Console.WriteLine($"HDD Temperature: {sensor.Value.Value} °C");
            }
        }
    } else if(hardwareItem.HardwareType == HardwareType.Mainboard)
    {
        foreach(var sensor in hardwareItem.Sensors)
        {
            if(sensor.SensorType == SensorType.Temperature)
            {
                Console.WriteLine($"Mainboard Temperature: {sensor.Value.Value} °C");
            }
        }
    }
}

Console.ReadKey();
