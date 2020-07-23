using System;
using System.Threading.Tasks;
using BrowserInterop.Extensions;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace GooglePayment
{
    public static class JSRuntimeExtensions
    {
        private static GooglePayClient? _client;

        public static async ValueTask<GooglePayClient> GetGooglePayClientAsync(this IJSRuntime jsRuntime)
        {
            if (_client != null)
            {
                return _client;
            }

            var jsObjRef = await jsRuntime.InvokeAsync<JsRuntimeObjectRef>("getGooglePaymentsClient");
            _client = new GooglePayClient(jsRuntime, jsObjRef);
            return _client; 
        }
    }
}