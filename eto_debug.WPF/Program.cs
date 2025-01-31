using System;
using Eto.Wpf;

namespace eto_debug.WPF;

internal static class Program
{
    [STAThread]
    public static void Main(string[] args)
    {
        Platform platform = new();

        QuiltContext quiltContext = new("");
        // run application with our main form
        QuiltApplication pa = new(platform, quiltContext);
        pa.Run();
    }
}