using SimpleEncryption.Encoders;

namespace SimpleEncryption.Tests.Encoders;

public class VigenereEncoderTests
{
    [Fact]
    public void VigenereEncoderWithOneByteInKeyTransformsLikeCaesarEncoder()
    {
        VigenereEncoder encoder = new([0b00000011]);
        Byte result = encoder.Transform(0b00000001);
        Assert.Equal(0b00000100, result);
    }

    [Fact]
    public void VigenereEncoderShifts()
    {
        Byte[] key = [0b00000001, 0b00000010, 0b00000011];
        Byte[] secret = [0b00000000, 0b00000000, 0b00000000, 0b00000000];
        VigenereEncoder encoder = new(key);
        Byte[] code = new Byte[4];
        for (int i = 0; i < code.Length; ++i)
            code[i] = encoder.Transform(secret[i]);
        Assert.Equal([0b00000001, 0b00000010, 0b00000011, 0b00000001], code);
    }

    [Fact]
    public void VigenereEncoderTransformationIsReversedWithReversedKey()
    {
        Byte[] key = [0b00000001, 0b00000010, 0b00000011];
        Byte[] keyReversed = [0b11111111, 0b11111110, 0b11111101];
        VigenereEncoder encoder = new(key);
        VigenereEncoder decoder = new(keyReversed);

        Byte[] secret = [0b00000001, 0b00000100, 0b00001000, 0b00001000];
        foreach (Byte b in secret)
            Assert.Equal(b, decoder.Transform(encoder.Transform(b)));
    }
}
