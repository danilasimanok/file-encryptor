using System.Text;
using SimpleEncryption.Encoders;

namespace SimpleEncryption.EncoderFactories;

public class VigenereDecoderFactory : IEncoderFactory
{
    private readonly Byte[] _key;
    public VigenereDecoderFactory(string key)
    {
        if (String.IsNullOrEmpty(key))
            throw new ArgumentException("Key should not be empty");

        _key = Encoding.Default.GetBytes(key);
        for (int i = 0; i < _key.Length; ++i)
            _key[i] = (byte) (256 - _key[i]);
    }

    public IEncoderStrategy CreateEncoder() => new VigenereEncoder(_key);
}
