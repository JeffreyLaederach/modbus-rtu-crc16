using System;

// To calculate the CRC (Cyclic Redundancy Check) checksum for Serial RS-485 communication, you can use the Modbus RTU CRC-16 algorithm. 
// This algorithm generates two bytes: CRC Low and CRC High, which are appended to the message to ensure data integrity.

class CRC16Calculator
{
    public static ushort ComputeCRC(byte[] data)
    {
        ushort crc = 0xFFFF;

        foreach (byte b in data)
        {
            crc ^= b;

            for (int i = 0; i < 8; i++)
            {
                if ((crc & 0x0001) != 0)
                {
                    crc >>= 1;
                    crc ^= 0xA001;
                }
                else
                {
                    crc >>= 1;
                }
            }
        }

        return crc;
    }

    public static void Main()
    {
        byte[] message = { 0x01, 0x03, 0x00, 0x00, 0x00, 0x0A }; // Example message
        ushort crc = ComputeCRC(message);
        byte crcLow = (byte)(crc & 0xFF);
        byte crcHigh = (byte)((crc >> 8) & 0xFF);

        Console.WriteLine($"CRC Low: {crcLow:X2}, CRC High: {crcHigh:X2}");
    }
}
