using System.Data.OleDb;

namespace torresJasmine_Inventory_Management_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            btnIn.Click += btnIn_Click;
            linkUp.LinkClicked += linkUp_LinkClicked;
        }

        private async void btnIn_Click(object? sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPass.Text;

            if (string.IsNullOrWhiteSpace(username))
            {
                ShowMessage("Enter your username.");
                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                ShowMessage("Enter your password.");
                txtPass.Focus();
                return;
            }

            btnIn.Enabled = false;
            try
            {
                object? storedHash = await Database.ExecuteScalarAsync(
                    "SELECT [PasswordHash] FROM [Users] WHERE [Username] = ?",
                    new OleDbParameter { Value = username });

                if (storedHash is not string hash ||
                    !PasswordHelper.VerifyPassword(password, hash))
                {
                    ShowMessage("Invalid username or password.");
                    return;
                }

                MessageBox.Show(
                    "Login successful.",
                    "Login",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                txtPass.Clear();
            }
            catch (OleDbException)
            {
                ShowMessage("Login is temporarily unavailable. Check that the account database is accessible.");
            }
            catch (Exception)
            {
                ShowMessage("We could not complete the login. Please try again.");
            }
            finally
            {
                btnIn.Enabled = true;
            }
        }

        private void linkUp_LinkClicked(object? sender, LinkLabelLinkClickedEventArgs e)
        {
            Register register = new();
            register.FormClosed += (_, _) => Show();
            register.Show();
            Hide();
        }

        private void ShowMessage(string message)
        {
            MessageBox.Show(
                message,
                "Login",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
