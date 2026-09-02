using SimpleEncryption.EncoderFactories;

namespace SimpleEncryption.Tests.EncoderFactories;

public class CaesarEncoderFactoryTests
{
    [Fact]
    public void CaesarEncoderFactoryDoesntAllowKeysWithAbsGreaterThan255()
    {
        Assert.Throws<ArgumentException>(() => new CaesarEncoderFactory(-256));
        Assert.Throws<ArgumentException>(() => new CaesarEncoderFactory(256));
    }

    [Fact]
    public void CaesarEncoderFactoryCreatesEncoderAndDecoder()
    {
        CaesarEncoderFactory encoderFactory = new(13);
        CaesarEncoderFactory decoderFactory = new(-13);
        const byte code = 0b01011001;
        var encoder = encoderFactory.CreateEncoder();
        var decoder = decoderFactory.CreateEncoder();
        Assert.Equal(code, decoder.Transform(encoder.Transform(code)));
    }
}
