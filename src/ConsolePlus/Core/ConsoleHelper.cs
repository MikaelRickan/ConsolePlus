using System;
using System.Runtime.InteropServices;

namespace ConsolePlus.Core;

public static class ConsoleHelper
{
    private const int STD_OUTPUT_HANDLE = -11;
    private const uint ENABLE_VIRTUAL_TERMINAL_PROCESSING = 0x0004;

    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern IntPtr GetStdHandle(int nStdHandle);

    [DllImport("kernel32.dll")]
    private static extern bool GetConsoleMode(IntPtr hConsoleHandle, out uint lpMode);

    [DllImport("kernel32.dll")]
    private static extern bool SetConsoleMode(IntPtr hConsoleHandle, uint dwMode);

    /// <summary>
    /// Static access to terminal capabilities.
    /// </summary>
    public static class Terminal
    {
        public static bool SupportsTrueColor { get; internal set; } = true;
        public static int Width => Console.WindowWidth;
        public static int Height => Console.WindowHeight;
    }

    /// <summary>
    /// Sets the terminal window title. Supports emojis.
    /// </summary>
    public static void SetTitle(string title)
    {
        try
        {
            Console.Title = title;
        }
        catch
        {
            // Some terminals don't support setting the title
        }
    }

    /// <summary>
    /// Initializes the console library with modern defaults.
    /// </summary>
    public static void Setup()
    {
        Initialize();
        
        // Basic detection for TrueColor support (modern terminals like VS Code, Windows Terminal)
        var colorTerm = Environment.GetEnvironmentVariable("COLORTERM");
        Terminal.SupportsTrueColor = !string.IsNullOrEmpty(colorTerm) && (colorTerm == "truecolor" || colorTerm == "24bit");
        
        // If we can't detect it, we assume true on modern OS
        if (string.IsNullOrEmpty(colorTerm))
        {
             Terminal.SupportsTrueColor = RuntimeInformation.IsOSPlatform(OSPlatform.Windows) || 
                                         RuntimeInformation.IsOSPlatform(OSPlatform.OSX);
        }
    }

    /// <summary>
    /// Initializes the console, enabling Virtual Terminal Processing on Windows if necessary.
    /// </summary>
    public static void Initialize()
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            var handle = GetStdHandle(STD_OUTPUT_HANDLE);
            if (GetConsoleMode(handle, out uint mode))
            {
                mode |= ENABLE_VIRTUAL_TERMINAL_PROCESSING;
                SetConsoleMode(handle, mode);
            }
        }
        
        // Ensure UTF-8 for Emojis
        Console.OutputEncoding = System.Text.Encoding.UTF8;
    }
}
