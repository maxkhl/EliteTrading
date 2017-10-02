namespace EliteTrading.Systems
{
    partial class Edit
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.PosX = new System.Windows.Forms.NumericUpDown();
            this.PosY = new System.Windows.Forms.NumericUpDown();
            this.PosZ = new System.Windows.Forms.NumericUpDown();
            this.Type1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Type2 = new System.Windows.Forms.ComboBox();
            this.Type3 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.PosX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PosY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PosZ)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(208, 143);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(127, 143);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(55, 10);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(226, 20);
            this.tbName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Position";
            // 
            // PosX
            // 
            this.PosX.Location = new System.Drawing.Point(55, 36);
            this.PosX.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.PosX.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.PosX.Name = "PosX";
            this.PosX.Size = new System.Drawing.Size(53, 20);
            this.PosX.TabIndex = 5;
            // 
            // PosY
            // 
            this.PosY.Location = new System.Drawing.Point(114, 36);
            this.PosY.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.PosY.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.PosY.Name = "PosY";
            this.PosY.Size = new System.Drawing.Size(53, 20);
            this.PosY.TabIndex = 6;
            // 
            // PosZ
            // 
            this.PosZ.Location = new System.Drawing.Point(173, 36);
            this.PosZ.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.PosZ.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            -2147483648});
            this.PosZ.Name = "PosZ";
            this.PosZ.Size = new System.Drawing.Size(53, 20);
            this.PosZ.TabIndex = 7;
            // 
            // Type1
            // 
            this.Type1.FormattingEnabled = true;
            this.Type1.Location = new System.Drawing.Point(55, 62);
            this.Type1.Name = "Type1";
            this.Type1.Size = new System.Drawing.Size(228, 21);
            this.Type1.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Types";
            // 
            // Type2
            // 
            this.Type2.FormattingEnabled = true;
            this.Type2.Location = new System.Drawing.Point(55, 89);
            this.Type2.Name = "Type2";
            this.Type2.Size = new System.Drawing.Size(228, 21);
            this.Type2.TabIndex = 10;
            // 
            // Type3
            // 
            this.Type3.FormattingEnabled = true;
            this.Type3.Location = new System.Drawing.Point(55, 116);
            this.Type3.Name = "Type3";
            this.Type3.Size = new System.Drawing.Size(228, 21);
            this.Type3.TabIndex = 11;
            // 
            // Edit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 175);
            this.Controls.Add(this.Type3);
            this.Controls.Add(this.Type2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Type1);
            this.Controls.Add(this.PosZ);
            this.Controls.Add(this.PosY);
            this.Controls.Add(this.PosX);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Edit";
            this.Text = "eSystem";
            ((System.ComponentModel.ISupportInitialize)(this.PosX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PosY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PosZ)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown PosX;
        private System.Windows.Forms.NumericUpDown PosY;
        private System.Windows.Forms.NumericUpDown PosZ;
        private System.Windows.Forms.ComboBox Type1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox Type2;
        private System.Windows.Forms.ComboBox Type3;
    }
}