namespace eto_debug;

public partial class MainForm
{
    private void pDoPatternElementUI_baseShape(int pattern, int index, string shapeString)
    {
        pDoPatternElementUI_baseShape1(pattern, index, shapeString);
        pDoPatternElementUI_baseShape_references(pattern, index);
        pDoPatternElementUI_baseShape2(pattern, index, shapeString);
    }

    private void pDoPatternElementUI_baseShape_references(int pattern, int index)
    {
        pDoPatternElementUI_baseShape_references_lengths(pattern, index);
        pDoPatternElementUI_baseShape_references_length_incs(pattern, index);
        pDoPatternElementUI_baseShape_references_length_steps(pattern, index);

        pDoPatternElementUI_baseShape_references_offsets(pattern, index);
        pDoPatternElementUI_baseShape_references_offset_incs(pattern, index);
        pDoPatternElementUI_baseShape_references_offset_steps(pattern, index);
    }

    private void pDoPatternElementUI_baseShape_referencesUI(int index)
    {
        for (int i = 0; i < 3; i++)
        {
            pMinHLRefSubShapeList_update(index, i);
            pMinVLRefSubShapeList_update(index, i);
            pMinHORefSubShapeList_update(index, i);
            pMinVORefSubShapeList_update(index, i);
            pHLIncRefSubShapeList_update(index, i);
            pVLIncRefSubShapeList_update(index, i);
            pHOIncRefSubShapeList_update(index, i);
            pVOIncRefSubShapeList_update(index, i);
            pHLStepsRefSubShapeList_update(index, i);
            pVLStepsRefSubShapeList_update(index, i);
            pHOStepsRefSubShapeList_update(index, i);
            pVOStepsRefSubShapeList_update(index, i);
        }
    }

    private void pDoPatternElementUI_baseShape_references_length_steps(int pattern, int index)
    {
    }

    private void pDoPatternElementUI_baseShape_references_length_incs(int pattern, int index)
    {
    }

    private void pDoPatternElementUI_baseShape_references_lengths(int pattern, int index)
    {
    }

    private void pDoPatternElementUI_baseShape_references_offset_steps(int pattern, int index)
    {
    }

    private void pDoPatternElementUI_baseShape_references_offset_incs(int pattern, int index)
    {
    }

    private void pDoPatternElementUI_baseShape_references_offsets(int pattern, int index)
    {
    }

    private void pDoPatternElementUI_baseShape1(int pattern, int index, string shapeString)
    {
        if (shapeString is "none" or "rectangle")
        {
            pClampSubShape2(minHLength: 0,
                maxHLength: 1000000,
                minVLength: 0,
                maxVLength: 1000000,
                minHOffset: -1000000,
                maxHOffset: 1000000,
                minVOffset: -1000000,
                maxVOffset: 1000000
            );
            pClampSubShape3(minHLength: 0,
                maxHLength: 1000000,
                minVLength: 0,
                maxVLength: 1000000,
                minHOffset: -1000000,
                maxHOffset: 1000000,
                minVOffset: -1000000,
                maxVOffset: 1000000
            );

            if (shapeString == "none")
            {
                num_layer_subshape_minhl.Value = 0;
                num_layer_subshape_minvl.Value = 0;
                num_layer_subshape_minho.Value = 0;
                num_layer_subshape_minvo.Value = 0;
            }

            num_layer_subshape2_minhl.Value = 0;
            num_layer_subshape2_minvl.Value = 0;
            num_layer_subshape2_minho.Value = 0;
            num_layer_subshape2_minvo.Value = 0;

            num_layer_subshape3_minhl.Value = 0;
            num_layer_subshape3_minvl.Value = 0;
            num_layer_subshape3_minho.Value = 0;
            num_layer_subshape3_minvo.Value = 0;

        }
    }

    private void pDoPatternElementUI_baseShape2(int pattern, int index, string shapeString)
    {
        // Subshape 2 offsets contingent on shape selection choice
        if (shapeString is "none" or "rectangle" or "GEOCORE" or "BOOLEAN")
        {
            return;
        }

        pClampSubShape(minHLength: 0.01,
            maxHLength: 1000000,
            minVLength: 0.01,
            maxVLength: 1000000,
            minHOffset: -1000000,
            maxHOffset: 1000000,
            minVOffset: -1000000,
            maxVOffset: 1000000
        );

        switch (shapeString)
        {
            // Limit offsets of subshape 2 for X-shape.
            case "X":
                pDoUI_X(pattern, index);
                break;
            // Disabled horizontal offset of subshape 2 for T-shape.
            case "T":
                pDoUI_T(pattern, index);
                break;
            // Disable horizontal and vertical offsets of subshape 2 for L-shape
            case "L":
                pDoUI_L(pattern, index);
                break;
            // U-shape
            case "U":
                pDoUI_U(pattern, index);
                break;
            // S-shape
            case "S":
                pDoUI_S(pattern, index);
                break;
        }
    }
}