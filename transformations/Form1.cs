using static transformations.FormLogic;

namespace transformations;

public partial class Form1 : Form
{
    private TextBox logBox;
    private List<string> clickLogOrder = new();
    private List<CheckBox> allCheckBoxes = new();
    private Dictionary<TrackBar, int> sliderDefaults = new();
    private List<Control> controlPairs = new();
    private ComboBox comboReflectBox;
    private Label lblReflectAxis;

    public Form1()
    {
        InitializeComponent();
        SetupUI();
    }
        
    private void Log(string message)
    {
        logBox.AppendText(message + Environment.NewLine);
    }

    private void LogClick(string label, bool isChecked)
    {
        if (isChecked)
        {
            if (!clickLogOrder.Contains(label))
                clickLogOrder.Add(label);
        }
        else
        {
            clickLogOrder.Remove(label);
        }
        Log($"Checkbox {(isChecked ? "checked" : "unchecked")}: {label} → Order: {string.Join(", ", clickLogOrder)}");
    }

    private void SetupUI()
    {
        this.Text = "Transformation Tester";
        this.Size = new Size(1050, 520);
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;

        pictureBox = new PictureBox
        {
            BorderStyle = BorderStyle.FixedSingle,
            Location = new Point(10, 10),
            Size = new Size(450, 450),
            BackColor = Color.Black,
            SizeMode = PictureBoxSizeMode.CenterImage,
            Image = resizeimage()
        };
        this.Controls.Add(pictureBox);

        int startX = 480;
        int currentY = 20;
        int labelWidth = 60;
        int trackWidth = 180;
        int spacing = 35;

        TrackBar CreateTrackBar(int min, int max, int value, string label, int y, out Label lbl, out Label valueLabel)
        {
            lbl = new Label { Text = label, Location = new Point(startX, y + 5), Width = labelWidth };
            this.Controls.Add(lbl);

            TrackBar track = new TrackBar
            {
                Minimum = min,
                Maximum = max,
                Value = value,
                TickFrequency = (max - min) / 5,
                Width = trackWidth,
                Location = new Point(startX + labelWidth, y)
            };
            this.Controls.Add(track);

            valueLabel = new Label
            {
                Text = value.ToString(),
                Location = new Point(startX + labelWidth + trackWidth + 10, y + 5),
                Width = 40
            };
            this.Controls.Add(valueLabel);

            Label valueLabelLocal = valueLabel;

            track.ValueChanged += (s, e) =>
            {
                valueLabelLocal.Text = track.Value.ToString();
                Log($"{label} Slider changed to: {track.Value}");
                ApplyTransformations();
            };

            sliderDefaults[track] = value;
            controlPairs.Add(track);
            controlPairs.Add(lbl);
            controlPairs.Add(valueLabel);

            return track;
        }

        var chkRotation = new CheckBox { Text = "Rotation", Location = new Point(startX, currentY) };
        this.Controls.Add(chkRotation);
        allCheckBoxes.Add(chkRotation);
        currentY += spacing;
        trackRotation = CreateTrackBar(-180, 180, 0, "Degree", currentY, out Label lblRot, out Label valRot);
        trackRotation.Enabled = lblRot.Enabled = valRot.Enabled = false;
        chkRotation.CheckedChanged += (s, e) =>
        {
            bool enabled = chkRotation.Checked;
            trackRotation.Enabled = lblRot.Enabled = valRot.Enabled = enabled;
            LogClick(chkRotation.Text, enabled);
        };
        currentY += spacing;

        var chkTranslation = new CheckBox { Text = "Translation", Location = new Point(startX, currentY) };
        this.Controls.Add(chkTranslation);
        allCheckBoxes.Add(chkTranslation);
        currentY += spacing;
        trackTransX = CreateTrackBar(-100, 100, 0, "Trans X", currentY, out Label lblTransX, out Label valTransX);
        currentY += spacing;
        trackTransY = CreateTrackBar(-100, 100, 0, "Trans Y", currentY, out Label lblTransY, out Label valTransY);
        trackTransX.Enabled = lblTransX.Enabled = valTransX.Enabled = false;
        trackTransY.Enabled = lblTransY.Enabled = valTransY.Enabled = false;
        chkTranslation.CheckedChanged += (s, e) =>
        {
            bool enabled = chkTranslation.Checked;
            trackTransX.Enabled = lblTransX.Enabled = valTransX.Enabled = enabled;
            trackTransY.Enabled = lblTransY.Enabled = valTransY.Enabled = enabled;
            LogClick(chkTranslation.Text, enabled);
        };
        currentY += spacing;

        var chkScale = new CheckBox { Text = "Scale", Location = new Point(startX, currentY) };
        this.Controls.Add(chkScale);
        allCheckBoxes.Add(chkScale);
        currentY += spacing;
        trackScaleX = CreateTrackBar(10, 300, 100, "Scale X", currentY, out Label lblScaleX, out Label valScaleX);
        currentY += spacing;
        trackScaleY = CreateTrackBar(10, 300, 100, "Scale Y", currentY, out Label lblScaleY, out Label valScaleY);
        trackScaleX.Enabled = lblScaleX.Enabled = valScaleX.Enabled = false;
        trackScaleY.Enabled = lblScaleY.Enabled = valScaleY.Enabled = false;
        chkScale.CheckedChanged += (s, e) =>
        {
            bool enabled = chkScale.Checked;
            trackScaleX.Enabled = lblScaleX.Enabled = valScaleX.Enabled = enabled;
            trackScaleY.Enabled = lblScaleY.Enabled = valScaleY.Enabled = enabled;
            LogClick(chkScale.Text, enabled);
        };
        currentY += spacing;

        var chkShear = new CheckBox { Text = "Shear", Location = new Point(startX, currentY) };
        this.Controls.Add(chkShear);
        allCheckBoxes.Add(chkShear);
        currentY += spacing;
        trackShearX = CreateTrackBar(-100, 100, 0, "Shear X", currentY, out Label lblShearX, out Label valShearX);
        currentY += spacing;
        trackShearY = CreateTrackBar(-100, 100, 0, "Shear Y", currentY, out Label lblShearY, out Label valShearY);
        trackShearX.Enabled = lblShearX.Enabled = valShearX.Enabled = false;
        trackShearY.Enabled = lblShearY.Enabled = valShearY.Enabled = false;
        chkShear.CheckedChanged += (s, e) =>
        {
            bool enabled = chkShear.Checked;
            trackShearX.Enabled = lblShearX.Enabled = valShearX.Enabled = enabled;
            trackShearY.Enabled = lblShearY.Enabled = valShearY.Enabled = enabled;
            LogClick(chkShear.Text, enabled);
        };
        currentY += spacing;

        var chkReflect = new CheckBox { Text = "Reflection", Location = new Point(startX, currentY) };
        this.Controls.Add(chkReflect);
        allCheckBoxes.Add(chkReflect);
        currentY += spacing;

        lblReflectAxis = new Label { Text = "Axis", Location = new Point(startX, currentY + 5), Width = labelWidth };
        comboReflectBox = new ComboBox
        {
            Location = new Point(startX + labelWidth, currentY),
            Width = trackWidth,
            DropDownStyle = ComboBoxStyle.DropDownList
        };
        comboReflectBox.Items.AddRange(new object[] { "None", "Horizontal", "Vertical", "Both" });
        comboReflectBox.SelectedIndex = 0;
        comboReflectBox.SelectedIndexChanged += (s, e) =>
        {
            Log($"Reflection Axis changed to: {comboReflectBox.SelectedItem}");
            ApplyTransformations();
        };
        lblReflectAxis.Enabled = comboReflectBox.Enabled = false;
        this.Controls.Add(lblReflectAxis);
        this.Controls.Add(comboReflectBox);
        currentY += spacing;

        chkReflect.CheckedChanged += (s, e) =>
        {
            bool enabled = chkReflect.Checked;
            lblReflectAxis.Enabled = comboReflectBox.Enabled = enabled;
            LogClick(chkReflect.Text, enabled);
        };

        logBox = new TextBox
        {
            Location = new Point(startX + 290, currentY - 450),
            Width = 240,
            Height = 200,
            Multiline = true,
            ReadOnly = true,
            ScrollBars = ScrollBars.Vertical
        };
        this.Controls.Add(logBox);
        currentY += 210;

        var btnReset = new Button
        {
            Text = "Reset",
            Location = new Point(startX + 290, currentY - 450),
            Width = 100
        };
        btnReset.Click += (s, e) =>
        {
            clickLogOrder.Clear();
            logBox.Clear();
            Log("Reset performed.");

            foreach (var cb in allCheckBoxes)
                cb.Checked = false;

            foreach (var kvp in sliderDefaults)
            {
                kvp.Key.Value = kvp.Value;
                kvp.Key.Enabled = false;
            }

            foreach (var control in controlPairs)
                control.Enabled = false;

            if (comboReflectBox != null)
            {
                comboReflectBox.SelectedIndex = 0;
                comboReflectBox.Enabled = false;
            }

            if (lblReflectAxis != null)
                lblReflectAxis.Enabled = false;

                pictureBox.Image = resizeimage();
        };
        this.Controls.Add(btnReset);
    }
}
