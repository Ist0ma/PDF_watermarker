using PDF_watermarker.Models;
using PdfSharp.Drawing;
using System.Drawing.Imaging;

namespace PDF_watermarker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            scaleFactorX = (float)previewDpiX / (float)dpiX;
            scaleFactorY = (float)previewDpiY / (float)dpiY;
        }

        private int previewDpiX = 60;
        private int previewDpiY = 60;
        private int dpiX = 300;
        private int dpiY = 300;
        private float scaleFactorX;
        private float scaleFactorY;

        private int size = 0, xSpace = 0, ySpace = 0, row1Offset = 0, row2Offset = 0, rotation = 0;
        private int wmWidth, wmHeight;
        private Image? originalWatermark = null, cachedWatermark = null;
        private PdfiumViewer.PdfDocument? pdfDocument;
        private ImageAttributes imageAttributes = new ImageAttributes();
        private List<PageViewModel> pages = new List<PageViewModel>();

        private bool ReadyToRender => originalWatermark != null && pages.Count > 0;

        private void ChooseFileButton_Click(object sender, EventArgs e)
        {
            if (PDFOpenFileDialog.ShowDialog() != DialogResult.OK)
                return;

            LoadDocument(PDFOpenFileDialog.FileName);
        }

        private void LoadDocument(string path)
        {
            ClearDocument();
            try
            {
                pdfDocument?.Dispose();
                pdfDocument = PdfiumViewer.PdfDocument.Load(path);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
                return;
            }
            PrintPDF();
        }

        private void PrintPDF()
        {
            int yOffset = 10;
            int maxPageWidth = 0;
            int maxPageHeight = 0;

            for (int pageIndex = 0; pageIndex < pdfDocument.PageCount; pageIndex++)
            {
                var pageSize = pdfDocument.PageSizes[pageIndex];
                int pageWidthPx = (int)(pageSize.Width * previewDpiX / 72f);
                int pageHeightPx = (int)(pageSize.Height * previewDpiY / 72f);

                if (pageWidthPx > maxPageWidth)
                    maxPageWidth = pageWidthPx;

                if (pageHeightPx > maxPageHeight)
                    maxPageHeight = pageHeightPx;

                using (var pagePreviewImage = pdfDocument.Render(pageIndex,
                                                                 pageWidthPx,
                                                                 pageHeightPx,
                                                                 previewDpiX,
                                                                 previewDpiY,
                                                                 true))
                {
                    var panel = new Panel
                    {
                        Size = new Size(pageWidthPx, pageHeightPx),
                        Location = new Point(10, yOffset)
                    };

                    var pb = new PictureBox
                    {
                        SizeMode = PictureBoxSizeMode.AutoSize,
                        Location = new Point(0, 0)
                    };

                    PageViewModel pvm = new PageViewModel((Image)pagePreviewImage.Clone(), pb, panel);

                    pb.Image = (Image)pagePreviewImage.Clone();
                    pb.Click += (sender, e) =>
                    {
                        FirstPageOnlyÑheckBox.Checked = false;
                        pvm.Marked = !pvm.Marked;
                        Render();
                    };

                    pages.Add(pvm);
                    panel.Controls.Add(pb);
                    PDFViewerPanel.Controls.Add(panel);

                    yOffset += pageHeightPx + 30;

                    Label label = new Label
                    {
                        Text = $"Page {pageIndex + 1}",
                        Location = new Point(10, yOffset - 30),
                        BackColor = Color.Transparent,
                        AutoSize = true,
                        ForeColor = Color.Black,
                        Font = new Font("Arial", 10, FontStyle.Italic)
                    };
                    PDFViewerPanel.Controls.Add(label);
                }
            }

            Width = ToolsPanel.Width + maxPageWidth + 100;
            Height = maxPageHeight + 100;
            if (ReadyToRender)
            {
                SetParameters();
                SettingsPanel.Show();

                Render();
            }
            else
            {
                SettingsPanel.Hide();
            }
        }

        private void SetParameters()
        {
            int firstPageWidth = pages[0].OriginalImage.Width;
            int firstPageHeight = pages[0].OriginalImage.Height;

            FirstPageOnlyÑheckBox.Checked = false;
            XSpaceTrackBar.Minimum = -originalWatermark.Width / 2;
            XSpaceTrackBar.Maximum = firstPageWidth;
            XSpaceNumericUpDown.Minimum = -originalWatermark.Width / 2;
            XSpaceNumericUpDown.Maximum = firstPageWidth;
            XSpaceTrackBar.LargeChange = firstPageWidth / 50;
            YSpaceTrackBar.Minimum = -originalWatermark.Height / 2;
            YSpaceTrackBar.Maximum = firstPageHeight;
            YSpaceNumericUpDown.Minimum = -originalWatermark.Height / 2;
            YSpaceNumericUpDown.Maximum = firstPageHeight;
            YSpaceTrackBar.LargeChange = firstPageHeight / 50;
            Row1OffsetTrackBar.Maximum = firstPageWidth;
            Row1OffsetNumericUpDown.Maximum = firstPageWidth;
            Row2OffsetTrackBar.Maximum = firstPageWidth;
            Row2OffsetNumericUpDown.Maximum = firstPageWidth;

            SizeTrackBar.Maximum = firstPageWidth - 1;
            SizeNumericUpDown.Maximum = firstPageWidth - 1;

            SetSize(firstPageWidth / 4, false);

            SetXSpace(firstPageWidth / 8, false);

            int maxRows = firstPageHeight / wmHeight;
            int bestRows = 1;
            int bestYSpace = 0;

            for (int rows = maxRows; rows >= 2; rows--)
            {
                int ySpace = (firstPageHeight - rows * wmHeight) / (rows - 1);
                if (ySpace > 0)
                {
                    bestRows = rows;
                    bestYSpace = ySpace;
                    break;
                }
            }

            SetYSpace(bestYSpace, false);

            SetRow1Offset(row1Offset, false);
            SetRow2Offset((wmWidth + xSpace) / 2, false);

            SetRotation(rotation, false);

            SetOpacity(30, false);
        }

        private Image GetCachedWatermark()
        {
            if (cachedWatermark != null)
                return cachedWatermark;

            cachedWatermark?.Dispose();
            cachedWatermark = ApplyOpacity(new Bitmap(originalWatermark, wmWidth, wmHeight));
            return cachedWatermark;
        }

        private Image ApplyOpacity(Image image)
        {
            int width = image.Width;
            int height = image.Height;

            Bitmap bmp = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.DrawImage(
                    image,
                    new Rectangle(0, 0, width, height),
                    0, 0, width, height,
                    GraphicsUnit.Pixel,
                    imageAttributes
                );
            }
            return bmp;
        }

        private void Render()
        {
            if (!ReadyToRender)
                return;

            try
            {
                var watermarkImg = GetCachedWatermark();

                for (int i = 0; i < pages.Count; i++)
                {
                    var original = pages[i].OriginalImage;

                    pages[i].PictureBox.Image?.Dispose();

                    if (!pages[i].Marked)
                    {
                        pages[i].PictureBox.Image = (Image)original.Clone();
                        continue;
                    }

                    using (Bitmap combined = new Bitmap(original.Width, original.Height))
                    {
                        using (Graphics g = Graphics.FromImage(combined))
                        {
                            g.DrawImage(original,
                                        0,
                                        0,
                                        original.Width,
                                        original.Height);

                            for (int y = 0, row = 0; y <= original.Height; y += wmHeight + ySpace, row++)
                            {
                                int xStart = (row % 2 == 0) ? row1Offset : row2Offset;
                                for (int x = -xStart; x <= original.Width; x += wmWidth + xSpace)
                                {
                                    if (rotation == 0 || rotation == 360)
                                    {
                                        g.DrawImage(watermarkImg,
                                                    x,
                                                    y,
                                                    wmWidth,
                                                    wmHeight);
                                        g.DrawRectangle(Pens.Red, x, y, wmWidth, wmHeight);
                                    }
                                    else
                                    {
                                        float centerX = x + wmWidth / 2f;
                                        float centerY = y + wmHeight / 2f;

                                        g.TranslateTransform(centerX, centerY);
                                        g.RotateTransform(rotation);
                                        g.TranslateTransform(-wmWidth / 2f, -wmHeight / 2f);

                                        g.DrawImage(watermarkImg, 0, 0, wmWidth, wmHeight);
                                        g.DrawRectangle(Pens.Red, 0, 0, wmWidth, wmHeight);

                                        g.ResetTransform();
                                    }
                                }
                            }
                        }
                        pages[i].PictureBox.Image = (Image)combined.Clone();
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void SavePDFButton_Click(object sender, EventArgs e)
        {
            try
            {
                Lock();
                using (var sfd = new SaveFileDialog
                {
                    Filter = "PDF files (*.pdf)|*.pdf",
                    DefaultExt = "pdf"
                })
                {
                    if (sfd.ShowDialog() != DialogResult.OK)
                        return;

                    int wmWidth = (int)(this.wmWidth / scaleFactorX);
                    int wmHeight = (int)(this.wmHeight / scaleFactorY);

                    SavingProgressBar.Value = 1;
                    SavingProgressBar.Show();
                    int xSpace = (int)(this.xSpace / scaleFactorX);
                    int ySpace = (int)(this.ySpace / scaleFactorY);
                    int row1Offset = (int)(this.row1Offset / scaleFactorX);
                    int row2Offset = (int)(this.row2Offset / scaleFactorX);

                    using (var document = new PdfSharp.Pdf.PdfDocument())
                    using (var watermark = ApplyOpacity(originalWatermark))
                    {
                        int totalWatermarks = 1;
                        for (int pageIndex = 0; pageIndex < pdfDocument.PageCount; pageIndex++)
                        {
                            var pageSize = pdfDocument.PageSizes[pageIndex];
                            int PageWidthPx = (int)(pageSize.Width * dpiX / 72);
                            int PageHeightPx = (int)(pageSize.Height * dpiY / 72);

                            if (pages[pageIndex].Marked)
                            {
                                for (int y = 0, row = 0; y <= PageHeightPx; y += wmHeight + ySpace, row++)
                                {
                                    int xStart = (row % 2 == 0) ? row1Offset : row2Offset;
                                    for (int x = -xStart; x <= PageWidthPx; x += wmWidth + xSpace)
                                    {
                                        totalWatermarks++;
                                    }
                                }
                            }
                        }

                        SavingProgressBar.Maximum = totalWatermarks;

                        for (int pageIndex = 0; pageIndex < pdfDocument.PageCount; pageIndex++)
                        {
                            var pageSize = pdfDocument.PageSizes[pageIndex];
                            int pageWidthPx = (int)(pageSize.Width * dpiX / 72);
                            int pageHeightPx = (int)(pageSize.Height * dpiY / 72);

                            using (Bitmap combined = new Bitmap(pageWidthPx, pageHeightPx))
                            {
                                using (var PageImage = pdfDocument.Render(pageIndex,
                                                                          pageWidthPx,
                                                                          pageHeightPx,
                                                                          dpiX,
                                                                          dpiY,
                                                                          true))
                                using (Graphics g = Graphics.FromImage(combined))
                                {
                                    g.DrawImage(PageImage,
                                                0,
                                                0,
                                                pageWidthPx,
                                                pageHeightPx);

                                    if (pages[pageIndex].Marked)
                                    {
                                        for (int y = 0, row = 0; y <= pageHeightPx; y += wmHeight + ySpace, row++)
                                        {
                                            int xStart = (row % 2 == 0) ? row1Offset : row2Offset;
                                            for (int x = -xStart; x <= pageWidthPx; x += wmWidth + xSpace)
                                            {
                                                if (rotation == 0 || rotation == 360)
                                                {
                                                    g.DrawImage(watermark,
                                                                x,
                                                                y,
                                                                wmWidth,
                                                                wmHeight);
                                                }
                                                else
                                                {
                                                    float centerX = x + wmWidth / 2f;
                                                    float centerY = y + wmHeight / 2f;

                                                    g.TranslateTransform(centerX, centerY);
                                                    g.RotateTransform(rotation);
                                                    g.TranslateTransform(-wmWidth / 2f, -wmHeight / 2f);

                                                    g.DrawImage(watermark, 0, 0, wmWidth, wmHeight);

                                                    g.ResetTransform();
                                                }
                                                SavingProgressBar.Value++;
                                                SavingProgressBar.Update();
                                            }
                                        }
                                    }
                                }
                                var pdfPage = document.AddPage();
                                pdfPage.Width = XUnit.FromPoint(pageWidthPx * 72.0 / dpiX);
                                pdfPage.Height = XUnit.FromPoint(pageHeightPx * 72.0 / dpiY);

                                using (var xgr = XGraphics.FromPdfPage(pdfPage))
                                using (var ms = new MemoryStream())
                                {
                                    combined.Save(ms, ImageFormat.Png);
                                    ms.Position = 0;
                                    using (var ximg = XImage.FromStream(ms))
                                    {
                                        xgr.DrawImage(ximg,
                                                      0,
                                                      0,
                                                      pdfPage.Width.Point,
                                                      pdfPage.Height.Point);
                                    }
                                }
                            }
                        }
                        document.Save(sfd.FileName);
                        MessageBox.Show("PDF saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                SavingProgressBar.Hide();
                Unlock();
            }
        }

        private void ChooseWatermarkFileButton_Click(object sender, EventArgs e)
        {
            if (ImageOpenFileDialog.ShowDialog() != DialogResult.OK)
                return;

            LoadWatermark(ImageOpenFileDialog.FileName);
        }

        private void LoadWatermark(string path)
        {
            try
            {
                ClearWatermark();

                using (var original = Image.FromFile(path))
                    originalWatermark = (Image)original.Clone();

                WatermarkPictureBox.Image?.Dispose();
                WatermarkPictureBox.Image = originalWatermark;

                wmHeight = originalWatermark.Height * size / originalWatermark.Width;
            }
            finally
            {
                if (ReadyToRender)
                {
                    SetParameters();
                    SettingsPanel.Show();

                    Render();
                }
                else
                {
                    SettingsPanel.Hide();
                }
            }
        }

        private void FirstPageOnlyÑheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (FirstPageOnlyÑheckBox.Checked)
            {
                PDFViewerPanel.AutoScrollPosition = new Point(0, 0);

                pages[0].Marked = true;

                for (int i = 1; i < pages.Count; i++)
                    pages[i].Marked = false;
            }
            else
            {
                for (int i = 0; i < pages.Count; i++)
                    pages[i].Marked = true;
            }
            Render();
        }

        private void SyncControlValues(TrackBar trackBar, NumericUpDown numericUpDown, int value)
        {
            if (numericUpDown.Value != value)
                numericUpDown.Value = value;

            if (trackBar.Value != value)
                trackBar.Value = value;
        }

        private void OpacityTrackBar_ValueChanged(object sender, EventArgs e)
        {
            SetOpacity(OpacityTrackBar.Value);
        }

        private void SetOpacity(int opacity, bool shouldRender = true)
        {
            OpacityTrackBar.Value = opacity;
            OpacityValueLabel.Text = $"{opacity} %";

            cachedWatermark = null;

            var colorMatrix = new ColorMatrix
            {
                Matrix33 = opacity / 100f
            };

            imageAttributes.SetColorMatrix(colorMatrix,
                                           ColorMatrixFlag.Default,
                                           ColorAdjustType.Bitmap);
            if (shouldRender)
                Render();
        }

        private void SizeTrackBar_ValueChanged(object sender, EventArgs e)
        {
            SetSize(SizeTrackBar.Value);
        }

        private void SizeNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            SetSize((int)SizeNumericUpDown.Value);
        }

        private void SetSize(int size, bool shouldRender = true)
        {
            SyncControlValues(SizeTrackBar, SizeNumericUpDown, size);

            if (this.size != size)
            {
                this.size = size;
                wmWidth = size;
                wmHeight = originalWatermark.Height * size / originalWatermark.Width;

                if (xSpace < -wmWidth / 2)
                    SetXSpace(-wmWidth / 2, false);

                XSpaceNumericUpDown.Minimum = -wmWidth / 2;
                XSpaceTrackBar.Minimum = -wmWidth / 2;

                if (ySpace < -wmHeight / 2)
                    SetYSpace(-wmHeight / 2, false);

                YSpaceNumericUpDown.Minimum = -wmHeight / 2;
                YSpaceTrackBar.Minimum = -wmHeight / 2;

                cachedWatermark = null;
                if (shouldRender)
                    Render();
            }
        }

        private void XSpaceTrackBar_ValueChanged(object sender, EventArgs e)
        {
            SetXSpace(XSpaceTrackBar.Value);
        }

        private void XSpaceNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            SetXSpace((int)XSpaceNumericUpDown.Value);
        }

        private void SetXSpace(int xSpace, bool shouldRender = true)
        {
            SyncControlValues(XSpaceTrackBar, XSpaceNumericUpDown, xSpace);
            if (this.xSpace != xSpace)
            {
                this.xSpace = xSpace;
                if (shouldRender)
                    Render();
            }
        }

        private void YSpaceTrackBar_ValueChanged(object sender, EventArgs e)
        {
            SetYSpace(YSpaceTrackBar.Value);
        }

        private void YSpaceNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            SetYSpace((int)YSpaceNumericUpDown.Value);
        }

        private void SetYSpace(int ySpace, bool shouldRender = true)
        {
            SyncControlValues(YSpaceTrackBar, YSpaceNumericUpDown, ySpace);
            if (this.ySpace != ySpace)
            {
                this.ySpace = ySpace;
                if (shouldRender)
                    Render();
            }
        }

        private void Row1OffsetTrackBar_ValueChanged(object sender, EventArgs e)
        {
            SetRow1Offset(Row1OffsetTrackBar.Value);
        }

        private void Row1OffsetNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            SetRow1Offset((int)Row1OffsetNumericUpDown.Value);
        }

        private void SetRow1Offset(int row1Offset, bool shouldRender = true)
        {
            SyncControlValues(Row1OffsetTrackBar, Row1OffsetNumericUpDown, row1Offset);
            if (this.row1Offset != row1Offset)
            {
                this.row1Offset = row1Offset;
                if (shouldRender)
                    Render();
            }
        }

        private void Row2OffsetTrackBar_ValueChanged(object sender, EventArgs e)
        {
            SetRow2Offset(Row2OffsetTrackBar.Value);
        }

        private void Row2OffsetNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            SetRow2Offset((int)Row2OffsetNumericUpDown.Value);
        }

        private void SetRow2Offset(int row2Offset, bool shouldRender = true)
        {
            SyncControlValues(Row2OffsetTrackBar, Row2OffsetNumericUpDown, row2Offset);
            if (this.row2Offset != row2Offset)
            {
                this.row2Offset = row2Offset;

                if (shouldRender)
                    Render();
            }
        }

        private void RotationTrackBar_Scroll(object sender, EventArgs e)
        {
            SetRotation((int)RotationTrackBar.Value);
        }

        private void RotationNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            SetRotation((int)RotationNumericUpDown.Value);
        }

        private void RotationComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RotationComboBox.SelectedItem is null)
                return;

            if (int.TryParse(RotationComboBox.SelectedItem.ToString(), out int angle))
                SetRotation(angle);
        }

        private void SetRotation(int rotation, bool shouldRender = true)
        {
            if (!RotationComboBox.Items.Contains(rotation.ToString()))
                RotationComboBox.SelectedItem = null;
            else
                RotationComboBox.SelectedItem = rotation.ToString();

            SyncControlValues(RotationTrackBar, RotationNumericUpDown, rotation);

            if (this.rotation != rotation)
            {
                this.rotation = rotation;
                if (shouldRender)
                    Render();
            }
        }

        private void Lock()
        {
            this.Enabled = false;
            this.Cursor = Cursors.WaitCursor;
        }

        private void Unlock()
        {
            this.Enabled = true;
            this.Cursor = Cursors.Default;
        }

        private void Form1_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data != null && e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[]? files = e.Data.GetData(DataFormats.FileDrop) as string[];
                if (files == null || files.Length == 0)
                {
                    e.Effect = DragDropEffects.None;
                    return;
                }

                string[] allowedExtensions = { ".pdf", ".png", ".jpg", ".jpeg", ".bmp", ".gif", ".tif", ".tiff" };

                bool isValidFile = files.Any(f => allowedExtensions.Contains(Path.GetExtension(f).ToLowerInvariant()));

                if (isValidFile)
                {
                    e.Effect = DragDropEffects.Copy;
                    return;
                }
            }

            e.Effect = DragDropEffects.None;
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data == null)
                return;

            string[]? files = e.Data.GetData(DataFormats.FileDrop) as string[];

            if (files == null || files.Length == 0)
                return;

            foreach (var file in files)
            {
                string ext = Path.GetExtension(file).ToLowerInvariant();

                if (ext == ".pdf")
                    LoadDocument(file);
                else
                    LoadWatermark(file);
            }
        }

        private void PlusButton_Click(object sender, EventArgs e)
        {
            ClearDocument();
            previewDpiX += 10;
            previewDpiY += 10;
            scaleFactorX = (float)previewDpiX / (float)dpiX;
            scaleFactorY = (float)previewDpiY / (float)dpiY;
            PrintPDF();
            Render();
        }

        private void MinusButton_Click(object sender, EventArgs e)
        {
            ClearDocument();
            previewDpiX -= 10;
            previewDpiY -= 10;
            scaleFactorX = (float)previewDpiX / (float)dpiX;
            scaleFactorY = (float)previewDpiY / (float)dpiY;
            PrintPDF();
            Render();
        }

        private void ClearDocument()
        {
            foreach (var page in pages)
                page.OriginalImage.Dispose();

            pages.Clear();

            foreach (Control ctrl in PDFViewerPanel.Controls)
                ctrl.Dispose();

            PDFViewerPanel.Controls.Clear();
        }

        private void ClearWatermark()
        {
            originalWatermark?.Dispose();
            originalWatermark = null;
            cachedWatermark?.Dispose();
            cachedWatermark = null;
            WatermarkPictureBox.Image?.Dispose();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            imageAttributes.Dispose();
            pdfDocument?.Dispose();
            ClearWatermark();
            ClearDocument();
        }
    }
}
