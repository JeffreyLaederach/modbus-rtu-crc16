function Calculate-CRC16 {
    param (
        [byte[]]$data
    )

    $crc = 0xFFFF

    foreach ($byte in $data) {
        $crc = $crc -bxor $byte
        for ($i = 0; $i -lt 8; $i++) {
            if ($crc -band 0x0001) {
                $crc = ($crc -shr 1) -bxor 0xA001
            } else {
                $crc = $crc -shr 1
            }
        }
    }

    # Swap high and low bytes
    $crc = (($crc -shr 8) -bor (($crc -shl 8) -band 0xFF00))

    return $crc
}

# Example usage
$data = [byte[]](0x18,0x0E,0x6A,0xFF,0xFF,0x8c,0x01,0xFF,0xFF,0xFF)
$crc = Calculate-CRC16 -data $data
"{0:X4}" -f $crc
