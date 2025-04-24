namespace Mass_Fill_PDF
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.InformationToFill_dataGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.rowsToGenerate_numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.selectPDF_button = new System.Windows.Forms.Button();
            this.generateRows_button = new System.Windows.Forms.Button();
            this.clearTable_button = new System.Windows.Forms.Button();
            this.fillPDF_button = new System.Windows.Forms.Button();
            this.addRow_button = new System.Windows.Forms.Button();
            this.namingComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.selectPDF_tooltip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.InformationToFill_dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rowsToGenerate_numericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // InformationToFill_dataGridView
            // 
            this.InformationToFill_dataGridView.AllowUserToAddRows = false;
            this.InformationToFill_dataGridView.AllowUserToDeleteRows = false;
            this.InformationToFill_dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.InformationToFill_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.InformationToFill_dataGridView.Location = new System.Drawing.Point(23, 62);
            this.InformationToFill_dataGridView.Name = "InformationToFill_dataGridView";
            this.InformationToFill_dataGridView.RowHeadersVisible = false;
            this.InformationToFill_dataGridView.Size = new System.Drawing.Size(752, 383);
            this.InformationToFill_dataGridView.TabIndex = 0;
            this.InformationToFill_dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.InformationToFill_dataGridView_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "1. Select the PDF(s) to Fill";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // rowsToGenerate_numericUpDown
            // 
            this.rowsToGenerate_numericUpDown.Location = new System.Drawing.Point(165, 35);
            this.rowsToGenerate_numericUpDown.Name = "rowsToGenerate_numericUpDown";
            this.rowsToGenerate_numericUpDown.Size = new System.Drawing.Size(37, 20);
            this.rowsToGenerate_numericUpDown.TabIndex = 4;
            this.selectPDF_tooltip.SetToolTip(this.rowsToGenerate_numericUpDown, "Select the number of rows to generate.");
            this.rowsToGenerate_numericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.rowsToGenerate_numericUpDown.ValueChanged += new System.EventHandler(this.rowsToGenerate_numericUpDown_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(162, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "2. How many rows to generate";
            // 
            // selectPDF_button
            // 
            this.selectPDF_button.Location = new System.Drawing.Point(23, 28);
            this.selectPDF_button.Name = "selectPDF_button";
            this.selectPDF_button.Size = new System.Drawing.Size(88, 30);
            this.selectPDF_button.TabIndex = 7;
            this.selectPDF_button.Text = "Select PDFs";
            this.selectPDF_tooltip.SetToolTip(this.selectPDF_button, "Select one or more PDFs with form fields.");
            this.selectPDF_button.UseVisualStyleBackColor = true;
            this.selectPDF_button.Click += new System.EventHandler(this.button1_Click);
            // 
            // generateRows_button
            // 
            this.generateRows_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.generateRows_button.Location = new System.Drawing.Point(625, 12);
            this.generateRows_button.Name = "generateRows_button";
            this.generateRows_button.Size = new System.Drawing.Size(150, 43);
            this.generateRows_button.TabIndex = 8;
            this.generateRows_button.Text = "3. Generate Rows for Selected PDF(s)";
            this.selectPDF_tooltip.SetToolTip(this.generateRows_button, "Generate the specified number of rows for the PDF(s) selected.");
            this.generateRows_button.UseVisualStyleBackColor = true;
            this.generateRows_button.Click += new System.EventHandler(this.generateRows_button_Click);
            // 
            // clearTable_button
            // 
            this.clearTable_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.clearTable_button.Location = new System.Drawing.Point(619, 473);
            this.clearTable_button.Name = "clearTable_button";
            this.clearTable_button.Size = new System.Drawing.Size(75, 23);
            this.clearTable_button.TabIndex = 9;
            this.clearTable_button.Text = "Clear Table";
            this.selectPDF_tooltip.SetToolTip(this.clearTable_button, "Clear the data grid of all data. This cannot be undone.");
            this.clearTable_button.UseVisualStyleBackColor = true;
            this.clearTable_button.Click += new System.EventHandler(this.clearTable_button_Click);
            // 
            // fillPDF_button
            // 
            this.fillPDF_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.fillPDF_button.Location = new System.Drawing.Point(700, 473);
            this.fillPDF_button.Name = "fillPDF_button";
            this.fillPDF_button.Size = new System.Drawing.Size(75, 23);
            this.fillPDF_button.TabIndex = 10;
            this.fillPDF_button.Text = "5. Fill PDF(s)";
            this.selectPDF_tooltip.SetToolTip(this.fillPDF_button, "Generate and fill in PDFs with the provided data to a chosen location.");
            this.fillPDF_button.UseVisualStyleBackColor = true;
            this.fillPDF_button.Click += new System.EventHandler(this.fillPDF_button_Click);
            // 
            // addRow_button
            // 
            this.addRow_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addRow_button.Location = new System.Drawing.Point(23, 473);
            this.addRow_button.Name = "addRow_button";
            this.addRow_button.Size = new System.Drawing.Size(75, 23);
            this.addRow_button.TabIndex = 11;
            this.addRow_button.Text = "Add Row";
            this.selectPDF_tooltip.SetToolTip(this.addRow_button, "Add one row to the data grid.");
            this.addRow_button.UseVisualStyleBackColor = true;
            this.addRow_button.Click += new System.EventHandler(this.addRow_button_Click);
            // 
            // namingComboBox
            // 
            this.namingComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.namingComboBox.FormattingEnabled = true;
            this.namingComboBox.Location = new System.Drawing.Point(355, 475);
            this.namingComboBox.Name = "namingComboBox";
            this.namingComboBox.Size = new System.Drawing.Size(258, 21);
            this.namingComboBox.TabIndex = 12;
            this.selectPDF_tooltip.SetToolTip(this.namingComboBox, "Choose a column in which each row has a UNIQUE value to append to the end of the " +
        "saved file.");
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(352, 459);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(262, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "4. Select header to use to generate unique file names:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // selectPDF_tooltip
            // 
            this.selectPDF_tooltip.Popup += new System.Windows.Forms.PopupEventHandler(this.selectPDF_tooltip_Popup);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 505);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.namingComboBox);
            this.Controls.Add(this.addRow_button);
            this.Controls.Add(this.fillPDF_button);
            this.Controls.Add(this.clearTable_button);
            this.Controls.Add(this.generateRows_button);
            this.Controls.Add(this.selectPDF_button);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rowsToGenerate_numericUpDown);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.InformationToFill_dataGridView);
            this.Name = "Form1";
            this.Text = "Mass Fill PDF";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.InformationToFill_dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rowsToGenerate_numericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView InformationToFill_dataGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown rowsToGenerate_numericUpDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button selectPDF_button;
        private System.Windows.Forms.Button generateRows_button;
        private System.Windows.Forms.Button clearTable_button;
        private System.Windows.Forms.Button fillPDF_button;
        private System.Windows.Forms.Button addRow_button;
        private System.Windows.Forms.ComboBox namingComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolTip selectPDF_tooltip;
    }
}

