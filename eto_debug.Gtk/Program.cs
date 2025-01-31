using System;
using Eto.GtkSharp;

namespace eto_debug.Gtk;

public static class MainClass
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