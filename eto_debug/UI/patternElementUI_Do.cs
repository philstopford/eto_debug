using Eto.Drawing;
using Eto.Forms;
using System;

namespace eto_debug;

public partial class MainForm
{
    private void pDoColors()
    {
    }

    private void pDoPatternElementUI(object sender, EventArgs e)
    {
        bool updateUI = false;
        try
        {
            if ((DropDown)sender == comboBox_patternElementShape)
            {
                updateUI = true;
            }
        }
        catch
        {
            // ignored
        }
        pDoPatternElementUI(updateUI);
        revertSim.Enabled = commonVars.projectFileName != "";
    }
    
    private void pDoPatternElementUI(bool updateUI = false)
    {
        if (UIFreeze)
        {
            return;
        }
        pDoPatternElementUI(0, updateUI);
    }

    private void pDoPatternElementUI_num(int pattern, int index, string shapeString)
    {
        groupBox_properties.Content = groupBox_subShapes_table;
        comboBox_patternElementShape.Visible = true;

        pSwitchUIGadgets_off();

        pRefState_subShape1(pattern, index);
            
        // Any configuration beyond the first couple requires a second shape to be defined so we need to display that part of the interface.
        if (shapeString != "none" && shapeString != "rectangle" && shapeString != "text")
        {
            // Let's display the subshape 2 section if a shape configuration is chosen that requires it.

            pRefState_subShape2(pattern, index);
                
            if (shapeString == "S")
            {
                pRefState_subShape3(pattern, index);
                    
                commonVars.subshapes.Clear();
                commonVars.subshapes.Add("1");
                commonVars.subshapes.Add("2");
                commonVars.subshapes.Add("3");
            }
            else
            {
                commonVars.subshapes.Clear();
                commonVars.subshapes.Add("1");
                commonVars.subshapes.Add("2");
            }
        }
        else
        {
            commonVars.subshapes.Clear();
            commonVars.subshapes.Add("1");
        }
        
        pRefState_tips(pattern, index);
    }

    private void pDoPatternElementUI(int pattern, bool updateUI = false, bool doPreview = true)
    {
        if (UIFreeze)
        {
            return;
        }

        if (suspendBuild)
        {
            pUpdateProgressLabel("Build suspended.");
        }

        UIFreeze = true;

        int index = listBox_entries.SelectedIndex;

        if (index == -1)
        {
            UIFreeze = false;
            pClearPatternElementUI();
            comboBox_patternElementShape.Visible = true;
            return;
        }
        
        comboBox_patternElementShape.Visible = true;
        
        groupBox_properties.Visible = true;

        string shapeString = "";

        groupBox_properties.Content = shapeString switch
        {
            "bounding" => groupBox_bounding_table,
            "complex" => new Expander() { Content = groupBox_layout_table, Header = "Edges", Expanded = false },
            _ => groupBox_properties.Content
        };

        pDoPatternElementUI_subshape(pattern, index, updateUI, shapeString);
        pDoPatternElementUI_position(pattern, index);
        pDoPatternElementUI_rotation(pattern, index);
        pDoPatternElementUI_transform(pattern, index);
        pDoPatternElementUI_array(pattern, index);

        pDoPatternElementUI_baseShape_referencesUI(index);

        UIFreeze = false;

    }
}