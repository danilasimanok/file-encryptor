using SimpleEncryption.Encoders;

namespace SimpleEncryption.Tests.Encoders;

public class XorEncoderTests
{
    private readonly XorEncoder _xorEncoder;

    public XorEncoderTests()
    {
        _xorEncoder = new XorEncoder(0b11000001);
    }


    [Fact]
    public void XorEncoder_InputsAre0b11000001And0b11001001_Return0b00001000()
    {
        Byte result = _xorEncoder.Transform(0b11001001);
        Assert.Equal(0b00001000, result);
    }

    [Fact]
    public void XorWithItselfReturnsZero()
    {
        Byte result = _xorEncoder.Transform(0b11000001);
        Assert.Equal(0b00000000, result);
    }

    [Fact]
    public void XorRevertsItself()
    {
        const Byte input = 0b00101011;
        Byte result = _xorEncoder.Transform(input);
        Assert.Equal(input, _xorEncoder.Transform(result));
    }
}
