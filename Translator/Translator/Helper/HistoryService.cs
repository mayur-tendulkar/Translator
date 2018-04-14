using Newtonsoft.Json;
using PCLStorage;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Translator.Model;

namespace Translator.Helper
{
    public static class HistoryService
    {

        public static async Task<List<TranslateHistory>> ReadHistoryAsync()
        {
            var root = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            
            var folder = new PCLStorage.FileSystemFolder(root, true);
            var file = await folder.CreateFileAsync("translateHistory.txt", CreationCollisionOption.OpenIfExists, default(CancellationToken));
            var data = await file.ReadAllTextAsync();
            return string.IsNullOrEmpty(data) ? new List<TranslateHistory>() : JsonConvert.DeserializeObject<List<TranslateHistory>>(data);
        }

        public static async void SaveHistoryAsync(List<TranslateHistory> history)
        {
            var root = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);

            var folder = new PCLStorage.FileSystemFolder(root, true);
            var file = await folder.CreateFileAsync("translateHistory.txt", CreationCollisionOption.ReplaceExisting, default(CancellationToken));
            await file.WriteAllTextAsync(JsonConvert.SerializeObject(history));
        }
    }
}
