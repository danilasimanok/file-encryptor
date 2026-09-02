using SimpleEncryption.EncoderFactories;

namespace SimpleEncryption.Tests.EncoderFactories;

public class VigenereEncoderFactoryTests
{
    [Fact]
    public void VigenereEncoderAndDecoderFactoriesDontAllowEmptyKeys()
    {
        Assert.Throws<ArgumentException>(() => new VigenereEncoderFactory(""));
        Assert.Throws<ArgumentException>(() => new VigenereDecoderFactory(""));
    }

    [Fact]
    public void VigenereEncoderAndDecoderFactoriesCreateEncoderAndDecoder()
    {
        const string key = "secret";
        VigenereEncoderFactory encoderFactory = new(key);
        VigenereDecoderFactory decoderFactory = new(key);
        const byte code = 0b01011001;
        var encoder = encoderFactory.CreateEncoder();
        var decoder = decoderFactory.CreateEncoder();
        Assert.Equal(code, decoder.Transform(encoder.Transform(code)));
    }
}
