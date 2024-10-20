using System;
using System.Runtime.InteropServices;
using System.Threading;

class Program
{
    [DllImport("user32.dll")]
    static extern void PostMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);

    [DllImport("user32.dll")]
    static extern IntPtr GetForegroundWindow();

    const uint WM_INPUTLANGCHANGEREQUEST = 0x0050;

    static void Main()
    {
        Random random = new Random();
        int[] layouts = { 0x0409, 0x0804, 0x0411, 0x0407, 0x0805, 0x0414, 0x0801, 0x0415, 0x0806, 0x0416, 0x0807, 0x0417, 0x0808, 0x0418, 0x0809, 0x0419, 0x080A, 0x041A, 0x080B, 0x041B, 0x080C, 0x041C, 0x080D, 0x041D, 0x080E, 0x041E, 0x080F, 0x041F, 0x0810, 0x0420, 0x0811, 0x0421, 0x0812, 0x0422, 0x0813, 0x0423, 0x0814, 0x0424, 0x0815, 0x0425, 0x0816, 0x0426, 0x0817, 0x0427, 0x0818, 0x0428, 0x0819, 0x0429, 0x081A, 0x042A, 0x081B, 0x042B, 0x081C, 0x042C, 0x081D, 0x042D, 0x081E, 0x042E, 0x081F };

        while (true)
        {
            int layout = layouts[random.Next(layouts.Length)];

            IntPtr foregroundWindow = GetForegroundWindow();
            PostMessage(foregroundWindow, WM_INPUTLANGCHANGEREQUEST, layout, 0);

            Thread.Sleep(1000); // Wait for 5 seconds
        }
    }
}
