using System;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Platform.Storage;

namespace FileTransformer.ViewModels;

public class FilePickerService(TopLevel topLevel)
{
    public async Task<string> PickFileAsync()
    {
        var files = await topLevel.StorageProvider.OpenFilePickerAsync(
            new FilePickerOpenOptions
            {
                Title = "Select a file",
                AllowMultiple = false
            });

        return files.Count > 0
            ? files[0].Path.LocalPath
            : String.Empty;
    }
}
