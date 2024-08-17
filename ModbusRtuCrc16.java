public class CRC16Modbus {
public static int calculateCRC(byte[] data) {
    int crc = 0xFFFF; 
    for (byte b : data) {
        crc ^= b & 0xFF;
        for (int i = 0; i < 8; i++) {
            if ((crc & 0x0001) != 0) {
                crc >>= 1;
                crc ^= 0xA001; 
            } else {
                crc >>= 1;
            }
        }
    }
    return crc & 0xFFFF; 
}

public static void main(String[] args) {
    String dataString = "";
    byte[] data = dataString.getBytes();
    int crcValue = calculateCRC(data);
    System.out.printf("The CRC-16/MODBUS value is: %04X%n", crcValue);
}