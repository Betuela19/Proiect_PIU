
namespace InterfataUtilizator_WindowsForms
{
    partial class NewFormFarmacie
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
            this.btnAfisare = new System.Windows.Forms.Button();
            this.btnFiltrare = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.lstMedicamente = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnAfisare
            // 
            this.btnAfisare.Location = new System.Drawing.Point(72, 70);
            this.btnAfisare.Name = "btnAfisare";
            this.btnAfisare.Size = new System.Drawing.Size(105, 34);
            this.btnAfisare.TabIndex = 0;
            this.btnAfisare.Text = "Afisare";
            this.btnAfisare.UseVisualStyleBackColor = true;
            this.btnAfisare.Click += new System.EventHandler(this.btnAfisare_Click);
            // 
            // btnFiltrare
            // 
            this.btnFiltrare.Location = new System.Drawing.Point(201, 70);
            this.btnFiltrare.Name = "btnFiltrare";
            this.btnFiltrare.Size = new System.Drawing.Size(103, 34);
            this.btnFiltrare.TabIndex = 1;
            this.btnFiltrare.Text = "Filtrare";
            this.btnFiltrare.UseVisualStyleBackColor = true;
            this.btnFiltrare.Click += new System.EventHandler(this.btnFiltrare_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(72, 233);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(675, 24);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.Text = "Medicamente ...";
            // 
            // lstMedicamente
            // 
            this.lstMedicamente.FormattingEnabled = true;
            this.lstMedicamente.ItemHeight = 16;
            this.lstMedicamente.Location = new System.Drawing.Point(72, 131);
            this.lstMedicamente.Name = "lstMedicamente";
            this.lstMedicamente.Size = new System.Drawing.Size(675, 84);
            this.lstMedicamente.TabIndex = 2;
            // 
            // NewFormFarmacie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.lstMedicamente);
            this.Controls.Add(this.btnFiltrare);
            this.Controls.Add(this.btnAfisare);
            this.Name = "NewFormFarmacie";
            this.Text = "NewFormFarmacie";
            this.Load += new System.EventHandler(this.NewFormFarmacie_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAfisare;
        private System.Windows.Forms.Button btnFiltrare;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ListBox lstMedicamente;
    }
}