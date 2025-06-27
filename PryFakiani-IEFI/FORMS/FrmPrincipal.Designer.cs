namespace PryFakiani_IEFI
{
    partial class FrmPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tAREASToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bUSCARToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aDMINISTRACIONToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aUDITORIAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aUDITORIAToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblBienvenida = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblIngreso = new System.Windows.Forms.ToolStripStatusLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(185)))), ((int)(((byte)(227)))));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tAREASToolStripMenuItem,
            this.aDMINISTRACIONToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(761, 30);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tAREASToolStripMenuItem
            // 
            this.tAREASToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bUSCARToolStripMenuItem});
            this.tAREASToolStripMenuItem.Font = new System.Drawing.Font("Cooper Black", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tAREASToolStripMenuItem.Name = "tAREASToolStripMenuItem";
            this.tAREASToolStripMenuItem.Size = new System.Drawing.Size(105, 26);
            this.tAREASToolStripMenuItem.Text = "TAREAS";
            // 
            // bUSCARToolStripMenuItem
            // 
            this.bUSCARToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(126)))), ((int)(((byte)(225)))));
            this.bUSCARToolStripMenuItem.Name = "bUSCARToolStripMenuItem";
            this.bUSCARToolStripMenuItem.Size = new System.Drawing.Size(176, 26);
            this.bUSCARToolStripMenuItem.Text = "BUSCAR";
            // 
            // aDMINISTRACIONToolStripMenuItem
            // 
            this.aDMINISTRACIONToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aUDITORIAToolStripMenuItem,
            this.aUDITORIAToolStripMenuItem1});
            this.aDMINISTRACIONToolStripMenuItem.Font = new System.Drawing.Font("Cooper Black", 10.8F);
            this.aDMINISTRACIONToolStripMenuItem.Name = "aDMINISTRACIONToolStripMenuItem";
            this.aDMINISTRACIONToolStripMenuItem.Size = new System.Drawing.Size(201, 26);
            this.aDMINISTRACIONToolStripMenuItem.Text = "ADMINISTRACION";
            // 
            // aUDITORIAToolStripMenuItem
            // 
            this.aUDITORIAToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(126)))), ((int)(((byte)(225)))));
            this.aUDITORIAToolStripMenuItem.Name = "aUDITORIAToolStripMenuItem";
            this.aUDITORIAToolStripMenuItem.Size = new System.Drawing.Size(208, 26);
            this.aUDITORIAToolStripMenuItem.Text = "USUARIOS";
            this.aUDITORIAToolStripMenuItem.Click += new System.EventHandler(this.aUDITORIAToolStripMenuItem_Click);
            // 
            // aUDITORIAToolStripMenuItem1
            // 
            this.aUDITORIAToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(126)))), ((int)(((byte)(225)))));
            this.aUDITORIAToolStripMenuItem1.Name = "aUDITORIAToolStripMenuItem1";
            this.aUDITORIAToolStripMenuItem1.Size = new System.Drawing.Size(208, 26);
            this.aUDITORIAToolStripMenuItem1.Text = "AUDITORIA";
            this.aUDITORIAToolStripMenuItem1.Click += new System.EventHandler(this.aUDITORIAToolStripMenuItem1_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(185)))), ((int)(((byte)(227)))));
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblBienvenida,
            this.lblIngreso});
            this.statusStrip1.Location = new System.Drawing.Point(0, 427);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusStrip1.Size = new System.Drawing.Size(761, 27);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblBienvenida
            // 
            this.lblBienvenida.Font = new System.Drawing.Font("Cooper Black", 10.8F);
            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.Size = new System.Drawing.Size(214, 21);
            this.lblBienvenida.Text = "toolStripStatusLabel1";
            // 
            // lblIngreso
            // 
            this.lblIngreso.Font = new System.Drawing.Font("Cooper Black", 10.8F);
            this.lblIngreso.LinkColor = System.Drawing.Color.White;
            this.lblIngreso.Name = "lblIngreso";
            this.lblIngreso.Size = new System.Drawing.Size(527, 21);
            this.lblIngreso.Spring = true;
            this.lblIngreso.Text = "toolStripStatusLabel1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cooper Black", 28.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label1.Location = new System.Drawing.Point(102, 185);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(563, 54);
            this.label1.TabIndex = 2;
            this.label1.Text = "Gestion              Negocio";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(126)))), ((int)(((byte)(225)))));
            this.ClientSize = new System.Drawing.Size(761, 454);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmPrincipal";
            this.Text = "MENU PRINCIPAL";
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblBienvenida;
        private System.Windows.Forms.ToolStripMenuItem tAREASToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aDMINISTRACIONToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aUDITORIAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aUDITORIAToolStripMenuItem1;
        private System.Windows.Forms.ToolStripStatusLabel lblIngreso;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem bUSCARToolStripMenuItem;
    }
}