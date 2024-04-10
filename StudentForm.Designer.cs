namespace Desktop_Information_System
{
    partial class StudentForm
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
            this.submitBtn = new Guna.UI2.WinForms.Guna2Button();
            this.emailInput = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.telephoneInput = new Guna.UI2.WinForms.Guna2TextBox();
            this.telephoneLabel = new System.Windows.Forms.Label();
            this.nameInput = new Guna.UI2.WinForms.Guna2TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.currentSubject2Input = new Guna.UI2.WinForms.Guna2TextBox();
            this.currentSubject1Input = new Guna.UI2.WinForms.Guna2TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.previousSubject1Input = new Guna.UI2.WinForms.Guna2TextBox();
            this.previousSubject2Input = new Guna.UI2.WinForms.Guna2TextBox();
            this.SuspendLayout();
            // 
            // submitBtn
            // 
            this.submitBtn.BorderRadius = 2;
            this.submitBtn.BorderThickness = 1;
            this.submitBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.submitBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.submitBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.submitBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.submitBtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(209)))), ((int)(((byte)(207)))));
            this.submitBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submitBtn.ForeColor = System.Drawing.Color.Black;
            this.submitBtn.Location = new System.Drawing.Point(12, 477);
            this.submitBtn.Margin = new System.Windows.Forms.Padding(3, 3, 3, 20);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(386, 45);
            this.submitBtn.TabIndex = 27;
            this.submitBtn.Text = "Submit";
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // emailInput
            // 
            this.emailInput.BackColor = System.Drawing.Color.Transparent;
            this.emailInput.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(209)))), ((int)(((byte)(207)))));
            this.emailInput.BorderRadius = 2;
            this.emailInput.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.emailInput.DefaultText = "";
            this.emailInput.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.emailInput.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.emailInput.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.emailInput.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.emailInput.FocusedState.BorderColor = System.Drawing.Color.Black;
            this.emailInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailInput.ForeColor = System.Drawing.Color.Black;
            this.emailInput.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.emailInput.Location = new System.Drawing.Point(15, 185);
            this.emailInput.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.emailInput.Name = "emailInput";
            this.emailInput.PasswordChar = '\0';
            this.emailInput.PlaceholderText = "";
            this.emailInput.SelectedText = "";
            this.emailInput.Size = new System.Drawing.Size(386, 38);
            this.emailInput.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(136)))), ((int)(((byte)(149)))));
            this.label3.Location = new System.Drawing.Point(12, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 20);
            this.label3.TabIndex = 19;
            this.label3.Text = "Email:";
            // 
            // telephoneInput
            // 
            this.telephoneInput.BackColor = System.Drawing.Color.Transparent;
            this.telephoneInput.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(209)))), ((int)(((byte)(207)))));
            this.telephoneInput.BorderRadius = 2;
            this.telephoneInput.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.telephoneInput.DefaultText = "";
            this.telephoneInput.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.telephoneInput.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.telephoneInput.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.telephoneInput.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.telephoneInput.FocusedState.BorderColor = System.Drawing.Color.Black;
            this.telephoneInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.telephoneInput.ForeColor = System.Drawing.Color.Black;
            this.telephoneInput.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.telephoneInput.Location = new System.Drawing.Point(15, 113);
            this.telephoneInput.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.telephoneInput.Name = "telephoneInput";
            this.telephoneInput.PasswordChar = '\0';
            this.telephoneInput.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.telephoneInput.PlaceholderText = "e.g. (+84) 987-123-456";
            this.telephoneInput.SelectedText = "";
            this.telephoneInput.Size = new System.Drawing.Size(386, 38);
            this.telephoneInput.TabIndex = 25;
            // 
            // telephoneLabel
            // 
            this.telephoneLabel.AutoSize = true;
            this.telephoneLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.telephoneLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(136)))), ((int)(((byte)(149)))));
            this.telephoneLabel.Location = new System.Drawing.Point(12, 89);
            this.telephoneLabel.Name = "telephoneLabel";
            this.telephoneLabel.Size = new System.Drawing.Size(88, 20);
            this.telephoneLabel.TabIndex = 20;
            this.telephoneLabel.Text = "Telephone:";
            // 
            // nameInput
            // 
            this.nameInput.BackColor = System.Drawing.Color.Transparent;
            this.nameInput.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(209)))), ((int)(((byte)(207)))));
            this.nameInput.BorderRadius = 2;
            this.nameInput.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.nameInput.DefaultText = "";
            this.nameInput.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.nameInput.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.nameInput.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.nameInput.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.nameInput.FocusedState.BorderColor = System.Drawing.Color.Black;
            this.nameInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameInput.ForeColor = System.Drawing.Color.Black;
            this.nameInput.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.nameInput.Location = new System.Drawing.Point(15, 39);
            this.nameInput.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.nameInput.Name = "nameInput";
            this.nameInput.PasswordChar = '\0';
            this.nameInput.PlaceholderText = "";
            this.nameInput.SelectedText = "";
            this.nameInput.Size = new System.Drawing.Size(386, 38);
            this.nameInput.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(136)))), ((int)(((byte)(149)))));
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 20);
            this.label1.TabIndex = 21;
            this.label1.Text = "Full Name:";
            // 
            // currentSubject2Input
            // 
            this.currentSubject2Input.BackColor = System.Drawing.Color.Transparent;
            this.currentSubject2Input.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(209)))), ((int)(((byte)(207)))));
            this.currentSubject2Input.BorderRadius = 2;
            this.currentSubject2Input.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.currentSubject2Input.DefaultText = "";
            this.currentSubject2Input.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.currentSubject2Input.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.currentSubject2Input.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.currentSubject2Input.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.currentSubject2Input.FocusedState.BorderColor = System.Drawing.Color.Black;
            this.currentSubject2Input.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentSubject2Input.ForeColor = System.Drawing.Color.Black;
            this.currentSubject2Input.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.currentSubject2Input.Location = new System.Drawing.Point(14, 303);
            this.currentSubject2Input.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.currentSubject2Input.Name = "currentSubject2Input";
            this.currentSubject2Input.PasswordChar = '\0';
            this.currentSubject2Input.PlaceholderText = "";
            this.currentSubject2Input.SelectedText = "";
            this.currentSubject2Input.Size = new System.Drawing.Size(385, 38);
            this.currentSubject2Input.TabIndex = 30;
            // 
            // currentSubject1Input
            // 
            this.currentSubject1Input.BackColor = System.Drawing.Color.Transparent;
            this.currentSubject1Input.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(209)))), ((int)(((byte)(207)))));
            this.currentSubject1Input.BorderRadius = 2;
            this.currentSubject1Input.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.currentSubject1Input.DefaultText = "";
            this.currentSubject1Input.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.currentSubject1Input.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.currentSubject1Input.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.currentSubject1Input.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.currentSubject1Input.FocusedState.BorderColor = System.Drawing.Color.Black;
            this.currentSubject1Input.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentSubject1Input.ForeColor = System.Drawing.Color.Black;
            this.currentSubject1Input.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.currentSubject1Input.Location = new System.Drawing.Point(16, 257);
            this.currentSubject1Input.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.currentSubject1Input.Name = "currentSubject1Input";
            this.currentSubject1Input.PasswordChar = '\0';
            this.currentSubject1Input.PlaceholderText = "";
            this.currentSubject1Input.SelectedText = "";
            this.currentSubject1Input.Size = new System.Drawing.Size(384, 38);
            this.currentSubject1Input.TabIndex = 29;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(136)))), ((int)(((byte)(149)))));
            this.label4.Location = new System.Drawing.Point(13, 232);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 20);
            this.label4.TabIndex = 28;
            this.label4.Text = "Current Subjects:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(136)))), ((int)(((byte)(149)))));
            this.label2.Location = new System.Drawing.Point(12, 350);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 20);
            this.label2.TabIndex = 28;
            this.label2.Text = "Previous Subjects:";
            // 
            // previousSubject1Input
            // 
            this.previousSubject1Input.BackColor = System.Drawing.Color.Transparent;
            this.previousSubject1Input.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(209)))), ((int)(((byte)(207)))));
            this.previousSubject1Input.BorderRadius = 2;
            this.previousSubject1Input.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.previousSubject1Input.DefaultText = "";
            this.previousSubject1Input.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.previousSubject1Input.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.previousSubject1Input.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.previousSubject1Input.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.previousSubject1Input.FocusedState.BorderColor = System.Drawing.Color.Black;
            this.previousSubject1Input.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.previousSubject1Input.ForeColor = System.Drawing.Color.Black;
            this.previousSubject1Input.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.previousSubject1Input.Location = new System.Drawing.Point(15, 375);
            this.previousSubject1Input.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.previousSubject1Input.Name = "previousSubject1Input";
            this.previousSubject1Input.PasswordChar = '\0';
            this.previousSubject1Input.PlaceholderText = "";
            this.previousSubject1Input.SelectedText = "";
            this.previousSubject1Input.Size = new System.Drawing.Size(384, 38);
            this.previousSubject1Input.TabIndex = 29;
            // 
            // previousSubject2Input
            // 
            this.previousSubject2Input.BackColor = System.Drawing.Color.Transparent;
            this.previousSubject2Input.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(209)))), ((int)(((byte)(207)))));
            this.previousSubject2Input.BorderRadius = 2;
            this.previousSubject2Input.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.previousSubject2Input.DefaultText = "";
            this.previousSubject2Input.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.previousSubject2Input.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.previousSubject2Input.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.previousSubject2Input.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.previousSubject2Input.FocusedState.BorderColor = System.Drawing.Color.Black;
            this.previousSubject2Input.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.previousSubject2Input.ForeColor = System.Drawing.Color.Black;
            this.previousSubject2Input.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.previousSubject2Input.Location = new System.Drawing.Point(13, 421);
            this.previousSubject2Input.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.previousSubject2Input.Name = "previousSubject2Input";
            this.previousSubject2Input.PasswordChar = '\0';
            this.previousSubject2Input.PlaceholderText = "";
            this.previousSubject2Input.SelectedText = "";
            this.previousSubject2Input.Size = new System.Drawing.Size(385, 38);
            this.previousSubject2Input.TabIndex = 30;
            // 
            // StudentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.Controls.Add(this.previousSubject2Input);
            this.Controls.Add(this.currentSubject2Input);
            this.Controls.Add(this.previousSubject1Input);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.currentSubject1Input);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.submitBtn);
            this.Controls.Add(this.emailInput);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.telephoneInput);
            this.Controls.Add(this.telephoneLabel);
            this.Controls.Add(this.nameInput);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "StudentForm";
            this.Size = new System.Drawing.Size(430, 630);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2Button submitBtn;
        private Guna.UI2.WinForms.Guna2TextBox emailInput;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2TextBox telephoneInput;
        private System.Windows.Forms.Label telephoneLabel;
        private Guna.UI2.WinForms.Guna2TextBox nameInput;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox currentSubject2Input;
        private Guna.UI2.WinForms.Guna2TextBox currentSubject1Input;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2TextBox previousSubject1Input;
        private Guna.UI2.WinForms.Guna2TextBox previousSubject2Input;
    }
}
