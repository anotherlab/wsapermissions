using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Storage;

namespace WsaPermissions;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
	}

	private async void OnFolderBtnClicked(object sender, EventArgs e) {
        CancellationTokenSource source = new();
        CancellationToken cancellationToken = source.Token;
        var folderPickerResult = await FolderPicker.PickAsync(cancellationToken);
        if (folderPickerResult.IsSuccessful) {
            await Toast.Make($"Folder picked: Name - {folderPickerResult.Folder.Name}, Path - {folderPickerResult.Folder.Path}", ToastDuration.Long).Show(cancellationToken);
        }
        else {
            await Toast.Make($"Folder is not picked, {folderPickerResult.Exception.Message}").Show(cancellationToken);
        }
    }
}

