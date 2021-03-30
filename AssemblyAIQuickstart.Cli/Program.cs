using System;
using System.Threading.Tasks;

namespace AssemblyAIQuickstart.Cli
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Please give me the path to your audio file.");
            var pathToAudioFile = Console.ReadLine();

            var transcriber = new TranscriptionService();

            var text = await transcriber.Transcribe(pathToAudioFile);
            Console.WriteLine(text);
            Console.ReadKey();
        }
    }
}