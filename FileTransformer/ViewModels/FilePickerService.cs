using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Platform.Storage;

namespace FileTransformer.ViewModels;

public class FilePickerService(TopLevel topLevel)
{
    public async Task<Uri?> PickFileToOpenAsync()
    {
        var files = await topLevel.StorageProvider.OpenFilePickerAsync(
            new FilePickerOpenOptions
            {
                Title = "Select a file",
                AllowMultiple = false
            });
        return files.Count > 0 ? files[0].Path : null;
    }

    public async Task<Uri?> PickFileToSaveAsync()
    {
        var file = await topLevel.StorageProvider.SaveFilePickerAsync(
            new FilePickerSaveOptions
            {
                Title = "Select a file",
                SuggestedFileName = "converted"
            });
        return file?.Path;
    }
}
