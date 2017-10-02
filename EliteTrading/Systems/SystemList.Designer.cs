namespace EliteTrading.Systems
{
    partial class SystemList
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.StationAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.note = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.populationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.governmentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.allegianceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.securityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.primaryeconomyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.needspermitDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.powercontrolfactionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coordinatesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.distanceToSolDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.systemBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.systemBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.systemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.systemBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.systemBindingSource3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.systemBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.systemBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.systemBindingSource2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.StationAmount,
            this.populationDataGridViewTextBoxColumn,
            this.note,
            this.governmentDataGridViewTextBoxColumn,
            this.allegianceDataGridViewTextBoxColumn,
            this.stateDataGridViewTextBoxColumn,
            this.securityDataGridViewTextBoxColumn,
            this.primaryeconomyDataGridViewTextBoxColumn,
            this.needspermitDataGridViewCheckBoxColumn,
            this.powercontrolfactionDataGridViewTextBoxColumn,
            this.coordinatesDataGridViewTextBoxColumn,
            this.distanceToSolDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.systemBindingSource3;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ControlText;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Size = new System.Drawing.Size(1191, 210);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.DataMemberChanged += new System.EventHandler(this.dataGridView1_DataMemberChanged);
            this.dataGridView1.DataSourceChanged += new System.EventHandler(this.dataGridView1_DataSourceChanged);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // StationAmount
            // 
            this.StationAmount.DataPropertyName = "StationAmount";
            this.StationAmount.HeaderText = "Stations";
            this.StationAmount.Name = "StationAmount";
            this.StationAmount.ReadOnly = true;
            this.StationAmount.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.StationAmount.Width = 50;
            // 
            // note
            // 
            this.note.DataPropertyName = "note";
            this.note.HeaderText = "Note";
            this.note.Name = "note";
            this.note.ReadOnly = true;
            this.note.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.note.ToolTipText = "Additional Information";
            this.note.Width = 150;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "name";
            this.dataGridViewTextBoxColumn1.HeaderText = "Name";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewTextBoxColumn1.ToolTipText = "Name of the System";
            // 
            // populationDataGridViewTextBoxColumn
            // 
            this.populationDataGridViewTextBoxColumn.DataPropertyName = "population";
            this.populationDataGridViewTextBoxColumn.HeaderText = "Population";
            this.populationDataGridViewTextBoxColumn.Name = "populationDataGridViewTextBoxColumn";
            this.populationDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // governmentDataGridViewTextBoxColumn
            // 
            this.governmentDataGridViewTextBoxColumn.DataPropertyName = "government";
            this.governmentDataGridViewTextBoxColumn.HeaderText = "Government";
            this.governmentDataGridViewTextBoxColumn.Name = "governmentDataGridViewTextBoxColumn";
            this.governmentDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // allegianceDataGridViewTextBoxColumn
            // 
            this.allegianceDataGridViewTextBoxColumn.DataPropertyName = "allegiance";
            this.allegianceDataGridViewTextBoxColumn.HeaderText = "Allegiance";
            this.allegianceDataGridViewTextBoxColumn.Name = "allegianceDataGridViewTextBoxColumn";
            this.allegianceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // stateDataGridViewTextBoxColumn
            // 
            this.stateDataGridViewTextBoxColumn.DataPropertyName = "state";
            this.stateDataGridViewTextBoxColumn.HeaderText = "State";
            this.stateDataGridViewTextBoxColumn.Name = "stateDataGridViewTextBoxColumn";
            this.stateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // securityDataGridViewTextBoxColumn
            // 
            this.securityDataGridViewTextBoxColumn.DataPropertyName = "security";
            this.securityDataGridViewTextBoxColumn.HeaderText = "Security";
            this.securityDataGridViewTextBoxColumn.Name = "securityDataGridViewTextBoxColumn";
            this.securityDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // primaryeconomyDataGridViewTextBoxColumn
            // 
            this.primaryeconomyDataGridViewTextBoxColumn.DataPropertyName = "primary_economy";
            this.primaryeconomyDataGridViewTextBoxColumn.HeaderText = "Primary Economy";
            this.primaryeconomyDataGridViewTextBoxColumn.Name = "primaryeconomyDataGridViewTextBoxColumn";
            this.primaryeconomyDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // needspermitDataGridViewCheckBoxColumn
            // 
            this.needspermitDataGridViewCheckBoxColumn.DataPropertyName = "needs_permit";
            this.needspermitDataGridViewCheckBoxColumn.HeaderText = "Needs Permit";
            this.needspermitDataGridViewCheckBoxColumn.Name = "needspermitDataGridViewCheckBoxColumn";
            this.needspermitDataGridViewCheckBoxColumn.ReadOnly = true;
            this.needspermitDataGridViewCheckBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.needspermitDataGridViewCheckBoxColumn.ToolTipText = "System needs special permit?";
            // 
            // powercontrolfactionDataGridViewTextBoxColumn
            // 
            this.powercontrolfactionDataGridViewTextBoxColumn.DataPropertyName = "power_control_faction";
            this.powercontrolfactionDataGridViewTextBoxColumn.HeaderText = "Power Control Faction";
            this.powercontrolfactionDataGridViewTextBoxColumn.Name = "powercontrolfactionDataGridViewTextBoxColumn";
            this.powercontrolfactionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // coordinatesDataGridViewTextBoxColumn
            // 
            this.coordinatesDataGridViewTextBoxColumn.DataPropertyName = "Coordinates";
            this.coordinatesDataGridViewTextBoxColumn.HeaderText = "Coordinates";
            this.coordinatesDataGridViewTextBoxColumn.Name = "coordinatesDataGridViewTextBoxColumn";
            this.coordinatesDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // distanceToSolDataGridViewTextBoxColumn
            // 
            this.distanceToSolDataGridViewTextBoxColumn.DataPropertyName = "DistanceToSol";
            this.distanceToSolDataGridViewTextBoxColumn.HeaderText = "Distance to Sol";
            this.distanceToSolDataGridViewTextBoxColumn.Name = "distanceToSolDataGridViewTextBoxColumn";
            this.distanceToSolDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // systemBindingSource3
            // 
            this.systemBindingSource3.DataSource = typeof(EliteTrading.Data.System);
            // 
            // systemBindingSource1
            // 
            this.systemBindingSource1.DataSource = typeof(EliteTrading.Data.System);
            // 
            // systemBindingSource
            // 
            this.systemBindingSource.DataSource = typeof(EliteTrading.Data.System);
            // 
            // systemBindingSource2
            // 
            this.systemBindingSource2.DataSource = typeof(EliteTrading.Data.System);
            // 
            // SystemList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView1);
            this.Name = "SystemList";
            this.Size = new System.Drawing.Size(1191, 210);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.systemBindingSource3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.systemBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.systemBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.systemBindingSource2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource systemBindingSource;
        private System.Windows.Forms.BindingSource systemBindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource systemBindingSource2;
        private System.Windows.Forms.BindingSource systemBindingSource3;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn StationAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn populationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn note;
        private System.Windows.Forms.DataGridViewTextBoxColumn governmentDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn allegianceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn securityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn primaryeconomyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn needspermitDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn powercontrolfactionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn coordinatesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn distanceToSolDataGridViewTextBoxColumn;
    }
}
