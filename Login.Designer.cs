namespace torresJasmine_Inventory_Management_System
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            panel1 = new Panel();
            panel2 = new Panel();
            this.txtUsername = new MaskedTextBox();
            this.txtPass = new MaskedTextBox();
            labelUser = new Label();
            labelPass = new Label();
            this.btnIn = new Button();
            messLogin = new Label();
            linkUp = new LinkLabel();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            button2 = new Button();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            panel1.BackColor = Color.FromArgb(117, 74, 50);
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(263, 24);
            panel1.Name = "panel1";
            panel1.Size = new Size(373, 537);
            panel1.TabIndex = 0;
            panel2.BackColor = Color.FromArgb(252, 247, 243);
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(button2);
            panel2.Controls.Add(linkUp);
            panel2.Controls.Add(messLogin);
            panel2.Controls.Add(this.btnIn);
            panel2.Controls.Add(labelPass);
            panel2.Controls.Add(labelUser);
            panel2.Controls.Add(this.txtPass);
            panel2.Controls.Add(this.txtUsername);
            panel2.Controls.Add(label6);
            panel2.ForeColor = Color.FromArgb(110, 66, 42);
            panel2.Location = new Point(-1, 110);
            panel2.Name = "panel2";
            panel2.Size = new Size(373, 426);
            panel2.TabIndex = 0;
            panel2.Paint += panel2_Paint;
            this.txtUsername.BackColor = SystemColors.Info;
            this.txtUsername.Font = new Font("Segoe UI", 10F);
            this.txtUsername.Location = new Point(38, 158);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new Size(293, 34);
            this.txtUsername.TabIndex = 0;
            this.txtUsername.MaskInputRejected += this.maskedTextBox1_MaskInputRejected;
            this.txtPass.BackColor = SystemColors.Info;
            this.txtPass.Font = new Font("Segoe UI", 10F);
            this.txtPass.Location = new Point(38, 234);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new Size(293, 34);
            this.txtPass.TabIndex = 1;
            this.txtPass.PasswordChar = '●';
            labelUser.AutoSize = true;
            labelUser.Location = new Point(36, 129);
            labelUser.Name = "labelUser";
            labelUser.Size = new Size(91, 25);
            labelUser.TabIndex = 2;
            labelUser.Text = "Username";
            labelPass.AutoSize = true;
            labelPass.Location = new Point(36, 206);
            labelPass.Name = "labelPass";
            labelPass.Size = new Size(87, 25);
            labelPass.TabIndex = 3;
            labelPass.Text = "Password";
            this.btnIn.BackColor = Color.FromArgb(117, 74, 50);
            this.btnIn.FlatStyle = FlatStyle.Flat;
            this.btnIn.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.btnIn.ForeColor = Color.White;
            this.btnIn.Location = new Point(111, 301);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new Size(157, 47);
            this.btnIn.TabIndex = 4;
            this.btnIn.Text = "Sign In ⟶";
            this.btnIn.UseVisualStyleBackColor = false;
            messLogin.AutoSize = true;
            messLogin.Font = new Font("Segoe UI", 8F);
            messLogin.Location = new Point(70, 356);
            messLogin.Name = "messLogin";
            messLogin.Size = new Size(171, 21);
            messLogin.TabIndex = 5;
            messLogin.Text = "Don't have an account?";
            linkUp.AutoSize = true;
            linkUp.Font = new Font("Segoe UI", 8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            linkUp.LinkColor = Color.FromArgb(110, 66, 42);
            linkUp.Location = new Point(235, 356);
            linkUp.Name = "linkUp";
            linkUp.Size = new Size(70, 21);
            linkUp.TabIndex = 6;
            linkUp.TabStop = true;
            linkUp.Text = "Sign Up";
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F);
            label1.ForeColor = Color.FromArgb(244, 228, 214);
            label1.Location = new Point(296, 22);
            label1.Name = "label1";
            label1.Size = new Size(45, 48);
            label1.TabIndex = 7;
            label1.Text = "♡";
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F);
            label2.ForeColor = Color.FromArgb(244, 228, 214);
            label2.Location = new Point(16, 59);
            label2.Name = "label2";
            label2.Size = new Size(45, 48);
            label2.TabIndex = 8;
            label2.Text = "♡";
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ButtonFace;
            label3.Location = new Point(114, 36);
            label3.Name = "label3";
            label3.Size = new Size(137, 48);
            label3.TabIndex = 7;
            label3.Text = "Sign In";
            button2.FlatStyle = FlatStyle.Flat;
            button2.Location = new Point(67, 37);
            button2.Name = "button2";
            button2.Size = new Size(236, 34);
            button2.TabIndex = 7;
            button2.Text = "    Sign in with Google";
            button2.UseVisualStyleBackColor = true;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label4.Location = new Point(80, 40);
            label4.Name = "label4";
            label4.Size = new Size(26, 28);
            label4.TabIndex = 8;
            label4.Text = "G";
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 7F);
            label5.Location = new Point(173, 92);
            label5.Name = "label5";
            label5.Size = new Size(22, 19);
            label5.TabIndex = 9;
            label5.Text = "or";
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 7F);
            label6.Location = new Point(40, 92);
            label6.Name = "label6";
            label6.Size = new Size(289, 19);
            label6.TabIndex = 10;
            label6.Text = "━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━";
            label6.Click += label6_Click;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 228, 214);
            ClientSize = new Size(912, 586);
            Controls.Add(panel1);
            Name = "Form1";
            Text = "Login";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private MaskedTextBox txtUsername;
        private MaskedTextBox txtPass;
        private Label messLogin;
        private Button btnIn;
        private Label labelPass;
        private Label labelUser;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button button2;
        private LinkLabel linkUp;
        private Label label5;
        private Label label4;
        private Label label6;
    }
}
