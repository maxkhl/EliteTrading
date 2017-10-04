namespace EliteTrading.Systems
{
    partial class Faction
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lState = new System.Windows.Forms.Label();
            this.lAllegiance = new System.Windows.Forms.Label();
            this.lGovernment = new System.Windows.Forms.Label();
            this.lName = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lHomeSystem = new System.Windows.Forms.LinkLabel();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lHomeSystem);
            this.groupBox1.Controls.Add(this.lState);
            this.groupBox1.Controls.Add(this.lAllegiance);
            this.groupBox1.Controls.Add(this.lGovernment);
            this.groupBox1.Controls.Add(this.lName);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(448, 91);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Faction Data";
            // 
            // lState
            // 
            this.lState.AutoSize = true;
            this.lState.ForeColor = System.Drawing.Color.DarkRed;
            this.lState.Location = new System.Drawing.Point(137, 55);
            this.lState.Name = "lState";
            this.lState.Size = new System.Drawing.Size(35, 13);
            this.lState.TabIndex = 13;
            this.lState.Text = "Name";
            // 
            // lAllegiance
            // 
            this.lAllegiance.AutoSize = true;
            this.lAllegiance.ForeColor = System.Drawing.Color.DarkRed;
            this.lAllegiance.Location = new System.Drawing.Point(137, 42);
            this.lAllegiance.Name = "lAllegiance";
            this.lAllegiance.Size = new System.Drawing.Size(35, 13);
            this.lAllegiance.TabIndex = 12;
            this.lAllegiance.Text = "Name";
            this.lAllegiance.Click += new System.EventHandler(this.lAllegiance_Click);
            // 
            // lGovernment
            // 
            this.lGovernment.AutoSize = true;
            this.lGovernment.ForeColor = System.Drawing.Color.DarkRed;
            this.lGovernment.Location = new System.Drawing.Point(137, 29);
            this.lGovernment.Name = "lGovernment";
            this.lGovernment.Size = new System.Drawing.Size(35, 13);
            this.lGovernment.TabIndex = 11;
            this.lGovernment.Text = "Name";
            // 
            // lName
            // 
            this.lName.AutoSize = true;
            this.lName.ForeColor = System.Drawing.Color.DarkRed;
            this.lName.Location = new System.Drawing.Point(137, 16);
            this.lName.Name = "lName";
            this.lName.Size = new System.Drawing.Size(35, 13);
            this.lName.TabIndex = 9;
            this.lName.Text = "Name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Home System";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "State";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Allegiance";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Government";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // lHomeSystem
            // 
            this.lHomeSystem.AutoSize = true;
            this.lHomeSystem.Location = new System.Drawing.Point(137, 68);
            this.lHomeSystem.Name = "lHomeSystem";
            this.lHomeSystem.Size = new System.Drawing.Size(35, 13);
            this.lHomeSystem.TabIndex = 15;
            this.lHomeSystem.TabStop = true;
            this.lHomeSystem.Text = "Name";
            this.lHomeSystem.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lHomeSystem_LinkClicked);
            // 
            // Faction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 91);
            this.Controls.Add(this.groupBox1);
            this.Name = "Faction";
            this.Text = "Faction";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lState;
        private System.Windows.Forms.Label lAllegiance;
        private System.Windows.Forms.Label lGovernment;
        private System.Windows.Forms.Label lName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel lHomeSystem;
    }
}