using System.Text.Json.Serialization;

namespace AssemblyAIQuickstart.Cli
{
    public class UploadResponse
    {
        [JsonPropertyName("upload_url")]
        public string UploadUrl { get; set; }
    }
}