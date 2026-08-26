namespace SimpleEncryption;

public class XorEncoder(Byte key) : IEncoderStrategy
{
    private Byte _key = key;

    public Byte Transform(Byte b)
    {
        return 0b00000001;
    }
}
