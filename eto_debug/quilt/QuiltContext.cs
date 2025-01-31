namespace eto_debug;

public class QuiltContext
{
    // This is intended to hold application context settings to allow for cleaner handling of
    // commandline options related to headless mode, XML file loading from the command line, viewport switches

    public string xmlFileArg;
    public int openGLZoomFactor;
    public double FGOpacity;
    public double BGOpacity;
    public double angularTolerance;
    public bool AA;
    public bool filledPolygons;
    public bool drawPoints;
    public bool drawExtents;
    public bool verticalRectDecomp;
    public bool expandUI;
    public int HTCount;

    public string licenceName;

    public QuiltContext(string xmlFileArg_)
    {
        makeContext(xmlFileArg_);
    }

    private void makeContext(string xmlFileArg_)
    {
        xmlFileArg = xmlFileArg_;
        openGLZoomFactor = 1;
        filledPolygons = false;
        drawPoints = false;
        drawExtents = true;
        verticalRectDecomp = true;
        expandUI = true;
        AA = true;
        FGOpacity = 0.7;
        BGOpacity = 0.3;
        angularTolerance = 0.2;
        licenceName = "GPLv3";
    }
}