using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Translator.Helper
{
    static class TranslateService
    {
        private const string SecretKey = "{insert-your-key-here}";
        private static string AccessToken = string.Empty;
        public static async Task<string> TranslateText(string textToTranslate, string languageCode)
        {
            var textToReturn = string.Empty;
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", SecretKey);
            var data = await client.PostAsync("https://api.cognitive.microsoft.com/sts/v1.0/issueToken", new StringContent(""));
            AccessToken = data.Content.ReadAsStringAsync().Result;
            client.DefaultRequestHeaders.Clear();
            var authHeader = "Bearer " + AccessToken;
            var translateEndpoint = "http://api.microsofttranslator.com/v2/Http.svc/Translate?text='" + textToTranslate + "'&to= " + languageCode;
            client.DefaultRequestHeaders.Add("Authorization", authHeader);
            var result = await client.GetStringAsync(translateEndpoint);
            var xTranslation = XDocument.Parse(result);
            textToReturn = xTranslation.Root?.FirstNode.ToString();
            return textToReturn;
        }
    }
}
