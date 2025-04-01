using Microsoft.JSInterop;

namespace YumBlazor.Extentions;

public static class IJsRuntimeExtensions
{
    public static async Task ToastrSuccess(this IJSRuntime jsRuntime,  string message)
    {
        await jsRuntime.InvokeVoidAsync("ShowToastr", "success", message);
    }
    
    public static async Task ToastrError(this IJSRuntime jsRuntime,  string message)
    {
        await jsRuntime.InvokeVoidAsync("ShowToastr", "error", message);
    }
}