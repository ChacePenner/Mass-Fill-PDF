using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iText.Forms;
using iText.Forms.Fields;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Annot;

namespace Mass_Fill_PDF
{
    public partial class Form1: Form
    {
        private string[] selectedFiles;
        private int rowsToGenerate = 1;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void InformationToFill_dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void DocumentsToFill_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = true;
            dialog.Filter = "PDF files(*.pdf)|*.pdf";

            if(dialog.ShowDialog() == DialogResult.OK)
            {
                selectedFiles = dialog.FileNames;
                MessageBox.Show("PDF(s) selected successfully.");
            }
            else
            {
                selectedFiles = null;
            }
        }

        private void generateRows_button_Click(object sender, EventArgs e)
        {
            //C:\MassFillPDF\Mass Fill PDF\PDF Templates\ELServicesWaiverFormEnglish.pdf
            //Replace later with the file path(s) from the Select PDF(s) button
            //If no PDF is selected, show an error message to the user
            
            if (selectedFiles == null || selectedFiles.Length == 0)
            {
                MessageBox.Show("No PDF selected. Please select one or more first.");
                return;
            }

            string filePath = selectedFiles[0];

            using (PdfReader reader = new PdfReader(filePath))
            using (PdfDocument document = new PdfDocument(reader))
            {
                PdfAcroForm acroForm = PdfAcroForm.GetAcroForm(document, false);
                IDictionary<string, PdfFormField> fields = acroForm.GetAllFormFields();

                InformationToFill_dataGridView.Columns.Clear();
                InformationToFill_dataGridView.Rows.Clear();

                foreach (var field in fields)
                {
                    InformationToFill_dataGridView.Columns.Add(field.Key, field.Key);
                }

                InformationToFill_dataGridView.Rows.Add(rowsToGenerate - 1);
            }

        }

        private void rowsToGenerate_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            rowsToGenerate = Convert.ToInt32(rowsToGenerate_numericUpDown.Value);
        }
    }
}
