using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iText.Forms;
using iText.Forms.Fields;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Annot;
using iText.Kernel.Exceptions;

namespace Mass_Fill_PDF
{
    public partial class Form1: Form
    {
        private string[] selectedFiles;
        private int rowsToGenerate = 1;
        private Dictionary<string, string> pdfDefaultFieldValues = new Dictionary<string, string>();
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

            var allFieldtypes = new Dictionary<string, PdfName>();
            var mergedDefaults = new Dictionary<string, string>();

            foreach (string path in selectedFiles)
            {
                var types = GetFormFieldTypes(path);
                if (types == null)
                {
                    return;
                }
                var defaults = GetDefaultFieldValues(path);
                if (defaults == null)
                {
                    return;
                }

                foreach (var kv in types)
                {
                    if (!allFieldtypes.ContainsKey(kv.Key))
                    {
                        allFieldtypes[kv.Key] = kv.Value;
                    }
                }

                foreach (var kv in defaults)
                {
                    if (!mergedDefaults.ContainsKey(kv.Key) || string.IsNullOrWhiteSpace(mergedDefaults[kv.Key]))
                    {
                        mergedDefaults[kv.Key] = kv.Value;
                    }
                }
            }

            InformationToFill_dataGridView.Columns.Clear();

            foreach (var kv in allFieldtypes)
            {
                string name = kv.Key;
                PdfName type = kv.Value;

                if (PdfName.Btn.Equals(type))
                {
                    InformationToFill_dataGridView.Columns.Add(new DataGridViewCheckBoxColumn { Name = name, HeaderText = name });
                }

                else if (PdfName.Ch.Equals(type))
                {
                    var combo = new DataGridViewComboBoxColumn { Name = name, HeaderText = name };
                    combo.Items.AddRange(PdfAcroForm.GetAcroForm(new PdfDocument(new PdfReader(selectedFiles[0])), false).GetField(name).GetAppearanceStates());
                    InformationToFill_dataGridView.Columns.Add(combo);
                }
                else
                {
                    InformationToFill_dataGridView.Columns.Add(name, name);
                }
            }

            pdfDefaultFieldValues = mergedDefaults;
            InformationToFill_dataGridView.Rows.Clear();

            for (int i = 0; i < rowsToGenerate; i++)
            {
                if (InformationToFill_dataGridView.Columns.Count <= 0)
                {
                    MessageBox.Show("Please select a PDF with form fields.");
                    return;
                }
                int index = InformationToFill_dataGridView.Rows.Add();
                foreach (DataGridViewColumn column in InformationToFill_dataGridView.Columns)
                {
                    if (pdfDefaultFieldValues.TryGetValue(column.Name, out string defVal))
                    {
                        var cell = InformationToFill_dataGridView.Rows[index].Cells[column.Index];
                        if (column is DataGridViewCheckBoxColumn)
                        {
                            cell.Value = ParseCheckboxValue(defVal);
                        }
                        else
                        {
                            cell.Value = defVal;
                        }
                    }
                }
            }

            namingComboBox.Items.Clear();
            namingComboBox.Items.Add("Default");
            foreach (DataGridViewColumn column in InformationToFill_dataGridView.Columns)
            {
                if (column is DataGridViewTextBoxColumn || column is DataGridViewComboBoxColumn)
                {
                    namingComboBox.Items.Add(column.Name);
                }
                namingComboBox.SelectedIndex = 0;
            }
        }

        private void rowsToGenerate_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            rowsToGenerate = Convert.ToInt32(rowsToGenerate_numericUpDown.Value);
        }

        private void addRow_button_Click(object sender, EventArgs e)
        {
            if (InformationToFill_dataGridView.Rows.Count == 0)
            {
                MessageBox.Show("Additional rows may only be added after first initializing a PDF.");
                return;
            }

            int newRowIndex = InformationToFill_dataGridView.Rows.Add();
            foreach (DataGridViewColumn column in InformationToFill_dataGridView.Columns)
            {
                if (pdfDefaultFieldValues.TryGetValue(column.Name, out string defaultValue))
                { 
                    if (column is DataGridViewCheckBoxColumn)
                    {
                        InformationToFill_dataGridView.Rows[newRowIndex].Cells[column.Index].Value = ParseCheckboxValue(defaultValue);
                    }
                    else
                    {
                        InformationToFill_dataGridView.Rows[newRowIndex].Cells[column.Index].Value = defaultValue; 
                    }
                        
                }
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

            try
            {
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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error with selected PDF at:\n{Path.GetFileName(filePath)}\n\n{ex.Message}", "Read Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            return fieldTypes;
        }

        private Dictionary<string, string> GetDefaultFieldValues(string filePath)
        {
            var fieldDefaults = new Dictionary<string, string>();

            try
            {
                using (var reader = new PdfReader(filePath))
                using (var pdfDoc = new PdfDocument(reader))
                {
                    PdfAcroForm form = PdfAcroForm.GetAcroForm(pdfDoc, false);
                    if (form == null || form.GetAllFormFields().Count == 0)
                    {
                        return fieldDefaults;
                    }

                    foreach (var field in form.GetAllFormFields())
                    {
                        string key = field.Key;
                        PdfFormField formField = field.Value;
                        PdfName type = formField.GetFormType();

                        if (PdfName.Btn.Equals(type))
                        {
                            PdfDictionary dict = formField.GetPdfObject();
                            PdfName value = dict.GetAsName(PdfName.V);
                            fieldDefaults[key] = value != null ? value.ToString() : "Off";
                        }
                        else
                        {
                            fieldDefaults[key] = formField.GetValueAsString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to read PDF form fields:\n{ex.Message}", "PDF Load Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }
            return fieldDefaults;
        }

        private bool ParseCheckboxValue(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return false;
            }

            string normalized = value.TrimStart('/').ToLower();
            return normalized.StartsWith("yes") || normalized == "1";
        }

        private void fillPDF_button_Click(object sender, EventArgs e)
        {
            //Checks that a template has been selected and rows have been generated
            if (selectedFiles == null || selectedFiles.Length == 0)
            {
                MessageBox.Show("No PDF selected.");
                return;
            }
            if (InformationToFill_dataGridView.Rows.Count == 0)
            {
                MessageBox.Show("No data to fill. The grid is empty.");
                return;
            }

            using (var folderDialog = new FolderBrowserDialog())
            {
                //Allows the user to select where the PDF(s) will be generated.
                folderDialog.Description = "Select output folder for filled PDFs.";
                if (folderDialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                string outFolder = folderDialog.SelectedPath;

                string nameSource = namingComboBox.SelectedItem?.ToString() ?? "Default";

                foreach (string templatePath in selectedFiles)
                {
                    string baseName = Path.GetFileNameWithoutExtension(templatePath);

                    //Creates a new PDF for each row of data.
                    for (int rowIndex = 0; rowIndex < InformationToFill_dataGridView.Rows.Count; rowIndex++)
                    {
                        var row = InformationToFill_dataGridView.Rows[rowIndex];

                        string fileName;
                        if (nameSource != "Default" && row.Cells[nameSource].Value is string raw && !string.IsNullOrWhiteSpace(raw))
                        {
                            var invalids = Path.GetInvalidFileNameChars();
                            var safe = new string(raw.Where(ch => !invalids.Contains(ch)).ToArray()).Trim();
                            if (string.IsNullOrEmpty(safe))
                            {
                                safe = (rowIndex + 1).ToString();
                            }
                            fileName = $"{baseName}_{safe}.pdf";
                        }
                        else
                        {
                            fileName = $"{baseName}_{rowIndex + 1}.pdf";
                        }
                        string outputPath = Path.Combine(outFolder, fileName);

                        // Opens the template PDF for reading and writing
                        using (var reader = new PdfReader(templatePath))
                        using (var writer = new PdfWriter(outputPath))
                        using (var pdfDoc = new PdfDocument(reader, writer))
                        {
                            var form = PdfAcroForm.GetAcroForm(pdfDoc, true);

                            //Fills in each field from the DataGridView

                            foreach (DataGridViewColumn column in InformationToFill_dataGridView.Columns)
                            {
                                string fieldName = column.Name;
                                var pdfField = form.GetField(fieldName);
                                if (pdfField == null)
                                {
                                    continue;
                                }

                                var cell = row.Cells[column.Index].Value;

                                if (column is DataGridViewCheckBoxColumn)
                                {
                                    bool isChecked = Convert.ToBoolean(cell);

                                    string onValue = form.GetField(fieldName).GetAppearanceStates().FirstOrDefault(s => !s.Equals("Off", StringComparison.OrdinalIgnoreCase)) ?? "Yes";
                                    form.GetField(fieldName).SetValue(isChecked ? onValue : "Off");
                                }
                                else
                                {
                                    string value = cell?.ToString().Trim() ?? "";
                                    form.GetField(fieldName).SetValue(value);
                                }
                            }
                        }
                    }
                }
                MessageBox.Show($"PDFs written to:\n{outFolder}");
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void selectPDF_tooltip_Popup(object sender, PopupEventArgs e)
        {
        }
    }
}
