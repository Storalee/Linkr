using System;
using Microsoft.Win32;

class Program
{
    static void Main()
    {
        try
        {
            // Accéder à la clé de registre Personalize
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize", true);

            if (key != null)
            {
                // Changer les valeurs pour activer le Light Mode
                key.SetValue("AppsUseLightTheme", 1, RegistryValueKind.DWord);
                key.SetValue("SystemUsesLightTheme", 1, RegistryValueKind.DWord);

                key.Close();

                Console.WriteLine("Le mode clair a été activé.");
            }
            else
            {
                Console.WriteLine("Impossible d'accéder à la clé de registre Personalize.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Une erreur s'est produite : " + ex.Message);
        }
    }
}
