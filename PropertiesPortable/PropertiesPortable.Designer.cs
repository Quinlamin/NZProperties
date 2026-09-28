namespace PropertiesPortable
{
    partial class PropertiesPortable
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
            saveFileDialog1 = new SaveFileDialog();
            exportButton = new Button();
            addressBox = new TextBox();
            SuspendLayout();
            // 
            // exportButton
            // 
            exportButton.Location = new Point(12, 41);
            exportButton.Name = "exportButton";
            exportButton.Size = new Size(270, 23);
            exportButton.TabIndex = 0;
            exportButton.Text = "Create PDF";
            exportButton.UseVisualStyleBackColor = true;
            exportButton.Click += exportButton_Click;
            // 
            // addressBox
            // 
            addressBox.Location = new Point(12, 12);
            addressBox.Name = "addressBox";
            addressBox.Size = new Size(270, 23);
            addressBox.TabIndex = 1;
            // 
            // PropertiesPortable
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(294, 75);
            Controls.Add(addressBox);
            Controls.Add(exportButton);
            Name = "PropertiesPortable";
            Text = "Properties Portable";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private SaveFileDialog saveFileDialog1;
        private Button exportButton;
        private TextBox addressBox;
    }
}
