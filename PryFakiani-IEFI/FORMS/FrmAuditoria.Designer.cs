namespace PryFakiani_IEFI
{
    partial class FrmAuditoria
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAuditoria));
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.radioASC = new System.Windows.Forms.RadioButton();
            this.RadioDesc = new System.Windows.Forms.RadioButton();
            this.chkfiltrarAuditoriaId = new System.Windows.Forms.CheckBox();
            this.txtAuditoriaId = new System.Windows.Forms.TextBox();
            this.chkUsuarioNombre = new System.Windows.Forms.CheckBox();
            this.txtUsuarioNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblTiempodeUso = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTiempouso = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblUsuarioAuditoria = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dateDesde = new System.Windows.Forms.DateTimePicker();
            this.dateHasta = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.chkFiltroFecha = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExcel = new System.Windows.Forms.Button();
            this.BtnActualizar = new System.Windows.Forms.Button();
            this.btnDescargar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvUsuarios
            // 
            this.dgvUsuarios.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios.Location = new System.Drawing.Point(283, 65);
            this.dgvUsuarios.Margin = new System.Windows.Forms.Padding(4);
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.RowHeadersWidth = 51;
            this.dgvUsuarios.Size = new System.Drawing.Size(726, 280);
            this.dgvUsuarios.TabIndex = 0;
            // 
            // radioASC
            // 
            this.radioASC.AutoSize = true;
            this.radioASC.Checked = true;
            this.radioASC.Font = new System.Drawing.Font("Cooper Black", 9F);
            this.radioASC.Location = new System.Drawing.Point(13, 61);
            this.radioASC.Margin = new System.Windows.Forms.Padding(4);
            this.radioASC.Name = "radioASC";
            this.radioASC.Size = new System.Drawing.Size(169, 21);
            this.radioASC.TabIndex = 4;
            this.radioASC.TabStop = true;
            this.radioASC.Text = "FiltrarAscendente";
            this.radioASC.UseVisualStyleBackColor = true;
            this.radioASC.CheckedChanged += new System.EventHandler(this.radioASC_CheckedChanged);
            // 
            // RadioDesc
            // 
            this.RadioDesc.AutoSize = true;
            this.RadioDesc.Font = new System.Drawing.Font("Cooper Black", 9F);
            this.RadioDesc.Location = new System.Drawing.Point(13, 105);
            this.RadioDesc.Margin = new System.Windows.Forms.Padding(4);
            this.RadioDesc.Name = "RadioDesc";
            this.RadioDesc.Size = new System.Drawing.Size(169, 21);
            this.RadioDesc.TabIndex = 5;
            this.RadioDesc.Text = "FiltarDescendente";
            this.RadioDesc.UseVisualStyleBackColor = true;
            this.RadioDesc.CheckedChanged += new System.EventHandler(this.RadioDesc_CheckedChanged);
            // 
            // chkfiltrarAuditoriaId
            // 
            this.chkfiltrarAuditoriaId.AutoSize = true;
            this.chkfiltrarAuditoriaId.Font = new System.Drawing.Font("Cooper Black", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkfiltrarAuditoriaId.Location = new System.Drawing.Point(13, 252);
            this.chkfiltrarAuditoriaId.Margin = new System.Windows.Forms.Padding(4);
            this.chkfiltrarAuditoriaId.Name = "chkfiltrarAuditoriaId";
            this.chkfiltrarAuditoriaId.Size = new System.Drawing.Size(262, 21);
            this.chkfiltrarAuditoriaId.TabIndex = 6;
            this.chkfiltrarAuditoriaId.Text = "FILTRAR POR AUDITORIA ID";
            this.chkfiltrarAuditoriaId.UseVisualStyleBackColor = true;
            this.chkfiltrarAuditoriaId.CheckedChanged += new System.EventHandler(this.chkfiltrarAuditoriaId_CheckedChanged);
            // 
            // txtAuditoriaId
            // 
            this.txtAuditoriaId.Location = new System.Drawing.Point(13, 292);
            this.txtAuditoriaId.Margin = new System.Windows.Forms.Padding(4);
            this.txtAuditoriaId.Name = "txtAuditoriaId";
            this.txtAuditoriaId.Size = new System.Drawing.Size(150, 22);
            this.txtAuditoriaId.TabIndex = 7;
            this.txtAuditoriaId.TextChanged += new System.EventHandler(this.txtAuditoriaId_TextChanged);
            // 
            // chkUsuarioNombre
            // 
            this.chkUsuarioNombre.AutoSize = true;
            this.chkUsuarioNombre.Font = new System.Drawing.Font("Cooper Black", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkUsuarioNombre.Location = new System.Drawing.Point(13, 168);
            this.chkUsuarioNombre.Margin = new System.Windows.Forms.Padding(4);
            this.chkUsuarioNombre.Name = "chkUsuarioNombre";
            this.chkUsuarioNombre.Size = new System.Drawing.Size(215, 21);
            this.chkUsuarioNombre.TabIndex = 13;
            this.chkUsuarioNombre.Text = "FILTRAR POR NOMBRE";
            this.chkUsuarioNombre.UseVisualStyleBackColor = true;
            this.chkUsuarioNombre.CheckedChanged += new System.EventHandler(this.chkUsuarioNombre_CheckedChanged);
            // 
            // txtUsuarioNombre
            // 
            this.txtUsuarioNombre.Location = new System.Drawing.Point(13, 197);
            this.txtUsuarioNombre.Margin = new System.Windows.Forms.Padding(4);
            this.txtUsuarioNombre.Name = "txtUsuarioNombre";
            this.txtUsuarioNombre.Size = new System.Drawing.Size(150, 22);
            this.txtUsuarioNombre.TabIndex = 12;
            this.txtUsuarioNombre.TextChanged += new System.EventHandler(this.txtUsuarioNombre_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(499, 698);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 13;
            this.label2.Text = "label2";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblTiempodeUso,
            this.lblTiempouso,
            this.lblUsuarioAuditoria});
            this.statusStrip1.Location = new System.Drawing.Point(0, 557);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1022, 26);
            this.statusStrip1.TabIndex = 14;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblTiempodeUso
            // 
            this.lblTiempodeUso.Name = "lblTiempodeUso";
            this.lblTiempodeUso.Size = new System.Drawing.Size(151, 20);
            this.lblTiempodeUso.Text = "toolStripStatusLabel1";
            // 
            // lblTiempouso
            // 
            this.lblTiempouso.Name = "lblTiempouso";
            this.lblTiempouso.Size = new System.Drawing.Size(0, 20);
            // 
            // lblUsuarioAuditoria
            // 
            this.lblUsuarioAuditoria.Name = "lblUsuarioAuditoria";
            this.lblUsuarioAuditoria.Size = new System.Drawing.Size(151, 20);
            this.lblUsuarioAuditoria.Text = "toolStripStatusLabel1";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(126)))), ((int)(((byte)(225)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1022, 58);
            this.panel1.TabIndex = 16;
            // 
            // dateDesde
            // 
            this.dateDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateDesde.Location = new System.Drawing.Point(12, 383);
            this.dateDesde.Name = "dateDesde";
            this.dateDesde.Size = new System.Drawing.Size(151, 22);
            this.dateDesde.TabIndex = 18;
            this.dateDesde.ValueChanged += new System.EventHandler(this.dateDesde_ValueChanged);
            // 
            // dateHasta
            // 
            this.dateHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateHasta.Location = new System.Drawing.Point(13, 448);
            this.dateHasta.Name = "dateHasta";
            this.dateHasta.Size = new System.Drawing.Size(150, 22);
            this.dateHasta.TabIndex = 19;
            this.dateHasta.ValueChanged += new System.EventHandler(this.dateHasta_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cooper Black", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(73, 420);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 15);
            this.label4.TabIndex = 20;
            this.label4.Text = "AL";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cooper Black", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(70, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(152, 32);
            this.label5.TabIndex = 21;
            this.label5.Text = "FILTROS ";
            // 
            // chkFiltroFecha
            // 
            this.chkFiltroFecha.AutoSize = true;
            this.chkFiltroFecha.Font = new System.Drawing.Font("Cooper Black", 9F);
            this.chkFiltroFecha.Location = new System.Drawing.Point(13, 344);
            this.chkFiltroFecha.Name = "chkFiltroFecha";
            this.chkFiltroFecha.Size = new System.Drawing.Size(200, 21);
            this.chkFiltroFecha.TabIndex = 22;
            this.chkFiltroFecha.Text = "FILTRAR POR FECHA";
            this.chkFiltroFecha.UseVisualStyleBackColor = true;
            this.chkFiltroFecha.CheckedChanged += new System.EventHandler(this.chkFiltroFecha_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(126)))), ((int)(((byte)(225)))));
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.dateHasta);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.chkFiltroFecha);
            this.panel2.Controls.Add(this.radioASC);
            this.panel2.Controls.Add(this.dateDesde);
            this.panel2.Controls.Add(this.RadioDesc);
            this.panel2.Controls.Add(this.chkUsuarioNombre);
            this.panel2.Controls.Add(this.txtUsuarioNombre);
            this.panel2.Controls.Add(this.chkfiltrarAuditoriaId);
            this.panel2.Controls.Add(this.txtAuditoriaId);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 58);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(276, 499);
            this.panel2.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cooper Black", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Image = global::PryFakiani_IEFI.Properties.Resources.ajustes_deslizadores;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Location = new System.Drawing.Point(410, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(296, 38);
            this.label1.TabIndex = 10;
            this.label1.Text = "AUDITORIAS      ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnExcel
            // 
            this.btnExcel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(174)))), ((int)(((byte)(251)))));
            this.btnExcel.Font = new System.Drawing.Font("Cooper Black", 9F);
            this.btnExcel.Image = global::PryFakiani_IEFI.Properties.Resources.buscar_alt;
            this.btnExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExcel.Location = new System.Drawing.Point(762, 350);
            this.btnExcel.Margin = new System.Windows.Forms.Padding(4);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(247, 38);
            this.btnExcel.TabIndex = 15;
            this.btnExcel.Text = "DESCARGAR EXCEL";
            this.btnExcel.UseVisualStyleBackColor = false;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // BtnActualizar
            // 
            this.BtnActualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(174)))), ((int)(((byte)(251)))));
            this.BtnActualizar.Font = new System.Drawing.Font("Cooper Black", 9F);
            this.BtnActualizar.Image = global::PryFakiani_IEFI.Properties.Resources.actualizar;
            this.BtnActualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnActualizar.Location = new System.Drawing.Point(283, 350);
            this.BtnActualizar.Margin = new System.Windows.Forms.Padding(4);
            this.BtnActualizar.Name = "BtnActualizar";
            this.BtnActualizar.Size = new System.Drawing.Size(241, 38);
            this.BtnActualizar.TabIndex = 11;
            this.BtnActualizar.Text = "ACTUALIZAR";
            this.BtnActualizar.UseVisualStyleBackColor = false;
            this.BtnActualizar.Click += new System.EventHandler(this.BtnActualizar_Click);
            // 
            // btnDescargar
            // 
            this.btnDescargar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(174)))), ((int)(((byte)(251)))));
            this.btnDescargar.Font = new System.Drawing.Font("Cooper Black", 9F);
            this.btnDescargar.Image = global::PryFakiani_IEFI.Properties.Resources.buscar_alt;
            this.btnDescargar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDescargar.Location = new System.Drawing.Point(532, 350);
            this.btnDescargar.Margin = new System.Windows.Forms.Padding(4);
            this.btnDescargar.Name = "btnDescargar";
            this.btnDescargar.Size = new System.Drawing.Size(222, 38);
            this.btnDescargar.TabIndex = 3;
            this.btnDescargar.Text = "DESCARGAR TXT";
            this.btnDescargar.UseVisualStyleBackColor = false;
            this.btnDescargar.Click += new System.EventHandler(this.btnDescargar_Click);
            // 
            // FrmAuditoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(185)))), ((int)(((byte)(227)))));
            this.ClientSize = new System.Drawing.Size(1022, 583);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.BtnActualizar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnDescargar);
            this.Controls.Add(this.dgvUsuarios);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmAuditoria";
            this.Text = "FrmAuditoriacs";
            this.Load += new System.EventHandler(this.FrmAuditoria_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.Button btnDescargar;
        private System.Windows.Forms.RadioButton radioASC;
        private System.Windows.Forms.RadioButton RadioDesc;
        private System.Windows.Forms.CheckBox chkfiltrarAuditoriaId;
        private System.Windows.Forms.TextBox txtAuditoriaId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnActualizar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblTiempodeUso;
        private System.Windows.Forms.ToolStripStatusLabel lblTiempouso;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.TextBox txtUsuarioNombre;
        private System.Windows.Forms.CheckBox chkUsuarioNombre;
        private System.Windows.Forms.ToolStripStatusLabel lblUsuarioAuditoria;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dateDesde;
        private System.Windows.Forms.DateTimePicker dateHasta;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkFiltroFecha;
        private System.Windows.Forms.Panel panel2;
    }
}