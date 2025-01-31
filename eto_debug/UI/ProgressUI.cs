using Eto.Forms;

namespace eto_debug;

public partial class MainForm
{
    private void pDelegates()
    {
    }

    private void pPreLoad_Storage()
    {
    }

    private void pLoadOK_Storage(string loadOK)
    {
    }

    private void pUpdateProgressBar(double val)
    {
        Application.Instance.Invoke(() =>
        {
            progressBar.Indeterminate = false;
            if (progressBar.MaxValue < 100)
            {
                progressBar.MaxValue = 100;
            }
            if (val > 1)
            {
                val = 1;
            }
            if (val < 0)
            {
                val = 0;
            }
            progressBar.Value = (int)(val * progressBar.MaxValue);
        });
    }

    private void pUpdateProgressBar(int count, int max)
    {
        double val = (double)count / max;
        pUpdateProgressBar(val);
    }

    private void pUpdateProgressLabel(string text)
    {
        if (text == "")
        {
            return;
        }
        Application.Instance.Invoke(() => progressLabel.Text = text);
    }

    private void pIndeterminateQuiltUI(string tooltipText, string labelText)
    {
        Application.Instance.Invoke(() =>
        {
            pSetUI(false);
            progressBar.Indeterminate = true;
            progressBar.ToolTip = tooltipText;
            progressLabel.Text = labelText;
        });

    }

    private void pGeneratingPatternUI()
    {
        Application.Instance.Invoke(() =>
        {
            progressBar.Indeterminate = false;
            progressBar.Value = 0;
        });
    }

    private void pStitchingQuiltUI()
    {
    }

    private void pDoneQuiltUI(string text)
    {
    }

}