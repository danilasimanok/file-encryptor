using System.Collections;

namespace SimpleEncryption;

public class VigenereEncoder(Byte[] key) : IEncoderStrategy
{
    private readonly Byte[] _key = key;
    private int _shift = 0;

    public byte Transform(byte b)
    {
        Byte result = (byte) (_key[_shift] + b);
        _shift = (_shift + 1) % _key.Length;
        return result;
    }
}
