using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AssemblyAIQuickstart.Cli
{
    public class TranscribeResponse
    {
        [JsonPropertyName("id")] public string Id { get; set; }

        [JsonPropertyName("status")] public string Status { get; set; }

        [JsonPropertyName("acoustic_model")]
        public string AcousticModel { get; set; }

        [JsonPropertyName("audio_duration")] public double? AudioDuration { get; set; }

        [JsonPropertyName("audio_url")] public string AudioUrl { get; set; }

        [JsonPropertyName("confidence")] public double? Confidence { get; set; }

        [JsonPropertyName("dual_channel")] public bool? DualChannel { get; set; }

        [JsonPropertyName("format_text")] public bool FormatText { get; set; }

        [JsonPropertyName("language_model")]
        public string LanguageModel { get; set; }

        [JsonPropertyName("punctuate")] public bool Punctuate { get; set; }

        [JsonPropertyName("text")] public string Text { get; set; }

        [JsonPropertyName("utterances")] public IEnumerable<Utterance> Utterances { get; set; }

        [JsonPropertyName("webhook_status_code")]
        public string WebhookStatusCode { get; set; }

        [JsonPropertyName("webhook_url")] public string WebhookUrl { get; set; }

        [JsonPropertyName("words")] public IEnumerable<Words> Words { get; set; }

        [JsonPropertyName("auto_highlights_result")]
        public AutoHighlightsResult AutoHighlightsResult { get; set; }
        
        [JsonPropertyName("error")] public string Error { get; set; }
    }

    public class AutoHighlightsResult
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }
        
        [JsonPropertyName("results")]
        public IEnumerable<HighlightResult> Results { get; set; }
    }
    
    public class HighlightResult
    {
        [JsonPropertyName("count")]
        public int Count { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("rank")]
        public decimal Rank { get; set; }

        [JsonPropertyName("timestamps")]
        public TimeStamp Timestamps { get; set; }
       
    }
    
    public class TimeStamp
    {
        [JsonPropertyName("start")]
        public int Start { get; set; }
        
        [JsonPropertyName("end")]
        public int End { get; set; }
    }
    public class Utterance
    {
        [JsonPropertyName("speaker")] public string Speaker { get; set; }

        [JsonPropertyName("confidence")] public float Confidence { get; set; }

        [JsonPropertyName("end")] public int End { get; set; }

        [JsonPropertyName("start")] public int Start { get; set; }

        [JsonPropertyName("text")] public string Text { get; set; }

        [JsonPropertyName("words")] public IEnumerable<Words> Words { get; set; }
    }
    public class Words
    {
        [JsonPropertyName("confidence")]
        public double Confidence { get; set; }

        [JsonPropertyName("end")]
        public int End { get; set; }

        [JsonPropertyName("start")]
        public int Start { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; }
		
        [JsonPropertyName("speaker")]
        public string Speaker { get; set; }
    }
}