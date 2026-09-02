namespace SimpleEncryption;

public interface IEncoderFactory
{
    public IEncoderStrategy CreateEncoder();
}
