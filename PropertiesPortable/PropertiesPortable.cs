using System.IO;

namespace PropertiesPortable
{
    public partial class PropertiesPortable : Form
    {
        public PropertiesPortable()
        {
            InitializeComponent();
        }
        public void createPDF()
        {

        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] data = Program.Build(addressBox.Text);
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    // 2. Configure properties
                    saveFileDialog.InitialDirectory = @"C:\";
                    saveFileDialog.Title = "Save PDF";
                    saveFileDialog.DefaultExt = "pdf";
                    
                    saveFileDialog.FilterIndex = 1;
                    saveFileDialog.RestoreDirectory = true;

                    // 3. Show the dialog and check if the user clicked "OK"
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // 4. Retrieve the selected file path
                        string filePath = saveFileDialog.FileName;

                        // 5. Write data to the file
                        string textToSave = "Hello, World! This is a test file.";
                        File.WriteAllBytes(filePath, data);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            
            
        }
    }
}
