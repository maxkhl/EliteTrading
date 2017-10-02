namespace EliteTrading
{
    partial class RouteSel
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
            this.cB_Start = new System.Windows.Forms.ComboBox();
            this.cB_End = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cB_Start
            // 
            this.cB_Start.FormattingEnabled = true;
            this.cB_Start.Location = new System.Drawing.Point(12, 8);
            this.cB_Start.Name = "cB_Start";
            this.cB_Start.Size = new System.Drawing.Size(151, 21);
            this.cB_Start.TabIndex = 0;
            this.cB_Start.SelectedIndexChanged += new System.EventHandler(this.cB_Start_SelectedIndexChanged);
            this.cB_Start.TextChanged += new System.EventHandler(this.cB_Start_TextChanged);
            // 
            // cB_End
            // 
            this.cB_End.FormattingEnabled = true;
            this.cB_End.Location = new System.Drawing.Point(191, 8);
            this.cB_End.Name = "cB_End";
            this.cB_End.Size = new System.Drawing.Size(151, 21);
            this.cB_End.TabIndex = 1;
            this.cB_End.SelectedIndexChanged += new System.EventHandler(this.cB_End_SelectedIndexChanged);
            this.cB_End.TextChanged += new System.EventHandler(this.cB_End_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(169, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "->";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(245, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Max. jump distance from main window gets applied";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(264, 35);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Show Route";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // RouteSel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 68);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cB_End);
            this.Controls.Add(this.cB_Start);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "RouteSel";
            this.Text = "Find Route";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cB_Start;
        private System.Windows.Forms.ComboBox cB_End;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}