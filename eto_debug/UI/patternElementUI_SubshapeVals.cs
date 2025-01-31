using Eto.Forms;
using System;

namespace eto_debug;

public partial class MainForm
{
    private void pSetTipVals(int index)
    {
    }

    private void pSetSubShapeVals(int index, int subShapeIndex)
    {
    }

    private void pClearSubShapeVals(int subShapeIndex)
    {
        switch (subShapeIndex)
        {
            case 0:
                num_layer_subshape_minhl.Value = 0;
                num_layer_subshape_minho.Value = 0;
                num_layer_subshape_minvl.Value = 0;
                num_layer_subshape_minvo.Value = 0;

                num_layer_subshape_incHL.Value = 0;
                num_layer_subshape_incHO.Value = 0;
                num_layer_subshape_incVL.Value = 0;
                num_layer_subshape_incVO.Value = 0;

                num_layer_subshape_stepsHL.Value = 1;
                num_layer_subshape_stepsHO.Value = 1;
                num_layer_subshape_stepsVL.Value = 1;
                num_layer_subshape_stepsVO.Value = 1;
                break;
            case 1:
                num_layer_subshape2_minhl.Value = 0;
                num_layer_subshape2_minho.Value = 0;
                num_layer_subshape2_minvl.Value = 0;
                num_layer_subshape2_minvo.Value = 0;

                num_layer_subshape2_incHL.Value = 0;
                num_layer_subshape2_incHO.Value = 0;
                num_layer_subshape2_incVL.Value = 0;
                num_layer_subshape2_incVO.Value = 0;

                num_layer_subshape2_stepsHL.Value = 1;
                num_layer_subshape2_stepsHO.Value = 1;
                num_layer_subshape2_stepsVL.Value = 1;
                num_layer_subshape2_stepsVO.Value = 1;
                break;
            case 2:
                num_layer_subshape3_minhl.Value = 0;
                num_layer_subshape3_minho.Value = 0;
                num_layer_subshape3_minvl.Value = 0;
                num_layer_subshape3_minvo.Value = 0;

                num_layer_subshape3_incHL.Value = 0;
                num_layer_subshape3_incHO.Value = 0;
                num_layer_subshape3_incVL.Value = 0;
                num_layer_subshape3_incVO.Value = 0;

                num_layer_subshape3_stepsHL.Value = 1;
                num_layer_subshape3_stepsHO.Value = 1;
                num_layer_subshape3_stepsVL.Value = 1;
                num_layer_subshape3_stepsVO.Value = 1;
                break;
        }
    }

    private static void pClampNumeric(ref NumericStepper num, double min, double max)
    {
        num.Value = Math.Max(min, num.Value);
        num.Value = Math.Min(max, num.Value);
    }

    private void pClampSubShape(double minHLength, double maxHLength, double minVLength, double maxVLength, double minHOffset, double maxHOffset, double minVOffset, double maxVOffset)
    {
        Application.Instance.Invoke(() =>
        {
            pClampNumeric(ref num_layer_subshape_minhl, minHLength, maxHLength);
            pClampNumeric(ref num_layer_subshape_minvl, minVLength, maxVLength);
            pClampNumeric(ref num_layer_subshape_minho, minHOffset, maxHOffset);
            pClampNumeric(ref num_layer_subshape_minvo, minVOffset, maxVOffset);
        });
    }

    private void pClampSubShape2(double minHLength, double maxHLength, double minVLength, double maxVLength, double minHOffset, double maxHOffset, double minVOffset, double maxVOffset)
    {
        Application.Instance.Invoke(() =>
        {
            pClampNumeric(ref num_layer_subshape2_minhl, minHLength, maxHLength);
            pClampNumeric(ref num_layer_subshape2_minvl, minVLength, maxVLength);
            pClampNumeric(ref num_layer_subshape2_minho, minHOffset, maxHOffset);
            pClampNumeric(ref num_layer_subshape2_minvo, minVOffset, maxVOffset);
        });
    }

    private void pClampSubShape3(double minHLength, double maxHLength, double minVLength, double maxVLength, double minHOffset, double maxHOffset, double minVOffset, double maxVOffset)
    {
        Application.Instance.Invoke(() =>
        {
            pClampNumeric(ref num_layer_subshape3_minhl, minHLength, maxHLength);
            pClampNumeric(ref num_layer_subshape3_minvl, minVLength, maxVLength);
            pClampNumeric(ref num_layer_subshape3_minho, minHOffset, maxHOffset);
            pClampNumeric(ref num_layer_subshape3_minvo, minVOffset, maxVOffset);
        });
    }
}