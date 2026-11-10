using System.Data.OleDb;
using System.Net.Mail;

namespace torresJasmine_Inventory_Management_System
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
            btnUp.Click += btnUp_Click;
            btnUp.Cursor = Cursors.Hand;
            linkIn.Cursor = Cursors.Hand;
            btnUp.BringToFront();
            linkIn.BringToFront();
        }

        private async void btnUp_Click(object? sender, EventArgs e)
        {
            string firstName = txtFname.Text.Trim();
            string lastName = txtLname.Text.Trim();
            string email = maskedTextBox2.Text.Trim();
            string username = txtUsername.Text.Trim();
            string password = maskedTextBox1.Text;

            if (string.IsNullOrWhiteSpace(firstName) ||
                string.IsNullOrWhiteSpace(lastName))
            {
                ShowMessage("Enter your first and last name.");
                return;
            }

            if (string.IsNullOrWhiteSpace(email))
            {
                ShowMessage("Enter your email address.");
                maskedTextBox2.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(username))
            {
                ShowMessage("Choose a username.");
                txtUsername.Focus();
                return;
            }

            if (username.Length < 3 || username.Length > 30 ||
                !username.All(c => char.IsLetterOrDigit(c) || c is '_' or '-' or '.'))
            {
                ShowMessage("Username must be 3–30 characters and use only letters, numbers, '.', '_' or '-'.");
                txtUsername.Focus();
                return;
            }

            if (!MailAddress.TryCreate(email, out _))
            {
                ShowMessage("Please enter a valid email address.");
                return;
            }

            if (password != maskedTextBox3.Text)
            {
                ShowMessage("The passwords do not match.");
                return;
            }

            btnUp.Enabled = false;
            try
            {
                object? existingUser = await Database.ExecuteScalarAsync(
                    "SELECT COUNT(*) FROM [Users] WHERE [Username] = ? OR [Email] = ?",
                    new OleDbParameter { Value = username },
                    new OleDbParameter { Value = email });

                if (Convert.ToInt32(existingUser) > 0)
                {
                    ShowMessage("That username or email is already registered.");
                    return;
                }

                await Database.ExecuteNonQueryAsync(
                    "INSERT INTO [Users] ([FirstName], [LastName], [Email], [Username], [PasswordHash]) VALUES (?, ?, ?, ?, ?)",
                    new OleDbParameter { Value = firstName },
                    new OleDbParameter { Value = lastName },
                    new OleDbParameter { Value = email },
                    new OleDbParameter { Value = username },
                    new OleDbParameter { Value = PasswordHelper.HashPassword(password) });

                MessageBox.Show(
                    $"Your account was created successfully and saved to:{Environment.NewLine}{Database.CurrentDatabasePath}",
                    "Registration complete",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                Form1 login = new();
                login.FormClosed += (_, _) => Close();
                login.Show();
                Hide();
            }
            catch (OleDbException ex)
            {
                ShowMessage(ex.Message.Contains("duplicate", StringComparison.OrdinalIgnoreCase)
                    ? "That username or email is already registered."
                    : "Unable to save the account. Check that the database is accessible and try again.");
            }
            catch (Exception)
            {
                ShowMessage("We could not create the account. Please try again.");
            }
            finally
            {
                btnUp.Enabled = true;
            }
        }

        private void ShowMessage(string message)
        {
            MessageBox.Show(
                message,
                "Registration",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 login = new();
            login.FormClosed += (_, _) => Close();
            login.Show();
            Hide();
        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void labelFname_Click(object sender, EventArgs e)
        {

        }

        private void labelLname_Click(object sender, EventArgs e)
        {

        }

        private void txtFname_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void labelEmail_Click(object sender, EventArgs e)
        {

        }
    }
}
