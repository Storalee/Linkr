using System;
using System.IO;
using NAudio.Wave;

class Program
{
    static void Main()
    {
        string audioFile = "burger.mp3";


        using (var audioFileReader = new AudioFileReader(audioFile))
        {
            using (var outputDevice = new WaveOutEvent())
            {
                outputDevice.Init(audioFileReader);


                outputDevice.Volume = 1.0f;


                DateTime startTime = DateTime.Now;
                TimeSpan duration = TimeSpan.FromMinutes(5);
                TimeSpan interval = TimeSpan.FromSeconds(2);

                Console.WriteLine($"Lecture de {audioFile} toutes les 4 secondes en boucle avec volume augmenté pendant 5 minutes...");

                while (DateTime.Now - startTime < duration)
                {
                    outputDevice.Play();
                    System.Threading.Thread.Sleep(interval);
                    outputDevice.Stop();
                    audioFileReader.Position = 0;
                }


                outputDevice.Stop();
                outputDevice.Dispose();
            }
        }

        Console.WriteLine("Lecture terminée.");
    }
}
