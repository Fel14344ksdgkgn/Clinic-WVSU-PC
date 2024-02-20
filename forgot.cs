using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clinic_WVSU_PC
{
    public partial class forgot : Form
    {
        public forgot()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Retrieve input from textboxes
            string firstname = firstnameTextBox.Text;
            string lastname = lastnameTextBox.Text;
            string newPassword = newPasswordTextBox.Text;

            string connectionString = @"Data Source=..\..\database\clinicdb.db;Version=3;";
            // Query to validate user
            string query = "SELECT * FROM Users WHERE firstname = @firstname AND Lastname = @lastname";

            // Execute the query to check if the user exists
            using (var connection = new SQLiteConnection(connectionString))
            using (var command = new SQLiteCommand(query, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@firstname", firstname);
                command.Parameters.AddWithValue("@lastname", lastname);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read()) // User exists
                    {
                        // Hash the new password
                        string hashedPassword = HashPassword(newPassword);

                        // Update the password in the database
                        string updateQuery = "UPDATE Users SET Password = @password WHERE Firstname = @firstname AND Lastname = @lastname";

                        using (var updateCommand = new SQLiteCommand(updateQuery, connection))
                        {
                            updateCommand.Parameters.AddWithValue("@password", hashedPassword);
                            updateCommand.Parameters.AddWithValue("@firstname", firstname);
                            updateCommand.Parameters.AddWithValue("@lastname", lastname);

                            int rowsAffected = updateCommand.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Password updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Failed to update password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or lastname.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private string HashPassword(string password)
        {
            // Implement password hashing (e.g., using SHA-256)
            // Replace this with a proper password hashing algorithm
            // Do not store passwords as plain text in the database
            // Consider using a library like BCrypt, Argon2, or PBKDF2
            // For demonstration purposes, a simple example is shown here
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }

    }
}
