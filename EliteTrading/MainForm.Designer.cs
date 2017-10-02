namespace EliteTrading
{
    partial class MainForm
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.l_Data = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.whereToBuyShipsGearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.powerplayImperialSlaveRoutesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commoditiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.routeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gB_MyData = new System.Windows.Forms.GroupBox();
            this.cB_LPad = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.minAveragePrice = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.routeLength = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.tStationStarDist = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.jDistance = new System.Windows.Forms.NumericUpDown();
            this.bFindGoodTrade = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tDistance = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cB_Location = new System.Windows.Forms.ComboBox();
            this.systemList1 = new EliteTrading.Systems.SystemList();
            this.l_LoadingStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gB_MyData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minAveragePrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.routeLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tStationStarDist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jDistance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tDistance)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.l_Data,
            this.progressBar,
            this.l_LoadingStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 464);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1193, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // l_Data
            // 
            this.l_Data.Name = "l_Data";
            this.l_Data.Size = new System.Drawing.Size(0, 17);
            // 
            // progressBar
            // 
            this.progressBar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(100, 16);
            this.progressBar.Visible = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolsToolStripMenuItem,
            this.commoditiesToolStripMenuItem,
            this.routeToolStripMenuItem,
            this.mapToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1193, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.whereToBuyShipsGearToolStripMenuItem,
            this.powerplayImperialSlaveRoutesToolStripMenuItem});
            this.toolsToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Desktop;
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.toolsToolStripMenuItem.Text = "Reports";
            // 
            // whereToBuyShipsGearToolStripMenuItem
            // 
            this.whereToBuyShipsGearToolStripMenuItem.Name = "whereToBuyShipsGearToolStripMenuItem";
            this.whereToBuyShipsGearToolStripMenuItem.Size = new System.Drawing.Size(272, 22);
            this.whereToBuyShipsGearToolStripMenuItem.Text = "Where to buy Ships/Gear";
            this.whereToBuyShipsGearToolStripMenuItem.Click += new System.EventHandler(this.whereToBuyShipsGearToolStripMenuItem_Click);
            // 
            // powerplayImperialSlaveRoutesToolStripMenuItem
            // 
            this.powerplayImperialSlaveRoutesToolStripMenuItem.Name = "powerplayImperialSlaveRoutesToolStripMenuItem";
            this.powerplayImperialSlaveRoutesToolStripMenuItem.Size = new System.Drawing.Size(272, 22);
            this.powerplayImperialSlaveRoutesToolStripMenuItem.Text = "Powerplay Imperial Slave (illegal-) Routes";
            this.powerplayImperialSlaveRoutesToolStripMenuItem.Click += new System.EventHandler(this.powerplayImperialSlaveRoutesToolStripMenuItem_Click);
            // 
            // commoditiesToolStripMenuItem
            // 
            this.commoditiesToolStripMenuItem.Name = "commoditiesToolStripMenuItem";
            this.commoditiesToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.commoditiesToolStripMenuItem.Text = "Commodities";
            this.commoditiesToolStripMenuItem.Click += new System.EventHandler(this.commoditiesToolStripMenuItem_Click);
            // 
            // routeToolStripMenuItem
            // 
            this.routeToolStripMenuItem.Name = "routeToolStripMenuItem";
            this.routeToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.routeToolStripMenuItem.Text = "Route";
            this.routeToolStripMenuItem.Click += new System.EventHandler(this.routeToolStripMenuItem_Click);
            // 
            // mapToolStripMenuItem
            // 
            this.mapToolStripMenuItem.Name = "mapToolStripMenuItem";
            this.mapToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.mapToolStripMenuItem.Text = "Map";
            this.mapToolStripMenuItem.Click += new System.EventHandler(this.mapToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gB_MyData);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.systemList1);
            this.splitContainer1.Size = new System.Drawing.Size(1193, 440);
            this.splitContainer1.SplitterDistance = 97;
            this.splitContainer1.TabIndex = 3;
            // 
            // gB_MyData
            // 
            this.gB_MyData.Controls.Add(this.cB_LPad);
            this.gB_MyData.Controls.Add(this.label10);
            this.gB_MyData.Controls.Add(this.label14);
            this.gB_MyData.Controls.Add(this.label13);
            this.gB_MyData.Controls.Add(this.minAveragePrice);
            this.gB_MyData.Controls.Add(this.label12);
            this.gB_MyData.Controls.Add(this.label9);
            this.gB_MyData.Controls.Add(this.label8);
            this.gB_MyData.Controls.Add(this.routeLength);
            this.gB_MyData.Controls.Add(this.label7);
            this.gB_MyData.Controls.Add(this.tStationStarDist);
            this.gB_MyData.Controls.Add(this.label6);
            this.gB_MyData.Controls.Add(this.label5);
            this.gB_MyData.Controls.Add(this.label4);
            this.gB_MyData.Controls.Add(this.jDistance);
            this.gB_MyData.Controls.Add(this.bFindGoodTrade);
            this.gB_MyData.Controls.Add(this.label3);
            this.gB_MyData.Controls.Add(this.tDistance);
            this.gB_MyData.Controls.Add(this.label2);
            this.gB_MyData.Controls.Add(this.label1);
            this.gB_MyData.Controls.Add(this.cB_Location);
            this.gB_MyData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gB_MyData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gB_MyData.Location = new System.Drawing.Point(0, 0);
            this.gB_MyData.Name = "gB_MyData";
            this.gB_MyData.Size = new System.Drawing.Size(1193, 97);
            this.gB_MyData.TabIndex = 0;
            this.gB_MyData.TabStop = false;
            this.gB_MyData.Text = "My Data";
            // 
            // cB_LPad
            // 
            this.cB_LPad.AutoSize = true;
            this.cB_LPad.Location = new System.Drawing.Point(759, 19);
            this.cB_LPad.Name = "cB_LPad";
            this.cB_LPad.Size = new System.Drawing.Size(15, 14);
            this.cB_LPad.TabIndex = 23;
            this.cB_LPad.UseVisualStyleBackColor = true;
            this.cB_LPad.CheckedChanged += new System.EventHandler(this.cB_LPad_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AccessibleDescription = "";
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(657, 21);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Only Large Pad?";
            // 
            // label14
            // 
            this.label14.AccessibleDescription = "";
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.Red;
            this.label14.Location = new System.Drawing.Point(154, 73);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(279, 13);
            this.label14.TabIndex = 21;
            this.label14.Text = "This is only using general import-export data to find trades.";
            // 
            // label13
            // 
            this.label13.AccessibleDescription = "";
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(832, 42);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(39, 13);
            this.label13.TabIndex = 20;
            this.label13.Text = "Credits";
            // 
            // minAveragePrice
            // 
            this.minAveragePrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.minAveragePrice.Location = new System.Drawing.Point(759, 40);
            this.minAveragePrice.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.minAveragePrice.Name = "minAveragePrice";
            this.minAveragePrice.Size = new System.Drawing.Size(67, 20);
            this.minAveragePrice.TabIndex = 19;
            this.minAveragePrice.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.minAveragePrice.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.minAveragePrice.ValueChanged += new System.EventHandler(this.minAveragePrice_ValueChanged);
            // 
            // label12
            // 
            this.label12.AccessibleDescription = "";
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(657, 42);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(96, 13);
            this.label12.TabIndex = 18;
            this.label12.Text = "Min. average Price";
            // 
            // label9
            // 
            this.label9.AccessibleDescription = "";
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(601, 42);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Jumps";
            // 
            // label8
            // 
            this.label8.AccessibleDescription = "";
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(419, 42);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Max Route Length";
            // 
            // routeLength
            // 
            this.routeLength.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.routeLength.Location = new System.Drawing.Point(528, 40);
            this.routeLength.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.routeLength.Name = "routeLength";
            this.routeLength.Size = new System.Drawing.Size(67, 20);
            this.routeLength.TabIndex = 12;
            this.routeLength.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.routeLength.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.routeLength.ValueChanged += new System.EventHandler(this.routeLength_ValueChanged);
            // 
            // label7
            // 
            this.label7.AccessibleDescription = "";
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(383, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(18, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Ls";
            // 
            // tStationStarDist
            // 
            this.tStationStarDist.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tStationStarDist.Location = new System.Drawing.Point(310, 39);
            this.tStationStarDist.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.tStationStarDist.Name = "tStationStarDist";
            this.tStationStarDist.Size = new System.Drawing.Size(67, 20);
            this.tStationStarDist.TabIndex = 10;
            this.tStationStarDist.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.tStationStarDist.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.tStationStarDist.ValueChanged += new System.EventHandler(this.tStationStarDist_ValueChanged);
            // 
            // label6
            // 
            this.label6.AccessibleDescription = "";
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(196, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Max. Station-Star-Dist";
            // 
            // label5
            // 
            this.label5.AccessibleDescription = "";
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(601, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Ly";
            // 
            // label4
            // 
            this.label4.AccessibleDescription = "";
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(419, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Max. Jump Distance";
            // 
            // jDistance
            // 
            this.jDistance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.jDistance.Location = new System.Drawing.Point(528, 18);
            this.jDistance.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.jDistance.Name = "jDistance";
            this.jDistance.Size = new System.Drawing.Size(67, 20);
            this.jDistance.TabIndex = 6;
            this.jDistance.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.jDistance.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.jDistance.ValueChanged += new System.EventHandler(this.jDistance_ValueChanged);
            // 
            // bFindGoodTrade
            // 
            this.bFindGoodTrade.Enabled = false;
            this.bFindGoodTrade.Location = new System.Drawing.Point(6, 68);
            this.bFindGoodTrade.Name = "bFindGoodTrade";
            this.bFindGoodTrade.Size = new System.Drawing.Size(142, 23);
            this.bFindGoodTrade.TabIndex = 5;
            this.bFindGoodTrade.Text = "Find potential Route";
            this.bFindGoodTrade.UseVisualStyleBackColor = true;
            this.bFindGoodTrade.Click += new System.EventHandler(this.bFindGoodTrade_Click);
            // 
            // label3
            // 
            this.label3.AccessibleDescription = "";
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(383, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ly";
            // 
            // tDistance
            // 
            this.tDistance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tDistance.Location = new System.Drawing.Point(310, 18);
            this.tDistance.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.tDistance.Name = "tDistance";
            this.tDistance.Size = new System.Drawing.Size(67, 20);
            this.tDistance.TabIndex = 3;
            this.tDistance.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.tDistance.Value = new decimal(new int[] {
            150,
            0,
            0,
            0});
            this.tDistance.ValueChanged += new System.EventHandler(this.tDistance_ValueChanged);
            // 
            // label2
            // 
            this.label2.AccessibleDescription = "";
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(196, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Max. Travel Distance";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Location";
            // 
            // cB_Location
            // 
            this.cB_Location.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cB_Location.FormattingEnabled = true;
            this.cB_Location.Location = new System.Drawing.Point(69, 18);
            this.cB_Location.Name = "cB_Location";
            this.cB_Location.Size = new System.Drawing.Size(121, 21);
            this.cB_Location.TabIndex = 0;
            this.cB_Location.SelectedIndexChanged += new System.EventHandler(this.cB_Location_SelectedIndexChanged);
            this.cB_Location.TextChanged += new System.EventHandler(this.cB_Location_TextChanged);
            // 
            // systemList1
            // 
            this.systemList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.systemList1.Location = new System.Drawing.Point(0, 0);
            this.systemList1.Name = "systemList1";
            this.systemList1.Size = new System.Drawing.Size(1193, 339);
            this.systemList1.TabIndex = 0;
            // 
            // l_LoadingStatus
            // 
            this.l_LoadingStatus.Name = "l_LoadingStatus";
            this.l_LoadingStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1193, 486);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Enabled = false;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Elite Trading Tool";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.gB_MyData.ResumeLayout(false);
            this.gB_MyData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minAveragePrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.routeLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tStationStarDist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jDistance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tDistance)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Systems.SystemList systemList1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripStatusLabel l_Data;
        private System.Windows.Forms.ToolStripProgressBar progressBar;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox gB_MyData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cB_Location;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown tDistance;
        private System.Windows.Forms.Button bFindGoodTrade;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown tStationStarDist;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown jDistance;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem whereToBuyShipsGearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem commoditiesToolStripMenuItem;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown routeLength;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown minAveragePrice;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox cB_LPad;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ToolStripMenuItem powerplayImperialSlaveRoutesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem routeToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel l_LoadingStatus;
    }
}

