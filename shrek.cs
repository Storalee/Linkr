using System;
using System.IO;
using System.Speech.Synthesis;

class Program
{
    static void Main()
    {
        // Créer une instance de SpeechSynthesizer
        SpeechSynthesizer synthesizer = new SpeechSynthesizer();

        try
        {
            // Lister les voix disponibles pour vérifier si une voix anglaise est présente
            foreach (var voice in synthesizer.GetInstalledVoices())
            {
                var info = voice.VoiceInfo;
                Console.WriteLine($"Name: {info.Name}, Culture: {info.Culture}");
            }

            // Sélectionner une voix anglaise si elle est disponible
            synthesizer.SelectVoiceByHints(VoiceGender.NotSet, VoiceAge.NotSet, 0, new System.Globalization.CultureInfo("en-US"));

            // Lire le contenu du fichier Shrek.txt
            string filePath = "Shrek.txt"; // Assurez-vous que le fichier se trouve dans le même répertoire que l'exécutable
            string text = File.ReadAllText(filePath);

            // Configurer le synthesizer
            synthesizer.SetOutputToDefaultAudioDevice();

            // Lire le texte
            synthesizer.Speak(text);

            Console.WriteLine("Lecture terminée.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Une erreur s'est produite : " + ex.Message);
        }
        finally
        {
            // Nettoyer
            synthesizer.Dispose();
        }
    }
}
