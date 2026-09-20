using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SimpleEncryption;
using SimpleEncryption.EncoderFactories;

namespace FileTransformer.ViewModels;

public partial class MainViewModel(FilePickerService filePickerService) : ObservableObject
{
    [ObservableProperty]
    public partial int TransformationIndex { get; set; } = 0;

    [ObservableProperty]
    public partial int ShortKey { get; set; } = 0;

    [ObservableProperty]
    public partial string LongKey { get; set; } = "Secret Key";

    [ObservableProperty]
    public partial string ChosenFile { get; set; } = String.Empty;
    private Uri? _inputFile;
    private Uri? _outputFile;

    [ObservableProperty]
    public partial string Result { get; set; } = String.Empty;

    [RelayCommand]
    public async Task SelectFileAsync()
    {
        _inputFile = await filePickerService.PickFileToOpenAsync();
        ChosenFile = _inputFile is null ? String.Empty : _inputFile.LocalPath;
    }

    private IEncoderFactory GetFactory()
    {
        return TransformationIndex switch
        {
            0 => new XorEncoderFactory(ShortKey),
            1 => new CaesarEncoderFactory(ShortKey),
            2 => new VigenereEncoderFactory(LongKey),
            3 => new VigenereDecoderFactory(LongKey),
            _ => throw new UnreachableException()
        };

    }


    [RelayCommand]
    public async Task ProcessFile()
    {
        try 
        {
            _outputFile = await filePickerService.PickFileToSaveAsync();

            var inputStream = File.OpenRead(_inputFile.LocalPath);
            var outputStream = File.Create(_outputFile.LocalPath);
            var encoder = GetFactory().CreateEncoder();

            byte[] buffer = new byte[1024];
            int readLength;
            while ((readLength = inputStream.Read(buffer, 0, buffer.Length)) > 0)
            {
                for (int i = 0; i < readLength; ++i)
                    buffer[i] = encoder.Transform(buffer[i]);
                outputStream.Write(buffer, 0, readLength);
            }

            inputStream.Close();
            outputStream.Close();

            Result = "Ok";
        }
        catch (Exception e)
        {
            Result = e.ToString();
        }
    }
}
