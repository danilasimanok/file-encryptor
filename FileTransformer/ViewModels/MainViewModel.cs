using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

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

    [RelayCommand]
    public async Task SelectFileAsync()
    {
        _inputFile = await filePickerService.PickFileToOpenAsync();
        ChosenFile = _inputFile is null ? String.Empty : _inputFile.LocalPath;
    }

    [RelayCommand]
    public async Task ProcessFile()
    {
        _outputFile = await filePickerService.PickFileToSaveAsync();
        Console.WriteLine($"Transform: {TransformationIndex}, File name: {_outputFile?.LocalPath}");
    }
}
