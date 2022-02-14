using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace ExampleJWT.UI.Helpers
{
    public class LocalStorageManager
    {
        public async Task SaveLocalStorage(string key, string value, ProtectedLocalStorage storage)
        {
            await storage.SetAsync(key, value);
        }

        public async Task<string> ReadToken(string key, ProtectedLocalStorage storage)
        {
            var result = await storage.GetAsync<string>(key);
            return result.Success ? result.Value : "";
        }

        public async Task Delete(string key, ProtectedLocalStorage storage)
        {
            await storage.DeleteAsync(key);
        }

    }
}
