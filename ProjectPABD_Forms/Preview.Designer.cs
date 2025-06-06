namespace ProjectPABD_Forms
{
    partial class Preview
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
            this.dgvPreview = new System.Windows.Forms.DataGridView();
            this.managementKomunitasDataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.management_KomunitasDataSet1 = new ProjectPABD_Forms.Management_KomunitasDataSet1();
            this.btnOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.managementKomunitasDataSet1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.management_KomunitasDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPreview
            // 
            this.dgvPreview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPreview.Location = new System.Drawing.Point(88, 45);
            this.dgvPreview.Name = "dgvPreview";
            this.dgvPreview.RowHeadersWidth = 51;
            this.dgvPreview.RowTemplate.Height = 24;
            this.dgvPreview.Size = new System.Drawing.Size(571, 283);
            this.dgvPreview.TabIndex = 0;
            // 
            // managementKomunitasDataSet1BindingSource
            // 
            this.managementKomunitasDataSet1BindingSource.DataSource = this.management_KomunitasDataSet1;
            this.managementKomunitasDataSet1BindingSource.Position = 0;
            // 
            // management_KomunitasDataSet1
            // 
            this.management_KomunitasDataSet1.DataSetName = "Management_KomunitasDataSet1";
            this.management_KomunitasDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(562, 381);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(97, 30);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // Preview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.dgvPreview);
            this.Name = "Preview";
            this.Text = "Preview";
            this.Load += new System.EventHandler(this.Preview_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.managementKomunitasDataSet1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.management_KomunitasDataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPreview;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.BindingSource managementKomunitasDataSet1BindingSource;
        private Management_KomunitasDataSet1 management_KomunitasDataSet1;
    }
}