using SimpleEncryption.Encoders;

namespace SimpleEncryption.EncoderFactories;

public class XorEncoderFactory : IEncoderFactory
{
    private readonly byte _key;
    public XorEncoderFactory(int key)
    {
        if ((key < 0) || (key > 255))
            throw new ArgumentException("Key should be in [0; 255]");
        _key = (byte) key;
    }

    public IEncoderStrategy CreateEncoder() => new XorEncoder((byte) _key);
}