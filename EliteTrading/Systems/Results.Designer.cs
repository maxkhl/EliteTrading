namespace EliteTrading.Systems
{
    partial class Results
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
            this.systemList1 = new EliteTrading.Systems.SystemList();
            this.SuspendLayout();
            // 
            // systemList1
            // 
            this.systemList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.systemList1.Location = new System.Drawing.Point(0, 0);
            this.systemList1.Name = "systemList1";
            this.systemList1.Size = new System.Drawing.Size(692, 310);
            this.systemList1.TabIndex = 0;
            // 
            // Results
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 310);
            this.Controls.Add(this.systemList1);
            this.Name = "Results";
            this.Text = "Results";
            this.ResumeLayout(false);

        }

        #endregion

        private SystemList systemList1;
    }
}