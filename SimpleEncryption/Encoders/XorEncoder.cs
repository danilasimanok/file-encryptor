namespace SimpleEncryption.Encoders;

public class XorEncoder(Byte key) : IEncoderStrategy
{
    private readonly Byte _key = key;

    public Byte Transform(Byte b)
    {
        return (byte) (_key ^ b);
    }
}
