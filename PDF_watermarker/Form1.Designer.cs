namespace PDF_watermarker
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            PDFOpenFileDialog = new OpenFileDialog();
            PDFViewerPanel = new Panel();
            ChoosePDFFileButton = new Button();
            FirstPageOnlyСheckBox = new CheckBox();
            ToolsPanel = new Panel();
            DragLabel = new Label();
            SettingsPanel = new Panel();
            MinusButton = new Button();
            SizeNumericUpDown = new NumericUpDown();
            PlusButton = new Button();
            RotationComboBox = new ComboBox();
            RotationNumericUpDown = new NumericUpDown();
            Row2OffsetNumericUpDown = new NumericUpDown();
            RotationOffsetLabel = new Label();
            Row1OffsetNumericUpDown = new NumericUpDown();
            RotationTrackBar = new TrackBar();
            YSpaceNumericUpDown = new NumericUpDown();
            XSpaceNumericUpDown = new NumericUpDown();
            Row2OffsetLabel = new Label();
            Row2OffsetTrackBar = new TrackBar();
            Row1OffsetLabel = new Label();
            Row1OffsetTrackBar = new TrackBar();
            YSpaceLabel = new Label();
            YSpaceTrackBar = new TrackBar();
            XSpaceLabel = new Label();
            XSpaceTrackBar = new TrackBar();
            SizeLabel = new Label();
            SizeTrackBar = new TrackBar();
            OpacityValueLabel = new Label();
            OpacityLabel = new Label();
            OpacityTrackBar = new TrackBar();
            SavePDFButton = new Button();
            WatermarkPictureBox = new PictureBox();
            ChooseWatermarkFileButton = new Button();
            SavingProgressBar = new ProgressBar();
            ImageOpenFileDialog = new OpenFileDialog();
            ToolsPanel.SuspendLayout();
            SettingsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SizeNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)RotationNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Row2OffsetNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Row1OffsetNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)RotationTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)YSpaceNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)XSpaceNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Row2OffsetTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Row1OffsetTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)YSpaceTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)XSpaceTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SizeTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)OpacityTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)WatermarkPictureBox).BeginInit();
            SuspendLayout();
            // 
            // PDFOpenFileDialog
            // 
            PDFOpenFileDialog.Filter = "PDF Files|*.pdf";
            PDFOpenFileDialog.Title = "Choose PDF";
            // 
            // PDFViewerPanel
            // 
            PDFViewerPanel.AutoScroll = true;
            PDFViewerPanel.Dock = DockStyle.Fill;
            PDFViewerPanel.Location = new Point(471, 0);
            PDFViewerPanel.Name = "PDFViewerPanel";
            PDFViewerPanel.Size = new Size(0, 664);
            PDFViewerPanel.TabIndex = 1;
            // 
            // ChoosePDFFileButton
            // 
            ChoosePDFFileButton.Location = new Point(15, 5);
            ChoosePDFFileButton.Name = "ChoosePDFFileButton";
            ChoosePDFFileButton.Size = new Size(117, 23);
            ChoosePDFFileButton.TabIndex = 2;
            ChoosePDFFileButton.Text = "Choose PDF File";
            ChoosePDFFileButton.UseVisualStyleBackColor = true;
            ChoosePDFFileButton.Click += ChooseFileButton_Click;
            // 
            // FirstPageOnlyСheckBox
            // 
            FirstPageOnlyСheckBox.AutoSize = true;
            FirstPageOnlyСheckBox.Location = new Point(15, 10);
            FirstPageOnlyСheckBox.Name = "FirstPageOnlyСheckBox";
            FirstPageOnlyСheckBox.Size = new Size(105, 19);
            FirstPageOnlyСheckBox.TabIndex = 3;
            FirstPageOnlyСheckBox.Text = "First Page Only";
            FirstPageOnlyСheckBox.UseVisualStyleBackColor = true;
            FirstPageOnlyСheckBox.CheckedChanged += FirstPageOnlyСheckBox_CheckedChanged;
            // 
            // ToolsPanel
            // 
            ToolsPanel.Controls.Add(DragLabel);
            ToolsPanel.Controls.Add(SettingsPanel);
            ToolsPanel.Controls.Add(WatermarkPictureBox);
            ToolsPanel.Controls.Add(ChooseWatermarkFileButton);
            ToolsPanel.Controls.Add(ChoosePDFFileButton);
            ToolsPanel.Dock = DockStyle.Left;
            ToolsPanel.Location = new Point(0, 0);
            ToolsPanel.Name = "ToolsPanel";
            ToolsPanel.Size = new Size(471, 664);
            ToolsPanel.TabIndex = 5;
            // 
            // DragLabel
            // 
            DragLabel.AutoSize = true;
            DragLabel.Location = new Point(290, 9);
            DragLabel.Name = "DragLabel";
            DragLabel.Size = new Size(71, 15);
            DragLabel.TabIndex = 26;
            DragLabel.Text = "Or drag files";
            // 
            // SettingsPanel
            // 
            SettingsPanel.Controls.Add(MinusButton);
            SettingsPanel.Controls.Add(SizeNumericUpDown);
            SettingsPanel.Controls.Add(PlusButton);
            SettingsPanel.Controls.Add(RotationComboBox);
            SettingsPanel.Controls.Add(RotationNumericUpDown);
            SettingsPanel.Controls.Add(Row2OffsetNumericUpDown);
            SettingsPanel.Controls.Add(RotationOffsetLabel);
            SettingsPanel.Controls.Add(Row1OffsetNumericUpDown);
            SettingsPanel.Controls.Add(RotationTrackBar);
            SettingsPanel.Controls.Add(YSpaceNumericUpDown);
            SettingsPanel.Controls.Add(XSpaceNumericUpDown);
            SettingsPanel.Controls.Add(Row2OffsetLabel);
            SettingsPanel.Controls.Add(Row2OffsetTrackBar);
            SettingsPanel.Controls.Add(Row1OffsetLabel);
            SettingsPanel.Controls.Add(Row1OffsetTrackBar);
            SettingsPanel.Controls.Add(YSpaceLabel);
            SettingsPanel.Controls.Add(YSpaceTrackBar);
            SettingsPanel.Controls.Add(XSpaceLabel);
            SettingsPanel.Controls.Add(XSpaceTrackBar);
            SettingsPanel.Controls.Add(SizeLabel);
            SettingsPanel.Controls.Add(SizeTrackBar);
            SettingsPanel.Controls.Add(OpacityValueLabel);
            SettingsPanel.Controls.Add(OpacityLabel);
            SettingsPanel.Controls.Add(OpacityTrackBar);
            SettingsPanel.Controls.Add(FirstPageOnlyСheckBox);
            SettingsPanel.Controls.Add(SavePDFButton);
            SettingsPanel.Location = new Point(0, 35);
            SettingsPanel.Name = "SettingsPanel";
            SettingsPanel.Size = new Size(471, 392);
            SettingsPanel.TabIndex = 25;
            SettingsPanel.Visible = false;
            // 
            // MinusButton
            // 
            MinusButton.Location = new Point(159, 7);
            MinusButton.Name = "MinusButton";
            MinusButton.Size = new Size(23, 23);
            MinusButton.TabIndex = 28;
            MinusButton.Text = "-";
            MinusButton.UseVisualStyleBackColor = true;
            MinusButton.Click += MinusButton_Click;
            // 
            // SizeNumericUpDown
            // 
            SizeNumericUpDown.Location = new Point(86, 80);
            SizeNumericUpDown.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            SizeNumericUpDown.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            SizeNumericUpDown.Name = "SizeNumericUpDown";
            SizeNumericUpDown.Size = new Size(50, 23);
            SizeNumericUpDown.TabIndex = 50;
            SizeNumericUpDown.Value = new decimal(new int[] { 10, 0, 0, 0 });
            SizeNumericUpDown.ValueChanged += SizeNumericUpDown_ValueChanged;
            // 
            // PlusButton
            // 
            PlusButton.Location = new Point(130, 7);
            PlusButton.Name = "PlusButton";
            PlusButton.Size = new Size(23, 23);
            PlusButton.TabIndex = 27;
            PlusButton.Text = "+";
            PlusButton.UseVisualStyleBackColor = true;
            PlusButton.Click += PlusButton_Click;
            // 
            // RotationComboBox
            // 
            RotationComboBox.FormattingEnabled = true;
            RotationComboBox.Items.AddRange(new object[] { "0", "45", "90", "135", "180", "225", "270", "315", "360" });
            RotationComboBox.Location = new Point(142, 329);
            RotationComboBox.Name = "RotationComboBox";
            RotationComboBox.Size = new Size(121, 23);
            RotationComboBox.TabIndex = 49;
            RotationComboBox.SelectedIndexChanged += RotationComboBox_SelectedIndexChanged;
            // 
            // RotationNumericUpDown
            // 
            RotationNumericUpDown.Location = new Point(86, 330);
            RotationNumericUpDown.Maximum = new decimal(new int[] { 360, 0, 0, 0 });
            RotationNumericUpDown.Name = "RotationNumericUpDown";
            RotationNumericUpDown.Size = new Size(50, 23);
            RotationNumericUpDown.TabIndex = 48;
            RotationNumericUpDown.ValueChanged += RotationNumericUpDown_ValueChanged;
            // 
            // Row2OffsetNumericUpDown
            // 
            Row2OffsetNumericUpDown.Location = new Point(112, 280);
            Row2OffsetNumericUpDown.Name = "Row2OffsetNumericUpDown";
            Row2OffsetNumericUpDown.Size = new Size(50, 23);
            Row2OffsetNumericUpDown.TabIndex = 47;
            Row2OffsetNumericUpDown.ValueChanged += Row2OffsetNumericUpDown_ValueChanged;
            // 
            // RotationOffsetLabel
            // 
            RotationOffsetLabel.AutoSize = true;
            RotationOffsetLabel.Location = new Point(15, 330);
            RotationOffsetLabel.Name = "RotationOffsetLabel";
            RotationOffsetLabel.Size = new Size(52, 15);
            RotationOffsetLabel.TabIndex = 48;
            RotationOffsetLabel.Text = "Rotation";
            // 
            // Row1OffsetNumericUpDown
            // 
            Row1OffsetNumericUpDown.Location = new Point(112, 230);
            Row1OffsetNumericUpDown.Name = "Row1OffsetNumericUpDown";
            Row1OffsetNumericUpDown.Size = new Size(50, 23);
            Row1OffsetNumericUpDown.TabIndex = 46;
            Row1OffsetNumericUpDown.ValueChanged += Row1OffsetNumericUpDown_ValueChanged;
            // 
            // RotationTrackBar
            // 
            RotationTrackBar.Location = new Point(0, 350);
            RotationTrackBar.Maximum = 360;
            RotationTrackBar.Name = "RotationTrackBar";
            RotationTrackBar.Size = new Size(471, 45);
            RotationTrackBar.TabIndex = 48;
            RotationTrackBar.TickFrequency = 10;
            RotationTrackBar.Scroll += RotationTrackBar_Scroll;
            // 
            // YSpaceNumericUpDown
            // 
            YSpaceNumericUpDown.Location = new Point(86, 180);
            YSpaceNumericUpDown.Name = "YSpaceNumericUpDown";
            YSpaceNumericUpDown.Size = new Size(50, 23);
            YSpaceNumericUpDown.TabIndex = 45;
            YSpaceNumericUpDown.ValueChanged += YSpaceNumericUpDown_ValueChanged;
            // 
            // XSpaceNumericUpDown
            // 
            XSpaceNumericUpDown.Location = new Point(86, 130);
            XSpaceNumericUpDown.Name = "XSpaceNumericUpDown";
            XSpaceNumericUpDown.Size = new Size(50, 23);
            XSpaceNumericUpDown.TabIndex = 44;
            XSpaceNumericUpDown.ValueChanged += XSpaceNumericUpDown_ValueChanged;
            // 
            // Row2OffsetLabel
            // 
            Row2OffsetLabel.AutoSize = true;
            Row2OffsetLabel.Location = new Point(15, 280);
            Row2OffsetLabel.Name = "Row2OffsetLabel";
            Row2OffsetLabel.Size = new Size(94, 15);
            Row2OffsetLabel.TabIndex = 41;
            Row2OffsetLabel.Text = "2 Row Offset(px)";
            // 
            // Row2OffsetTrackBar
            // 
            Row2OffsetTrackBar.Location = new Point(0, 300);
            Row2OffsetTrackBar.Maximum = 100;
            Row2OffsetTrackBar.Name = "Row2OffsetTrackBar";
            Row2OffsetTrackBar.Size = new Size(471, 45);
            Row2OffsetTrackBar.TabIndex = 40;
            Row2OffsetTrackBar.TickFrequency = 10;
            Row2OffsetTrackBar.ValueChanged += Row2OffsetTrackBar_ValueChanged;
            // 
            // Row1OffsetLabel
            // 
            Row1OffsetLabel.AutoSize = true;
            Row1OffsetLabel.Location = new Point(15, 230);
            Row1OffsetLabel.Name = "Row1OffsetLabel";
            Row1OffsetLabel.Size = new Size(94, 15);
            Row1OffsetLabel.TabIndex = 38;
            Row1OffsetLabel.Text = "1 Row Offset(px)";
            // 
            // Row1OffsetTrackBar
            // 
            Row1OffsetTrackBar.Location = new Point(0, 250);
            Row1OffsetTrackBar.Maximum = 100;
            Row1OffsetTrackBar.Name = "Row1OffsetTrackBar";
            Row1OffsetTrackBar.Size = new Size(471, 45);
            Row1OffsetTrackBar.TabIndex = 37;
            Row1OffsetTrackBar.TickFrequency = 10;
            Row1OffsetTrackBar.ValueChanged += Row1OffsetTrackBar_ValueChanged;
            // 
            // YSpaceLabel
            // 
            YSpaceLabel.AutoSize = true;
            YSpaceLabel.Location = new Point(15, 180);
            YSpaceLabel.Name = "YSpaceLabel";
            YSpaceLabel.Size = new Size(68, 15);
            YSpaceLabel.TabIndex = 35;
            YSpaceLabel.Text = "Y Space(px)";
            // 
            // YSpaceTrackBar
            // 
            YSpaceTrackBar.Location = new Point(0, 200);
            YSpaceTrackBar.Maximum = 100;
            YSpaceTrackBar.Name = "YSpaceTrackBar";
            YSpaceTrackBar.Size = new Size(471, 45);
            YSpaceTrackBar.TabIndex = 34;
            YSpaceTrackBar.TickFrequency = 10;
            YSpaceTrackBar.ValueChanged += YSpaceTrackBar_ValueChanged;
            // 
            // XSpaceLabel
            // 
            XSpaceLabel.AutoSize = true;
            XSpaceLabel.Location = new Point(15, 130);
            XSpaceLabel.Name = "XSpaceLabel";
            XSpaceLabel.Size = new Size(68, 15);
            XSpaceLabel.TabIndex = 32;
            XSpaceLabel.Text = "X Space(px)";
            // 
            // XSpaceTrackBar
            // 
            XSpaceTrackBar.Location = new Point(0, 150);
            XSpaceTrackBar.Maximum = 100;
            XSpaceTrackBar.Name = "XSpaceTrackBar";
            XSpaceTrackBar.Size = new Size(471, 45);
            XSpaceTrackBar.TabIndex = 31;
            XSpaceTrackBar.TickFrequency = 10;
            XSpaceTrackBar.ValueChanged += XSpaceTrackBar_ValueChanged;
            // 
            // SizeLabel
            // 
            SizeLabel.AutoSize = true;
            SizeLabel.Location = new Point(15, 80);
            SizeLabel.Name = "SizeLabel";
            SizeLabel.Size = new Size(47, 15);
            SizeLabel.TabIndex = 29;
            SizeLabel.Text = "Size(px)";
            // 
            // SizeTrackBar
            // 
            SizeTrackBar.LargeChange = 1;
            SizeTrackBar.Location = new Point(0, 100);
            SizeTrackBar.Minimum = 10;
            SizeTrackBar.Name = "SizeTrackBar";
            SizeTrackBar.Size = new Size(471, 45);
            SizeTrackBar.TabIndex = 28;
            SizeTrackBar.TickFrequency = 10;
            SizeTrackBar.Value = 10;
            SizeTrackBar.ValueChanged += SizeTrackBar_ValueChanged;
            // 
            // OpacityValueLabel
            // 
            OpacityValueLabel.AutoSize = true;
            OpacityValueLabel.Location = new Point(66, 30);
            OpacityValueLabel.Name = "OpacityValueLabel";
            OpacityValueLabel.Size = new Size(0, 15);
            OpacityValueLabel.TabIndex = 27;
            // 
            // OpacityLabel
            // 
            OpacityLabel.AutoSize = true;
            OpacityLabel.Location = new Point(15, 30);
            OpacityLabel.Name = "OpacityLabel";
            OpacityLabel.Size = new Size(48, 15);
            OpacityLabel.TabIndex = 26;
            OpacityLabel.Text = "Opacity";
            // 
            // OpacityTrackBar
            // 
            OpacityTrackBar.Location = new Point(0, 50);
            OpacityTrackBar.Maximum = 100;
            OpacityTrackBar.Name = "OpacityTrackBar";
            OpacityTrackBar.Size = new Size(471, 45);
            OpacityTrackBar.TabIndex = 25;
            OpacityTrackBar.TickFrequency = 10;
            OpacityTrackBar.ValueChanged += OpacityTrackBar_ValueChanged;
            // 
            // SavePDFButton
            // 
            SavePDFButton.Location = new Point(188, 7);
            SavePDFButton.Name = "SavePDFButton";
            SavePDFButton.Size = new Size(75, 23);
            SavePDFButton.TabIndex = 21;
            SavePDFButton.Text = "Save PDF";
            SavePDFButton.UseVisualStyleBackColor = true;
            SavePDFButton.Click += SavePDFButton_Click;
            // 
            // WatermarkPictureBox
            // 
            WatermarkPictureBox.Location = new Point(0, 424);
            WatermarkPictureBox.Name = "WatermarkPictureBox";
            WatermarkPictureBox.Size = new Size(471, 240);
            WatermarkPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            WatermarkPictureBox.TabIndex = 5;
            WatermarkPictureBox.TabStop = false;
            // 
            // ChooseWatermarkFileButton
            // 
            ChooseWatermarkFileButton.Location = new Point(135, 5);
            ChooseWatermarkFileButton.Name = "ChooseWatermarkFileButton";
            ChooseWatermarkFileButton.Size = new Size(149, 23);
            ChooseWatermarkFileButton.TabIndex = 4;
            ChooseWatermarkFileButton.Text = "Choose Watermark File";
            ChooseWatermarkFileButton.UseVisualStyleBackColor = true;
            ChooseWatermarkFileButton.Click += ChooseWatermarkFileButton_Click;
            // 
            // SavingProgressBar
            // 
            SavingProgressBar.Dock = DockStyle.Bottom;
            SavingProgressBar.Location = new Point(0, 664);
            SavingProgressBar.Name = "SavingProgressBar";
            SavingProgressBar.Size = new Size(471, 23);
            SavingProgressBar.TabIndex = 22;
            SavingProgressBar.Visible = false;
            // 
            // ImageOpenFileDialog
            // 
            ImageOpenFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.tif;*.tiff";
            ImageOpenFileDialog.Title = "Choose Watermark";
            // 
            // Form1
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(471, 687);
            Controls.Add(PDFViewerPanel);
            Controls.Add(ToolsPanel);
            Controls.Add(SavingProgressBar);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PDF Watermarker";
            FormClosing += Form1_FormClosing;
            DragDrop += Form1_DragDrop;
            DragOver += Form1_DragOver;
            ToolsPanel.ResumeLayout(false);
            ToolsPanel.PerformLayout();
            SettingsPanel.ResumeLayout(false);
            SettingsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)SizeNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)RotationNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)Row2OffsetNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)Row1OffsetNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)RotationTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)YSpaceNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)XSpaceNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)Row2OffsetTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)Row1OffsetTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)YSpaceTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)XSpaceTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)SizeTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)OpacityTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)WatermarkPictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private OpenFileDialog PDFOpenFileDialog;
        private Panel PDFViewerPanel;
        private Button ChoosePDFFileButton;
        private CheckBox FirstPageOnlyСheckBox;
        private Panel ToolsPanel;
        private Button ChooseWatermarkFileButton;
        private PictureBox WatermarkPictureBox;
        private OpenFileDialog ImageOpenFileDialog;
        private Button SavePDFButton;
        private ProgressBar SavingProgressBar;
        private Panel SettingsPanel;
        private Label Row2OffsetLabel;
        private TrackBar Row2OffsetTrackBar;
        private Label Row1OffsetLabel;
        private TrackBar Row1OffsetTrackBar;
        private Label YSpaceLabel;
        private TrackBar YSpaceTrackBar;
        private Label XSpaceLabel;
        private TrackBar XSpaceTrackBar;
        private TrackBar SizeTrackBar;
        private Label OpacityValueLabel;
        private Label OpacityLabel;
        private TrackBar OpacityTrackBar;
        private Label DragLabel;
        private NumericUpDown XSpaceNumericUpDown;
        private NumericUpDown YSpaceNumericUpDown;
        private NumericUpDown Row2OffsetNumericUpDown;
        private NumericUpDown Row1OffsetNumericUpDown;
        private NumericUpDown RotationNumericUpDown;
        private Label RotationOffsetLabel;
        private TrackBar RotationTrackBar;
        private ComboBox RotationComboBox;
        private NumericUpDown SizeNumericUpDown;
        private Label SizeLabel;
        private Button PlusButton;
        private Button MinusButton;
    }
}
