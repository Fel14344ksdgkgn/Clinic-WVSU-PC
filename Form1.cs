using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Net.PeerToPeer;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Clinic_WVSU_PC
{
    public partial class Form1 : Form
    {
        private string databaseFilePath;
        public Form1()
        {
            InitializeComponent();
            this.AcceptButton = button1;
            // Get the directory where the application executable is located
            string appDirectory = Path.GetDirectoryName(Application.ExecutablePath);

            // Combine the application directory with the database file name
            databaseFilePath = Path.Combine(appDirectory, "database.db");
            CreateTables();
        }


        private void CreateTables()
        {
            // SQL commands to create tables
            string[] createTableCommands = new string[]
            {
                @"CREATE TABLE IF NOT EXISTS users (
                    userid TEXT NOT NULL UNIQUE,
                    username TEXT NOT NULL,
                    password TEXT NOT NULL,
                    firstname TEXT,
                    lastname TEXT,
                    CONSTRAINT PK_users PRIMARY KEY(userid)
                )",

                @"CREATE TABLE IF NOT EXISTS patientinfo (
                    patientid INTEGER PRIMARY KEY AUTOINCREMENT,
                    category TEXT NOT NULL UNIQUE,
                    name TEXT NOT NULL,
                    dob TEXT NOT NULL,
                    age TEXT NOT NULL,
                    sex TEXT NOT NULL,
                    civilstatus TEXT NOT NULL,
                    pgname TEXT NOT NULL,
                    phone TEXT NOT NULL,
                    course TEXT NOT NULL,
                    year TEXT NOT NULL,
                    section TEXT NOT NULL,
                    contactperson TEXT
                )",

                @"CREATE TABLE IF NOT EXISTS medicalhistory (
                    medicalhistoryid INTEGER PRIMARY KEY AUTOINCREMENT,
                    name TEXT NOT NULL,
                    recentillness TEXT NOT NULL,
                    recentmedications TEXT NOT NULL,
                    hospitalization TEXT NOT NULL,
                    surgery TEXT NOT NULL,
                    allergy TEXT NOT NULL,
                    immunization TEXT NOT NULL,
                    illnessinthefamily TEXT NOT NULL,
                    ageofonset TEXT,
                    dateoflastmenses TEXT
                )",

                @"CREATE TABLE IF NOT EXISTS physicalexamination (
                    physicalexaminationid INTEGER PRIMARY KEY AUTOINCREMENT,
                    name TEXT NOT NULL,
                    bp TEXT NOT NULL,
                    t TEXT NOT NULL,
                    pr TEXT NOT NULL,
                    rr TEXT NOT NULL,
                    ht TEXT NOT NULL,
                    wt TEXT NOT NULL,
                    od TEXT NOT NULL,
                    os TEXT NOT NULL,
                    correctedod TEXT NOT NULL,
                    correctedos TEXT NOT NULL,
                    generalappearance TEXT NOT NULL,
                    skin TEXT NOT NULL,
                    headandneck TEXT NOT NULL,
                    lungs TEXT NOT NULL,
                    breast TEXT NOT NULL,
                    heart TEXT NOT NULL,
                    abdomen TEXT NOT NULL,
                    backandspine TEXT NOT NULL,
                    genitals TEXT NOT NULL,
                    rectum TEXT NOT NULL,
                    extremities TEXT NOT NULL,
                    neuro TEXT NOT NULL,
                    remarks TEXT
                )"
            };

            // Create connection and execute SQL commands
            using (SQLiteConnection connection = new SQLiteConnection("Data Source=" + databaseFilePath))
            {
                connection.Open();
                foreach (string commandText in createTableCommands)
                {
                    using (SQLiteCommand command = new SQLiteCommand(commandText, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
        }
    

    private void button1_Click(object sender, EventArgs e)
        {
            /* if (ValidateChildren(ValidationConstraints.Enabled))
            {
                try
                {
                    string connectionString = @"Data Source=clinicdb.db;Version=3;";

                    string searchQuery = "SELECT * FROM users WHERE username = @username AND password = @password";

                    using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                    {
                        connection.Open();

                        using (SQLiteCommand command = new SQLiteCommand(searchQuery, connection))
                        {
                            // Bind parameters
                            command.Parameters.AddWithValue("@username", userNameTextBox.Text);
                            command.Parameters.AddWithValue("@password", HashPassword(passwordTextBox.Text)); // Assuming plain text for this example

                            using (SQLiteDataReader reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {


                                    string username = userNameTextBox.Text;
                                
                                    // Open the userpage form
                                    dashboardForm dashboard = new dashboardForm(username);
                                    dashboard.Show();
                                    this.Hide();
                                }
                                else
                                {
                                    // User not found
                                    MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }*/
            string username = "hello world";
            dashboardForm dashboard = new dashboardForm(username);
            dashboard.Show();
            this.Hide();
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









        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void passwordTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(passwordTextBox.Text))
            {
                e.Cancel = true;
                userNameTextBox.Focus();
                errorProvider.SetError(passwordTextBox, "Please enter your password ");

            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(passwordTextBox, null);
            }
        }

        private void userNameTextbox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(userNameTextBox.Text))
            {
                e.Cancel = true;
                userNameTextBox.Focus();
                errorProvider.SetError(userNameTextBox, "Please enter your user name ");

            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(userNameTextBox, null);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            forgot frgt = new forgot();
            frgt.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {


        }
        private void PrintPage(object sender, PrintPageEventArgs e)
        {

        }
    }
}