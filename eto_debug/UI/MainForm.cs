using Eto;
using Eto.Drawing;
using Eto.Forms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Diagnostics;

namespace eto_debug;

/// <summary>
/// Your application's main form
/// </summary>
public partial class MainForm : Form
{
    public class UIStringLists
    {
        public ObservableCollection<string> patternElementNames { get; init; }
        public ObservableCollection<string> patternElementNames_filtered { get; init; }

        public ObservableCollection<string> patternElementNamesForMerge_filtered { get; init; }
            
        public ObservableCollection<string> patternElementNames_filtered_array { get; init; }
        public ObservableCollection<string> xPosRefSubShapeList { get; init; }
        public ObservableCollection<string> yPosRefSubShapeList { get; init; }

        public ObservableCollection<string> minHLRefSubShapeList { get; init; }
        public ObservableCollection<string> minHLRefSubShape2List { get; init; }
        public ObservableCollection<string> minHLRefSubShape3List { get; init; }
        public ObservableCollection<string> minVLRefSubShapeList { get; init; }
        public ObservableCollection<string> minVLRefSubShape2List { get; init; }
        public ObservableCollection<string> minVLRefSubShape3List { get; init; }
        public ObservableCollection<string> minHORefSubShapeList { get; init; }
        public ObservableCollection<string> minHORefSubShape2List { get; init; }
        public ObservableCollection<string> minHORefSubShape3List { get; init; }
        public ObservableCollection<string> minVORefSubShapeList { get; init; }
        public ObservableCollection<string> minVORefSubShape2List { get; init; }
        public ObservableCollection<string> minVORefSubShape3List { get; init; }

        public ObservableCollection<string> minHLStepsRefSubShapeList { get; init; }
        public ObservableCollection<string> minHLStepsRefSubShape2List { get; init; }
        public ObservableCollection<string> minHLStepsRefSubShape3List { get; init; }
        public ObservableCollection<string> minVLStepsRefSubShapeList { get; init; }
        public ObservableCollection<string> minVLStepsRefSubShape2List { get; init; }
        public ObservableCollection<string> minVLStepsRefSubShape3List { get; init; }
        public ObservableCollection<string> minHOStepsRefSubShapeList { get; init; }
        public ObservableCollection<string> minHOStepsRefSubShape2List { get; init; }
        public ObservableCollection<string> minHOStepsRefSubShape3List { get; init; }
        public ObservableCollection<string> minVOStepsRefSubShapeList { get; init; }
        public ObservableCollection<string> minVOStepsRefSubShape2List { get; init; }
        public ObservableCollection<string> minVOStepsRefSubShape3List { get; init; }
        public ObservableCollection<string> minHLIncRefSubShapeList { get; init; }
        public ObservableCollection<string> minHLIncRefSubShape2List { get; init; }
        public ObservableCollection<string> minHLIncRefSubShape3List { get; init; }
        public ObservableCollection<string> minVLIncRefSubShapeList { get; init; }
        public ObservableCollection<string> minVLIncRefSubShape2List { get; init; }
        public ObservableCollection<string> minVLIncRefSubShape3List { get; init; }
        public ObservableCollection<string> minHOIncRefSubShapeList { get; init; }
        public ObservableCollection<string> minHOIncRefSubShape2List { get; init; }
        public ObservableCollection<string> minHOIncRefSubShape3List { get; init; }
        public ObservableCollection<string> minVOIncRefSubShapeList { get; init; }
        public ObservableCollection<string> minVOIncRefSubShape2List { get; init; }
        public ObservableCollection<string> minVOIncRefSubShape3List { get; init; }

        public ObservableCollection<string> tipRefSubShapeList { get; init; }
        public ObservableCollection<string> tipRefSubShape2List { get; init; }
        public ObservableCollection<string> tipRefSubShape3List { get; init; }

        public List<string> shapes { get; init; }
        public List<string> subShapePos { get; init; }
        public List<string> subShapeHorPos { get; init; }
        public List<string> subShapeVerPos { get; init; }

        public ObservableCollection<string> geoCoreStructureList_exp { get; init; }

        public ObservableCollection<string> subShapeList { get; init; }
        
        public List<string> tipLocs { get; init; }
        public List<string> openGLMode { get; set; }
    }


    private string helpPath;
    private bool helpAvailable;

    private bool suspendBuild; // to allow user to suspend quilt build.

    private QuiltContext quiltContext;

    private Command quitCommand, helpCommand, aboutCommand, copyLayer, pasteLayer, newSim, openSim, fromLayout, revertSim, saveSim, saveAsSim;

    private object drawingLock;

    private CommonVars commonVars;

    private void pSetupUIDataContext()
    {
        DataContext = new UIStringLists
        {
            xPosRefSubShapeList = commonVars.xPosRefSubShapeList,
            yPosRefSubShapeList = commonVars.yPosRefSubShapeList,
            minHLRefSubShapeList = commonVars.minHLRefSubShapeList,
            minHLRefSubShape2List = commonVars.minHLRefSubShape2List,
            minHLRefSubShape3List = commonVars.minHLRefSubShape3List,
            minVLRefSubShapeList = commonVars.minVLRefSubShapeList,
            minVLRefSubShape2List = commonVars.minVLRefSubShape2List,
            minVLRefSubShape3List = commonVars.minVLRefSubShape3List,
            minHORefSubShapeList = commonVars.minHORefSubShapeList,
            minHORefSubShape2List = commonVars.minHORefSubShape2List,
            minHORefSubShape3List = commonVars.minHORefSubShape3List,
            minVORefSubShapeList = commonVars.minVORefSubShapeList,
            minVORefSubShape2List = commonVars.minVORefSubShape2List,
            minVORefSubShape3List = commonVars.minVORefSubShape3List,
            minHLIncRefSubShapeList = commonVars.minHLIncRefSubShapeList,
            minHLIncRefSubShape2List = commonVars.minHLIncRefSubShape2List,
            minHLIncRefSubShape3List = commonVars.minHLIncRefSubShape3List,
            minVLIncRefSubShapeList = commonVars.minVLIncRefSubShapeList,
            minVLIncRefSubShape2List = commonVars.minVLIncRefSubShape2List,
            minVLIncRefSubShape3List = commonVars.minVLIncRefSubShape3List,
            minHOIncRefSubShapeList = commonVars.minHOIncRefSubShapeList,
            minHOIncRefSubShape2List = commonVars.minHOIncRefSubShape2List,
            minHOIncRefSubShape3List = commonVars.minHOIncRefSubShape3List,
            minVOIncRefSubShapeList = commonVars.minVOIncRefSubShapeList,
            minVOIncRefSubShape2List = commonVars.minVOIncRefSubShape2List,
            minVOIncRefSubShape3List = commonVars.minVOIncRefSubShape3List,
            minHLStepsRefSubShapeList = commonVars.minHLStepsRefSubShapeList,
            minHLStepsRefSubShape2List = commonVars.minHLStepsRefSubShape2List,
            minHLStepsRefSubShape3List = commonVars.minHLStepsRefSubShape3List,
            minVLStepsRefSubShapeList = commonVars.minVLStepsRefSubShapeList,
            minVLStepsRefSubShape2List = commonVars.minVLStepsRefSubShape2List,
            minVLStepsRefSubShape3List = commonVars.minVLStepsRefSubShape3List,
            minHOStepsRefSubShapeList = commonVars.minHOStepsRefSubShapeList,
            minHOStepsRefSubShape2List = commonVars.minHOStepsRefSubShape2List,
            minHOStepsRefSubShape3List = commonVars.minHOStepsRefSubShape3List,
            minVOStepsRefSubShapeList = commonVars.minVOStepsRefSubShapeList,
            minVOStepsRefSubShape2List = commonVars.minVOStepsRefSubShape2List,
            minVOStepsRefSubShape3List = commonVars.minVOStepsRefSubShape3List,
            tipRefSubShapeList = commonVars.tipRefSubShapeList,
            tipRefSubShape2List = commonVars.tipRefSubShape2List,
            tipRefSubShape3List = commonVars.tipRefSubShape3List,
            subShapeList = commonVars.subshapes,
            geoCoreStructureList_exp = commonVars.structureList_exp,
            openGLMode = commonVars.openGLModeList
        };
    }
    
    private void pSetUI(bool status)
    {
        fileMenu.Enabled = status;
        editMenu.Enabled = status;

        //settings_tl.Enabled = status;
        left_tl.Enabled = status;
        right_tl.Enabled = status;

        if (status)
        {
            pUpdatePatternElementUI(false);
        }
    }

    public MainForm(QuiltContext _quiltContext)
    {
        pMainForm(_quiltContext);
    }

    private void pMainForm(QuiltContext _quiltContext)
    {
        // string basePath = AppContext.BaseDirectory; // Disabled this as release builds do not seem to populate this field. Use the above complex approach instead.
        helpPath = Path.Combine(EtoEnvironment.GetFolderPath(EtoSpecialFolder.ApplicationResources), "Documentation", "index.html");
        helpAvailable = File.Exists(helpPath);

        pUI(_quiltContext);
    }
    
    private void pUI(QuiltContext _quiltContext)
    {
        quiltContext = _quiltContext ?? new QuiltContext("");


        commonVars = new CommonVars(ref quiltContext);

        pDelegates();

        pSetupUIDataContext();

        drawingLock = new object();

        Title = commonVars.titleText;

        pCommandsUI();

        // Compensate for menu.
        MinimumSize = new Size(750, 450);
        Size = new Size(1250,760);

        Panel vp = new();

        TableLayout vp_tl = new();

        vp.Content = vp_tl;

        vp_tl.Rows.Add(new TableRow());

        pPatternSettingsUI();
        Scrollable settings_sc = new() {Content = settings};

        quiltUISplitter = new Panel
        {
            Content = new Splitter
            {
                Orientation = Orientation.Horizontal,
                FixedPanel = SplitterFixedPanel.Panel1,
                Panel1 = settings_sc,
                Panel2 = vp
                // Panel1MinimumSize = settings.Size.Width,
            }
        };

        tabControl = new TabControl();
        quiltPage = new TabPage {Text = "eto_debug"};
        tabControl.Pages.Add(quiltPage);
        pQuiltUISetup();
        quiltPage.Content = quiltUISplitter;

        prefsPage = new TabPage {Text = "Preferences"};
        tabControl.Pages.Add(prefsPage);
        prefsPage.Content = prefsPanel;
        tabControl.SelectedIndexChanged += pInterfaceUpdate;

        Content = tabControl;

        pDoPatternElementUI(0, updateUI: true);

        pUpdateProgressLabel("Hello");
        pUpdateUIColors();
        
        Title = commonVars.titleText;

        vp_tl.Rows[0].Cells.Add(new TableCell { Control = new Panel() {Width = viewportSize, Height = viewportSize} });

        if (quiltContext.xmlFileArg != "")
        {
            pDoLoad(quiltContext.xmlFileArg);
        }

        tabControl.DragEnter += pDragEvent;
        tabControl.DragOver += pDragEvent;

        tabControl.DragDrop += pDragAndDrop;
    }

    private void pInterfaceUpdate(object sender, EventArgs e)
    {
        if (tabControl.SelectedIndex == 1) // utils
        {
            utilsUIFrozen = true;
            pUpdatePrefsUI();
            utilsUIFrozen = false;
        }
        else
        {
            pDoPatternElementUI(sender, e);
        }
    }
    
    private void pLaunchHelp(object sender, EventArgs e)
    {
        if (helpAvailable)
        {
            new Process
            {
                StartInfo = new ProcessStartInfo(helpPath)
                {
                    UseShellExecute = true
                }
            }.Start();
        }
    }

    private void pCommandsUI()
    {
        Closed += pQuitHandler;

        quitCommand = new Command { MenuText = "Quit", Shortcut = Application.Instance.CommonModifier | Keys.Q };
        quitCommand.Executed += pQuit;
        Application.Instance.Terminating += pQuitHandler;

        aboutCommand = new Command { MenuText = "About..." };
        aboutCommand.Executed += pAboutMe;

        helpCommand = new Command { MenuText = "Help...", Shortcut = Keys.F1 };
        helpCommand.Executed += pLaunchHelp;

        copyLayer = new Command { MenuText = "Copy", ToolBarText = "Copy", Shortcut = Application.Instance.CommonModifier | Keys.C };
        copyLayer.Executed += pCopyHandler;

        pasteLayer = new Command { MenuText = "Paste", ToolBarText = "Paste", Shortcut = Application.Instance.CommonModifier | Keys.V };
        pasteLayer.Executed += pPasteHandler;

        newSim = new Command { MenuText = "New", ToolBarText = "New", Shortcut = Application.Instance.CommonModifier | Keys.N };
        newSim.Executed += pNewHandler;
        openSim = new Command { MenuText = "Open", ToolBarText = "Open", Shortcut = Application.Instance.CommonModifier | Keys.O };
        openSim.Executed += pOpenHandler;

        fromLayout = new Command { MenuText = "Layout", ToolBarText = "Layout", Shortcut = Application.Instance.CommonModifier | Keys.I };
        fromLayout.Executed += pFromLayoutHandler;

        revertSim = new Command { MenuText = "Revert", ToolBarText = "Revert", Shortcut = Application.Instance.CommonModifier | Keys.R };
        revertSim.Executed += pRevertHandler;
        revertSim.Enabled = false;

        saveSim = new Command { MenuText = "Save", ToolBarText = "Save", Shortcut = Application.Instance.CommonModifier | Keys.S };
        saveSim.Executed += pSaveHandler;

        saveAsSim = new Command { MenuText = "Save As", ToolBarText = "Save As", Shortcut = Application.Instance.CommonModifier | Keys.Shift | Keys.S };
        saveAsSim.Executed += pSaveAsHandler;

        fileMenu = new ButtonMenuItem { Text = "&File", Items = { newSim, openSim, fromLayout, revertSim, saveSim, saveAsSim } };
        editMenu = new ButtonMenuItem { Text = "&Edit", Items = { copyLayer, pasteLayer } };

        // create menu
        Menu = new MenuBar
        {
            Items = {
                fileMenu,
                editMenu
            },
            /*ApplicationItems = {
                // application (OS X) or file menu (others)
                new ButtonMenuItem { Text = "&Preferences..." },
            },*/
            QuitItem = quitCommand,
            HelpItems = {
                helpCommand
            },
            AboutItem = aboutCommand
        };

        helpCommand.Enabled = helpAvailable;
    }

    private void pPatternSettingsUI()
    {
        settings_tl = new TableLayout();
        Panel p = new() {Content = settings_tl};

        settings = new Panel {Size = new Size(540, 270), Content = p};
            
        main_tl = new TableLayout();
        Panel pMain = new() {Content = main_tl};

        TableRow main_tr = new();
        main_tl.Rows.Add(main_tr);
        TableCell main_tc0 = new();
        main_tr.Cells.Add(main_tc0);

        left_tl = new TableLayout();
        main_tc0.Control = left_tl;

        right_tl = new TableLayout();
        Scrollable right_s = new() {Content = right_tl};

        TableCell main_tc1 = new() {Control = right_s};
        main_tr.Cells.Add(main_tc1);

        settings_tl.Rows.Add(new TableRow { ScaleHeight = true });
        settings_tl.Rows[^1].Cells.Add(new TableCell { Control = pMain });

        progress_tl = new TableLayout();
        Panel progressPanel = new() {Content = progress_tl};
        TableRow progress_tr = new();
        progress_tl.Rows.Add(progress_tr);

        progressLabel = new Label {Text = ""};
        pSetSize(progressLabel, listBox_entries_Width, label_Height * 2);
        TableCell progress_tc0 = new() {Control = progressLabel};
        progress_tr.Cells.Add(progress_tc0);

        progressBar = new ProgressBar {Height = 10};
        TableCell progress_tc1 = new() {Control = progressBar, ScaleWidth = true};
        progress_tr.Cells.Add(progress_tc1);

        btn_Cancel = new Button {Text = "Cancel", Enabled = false};
        btn_Cancel.Click += pCancelLayoutProcessing;
        TableCell progress_tc2 = new() {Control = TableLayout.AutoSized(btn_Cancel)};
        progress_tr.Cells.Add(progress_tc2);
            
        settings_tl.Rows.Add(new TableRow());
        settings_tl.Rows[^1].Cells.Add(new TableCell { Control = progressPanel });

        pPatternSettingsUI_2();
    }

    private void pPatternSettingsUI_2()
    {
        TableRow left_layout_tr = new();
        left_tl.Rows.Add(left_layout_tr);

        Panel layout_pnl = new();
        TableLayout layout_tl = new();
        layout_pnl.Content = TableLayout.AutoSized(layout_tl);
        left_layout_tr.Cells.Add(new TableCell { Control = layout_pnl });

        layout_tl.Rows.Add(new TableRow());

        btn_layout = new Button {Text = "From File", ToolTip = "Use layout to define pattern."};
        btn_layout.Click += pFromLayoutHandler;

        comboBox_layout_structures = new DropDown();
        comboBox_layout_structures.BindDataContext(c => c.DataStore, (UIStringLists m) => m.geoCoreStructureList_exp);
        comboBox_layout_structures.SelectedIndexChanged += pProcessLayout;

        layout_tl.Rows[^1].Cells.Add(new TableCell { Control = TableLayout.AutoSized(btn_layout) });

        layout_tl.Rows[^1].Cells.Add(new TableCell { Control = TableLayout.AutoSized(comboBox_layout_structures), ScaleWidth = true });

        TableRow left_tr0 = new() {ScaleHeight = true};
        left_tl.Rows.Add(left_tr0);

        listBox_entries = new ListBox {ContextMenu = listbox_menu};
        pSetSize(listBox_entries, listBox_entries_Width, listBox_entries_Height);
        listBox_entries.BindDataContext(c => c.DataStore, (UIStringLists m) => m.patternElementNames);
        listBox_entries.SelectedIndexChanged += pUpdatePatternElementUI;

        TableCell left_tr0_0 = new();
        left_tr0.Cells.Add(left_tr0_0);

        Panel listBox_pnl = new() {Content = listBox_entries};
        left_tr0_0.Control = listBox_pnl;

        TableLayout settings_table = new();
        Panel lowerLeftContainer = new() {Content = settings_table};

        TableRow left_tr1 = new();
        left_tl.Rows.Add(left_tr1);
        TableCell left_tr1_0 = new();
        left_tr1.Cells.Add(left_tr1_0);
        left_tr1_0.Control = lowerLeftContainer;

        settings_table.Rows.Add(new TableRow());

        text_patternElement = new TextBox {ToolTip = "Name of pattern element."};
        settings_table.Rows[^1].Cells.Add(new TableCell { Control = text_patternElement });

        settings_table.Rows.Add(new TableRow());
        TableLayout bTable = new();
        Panel bPanel = new() {Content = bTable};
        settings_table.Rows[^1].Cells.Add(new TableCell { Control = bPanel });

        bTable.Rows.Add(new TableRow());

        entry_Add = new Button();

        const int entry_btnWidth = listBox_entries_Width / 3;
        entry_Add.Text = "Add";
        entry_Add.ToolTip = "Add new pattern entry (duplicates will not be added).";
        pSetSize(entry_Add, entry_btnWidth, 21);
        bTable.Rows[^1].Cells.Add(new TableCell { Control = entry_Add });

        entry_Rename = new Button {Text = "Rename", ToolTip = "Rename selected pattern entry."};
        pSetSize(entry_Rename, entry_btnWidth, 21);
        bTable.Rows[^1].Cells.Add(new TableCell { Control = entry_Rename });

        entry_Remove = new Button {Text = "Remove", ToolTip = "Remove selected pattern entry."};
        pSetSize(entry_Remove, entry_btnWidth, 21);
        bTable.Rows[^1].Cells.Add(new TableCell { Control = entry_Remove });

        settings_table.Rows.Add(new TableRow());
        TableLayout row2tl = new();
        Panel row2panel = new() {Content = row2tl};
        settings_table.Rows[^1].Cells.Add(new TableCell { Control = row2panel });

        row2tl.Rows.Add(new TableRow());

        lbl_viewportZoom = new Label {Text = "Zoom"};

        int nW = 55;
        num_viewportZoom = new NumericStepper {Value = 1.0f, DecimalPlaces = 2, MinValue = 1E-2};
        pSetSize(num_viewportZoom, nW, num_Height);

        TableLayout row2leftTL = new();
        Panel row2left = new() {Content = row2leftTL};
        row2tl.Rows[^1].Cells.Add(new TableCell { Control = row2left });

        row2leftTL.Rows.Add(new TableRow());
        row2leftTL.Rows[^1].Cells.Add(new TableCell { Control = lbl_viewportZoom });

        row2leftTL.Rows[^1].Cells.Add(new TableCell { Control = num_viewportZoom });

        row2leftTL.Rows[^1].Cells.Add(new TableCell { Control = null, ScaleWidth = true });

        checkBox_suspendBuild = new CheckBox
        {
            Text = "Suspend", ToolTip = "If checked, do not rebuild the quilt with changes."
        };

        row2tl.Rows[^1].Cells.Add(new TableCell { Control = checkBox_suspendBuild });

        checkBox_showInput = new CheckBox
        {
            Text = "Input",
            ToolTip = "If checked, show subshapes in viewport, rather than the final shapes.",
            Checked = true
        };

        row2tl.Rows[^1].Cells.Add(new TableCell { Control = checkBox_showInput });

        row2tl.Rows[^1].Cells.Add(new TableCell { Control = null });

        settings_table.Rows.Add(new TableRow());
        TableLayout row3tl = new();
        Panel row3panel = new() {Content = row3tl};
        settings_table.Rows[^1].Cells.Add(new TableCell { Control = row3panel });

        row3tl.Rows.Add(new TableRow());

        lbl_viewportPos = new Label {Text = "Position"};

        row3tl.Rows[^1].Cells.Add(new TableCell { Control = lbl_viewportPos });

        num_viewportX = new NumericStepper
        {
            Value = 0.0f, DecimalPlaces = 2, ToolTip = "X coordinate at center of viewport."
        };
        pSetSize(num_viewportX, nW, num_Height);

        row3tl.Rows[^1].Cells.Add(new TableCell { Control = num_viewportX });

        num_viewportY = new NumericStepper
        {
            Value = 0.0f, DecimalPlaces = 2, ToolTip = "Y coordinate at center of viewport."
        };
        pSetSize(num_viewportY, nW, num_Height);

        row3tl.Rows[^1].Cells.Add(new TableCell { Control = num_viewportY });

        row3tl.Rows[^1].Cells.Add(new TableCell { Control = null });

        settings_table.Rows.Add(new TableRow());
        TableLayout row4tl = new();
        Panel row4panel = new() {Content = row4tl};
        settings_table.Rows[^1].Cells.Add(new TableCell { Control = row4panel });

        row4tl.Rows.Add(new TableRow());

        lbl_padding = new Label {Text = "Padding"};

        row4tl.Rows[^1].Cells.Add(new TableCell { Control = lbl_padding });

        num_padding = new NumericStepper
        {
            MinValue = 0,
            DecimalPlaces = 2,
            Increment = 0.1,
            Value = 0,
            ToolTip = "Padding to apply in both directions between patterns in quilt."
        };
        pSetSize(num_padding, 55, num_Height);

        row4tl.Rows[^1].Cells.Add(new TableCell { Control = num_padding });

        row4tl.Rows[^1].Cells.Add(new TableCell { Control = null });

        lbl_patNum = new Label {Text = "#"};

        row4tl.Rows[^1].Cells.Add(new TableCell { Control = lbl_patNum });

        nW = 75;
        num_patNum = new NumericStepper
        {
            MinValue = 0,
            Increment = 1,
            Value = 0,
            MaxValue = 0,
            ToolTip = "Go to this pattern in the quilt."
        };
        pSetSize(num_patNum, nW, num_Height);

        patternIndex = 0;

        row4tl.Rows[^1].Cells.Add(new TableCell { Control = num_patNum });

        row4tl.Rows[^1].Cells.Add(new TableCell { Control = null });

        settings_table.Rows.Add(new TableRow());
        TableLayout row5tl = new();
        Panel row5panel = new() {Content = row5tl};
        settings_table.Rows[^1].Cells.Add(new TableCell { Control = row5panel });

        row5tl.Rows.Add(new TableRow());

        btn_export = new Button
        {
            Text = "Export", ToolTip = "Export quilt to layout file, rebuilding if suspended."
        };
        pSetSize(btn_export, 200, 21);
        row5tl.Rows[^1].Cells.Add(new TableCell { Control = TableLayout.AutoSized(btn_export) });

        row5tl.Rows[^1].Cells.Add(new TableCell { Control = null });
    }

    private void pUpdatePrefsUI()
    {
    }
}