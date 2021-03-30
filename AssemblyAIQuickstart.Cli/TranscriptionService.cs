using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace AssemblyAIQuickstart.Cli
{
    public class TranscriptionService
    {
        private HttpClient _httpClient;
        private string _apiKey;
        
        public TranscriptionService()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://api.assemblyai.com/v2/");
            _apiKey = Environment.GetEnvironmentVariable("ASSEMBLYAI_API_KEY", EnvironmentVariableTarget.User);
            _httpClient.DefaultRequestHeaders.Add("Authorization", _apiKey);
        }
        
        public async Task<string> Transcribe(string pathToAudioFile)
        {
            throw new NotImplementedException();
        } 

       
     }
}