namespace Desktop_Information_System
{
    partial class AddDataPage
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
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.addStudentBtn = new Guna.UI2.WinForms.Guna2Button();
            this.addAdministrationBtn = new Guna.UI2.WinForms.Guna2Button();
            this.addTeachingStaffBtn = new Guna.UI2.WinForms.Guna2Button();
            this.panelContainer = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BorderColor = System.Drawing.Color.Black;
            this.guna2Panel1.Controls.Add(this.addStudentBtn);
            this.guna2Panel1.Controls.Add(this.addAdministrationBtn);
            this.guna2Panel1.Controls.Add(this.addTeachingStaffBtn);
            this.guna2Panel1.CustomBorderColor = System.Drawing.Color.Black;
            this.guna2Panel1.CustomBorderThickness = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Margin = new System.Windows.Forms.Padding(4);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(201, 347);
            this.guna2Panel1.TabIndex = 1;
            // 
            // addStudentBtn
            // 
            this.addStudentBtn.BorderRadius = 2;
            this.addStudentBtn.BorderThickness = 1;
            this.addStudentBtn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.addStudentBtn.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(209)))), ((int)(((byte)(207)))));
            this.addStudentBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.addStudentBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.addStudentBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.addStudentBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.addStudentBtn.FillColor = System.Drawing.Color.White;
            this.addStudentBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addStudentBtn.ForeColor = System.Drawing.Color.Black;
            this.addStudentBtn.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(209)))), ((int)(((byte)(207)))));
            this.addStudentBtn.Location = new System.Drawing.Point(11, 178);
            this.addStudentBtn.Margin = new System.Windows.Forms.Padding(4);
            this.addStudentBtn.Name = "addStudentBtn";
            this.addStudentBtn.Size = new System.Drawing.Size(172, 55);
            this.addStudentBtn.TabIndex = 2;
            this.addStudentBtn.Text = "Student";
            this.addStudentBtn.Click += new System.EventHandler(this.addStudentBtn_Click);
            // 
            // addAdministrationBtn
            // 
            this.addAdministrationBtn.BorderRadius = 2;
            this.addAdministrationBtn.BorderThickness = 1;
            this.addAdministrationBtn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.addAdministrationBtn.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(209)))), ((int)(((byte)(207)))));
            this.addAdministrationBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.addAdministrationBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.addAdministrationBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.addAdministrationBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.addAdministrationBtn.FillColor = System.Drawing.Color.White;
            this.addAdministrationBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addAdministrationBtn.ForeColor = System.Drawing.Color.Black;
            this.addAdministrationBtn.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(209)))), ((int)(((byte)(207)))));
            this.addAdministrationBtn.Location = new System.Drawing.Point(11, 98);
            this.addAdministrationBtn.Margin = new System.Windows.Forms.Padding(4);
            this.addAdministrationBtn.Name = "addAdministrationBtn";
            this.addAdministrationBtn.Size = new System.Drawing.Size(172, 55);
            this.addAdministrationBtn.TabIndex = 2;
            this.addAdministrationBtn.Text = "Administration";
            this.addAdministrationBtn.Click += new System.EventHandler(this.addAdministrationBtn_Click);
            // 
            // addTeachingStaffBtn
            // 
            this.addTeachingStaffBtn.BorderRadius = 2;
            this.addTeachingStaffBtn.BorderThickness = 1;
            this.addTeachingStaffBtn.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            this.addTeachingStaffBtn.Checked = true;
            this.addTeachingStaffBtn.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(209)))), ((int)(((byte)(207)))));
            this.addTeachingStaffBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.addTeachingStaffBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.addTeachingStaffBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.addTeachingStaffBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.addTeachingStaffBtn.FillColor = System.Drawing.Color.White;
            this.addTeachingStaffBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addTeachingStaffBtn.ForeColor = System.Drawing.Color.Black;
            this.addTeachingStaffBtn.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(209)))), ((int)(((byte)(207)))));
            this.addTeachingStaffBtn.Location = new System.Drawing.Point(11, 23);
            this.addTeachingStaffBtn.Margin = new System.Windows.Forms.Padding(4);
            this.addTeachingStaffBtn.Name = "addTeachingStaffBtn";
            this.addTeachingStaffBtn.Size = new System.Drawing.Size(172, 55);
            this.addTeachingStaffBtn.TabIndex = 2;
            this.addTeachingStaffBtn.Text = "Teaching Staff";
            this.addTeachingStaffBtn.Click += new System.EventHandler(this.addTeachingStaffBtn_Click);
            // 
            // panelContainer
            // 
            this.panelContainer.AutoScroll = true;
            this.panelContainer.BorderColor = System.Drawing.Color.Black;
            this.panelContainer.CustomBorderColor = System.Drawing.Color.Black;
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelContainer.Location = new System.Drawing.Point(203, 0);
            this.panelContainer.Margin = new System.Windows.Forms.Padding(4);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(573, 347);
            this.panelContainer.TabIndex = 2;
            // 
            // AddDataPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.panelContainer);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "AddDataPage";
            this.Size = new System.Drawing.Size(776, 347);
            this.guna2Panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Button addTeachingStaffBtn;
        private Guna.UI2.WinForms.Guna2Button addStudentBtn;
        private Guna.UI2.WinForms.Guna2Button addAdministrationBtn;
        private Guna.UI2.WinForms.Guna2Panel panelContainer;
    }
}
