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
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing.Drawing2D;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using System.Drawing.Printing;



namespace Clinic_WVSU_PC
{
    public partial class consultation : Form
    {
        private DataTable dataTable;
        private readonly string username;
        private Timer patientPanelTimer = new Timer();



        private PrintDocument printDocument;
        private DataGridViewPrinter dataGridViewPrinter;
        private PrintPreviewDialog printPreviewDialog;


        public consultation(string username)
        {


            InitializeComponent();
            LoadDataIntoDataGridView();
            LoadDataIntoChart();
            // Set up a timer to update the date and time labels every second TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME
            Timer timers = new Timer();
            timers.Interval = 1000; // Update every second
            timers.Tick += Timer_Ticker;
            timers.Start();
















            // Save the username
            this.username = username;

            usernameLabel.Text = username;
        }
        private void Timer_Ticker(object sender, EventArgs e)
        {
            // Update dateLabel with the current date TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME
            dateLabel.Text = DateTime.Now.ToString("MMMM d, yyyy");

            // Update timeLabel with the current time
            timeLabel.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }


        public bool DrawDataGridView(Graphics graphics)
        {
            // Your printing logic here
            return true; // Return true if printing is successful, false otherwise
        }


        private void refreshButton_Click(object sender, EventArgs e)
        {
            consultation consult = new consultation(username);
            consult.Show();
            this.Hide();
        }


        private void LoadDataIntoChart()
        {
            // Connection string for SQLite
            string connectionString = @"Data Source=database.db;Version=3;";

            // SQL query
            string query = "SELECT complaints, COUNT(*) AS count FROM consultation GROUP BY complaints";

            // Create a SQLiteConnection object
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                // Create a SQLiteCommand object
                SQLiteCommand command = new SQLiteCommand(query, connection);

                // Open the connection
                connection.Open();

                // Create a SQLiteDataReader object to read data
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    // Clear existing data in the chart
                    complaintsChart.Series.Clear();

                    // Add a series to the chart
                    Series series = complaintsChart.Series.Add("Complaints");
                    // Set the chart type to Pie
                    series.ChartType = SeriesChartType.Pie;

                    // Loop through the result set and add data points to the series
                    while (reader.Read())
                    {
                        string complaint = reader["complaints"].ToString();
                        int count = Convert.ToInt32(reader["count"]);

                        // Add data point to the series
                        series.Points.AddXY(complaint, count);
                        // Add formatted string to ListBox
                        complaintsListBox.Items.Add($"{complaint}: {count}");
                    }

                }
            }

            // Set chart title
            complaintsChart.Titles.Add("Complaints Chart");
        }
        private void LoadDataIntoDataGridView()
        {
            try
            {
                string connectionString = @"Data Source=database.db;Version=3;";
                // Initial SELECT query without WHERE clause
                string selectQuery = "SELECT * FROM consultation";


                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    using (SQLiteCommand command = new SQLiteCommand(selectQuery, connection))
                    {
                        using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                        {
                            this.dataTable = new DataTable();
                            adapter.Fill(this.dataTable);

                            consultationDataGridView.DataSource = this.dataTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void patientInfoLabel_Click(object sender, EventArgs e)
        {
            OpenPatientList();
        }

        private void patientsInfoButton_Click(object sender, EventArgs e)
        {
            OpenPatientList();
        }

        private void OpenPatientList()
        {
            // Open the consultation form
            patientsList list = new patientsList(username);
            list.Show();
            this.Hide();
        }

        private void consultationPanel_Click(object sender, EventArgs e)
        {
            OpenPatientList();
        }

        private void logOutButton_Click(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void consultation_Load(object sender, EventArgs e)
        {

        }
    






        private void patientPanel_MouseEnter(object sender, EventArgs e)
        {
            // Start the animation when the mouse enters the panel
            patientPanelTimer.Start();
        }

        private void complaintsChart_Click(object sender, EventArgs e)
        {

        }

        private void closeButton_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {

        }

        private void printButton_Click(object sender, EventArgs e)
        {
            printConsultation print = new printConsultation();
            print.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            patientsList list = new patientsList(username);
            list.Show();
            this.Hide();
        }
    }
}
