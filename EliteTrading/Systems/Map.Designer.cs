namespace EliteTrading.Systems
{
    partial class Map
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pB_Map = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pB_Map)).BeginInit();
            this.SuspendLayout();
            // 
            // pB_Map
            // 
            this.pB_Map.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pB_Map.Location = new System.Drawing.Point(0, 0);
            this.pB_Map.Name = "pB_Map";
            this.pB_Map.Size = new System.Drawing.Size(462, 388);
            this.pB_Map.TabIndex = 1;
            this.pB_Map.TabStop = false;
            this.pB_Map.SizeChanged += new System.EventHandler(this.pB_Map_SizeChanged);
            this.pB_Map.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pB_Map_MouseDown);
            this.pB_Map.MouseLeave += new System.EventHandler(this.pB_Map_MouseLeave);
            this.pB_Map.MouseHover += new System.EventHandler(this.pB_Map_MouseHover);
            this.pB_Map.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pB_Map_MouseUp);
            // 
            // Map
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pB_Map);
            this.Name = "Map";
            this.Size = new System.Drawing.Size(462, 388);
            ((System.ComponentModel.ISupportInitialize)(this.pB_Map)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pB_Map;
    }
}
