namespace SimpleEncryption;

public class CaesarEncoder(Byte shift) : IEncoderStrategy
{
    private readonly Byte _shift = shift;
    public byte Transform(byte b)
    {
        return (byte) (_shift + b);
    }
}
