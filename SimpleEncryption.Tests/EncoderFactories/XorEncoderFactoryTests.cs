using SimpleEncryption.EncoderFactories;

namespace SimpleEncryption.Tests.EncoderFactories;

public class XorEncoderFactoryTests
{
    [Fact]
    public void XorEncoderFactoryDoesntAllowNegativeKeysOrKeysGreaterThan255()
    {
        Assert.Throws<ArgumentException>(() => new XorEncoderFactory(-1));
        Assert.Throws<ArgumentException>(() => new XorEncoderFactory(256));
    }

    [Fact]
    public void XorEncoderFactoryCreatesEncoderAndDecoder()
    {
        XorEncoderFactory factory = new(13);
        const byte code = 0b01011001;
        var encoder = factory.CreateEncoder();
        var decoder = factory.CreateEncoder();
        Assert.Equal(code, decoder.Transform(encoder.Transform(code)));
    }
}
