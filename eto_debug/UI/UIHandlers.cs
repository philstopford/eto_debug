using Eto.Drawing;
using Eto.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace eto_debug;

public partial class MainForm
{
    private string layout_filename;
    private BackgroundWorker bw;
    private bool abortLoad;

    private void pNewHandler(object sender, EventArgs e)
    {
        DialogResult result = MessageBox.Show("Are you sure?", "New", MessageBoxButtons.YesNo, type: MessageBoxType.Question);
        if (result == DialogResult.Yes)
        {
            pNew();
        }
    }

    private void pNew(bool empty = false)
    {
    }

    private void pFromLayoutHandler(object sender, EventArgs e)
    {
    }

    private void pProcessLayout(object sender, EventArgs e)
    {
    }

    private void pProcessLayoutWithWorker(int index)
    {
    }

    private void pLoadLayoutFromFile()
    {
    }

    private void pCancelLayoutProcessing(object sender, EventArgs e)
    {
    }

    private void pPrepLayoutBW()
    {
    }

    private void pPreWorker(int structureIndex)
    {
    }

    private void pPostWorker(object sender, EventArgs e)
    {
    }

    private void pProcessLayoutWithWorker(object sender, EventArgs e)
    {
    }
    
    private void pSaveHandler(object sender, EventArgs e)
    {
    }

    private void pSaveProject(string filename)
    {
    }

    private void pSaveAsHandler(object sender, EventArgs e)
    {
    }

    private void pSaveEnabler()
    {
    }

    private static void pDragEvent(object sender, DragEventArgs e)
    {
    }

    private void pDragAndDrop(object sender, DragEventArgs e)
    {
    }

    private void pOpenHandler(object sender, EventArgs e)
    {
    }

    private void pCopyHandler(object sender, EventArgs e)
    {
        pCopy();
    }

    private void pCopy()
    {
    }

    private void pPasteHandler(object sender, EventArgs e)
    {
    }

    private void pPaste()
    {
    }

    private async void pDoLoad(string xmlFile)
    {
    }

    private void pRevertHandler(object sender, EventArgs e)
    {
    }

    private void pQuit(object sender, EventArgs e)
    {
    }

    private void pQuitHandler(object sender, EventArgs e)
    {
    }

    private void pAddPatternElement(object sender, EventArgs e)
    {
    }

    private void pAddPatternElement(int index = -1)
    {
    }

    private void pRenamePatternElement(object sender, EventArgs e)
    {
    }

    private void pRenamePatternElement()
    {
    }

    private void pRemovePatternElement(object sender, EventArgs e)
    {
    }

    private void pRemovePatternElement()
    {
    }

    private void pDuplicatePatternElement()
    {
    }

    private void pExportClicked(object sender, EventArgs e)
    {
    }

    private async void pDoExport()
    {
    }

    private void pAboutMe(object sender, EventArgs e)
    {
    }

    private void pAddPrefsHandlers()
    {
    }

    private void pLayerColorChange(Label id, Color colDialogColor)
    {
    }

    private void pLayerColorChange(object sender, EventArgs e)
    {
    }

    private void pPreferencesChange(object sender, EventArgs e)
    {
    }

    private void pResetColors(object sender, EventArgs e)
    {
    }

    private void pUpdateUIColors()
    {
    }

    private void pSetPadding(object sender, EventArgs e)
    {
    }

    private void pSetPadding()
    {
    }

    private void pSuspendQuiltBuild(object sender, EventArgs e)
    {
    }

    private void pSuspendQuiltBuild()
    {
    }

    private void pShowInput(object sender, EventArgs e)
    {
    }

    private void pShowInput()
    {
    }
}
