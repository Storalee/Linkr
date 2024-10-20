using System;
using System.Runtime.InteropServices;
using System.Threading;

class Program
{
    // Importation de la fonction keybd_event de la bibliothèque user32.dll
    [DllImport("user32.dll", SetLastError = true)]
    static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, IntPtr dwExtraInfo);

    // Déclaration des constantes pour les touches du clavier
    const byte VK_CONTROL = 0x11;
    const byte VK_LWIN = 0x5B;
    const byte VK_RETURN = 0x0D;
    const uint KEYEVENTF_KEYUP = 0x0002;

    static void Main()
    {
        // Simuler l'appui des touches Ctrl + Win + Enter
        keybd_event(VK_CONTROL, 0, 0, IntPtr.Zero);
        keybd_event(VK_LWIN, 0, 0, IntPtr.Zero);
        keybd_event(VK_RETURN, 0, 0, IntPtr.Zero);

        // Attendre un court instant
        Thread.Sleep(100);

        // Simuler le relâchement des touches
        keybd_event(VK_RETURN, 0, KEYEVENTF_KEYUP, IntPtr.Zero);
        keybd_event(VK_LWIN, 0, KEYEVENTF_KEYUP, IntPtr.Zero);
        keybd_event(VK_CONTROL, 0, KEYEVENTF_KEYUP, IntPtr.Zero);

        Console.WriteLine("Le mode narrateur a été activé.");
    }
}
