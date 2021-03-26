
namespace Tubes_2
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.BFSrb = new System.Windows.Forms.RadioButton();
            this.DFSrb = new System.Windows.Forms.RadioButton();
            this.Awal = new System.Windows.Forms.ComboBox();
            this.Akhir = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.SearchButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.NamaFile = new System.Windows.Forms.Label();
            this.GraphPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Showcard Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(98, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(254, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "FRIEND YOU MAY KNOW";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "File Input";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Algoritma";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(153, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(10, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = ":";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(153, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(10, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = ":";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(172, 358);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(77, 30);
            this.button1.TabIndex = 6;
            this.button1.Text = "Execute!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // BFSrb
            // 
            this.BFSrb.AutoSize = true;
            this.BFSrb.Location = new System.Drawing.Point(170, 82);
            this.BFSrb.Name = "BFSrb";
            this.BFSrb.Size = new System.Drawing.Size(44, 19);
            this.BFSrb.TabIndex = 8;
            this.BFSrb.TabStop = true;
            this.BFSrb.Text = "BFS";
            this.BFSrb.UseVisualStyleBackColor = true;
            // 
            // DFSrb
            // 
            this.DFSrb.AutoSize = true;
            this.DFSrb.Location = new System.Drawing.Point(230, 82);
            this.DFSrb.Name = "DFSrb";
            this.DFSrb.Size = new System.Drawing.Size(45, 19);
            this.DFSrb.TabIndex = 9;
            this.DFSrb.TabStop = true;
            this.DFSrb.Text = "DFS";
            this.DFSrb.UseVisualStyleBackColor = true;
            // 
            // Awal
            // 
            this.Awal.FormattingEnabled = true;
            this.Awal.Location = new System.Drawing.Point(241, 296);
            this.Awal.Name = "Awal";
            this.Awal.Size = new System.Drawing.Size(121, 23);
            this.Awal.TabIndex = 10;
            // 
            // Akhir
            // 
            this.Akhir.FormattingEnabled = true;
            this.Akhir.Location = new System.Drawing.Point(241, 325);
            this.Akhir.Name = "Akhir";
            this.Akhir.Size = new System.Drawing.Size(121, 23);
            this.Akhir.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(63, 299);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 15);
            this.label6.TabIndex = 13;
            this.label6.Text = "Nama Akun";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(43, 399);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(347, 218);
            this.richTextBox1.TabIndex = 14;
            this.richTextBox1.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(63, 328);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(119, 15);
            this.label7.TabIndex = 15;
            this.label7.Text = "Eksplor dengan Akun";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(176, 270);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 15);
            this.label8.TabIndex = 16;
            this.label8.Text = "OPSI FITUR";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(205, 299);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(10, 15);
            this.label9.TabIndex = 17;
            this.label9.Text = ":";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(205, 328);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(10, 15);
            this.label10.TabIndex = 18;
            this.label10.Text = ":";
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(169, 50);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(75, 23);
            this.SearchButton.TabIndex = 19;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // NamaFile
            // 
            this.NamaFile.AutoSize = true;
            this.NamaFile.Location = new System.Drawing.Point(251, 54);
            this.NamaFile.Name = "NamaFile";
            this.NamaFile.Size = new System.Drawing.Size(12, 15);
            this.NamaFile.TabIndex = 20;
            this.NamaFile.Text = "-";
            // 
            // GraphPanel
            // 
            this.GraphPanel.Location = new System.Drawing.Point(41, 107);
            this.GraphPanel.Name = "GraphPanel";
            this.GraphPanel.Size = new System.Drawing.Size(321, 160);
            this.GraphPanel.TabIndex = 21;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(432, 655);
            this.Controls.Add(this.GraphPanel);
            this.Controls.Add(this.NamaFile);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Akhir);
            this.Controls.Add(this.Awal);
            this.Controls.Add(this.DFSrb);
            this.Controls.Add(this.BFSrb);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "BFS DFS!";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton BFSrb;
        private System.Windows.Forms.RadioButton DFSrb;
        private System.Windows.Forms.ComboBox Awal;
        private System.Windows.Forms.ComboBox Akhir;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label NamaFile;
        private System.Windows.Forms.Panel GraphPanel;
    }
}

