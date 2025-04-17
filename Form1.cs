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
            if (selectedFiles == null || selectedFiles.Length == 0)
            {
                MessageBox.Show("No PDF selected. Please select one or more first.");
                return;
            }
            if (rowsToGenerate <= 0)
            {
                MessageBox.Show("Rows to generate must be greater than 0.");
                return;
            }

            string filePath = selectedFiles[0];

            using (PdfReader reader = new PdfReader(filePath))
            using (PdfDocument document = new PdfDocument(reader))
            {
                PdfAcroForm acroForm = PdfAcroForm.GetAcroForm(document, false);

                if (acroForm == null)
                {
                    MessageBox.Show("Selected PDF(s) do not contain form fields.");
                    return;
                }

                IDictionary<string, PdfFormField> fields = acroForm.GetAllFormFields();

                if (fields == null || fields.Count == 0)
                {
                    MessageBox.Show("Selected PDF(s) do not contain form fields.");
                    return;
                }

                Dictionary<string, PdfName> fieldTypes = GetFormFieldTypes(filePath);

                InformationToFill_dataGridView.Columns.Clear();
                InformationToFill_dataGridView.Rows.Clear();

                foreach (var field in fields)
                {
                    PdfName fieldType = fieldTypes.ContainsKey(field.Key) ? fieldTypes[field.Key] : null;

                    if (PdfName.Btn.Equals(fieldType))
                    {
                        InformationToFill_dataGridView.Columns.Add(new DataGridViewCheckBoxColumn
                        {
                            Name = field.Key,
                            HeaderText = field.Key
                        });
                    }
                    else if (PdfName.Ch.Equals(fieldType))
                    {
                        var dropdownBox = new DataGridViewComboBoxColumn
                        {
                            Name = field.Key,
                            HeaderText = field.Key
                        };

                        string[] dropdownOptions = field.Value.GetAppearanceStates();
                        dropdownBox.Items.AddRange(dropdownOptions);

                        InformationToFill_dataGridView.Columns.Add(dropdownBox);
                    }
                    else if (PdfName.Tx.Equals(fieldType))
                    {
                        InformationToFill_dataGridView.Columns.Add(field.Key, field.Key);
                    }
                    else
                    {
                        MessageBox.Show($"Field '{field.Key}' has unsupported type '{fieldType?.ToString() ?? "Unknown"}'. It must be handwritten.");
                    }
                }
                
                InformationToFill_dataGridView.Rows.Add(rowsToGenerate);
            }
        }

        private void rowsToGenerate_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            rowsToGenerate = Convert.ToInt32(rowsToGenerate_numericUpDown.Value);
        }

        private void addRow_button_Click(object sender, EventArgs e)
        {
            if (InformationToFill_dataGridView.Rows.Count > 0)
            {
                InformationToFill_dataGridView.Rows.Add(1);
            }
            else
            {
                MessageBox.Show("Additional rows may only be added after first initializing a PDF.");
                return;
            }
        }

        private void clearTable_button_Click(object sender, EventArgs e)
        {
            DialogResult clearDialog = MessageBox.Show("Are you sure you want to clear all data in the grid? This cannot be undone.", "Clear All Data", MessageBoxButtons.YesNo);
            if (clearDialog == DialogResult.Yes)
            {
                InformationToFill_dataGridView.Columns.Clear();
                InformationToFill_dataGridView.Rows.Clear();
            }
        }

        private Dictionary<string, PdfName> GetFormFieldTypes(string filePath)
            //Retrieves the form field types (check box, text, radio button, etc.)
        {
            var fieldTypes = new Dictionary<string, PdfName>();

            using (var reader = new PdfReader(filePath))
            using (var pdfDoc = new PdfDocument(reader))
            {
                PdfAcroForm form = PdfAcroForm.GetAcroForm(pdfDoc, false);
                if (form == null || form.GetAllFormFields().Count == 0)
                {
                    return fieldTypes;
                }

                foreach (var field in form.GetAllFormFields())
                {
                    PdfName type = field.Value.GetFormType();
                    fieldTypes.Add(field.Key, type);
                }
            }

            return fieldTypes;
        }
    }
}
