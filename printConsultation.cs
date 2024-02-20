using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing.Printing;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Globalization;
using System.Collections.Generic;

namespace Clinic_WVSU_PC
{
    public partial class printConsultation : Form
    {
        private DataTable dataTable;
        private FormBorderStyle previousFormBorderStyle;
        private bool previousPictureBoxVisibility;
        private bool previousYearVisibility;
        private bool previousMonthVisibility;


        public printConsultation()
        {
            InitializeComponent();
            PopulateYearComboBox();
            LoadDataIntoDataGridView();

        }

        private void PopulateYearComboBox()
        {
            int currentYear = DateTime.Now.Year;

            for (int year = 2023; year <= currentYear; year++)
            {
                yearDateComboBox.Items.Add(year.ToString());
            }

            yearDateComboBox.SelectedItem = currentYear.ToString();
        }


        private void LoadDataIntoDataGridView()
        {
            try
            {
                string connectionString = @"Data Source=database.db;Version=3;";
                string selectQuery = "SELECT * FROM consultation";

                // Build the WHERE clause based on selected filter values
                List<string> whereConditions = new List<string>();

                if (monthDateComboBox.SelectedItem != null && !string.IsNullOrWhiteSpace(monthDateComboBox.SelectedItem.ToString()))
                    whereConditions.Add($"monthdate = '{monthDateComboBox.SelectedItem}'");

                if (yearDateComboBox.SelectedItem != null && !string.IsNullOrWhiteSpace(yearDateComboBox.SelectedItem.ToString()))
                    whereConditions.Add($"yeardate = '{yearDateComboBox.SelectedItem}'");

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
                            DataTable dataTable = new DataTable(); // Create a new DataTable instead of reassigning the instance variable
                            adapter.Fill(dataTable); // Fill the new DataTable

                            consultationDataGridView.DataSource = dataTable; // Assign the new DataTable as the data source
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }










        private void printButton_Click(object sender, EventArgs e)
        {
            // Save the current state
            previousFormBorderStyle = this.FormBorderStyle;
            previousPictureBoxVisibility = printButton.Visible;
            previousYearVisibility = yearDateComboBox.Visible;
            previousMonthVisibility = monthDateComboBox.Visible;

            // Set the desired state for printing
            this.FormBorderStyle = FormBorderStyle.None;
            printButton.Visible = false;
            yearDateComboBox.Visible = false;
            monthDateComboBox.Visible = false;


            // Create a bitmap to hold the screenshot of the form
            Bitmap bitmap = new Bitmap(this.Width, this.Height);
            this.DrawToBitmap(bitmap, new Rectangle(0, 0, this.Width, this.Height));

            // Create a PrintDocument instance
            PrintDocument printDocument = new PrintDocument();

            // Handle the PrintPage event to define content to be printed
            printDocument.PrintPage += (s, ev) =>
            {
                // Print the captured image of the form
                ev.Graphics.DrawImage(bitmap, ev.PageBounds);
            };

            // Create PrintPreviewDialog instance
            using (PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog())
            {
                // Assign the print document to the print preview dialog
                printPreviewDialog.Document = printDocument;

                // Handle the PrintPreviewDialog's closing event
                printPreviewDialog.FormClosing += (sender1, args) =>
                {
                    // Restore the previous state after closing the print dialog
                    this.FormBorderStyle = previousFormBorderStyle;
                    printButton.Visible = previousPictureBoxVisibility;
                    yearDateComboBox.Visible = previousYearVisibility;
                    monthDateComboBox.Visible = previousMonthVisibility;
                };

                // Show the print preview dialog
                printPreviewDialog.ShowDialog();
            }
        }
    }
}
