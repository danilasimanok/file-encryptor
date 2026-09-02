using SimpleEncryption.Encoders;

namespace SimpleEncryption.EncoderFactories;

public class CaesarEncoderFactory : IEncoderFactory
{
    private readonly Byte _shift;
    public CaesarEncoderFactory(int shift)
    {
        if ((shift < -255) || (shift > 255))
            throw new ArgumentException("abs(shift) should be less then 256");
        if (shift > 0)
            _shift = (byte) shift;
        else
            _shift = (byte) (256 + shift);
    }

    public IEncoderStrategy CreateEncoder() => new CaesarEncoder(_shift);
}
