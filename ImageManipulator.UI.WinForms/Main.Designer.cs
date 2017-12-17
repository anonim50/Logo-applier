using System.IO;
using System.Windows.Forms;

namespace ImageManipulator.UI.WinForms
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.outputPictureBox = new System.Windows.Forms.PictureBox();
            this.inputPictureBox = new System.Windows.Forms.PictureBox();
            this.executeBtn = new System.Windows.Forms.Button();
            this.loadLogoBtn = new System.Windows.Forms.Button();
            this.loadImagesBtn = new System.Windows.Forms.Button();
            this.inputGroupBox = new System.Windows.Forms.GroupBox();
            this.outputGroupBox = new System.Windows.Forms.GroupBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog.InitialDirectory = Application.StartupPath;
            ((System.ComponentModel.ISupportInitialize)(this.outputPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputPictureBox)).BeginInit();
            this.inputGroupBox.SuspendLayout();
            this.outputGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // outputPictureBox
            // 
            this.outputPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outputPictureBox.Location = new System.Drawing.Point(21, 30);
            this.outputPictureBox.Name = "outputPictureBox";
            this.outputPictureBox.Size = new System.Drawing.Size(369, 187);
            this.outputPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.outputPictureBox.TabIndex = 9;
            this.outputPictureBox.TabStop = false;
            // 
            // inputPictureBox
            // 
            this.inputPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputPictureBox.Location = new System.Drawing.Point(17, 30);
            this.inputPictureBox.Name = "inputPictureBox";
            this.inputPictureBox.Size = new System.Drawing.Size(512, 432);
            this.inputPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.inputPictureBox.TabIndex = 8;
            this.inputPictureBox.TabStop = false;
            // 
            // executeBtn
            // 
            this.executeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.executeBtn.Location = new System.Drawing.Point(597, 432);
            this.executeBtn.Name = "executeBtn";
            this.executeBtn.Size = new System.Drawing.Size(409, 50);
            this.executeBtn.TabIndex = 7;
            this.executeBtn.Text = "Execute Operations";
            this.executeBtn.UseVisualStyleBackColor = true;
            this.executeBtn.Click += new System.EventHandler(this.executeBtn_Click);
            // 
            // loadLogoBtn
            // 
            this.loadLogoBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loadLogoBtn.Location = new System.Drawing.Point(597, 361);
            this.loadLogoBtn.Name = "loadLogoBtn";
            this.loadLogoBtn.Size = new System.Drawing.Size(409, 50);
            this.loadLogoBtn.TabIndex = 6;
            this.loadLogoBtn.Text = "Load logo";
            this.loadLogoBtn.UseVisualStyleBackColor = true;
            this.loadLogoBtn.Click += new System.EventHandler(this.loadLogoBtn_Click);
            // 
            // loadImagesBtn
            // 
            this.loadImagesBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loadImagesBtn.Location = new System.Drawing.Point(597, 289);
            this.loadImagesBtn.Name = "loadImagesBtn";
            this.loadImagesBtn.Size = new System.Drawing.Size(409, 50);
            this.loadImagesBtn.TabIndex = 5;
            this.loadImagesBtn.Text = "Load images";
            this.loadImagesBtn.UseVisualStyleBackColor = true;
            this.loadImagesBtn.Click += new System.EventHandler(this.loadImagesBtn_Click);
            // 
            // inputGroupBox
            // 
            this.inputGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.inputGroupBox.Controls.Add(this.inputPictureBox);
            this.inputGroupBox.Location = new System.Drawing.Point(19, 20);
            this.inputGroupBox.Name = "inputGroupBox";
            this.inputGroupBox.Size = new System.Drawing.Size(551, 482);
            this.inputGroupBox.TabIndex = 10;
            this.inputGroupBox.TabStop = false;
            this.inputGroupBox.Text = "Input image";
            // 
            // outputGroupBox
            // 
            this.outputGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outputGroupBox.Controls.Add(this.outputPictureBox);
            this.outputGroupBox.Location = new System.Drawing.Point(597, 20);
            this.outputGroupBox.Name = "outputGroupBox";
            this.outputGroupBox.Size = new System.Drawing.Size(409, 239);
            this.outputGroupBox.TabIndex = 11;
            this.outputGroupBox.TabStop = false;
            this.outputGroupBox.Text = "Output image";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 514);
            this.Controls.Add(this.outputGroupBox);
            this.Controls.Add(this.inputGroupBox);
            this.Controls.Add(this.executeBtn);
            this.Controls.Add(this.loadLogoBtn);
            this.Controls.Add(this.loadImagesBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Image manipulator";
            ((System.ComponentModel.ISupportInitialize)(this.outputPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputPictureBox)).EndInit();
            this.inputGroupBox.ResumeLayout(false);
            this.outputGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox outputPictureBox;
        private System.Windows.Forms.PictureBox inputPictureBox;
        private System.Windows.Forms.Button executeBtn;
        private System.Windows.Forms.Button loadLogoBtn;
        private System.Windows.Forms.Button loadImagesBtn;
        private System.Windows.Forms.GroupBox inputGroupBox;
        private System.Windows.Forms.GroupBox outputGroupBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}

