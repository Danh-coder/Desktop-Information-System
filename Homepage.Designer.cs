namespace Desktop_Information_System
{
    partial class Homepage
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
            this.label1 = new System.Windows.Forms.Label();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.addDataBtn = new Guna.UI2.WinForms.Guna2Button();
            this.viewAllBtn = new Guna.UI2.WinForms.Guna2Button();
            this.viewByUserGroupBtn = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(208, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(368, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "Desktop Information System";
            // 
            // panelContainer
            // 
            this.panelContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelContainer.Location = new System.Drawing.Point(12, 100);
            this.panelContainer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(775, 346);
            this.panelContainer.TabIndex = 5;
            // 
            // addDataBtn
            // 
            this.addDataBtn.BorderRadius = 2;
            this.addDataBtn.BorderThickness = 1;
            this.addDataBtn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.addDataBtn.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(228)))), ((int)(((byte)(201)))));
            this.addDataBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.addDataBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.addDataBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.addDataBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.addDataBtn.FillColor = System.Drawing.Color.White;
            this.addDataBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addDataBtn.ForeColor = System.Drawing.Color.Black;
            this.addDataBtn.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(228)))), ((int)(((byte)(201)))));
            this.addDataBtn.Location = new System.Drawing.Point(11, 46);
            this.addDataBtn.Margin = new System.Windows.Forms.Padding(4);
            this.addDataBtn.Name = "addDataBtn";
            this.addDataBtn.Size = new System.Drawing.Size(236, 49);
            this.addDataBtn.TabIndex = 6;
            this.addDataBtn.Text = "Add New Data";
            this.addDataBtn.Click += new System.EventHandler(this.addDataBtn_Click);
            // 
            // viewAllBtn
            // 
            this.viewAllBtn.BorderRadius = 2;
            this.viewAllBtn.BorderThickness = 1;
            this.viewAllBtn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.viewAllBtn.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(228)))), ((int)(((byte)(201)))));
            this.viewAllBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.viewAllBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.viewAllBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.viewAllBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.viewAllBtn.FillColor = System.Drawing.Color.White;
            this.viewAllBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewAllBtn.ForeColor = System.Drawing.Color.Black;
            this.viewAllBtn.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(228)))), ((int)(((byte)(201)))));
            this.viewAllBtn.Location = new System.Drawing.Point(255, 46);
            this.viewAllBtn.Margin = new System.Windows.Forms.Padding(4);
            this.viewAllBtn.Name = "viewAllBtn";
            this.viewAllBtn.Size = new System.Drawing.Size(236, 49);
            this.viewAllBtn.TabIndex = 6;
            this.viewAllBtn.Text = "View All Data";
            this.viewAllBtn.Click += new System.EventHandler(this.viewAllBtn_Click);
            // 
            // viewByUserGroupBtn
            // 
            this.viewByUserGroupBtn.BorderRadius = 2;
            this.viewByUserGroupBtn.BorderThickness = 1;
            this.viewByUserGroupBtn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.viewByUserGroupBtn.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(228)))), ((int)(((byte)(201)))));
            this.viewByUserGroupBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.viewByUserGroupBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.viewByUserGroupBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.viewByUserGroupBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.viewByUserGroupBtn.FillColor = System.Drawing.Color.White;
            this.viewByUserGroupBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewByUserGroupBtn.ForeColor = System.Drawing.Color.Black;
            this.viewByUserGroupBtn.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(228)))), ((int)(((byte)(201)))));
            this.viewByUserGroupBtn.Location = new System.Drawing.Point(499, 46);
            this.viewByUserGroupBtn.Margin = new System.Windows.Forms.Padding(4);
            this.viewByUserGroupBtn.Name = "viewByUserGroupBtn";
            this.viewByUserGroupBtn.Size = new System.Drawing.Size(292, 49);
            this.viewByUserGroupBtn.TabIndex = 6;
            this.viewByUserGroupBtn.Text = "View Data By User Group";
            this.viewByUserGroupBtn.Click += new System.EventHandler(this.viewByUserGroupBtn_Click);
            // 
            // Homepage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.viewByUserGroupBtn);
            this.Controls.Add(this.viewAllBtn);
            this.Controls.Add(this.addDataBtn);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Homepage";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelContainer;
        private Guna.UI2.WinForms.Guna2Button addDataBtn;
        private Guna.UI2.WinForms.Guna2Button viewAllBtn;
        private Guna.UI2.WinForms.Guna2Button viewByUserGroupBtn;
    }
}

