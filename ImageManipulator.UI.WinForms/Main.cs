using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ImageManipulator.Core;
using ImageManipulator.UI.WinForms.Properties;
using static FileService.Core.FileService;

namespace ImageManipulator.UI.WinForms
{
    public partial class Main : Form
    {
        private string[] _inputImagesPath;
        private string _logoPath;

        public bool IsImagesLoaded => _inputImagesPath != null && _inputImagesPath.Length > 0;
        public bool IsLogoLoaded => !string.IsNullOrEmpty(_logoPath);

        public Main()
        {
            InitializeComponent();
            openFileDialog.Filter = @"Bitmap files (*.bmp)|*.bmp";
        }

        private void loadImagesBtn_Click(object sender, EventArgs e)
        {
            openFileDialog.Multiselect = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _inputImagesPath = openFileDialog.FileNames;
                inputPictureBox.ImageLocation = _inputImagesPath[0];
            }
        }

        private void loadLogoBtn_Click(object sender, EventArgs e)
        {
            openFileDialog.Multiselect = false;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                _logoPath = openFileDialog.FileName;
            }
        }

        private void executeBtn_Click(object sender, EventArgs e)
        {
            if (!IsImagesLoaded)
            {
                MessageBox.Show(this, Resources.select_input_images_message, Resources.warning_title,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!IsLogoLoaded)
            {
                MessageBox.Show(this, Resources.select_logo_message, Resources.warning_title, MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            CreateIfNotExists(OutputDirectory);


            using (var logoImage = new Bitmap(_logoPath))
            {
                var logo = new Logo(logoImage);

                foreach (var imagePath in _inputImagesPath)
                {
                    try
                    {
                        Apply(logo, imagePath);
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(this, exception.ToString());
                    }
                }
            }

            DisplaySuccessfullyMessage();
        }

        private void Apply(Logo logo, string imagePath)
        {
            using (var inputImage = new Bitmap(imagePath))
            using (var outputImage = logo.ApplyTo(inputImage))
            {
                var outputPath = GetOutputPath(OutputDirectory, Path.GetFileName(imagePath));
                outputImage.Save(outputPath);

                DisposeImageFrom(inputPictureBox);
                ShowImage(imagePath, inputPictureBox);
                DisposeImageFrom(outputPictureBox);
                ShowImage(outputPath, outputPictureBox);
            }
        }

        private void DisplaySuccessfullyMessage()
        {
            MessageBox.Show(Resources.successful_message, Resources.information_title, MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void ShowImage(string imagePath, PictureBox pictureBox)
        {
            pictureBox.Image = new Bitmap(imagePath);
            pictureBox.Refresh();
        }

        private void DisposeImageFrom(PictureBox pictureBox)
        {
            pictureBox.Image?.Dispose();
        }
    }
}