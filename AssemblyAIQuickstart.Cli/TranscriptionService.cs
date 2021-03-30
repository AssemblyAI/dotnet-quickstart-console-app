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
            var url = await Upload(pathToAudioFile);
            var id = await Transcription(url);
            var text = await Download(id);
            return text;
        } 

        private async Task<string> Upload(string pathToAudioFile)
        {
         
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Post,"upload");
                request.Headers.Add("Transfer-Encoding", "chunked");
                request.Headers.Add("Authorization", _apiKey);

                var fileReader = System.IO.File.OpenRead(pathToAudioFile);
                var streamContent = new StreamContent(fileReader);
                request.Content = streamContent;
                HttpResponseMessage response = await _httpClient.SendAsync(request);
                var contentResponse = await response.Content.ReadAsStringAsync();
                var jsonResult = JsonSerializer.Deserialize<UploadResponse>(contentResponse);
                
                return jsonResult?.UploadUrl;
            } catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return string.Empty;
            }	
          
        }
        
       

        private async Task<string> Transcription(string url)
        {
            TranscribeResponse jsonResult = new (){Status = "unset"};
            
            var json = new
            {
                audio_url = url
            };

            StringContent payload = new StringContent(JsonSerializer.Serialize(json), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync("transcript", payload);
            var contentResponse = await response.Content.ReadAsStringAsync();
            jsonResult = JsonSerializer.Deserialize<TranscribeResponse>(contentResponse);
            
            if (jsonResult.Status == "error") return $"Something went wrong with your transcription: {jsonResult.Error}";
            
            return jsonResult.Id;

        }

        public async Task<string> Download(string id)
        {
            _httpClient.DefaultRequestHeaders.Add("Accepts", "application/json");

            TranscribeResponse jsonResult = new (){Status = "unset"};
            do
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"transcript/{id}");

                var contentResponse = await response.Content.ReadAsStringAsync();
                jsonResult = JsonSerializer.Deserialize<TranscribeResponse>(contentResponse);
                if (jsonResult.Status == "error") return $"Something went wrong with your transcription: {jsonResult.Error}";

            } while (jsonResult.Status != "completed");

            return jsonResult.Text;
        }
     }
}