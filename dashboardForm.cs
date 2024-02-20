using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Clinic_WVSU_PC
{
    public partial class dashboardForm : Form
    {
        private readonly string username;

        public dashboardForm(string username)
        {
            InitializeComponent();
            this.username = username;
            Timer timer = new Timer();
            timer.Interval = 1000; // Update every second
            timer.Tick += Timer_Tick;
            timer.Start();

        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Update dateLabel with the current date TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME
            yearComboBox.Text = DateTime.Now.ToString("yyyy");
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            patientsList list = new patientsList(username);
            list.Show();
            this.Hide();
        }

        private void categoryChart_Click(object sender, EventArgs e)
        {

        }



        private void dashboardForm_Load(object sender, EventArgs e)
        {

        }













        private void pictureBox3_Click(object sender, EventArgs e)
        {
            
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            // Ask the user if they want to logout or close the application
            DialogResult result = MessageBox.Show("Do you want to exit application?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


            // Check the user's choice
            if (result == DialogResult.Yes)
            {
                // Close the application
                Application.Exit();
            }
            else if (result == DialogResult.No)
            {
                
            }
            // If the user clicks Cancel, do nothing (exit the method)
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {

        }

        private void consultChart_Click(object sender, EventArgs e)
        {

        }

        private void logOutButton_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void minimizeButton_Click(object sender, EventArgs e)
        {
            // Minimize the form
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
