using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clinic_WVSU_PC
{
    public partial class patientsList : Form

    {
        private readonly string username;

        private DataTable dataTable;
        public TextBox nameTextBox;

        private bool isSettingsButtonClicked = false;

        private Timer settingsButtonTimer = new Timer();


        private Timer consultationPanelTimer = new Timer();


        private Timer refreshTimer;




        private int cornerRadius = 10;

        public int CornerRadius
        {
            get { return cornerRadius; }
            set
            {
                cornerRadius = value;
                UpdateRegion();
            }
        }

        public patientsList(string username)

        {
            InitializeComponent();
            // Set up a timer to update the date and time labels every second TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME
            Timer timers = new Timer();
            timers.Interval = 1000; // Update every second
            timers.Tick += Timer_Ticker;
            
            timers.Start();


            refreshTimer = new Timer();
            refreshTimer.Interval = 5000; // Adjust interval as needed (in milliseconds)
            refreshTimer.Tick += RefreshDataGridView;
            refreshTimer.Start();


            settingsButtonTimer.Interval = 10; // You can adjust the interval for smoother/faster animation
            settingsButtonTimer.Tick += SettingsButtonTimer_Tick;

            // Save the username
            this.username = username;







            // Assuming username is "John Doe"
            string[] nameParts = username.Split(' ');


            if (nameParts.Length >= 2)
            {
                // Take the first letter of each part of the name and convert to uppercase
                string initials = string.Join("", nameParts.Select(part => char.ToUpper(part[0])));

                // Display the uppercase initials
                userIdLabel.Text = $"{initials}";
            }
            else
            {
                // Handle the case where there's only one part in the name
                userIdLabel.Text = $"{username.ToUpper()}";
            }
            // Handle the Load event of the form to load data into the DataGridView
            this.Load += userpage_Load;
            // Subscribe to the TextChanged event of textBox1 for search functionality
            userIdLabel.TextChanged += textBox1_TextChanged;

        }






        private void UpdateRegion()
        {
            using (GraphicsPath path = CreateRoundPath(0, 0, Width, Height, cornerRadius))
            {
                this.Region = new Region(path);
            }
        }

        private GraphicsPath CreateRoundPath(int x, int y, int width, int height, int radius)
        {
            GraphicsPath path = new GraphicsPath();

            path.AddArc(x, y, radius, radius, 180, 90);
            path.AddArc(width - radius, y, radius, radius, 270, 90);
            path.AddArc(width - radius, height - radius, radius, radius, 0, 90);
            path.AddArc(x, height - radius, radius, radius, 90, 90);

            path.CloseFigure();

            return path;
        }

        private void SettingsButtonTimer_Tick(object sender, EventArgs e)
        {
            // Move the buttons towards their target locations gradually
            if (isSettingsButtonClicked)
            {
                // Move the buttons to the new positions
                if (addButton.Top > 710)
                {
                    addButton.Top -= 15; // You can adjust the step size
                    editButton.Top -= 10;
                    deleteButton.Top -= 5;
                }
                else
                {
                    // Stop the animation when the buttons reach their target locations
                    settingsButtonTimer.Stop();
                }
            }
            
            else
            {
                // Move the buttons back to their original positions
                if (addButton.Top < 929)
                {
                    addButton.Top += 15; // You can adjust the step size
                    editButton.Top += 10;
                    deleteButton.Top += 5;
                }
                else
                {
                    // Stop the animation when the buttons reach their original positions
                    settingsButtonTimer.Stop();
                }
            }
        }












        private void Timer_Ticker(object sender, EventArgs e)
        {
            // Update dateLabel with the current date TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME
            dateLabel.Text = DateTime.Now.ToString("MMMM d, yyyy");

            // Update timeLabel with the current time
            timeLabel.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }




        private void userpage_Load(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Filter the DataTable based on the entered text in textBox1
            string searchText = textBox1.Text.Trim();

            if (!string.IsNullOrEmpty(searchText))
            {
                // Case-insensitive search in StudentID and StudentName columns with column existence check
                var filteredRows = dataTable.AsEnumerable()
                    .Where(row =>
                        (row.Table.Columns.Contains("PatientID") && row.Field<string>("PatientID")?.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0) ||
                        (row.Table.Columns.Contains("PatientName") && row.Field<string>("PatientName")?.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0)
                    );

                if (filteredRows.Any())
                {
                    // If there are matching rows, update the DataGridView
                    dataGridView1.DataSource = filteredRows.CopyToDataTable();
                }
                else
                {
                    // If no matching rows, clear the DataGridView or handle it as needed
                    dataGridView1.DataSource = null;
                }
            }
            else
            {
                // If the search text is empty, display the original DataTable
                dataGridView1.DataSource = dataTable;
            }
        }
        private void InitializeTimer()
        {
            refreshTimer = new Timer();
            refreshTimer.Interval = 5000; // Adjust interval as needed (in milliseconds)
            refreshTimer.Tick += RefreshDataGridView;
            refreshTimer.Start();
        }

        private void RefreshDataGridView(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();
        }

        private void LoadDataIntoDataGridView()
        {
            try
            {
                string connectionString = @"Data Source=database.db;Version=3;";
                // Initial SELECT query without WHERE clause
                string selectQuery = "SELECT * FROM patientinfo";

                // Build the WHERE clause based on selected filter values
                List<string> whereConditions = new List<string>();

                if (categoryCombobox.SelectedItem != null)
                    whereConditions.Add($"Category = '{categoryCombobox.SelectedItem}'");

                if (courseCombobox.SelectedItem != null)
                    whereConditions.Add($"Course = '{courseCombobox.SelectedItem}'");

                if (yearCombobox.SelectedItem != null)
                    whereConditions.Add($"Year = '{yearCombobox.SelectedItem}'");

                if (sectionCombobox.SelectedItem != null)
                    whereConditions.Add($"Section = '{sectionCombobox.SelectedItem}'");

                // Check if any conditions are added
                if (whereConditions.Count > 0)
                {
                    string whereClause = "WHERE " + string.Join(" AND ", whereConditions);
                    selectQuery += $" {whereClause}";
                }

                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    using (SQLiteCommand command = new SQLiteCommand(selectQuery, connection))
                    {
                        using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                        {
                            this.dataTable = new DataTable();
                            adapter.Fill(this.dataTable);

                            dataGridView1.DataSource = this.dataTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
            {
            addHistory patient = new addHistory(username);
            patient.CategoryTextBox = this.dataGridView1.CurrentRow.Cells[1].Value.ToString() ?? "";
            patient.NameTextBox = this.dataGridView1.CurrentRow.Cells[2].Value.ToString() ?? "";
            patient.DateTextBox = this.dataGridView1.CurrentRow.Cells[3].Value.ToString() ?? "";
            patient.SexTextBox = this.dataGridView1.CurrentRow.Cells[4].Value.ToString() ?? "";
            patient.CivilStatusTextBox = this.dataGridView1.CurrentRow.Cells[5].Value.ToString() ?? "";
            patient.AddressTextBox = this.dataGridView1.CurrentRow.Cells[6].Value.ToString() ?? "";
            patient.ParentTextBox = this.dataGridView1.CurrentRow.Cells[7].Value.ToString() ?? "";
            patient.CourseTextBox = this.dataGridView1.CurrentRow.Cells[8].Value.ToString() ?? "";
            patient.YearTextBox = this.dataGridView1.CurrentRow.Cells[9].Value.ToString() ?? "";
            patient.SectionTextBox = this.dataGridView1.CurrentRow.Cells[10].Value.ToString() ?? "";
            patient.ContactPersonTextBox = this.dataGridView1.CurrentRow.Cells[11].Value.ToString() ?? "";
            patient.PhoneTextBox = this.dataGridView1.CurrentRow.Cells[12].Value.ToString();




            patient.Show();

            }

        private void sectionCombobox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();
        }

        private void categoryCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();

            if (categoryCombobox.SelectedItem != null && categoryCombobox.SelectedItem.ToString() == "STUDENT")
            {

                // Make courseCombobox, yearCombobox, and sectionCombobox visible
                courseLabel.Visible = true;
                yearLabel.Visible = true;
                sectionLabel.Visible = true;
                courseCombobox.Visible = true;
                yearCombobox.Visible = true;
                sectionCombobox.Visible = true;
            }
            else
            {

                // Hide courseCombobox, yearCombobox, and sectionCombobox
                courseLabel.Visible = false;
                yearLabel.Visible = false;
                sectionLabel.Visible = false;
                courseCombobox.Visible = false;
                yearCombobox.Visible = false;
                sectionCombobox.Visible = false;
            }
        }

        private void courseCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();
        }

        private void yearCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            patientsList list = new patientsList(username);
            list.Show();
            this.Hide();
        }





        private void userIdLabel_Click(object sender, EventArgs e)
        {

        }

        private void patientsList_Load(object sender, EventArgs e)
        {

        }






















        private void settingsButton_Click(object sender, EventArgs e)
        {
            // Toggle the flag to track the state of the button click
            isSettingsButtonClicked = !isSettingsButtonClicked;

            // Start the animation to move buttons to their new or original positions
            settingsButtonTimer.Start();
        }








        private void label5_Click(object sender, EventArgs e)
        {

        }








        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

        private void consultationPanel_MouseEnter(object sender, EventArgs e)
        {
            // Start the animation when the mouse enters the panel
            consultationPanelTimer.Start();
        }











        private void consultationPanel_Click(object sender, EventArgs e)
        {
            OpenConsultationForm();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenConsultationForm();
        }
        private void OpenConsultationForm()
        {
            // Open the consultation form
            consultation consult = new consultation(username);
            consult.Show();
            this.Hide();
        }

    



        private void addButton_Click(object sender, EventArgs e)
        {
            addPatient addPatient = new addPatient(username);
            addPatient.Show();
        }

        private void editButton_Click(object sender, EventArgs e)
        {

        }

        private void deleteButton_Click(object sender, EventArgs e)
        {

        }

        private void logOutButton_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void refreshButton_Click_1(object sender, EventArgs e)
        {
            patientsList list = new patientsList(username);
            list.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            OpenConsultationForm();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {

        }

        private void consultationLogLabel_Click(object sender, EventArgs e)
        {
            consultation consult = new consultation(username);
            consult.Show();
            this.Hide();
        }
    }
}
