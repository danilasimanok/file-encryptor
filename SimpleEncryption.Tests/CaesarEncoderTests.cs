using SimpleEncryption.Encoders;

namespace SimpleEncryption.Tests;

public class CaesarEncoderTests
{
    [Fact]
    public void CaesarEncoder_InputsAre0b00000011And0b00000001_Return0b00000100()
    {
        CaesarEncoder encoder = new(0b00000011);
        Byte result = encoder.Transform(0b00000001);
        Assert.Equal(0b00000100, result);
    }

    [Fact]
    public void CaesarEncoderWithZeroShiftChangesNothing()
    {
        CaesarEncoder encoder = new(0b00000000);
        Byte result = encoder.Transform(0b00000001);
        Assert.Equal(0b00000001, result);
    }

    [Fact]
    public void CaesarEncoderTransformationIsReversedWithReversedShift()
    {
        CaesarEncoder encoder = new(0b00000011);
        CaesarEncoder decoder = new(0b11111101);
        const Byte input = 0b11110000;
        Byte result = encoder.Transform(input);
        Assert.Equal(input, decoder.Transform(result));
    }
}
