using System.Text;
using SimpleEncryption.Encoders;

namespace SimpleEncryption.EncoderFactories;

public class VigenereEncoderFactory : IEncoderFactory
{
    private readonly Byte[] _key;
    public VigenereEncoderFactory(string key)
    {
        if (String.IsNullOrEmpty(key))
            throw new ArgumentException("Key should not be empty");
        _key = Encoding.Default.GetBytes(key);
    }

    public IEncoderStrategy CreateEncoder() => new VigenereEncoder(_key);
}
