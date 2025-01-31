using Eto.Forms;

namespace eto_debug;

public partial class MainForm
{
    private void pSwitchUIGadgets_off()
    {
        comboBox_s1_minhl_ref.Enabled = false;
        comboBox_s1_minhlinc_ref.Enabled = false;
        comboBox_s1_minhlsteps_ref.Enabled = false;

        cb_s1_hl_final.Enabled = false;
            
        comboBox_s1_minhl_subShapeRef.Enabled = false;
        comboBox_s1_minhlinc_subShapeRef.Enabled = false;
        comboBox_s1_minhlsteps_subShapeRef.Enabled = false;

        num_layer_subshape2_minhl.Enabled = false;
        num_layer_subshape2_incHL.Enabled = false;
        num_layer_subshape2_stepsHL.Enabled = false;

        comboBox_s1_minvl_ref.Enabled = false;
        comboBox_s1_minvlinc_ref.Enabled = false;
        comboBox_s1_minvlsteps_ref.Enabled = false;
            
        cb_s1_vl_final.Enabled = false;

        comboBox_s1_minvl_subShapeRef.Enabled = false;
        comboBox_s1_minvlinc_subShapeRef.Enabled = false;
        comboBox_s1_minvlsteps_subShapeRef.Enabled = false;

        num_layer_subshape2_minvl.Enabled = false;
        num_layer_subshape2_incVL.Enabled = false;
        num_layer_subshape2_stepsVL.Enabled = false;

        comboBox_s1_minho_ref.Enabled = false;
        comboBox_s1_minhoinc_ref.Enabled = false;
        comboBox_s1_minhosteps_ref.Enabled = false;

        cb_s1_ho_final.Enabled = false;

        comboBox_s1_minho_subShapeRef.Enabled = false;
        comboBox_s1_minhoinc_subShapeRef.Enabled = false;
        comboBox_s1_minhosteps_subShapeRef.Enabled = false;
            
        num_layer_subshape2_minho.Enabled = false;
        num_layer_subshape2_incHO.Enabled = false;
        num_layer_subshape2_stepsHO.Enabled = false;

        comboBox_s1_minvo_ref.Enabled = false;
        comboBox_s1_minvoinc_ref.Enabled = false;
        comboBox_s1_minvosteps_ref.Enabled = false;

        cb_s1_vo_final.Enabled = false;

        comboBox_s1_minvo_subShapeRef.Enabled = false;
        comboBox_s1_minvoinc_subShapeRef.Enabled = false;
        comboBox_s1_minvosteps_subShapeRef.Enabled = false;

        num_layer_subshape2_minvo.Enabled = false;
        num_layer_subshape2_incVO.Enabled = false;
        num_layer_subshape2_stepsVO.Enabled = false;

        comboBox_s2_minhl_ref.Enabled = false;
        comboBox_s2_minhlinc_ref.Enabled = false;
        comboBox_s2_minhlsteps_ref.Enabled = false;

        cb_s2_hl_final.Enabled = false;

        comboBox_s2_minhl_subShapeRef.Enabled = false;
        comboBox_s2_minhlinc_subShapeRef.Enabled = false;
        comboBox_s2_minhlsteps_subShapeRef.Enabled = false;

        num_layer_subshape3_minhl.Enabled = false;
        num_layer_subshape3_incHL.Enabled = false;
        num_layer_subshape3_stepsHL.Enabled = false;

        comboBox_s2_minvl_ref.Enabled = false;
        comboBox_s2_minvlinc_ref.Enabled = false;
        comboBox_s2_minvlsteps_ref.Enabled = false;

        cb_s2_vl_final.Enabled = false;

        comboBox_s2_minvl_subShapeRef.Enabled = false;
        comboBox_s2_minvlinc_subShapeRef.Enabled = false;
        comboBox_s2_minvlsteps_subShapeRef.Enabled = false;

        num_layer_subshape3_minvl.Enabled = false;
        num_layer_subshape3_incVL.Enabled = false;
        num_layer_subshape3_stepsVL.Enabled = false;

        comboBox_s2_minho_ref.Enabled = false;
        comboBox_s2_minhoinc_ref.Enabled = false;
        comboBox_s2_minhosteps_ref.Enabled = false;

        cb_s2_ho_final.Enabled = false;

        comboBox_s2_minho_subShapeRef.Enabled = false;
        comboBox_s2_minhoinc_subShapeRef.Enabled = false;
        comboBox_s2_minhosteps_subShapeRef.Enabled = false;

        num_layer_subshape3_minho.Enabled = false;
        num_layer_subshape3_incHO.Enabled = false;
        num_layer_subshape3_stepsHO.Enabled = false;

        comboBox_s2_minvo_ref.Enabled = false;
        comboBox_s2_minvoinc_ref.Enabled = false;
        comboBox_s2_minvosteps_ref.Enabled = false;

        cb_s2_vo_final.Enabled = false;

        comboBox_s2_minvo_subShapeRef.Enabled = false;
        comboBox_s2_minvoinc_subShapeRef.Enabled = false;
        comboBox_s2_minvosteps_subShapeRef.Enabled = false;

        num_layer_subshape3_minvo.Enabled = false;
        num_layer_subshape3_incVO.Enabled = false;
        num_layer_subshape3_stepsVO.Enabled = false;

        comboBox_tipLocations2.Enabled = false;
        comboBox_tipLocations3.Enabled = false;

        comboBox_s1_tip_ref.Enabled = false;
        comboBox_s1_tip_subShapeRef.Enabled = false;
        comboBox_s2_tip_ref.Enabled = false;
        comboBox_s2_tip_subShapeRef.Enabled = false;
        
        cb_ht_final.Enabled = false;
        cb_vt_final.Enabled = false;
    }

    private void pRefState_tips(int pattern, int index)
    {
    }
    
    private void pRefState_subShape1(int pattern, int index)
    {
    }

    private void pRefState_subShape2(int pattern, int index)
    {
    }

    private void pRefState_subShape3(int pattern, int index)
    {
    }

    private void pDoPatternElementUI_subshape(int pattern, int index, bool updateUI, string shapeString)
    {
        int previousIndex = comboBox_subShapeRef.SelectedIndex;

        if (updateUI)
        {
            if (shapeString != "bounding" && shapeString != "complex")
            {
                pDoPatternElementUI_num(pattern, index, shapeString);
            }
            else
            {
                groupBox_properties.Content = shapeString switch
                {
                    "bounding" => groupBox_bounding_table,
                    "complex" => new Expander() { Content = groupBox_layout_table, Header = "Edges", Expanded = false },
                    _ => groupBox_properties.Content
                };

                commonVars.subshapes.Clear();
                commonVars.subshapes.Add("1");
            }
        }
        if (previousIndex >= commonVars.subshapes.Count)
        {
            previousIndex = commonVars.subshapes.Count - 1;
        }

        comboBox_subShapeRef.SelectedIndex = previousIndex;

        if (shapeString != "bounding" && shapeString != "complex")
        {
            pDoPatternElementUI_baseShape(pattern, index, shapeString);
        }
        else
        {
            switch (shapeString)
            {
                case "bounding":
                    pDoUI_bounding(pattern, index);
                    break;
                case "complex":
                    pDoUI_complex(pattern, index);
                    break;
            }
        }

    }
}