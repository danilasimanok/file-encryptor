using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace FileTransformer.ViewModels;

public partial class MainViewModel(FilePickerService filePickerService) : ObservableObject
{
    [ObservableProperty]
    public partial int ShortKey { get; set; } = 0;

    [ObservableProperty]
    public partial string LongKey { get; set; } = "Secret Key";

    [ObservableProperty]
    public partial string ChosenFile { get; set; } = String.Empty;

    [RelayCommand]
    public async Task SelectFileAsync()
    {
        ChosenFile = await filePickerService.PickFileAsync();
    }
}
