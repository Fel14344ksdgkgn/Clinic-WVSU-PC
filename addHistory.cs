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
    public partial class addHistory : Form
    {
        private readonly string username;
        public addHistory(string username)
        {
            InitializeComponent();
            Load += addHistory_Load;
            this.username = username;


            // You can use a Timer to update the age regularly
            Timer timer = new Timer();
            timer.Interval = 1000; // Update every second
            timer.Tick += Timer_Tick;
            timer.Start();

        }



        private void Timer_Tick(object sender, EventArgs e)
        {

            // Update dateLabel with the current date TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME TIME
            dateTextBox.Text = DateTime.Now.ToString("MMMM d, yyyy");

            monthDateTextBox.Text = DateTime.Now.ToString("MMMM yyyy");

            // Update timeLabel with the current time
            timeTextBox.Text = DateTime.Now.ToString("hh:mm:ss tt");
            InitializeCheckBox();

            // Calculate and update the ageTextBox
            if (DateTime.TryParse(dobTextBox.Text, out DateTime birthdate))
            {
                int age = CalculateAge(birthdate, DateTime.Now);
                ageTextBox.Text = age.ToString();
            }
        }



        private int CalculateAge(DateTime birthdate, DateTime currentDate)
        {
            int age = currentDate.Year - birthdate.Year;
            if (currentDate.Month < birthdate.Month || (currentDate.Month == birthdate.Month && currentDate.Day < birthdate.Day))
            {
                age--;
            }
            return age;
        }








        public string CategoryTextBox
        {
            get { return categoryTextBox.Text; }
            set { categoryTextBox.Text = value; }

        }




        
        public string DateTextBox
        {
            get { return dobTextBox.Text; }
            set { dobTextBox.Text = value; }
        }

        public string SexTextBox
        {
            get { return sexTextBox.Text; }
            set
            {
                { sexTextBox.Text = value; }
                if (SexTextBox.Equals("M"))
                {
                    femaleLabel.Visible = false;
                    femaleAgeLabel.Visible = false;
                    femaleDateLabel.Visible = false;
                    ageOfsetTextBox.Visible = false;
                    lastMensDateTimePicker.Visible = false;

                }
            }
        }


        public string CivilStatusTextBox
        {
            get { return civilStatusTextBox.Text; }
            set { civilStatusTextBox.Text = value; }
        }



        public string AddressTextBox
        {
            get { return addressTextBox.Text; }
            set { addressTextBox.Text = value; }
        }




        public string NameTextBox
        {
            get { return nameTextBox.Text; }
            set
            {
                { nameTextBox.Text = value; }
                try
                {
                    // Get the name from the nameTextBox
                    string name = nameTextBox.Text;

                    // SQL query to retrieve medical history for the given name
                    string getMedicalHistoryQuery = "SELECT recentillness, recentmedications, hospitalization, surgery, allergy, immunization, illnessinthefamily, ageofonset, dateoflastmenses " +
                                         "FROM medicalhistory WHERE name = @name";

                    // SQL query to retrieve medical history for the given name
                    string getPhysicalExaminationQuery = "SELECT bp, t, pr, rr, ht, wt, od, os, correctedod, correctedos, generalappearance, skin, headandneck, lungs, breast, heart, abdomen, backandspine, genitals, rectum, extremities, neuro, remarks " +
                                         "FROM physicalexamination WHERE name = @name";
                    // Connection string
                    string connectionString = @"Data Source=database.db;Version=3;";

                    // Create and open connection
                    using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                    {
                        connection.Open();

                        // Create command with parameters
                        using (SQLiteCommand command = new SQLiteCommand(getMedicalHistoryQuery, connection))
                        {
                            command.Parameters.AddWithValue("@name", name);

                            // Execute reader query to get medical history for the given name
                            using (SQLiteDataReader reader = command.ExecuteReader())
                            {
                                // Check if any rows are returned
                                if (reader.Read())
                                {
                                    // Populate text boxes with medical history values
                                    recentIllnessTextBox.Text = reader["recentillness"].ToString();
                                    recentMedicationTextBox.Text = reader["recentmedications"].ToString();
                                    hospitalizationTextBox.Text = reader["hospitalization"].ToString();
                                    surgeryTextBox.Text = reader["surgery"].ToString();
                                    allergyTextBox.Text = reader["allergy"].ToString();
                                    immunizationTextBox.Text = reader["immunization"].ToString();
                                    illnessInTheFamilyTextBox.Text = reader["illnessinthefamily"].ToString();
                                    ageOfsetTextBox.Text = reader["ageofonset"].ToString();
                                    lastMensDateTimePicker.Value = DateTime.Parse(reader["dateoflastmenses"].ToString());
                                }
                                else
                                {
                                    // No matching record found
                                    MessageBox.Show("No medical history found for the given name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                        using (SQLiteCommand command = new SQLiteCommand(getPhysicalExaminationQuery, connection))
                        {
                            command.Parameters.AddWithValue("@name", name);

                            // Execute reader query to get medical history for the given name
                            using (SQLiteDataReader reader = command.ExecuteReader())
                            {
                                // Check if any rows are returned
                                if (reader.Read())
                                {
                                    // Populate text boxes with medical history values
                                    bpTextBox.Text = reader["bp"].ToString();
                                    tempTextBox.Text = reader["t"].ToString();
                                    prTextBox.Text = reader["pr"].ToString();
                                    rrTextBox.Text = reader["rr"].ToString();
                                    htTextBox.Text = reader["ht"].ToString();
                                    wtTextBox.Text = reader["wt"].ToString();
                                    odTextBox.Text = reader["od"].ToString();
                                    osTextBox.Text = reader["os"].ToString();
                                    correctedOdTextBox.Text = reader["correctedod"].ToString();
                                    correctedOsTextBox.Text = reader["correctedos"].ToString();
                                    genAppearanceTextBox.Text = reader["generalappearance"].ToString();
                                    skinTextBox.Text = reader["skin"].ToString();
                                    headNeckTextBox.Text = reader["headandneck"].ToString();
                                    lungsTextBox.Text = reader["lungs"].ToString();
                                    breastTextBox.Text = reader["breast"].ToString();
                                    heartTextBox.Text = reader["heart"].ToString();
                                    abdomenTextBox.Text = reader["abdomen"].ToString();
                                    backSpineTextBox.Text = reader["backandspine"].ToString();
                                    genitalsTextBox.Text = reader["genitals"].ToString();
                                    rectumTextBox.Text = reader["rectum"].ToString();
                                    extremitiesTextBox.Text = reader["extremities"].ToString();
                                    neuroTextBox.Text = reader["neuro"].ToString();
                                    remarksTextBox.Text = reader["remarks"].ToString();

                                    ;
                                }
                                else
                                {
                                    // No matching record found
                                    MessageBox.Show("No medical history found for the given name.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        public string CourseTextBox
        {
            get { return courseTextBox.Text; }
            set
            {
                { courseTextBox.Text = value; }
                if (CategoryTextBox.Equals("STUDENT"))
                {
                    courseLabel.Visible = true;
                    courseTextBox.Visible = true;
                    yearTextBox.Visible = true;
                    sectionTextBox.Visible = true;

                    string designation = "wala sulod";
                    if (CourseTextBox.Equals("BSINFOTECH") || CourseTextBox.Equals("BSIS"))
                    {
                        designation = "SOICT";
                    }
                    else if (CourseTextBox.Equals("BEED") || CourseTextBox.Equals("BSED") || CourseTextBox.Equals("BTVTED"))
                    {
                        designation = "SOED";
                    }
                    else if (CourseTextBox.Equals("BSHM"))
                    {
                        designation = "SOBM";
                    }
                    else if (CourseTextBox.Equals("BSIT"))
                    {
                        designation = "SOIT";
                    }
                    designationTextBox.Text = designation;
                }
            }
        }


        public string YearTextBox
        {
            get { return yearTextBox.Text; }
            set { yearTextBox.Text = value; }
        }


        public string SectionTextBox
        {
            get { return sectionTextBox.Text; }
            set { sectionTextBox.Text = value; }
        }


        public string ParentTextBox
        {
            get { return pgTextBox.Text; }
            set { pgTextBox.Text = value; }
        }


        public string ContactPersonTextBox
        {
            get { return contactNameTextBox.Text; }
            set { contactNameTextBox.Text = value; }
        }

        public string PhoneTextBox
        {
            get { return phoneTextBox.Text; }
            set { phoneTextBox.Text = value; }
        }








        private void label7_Click(object sender, EventArgs e)
        {

        }










        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void addHistory_Load(object sender, EventArgs e)
        {
             
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            patientsList list = new patientsList(username);
            list.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void dobTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void timeTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void complaintsTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void monthTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void diagnosisTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void civilStatComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
 

            try
            {
                // Retrieve values from textboxes
                string date = dateTextBox.Text;
                string time = timeTextBox.Text;
                string name = nameTextBox.Text;
                string sex = sexTextBox.Text;
                string age = ageTextBox.Text;
                string course = courseTextBox.Text;
                string year = yearTextBox.Text;
                string section = sectionTextBox.Text;
                string complaints = complaintsTextBox.Text;
                string treatment = treatmentTextBox.Text;
                string designation = designationTextBox.Text;
                string username = usernameLabel.Text;
                string graphDate = monthDateTextBox.Text;

               
                // Your SQLite connection string
                string connectionString = @"Data Source=database.db;Version=3;";

                // Insert into the consultation table
                string insertQuery = "INSERT INTO consultation (date, time, name, sex, age, course, year, section, complaints, treatment, designation, username, graphdate) " +
                                     "VALUES (@date, @time, @name, @sex, @age, @course, @year, @section, @complaints, @treatment, @designation, @username, @graphDate)";

                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    using (SQLiteCommand insertCommand = new SQLiteCommand(insertQuery, connection))
                    {
                        // Add parameters for the values you want to insert
                        insertCommand.Parameters.AddWithValue("@date", date);
                        insertCommand.Parameters.AddWithValue("@time", time);
                        insertCommand.Parameters.AddWithValue("@name", name);
                        insertCommand.Parameters.AddWithValue("@sex", sex);
                        insertCommand.Parameters.AddWithValue("@age", age);
                        insertCommand.Parameters.AddWithValue("@course", course);
                        insertCommand.Parameters.AddWithValue("@year", year);
                        insertCommand.Parameters.AddWithValue("@section", section);
                        insertCommand.Parameters.AddWithValue("@complaints", complaints);
                        insertCommand.Parameters.AddWithValue("@treatment", treatment);
                        insertCommand.Parameters.AddWithValue("@designation", designation);
                        insertCommand.Parameters.AddWithValue("@username", username);
                        insertCommand.Parameters.AddWithValue("@graphDate", graphDate);



                        // Execute the query
                        insertCommand.ExecuteNonQuery();
                    }






                    // Show success message
                    MessageBox.Show("Consultation record saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide(); // Hide the form after successful save
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    
        private void InitializeCheckBox()
        {
            //Medical History

            if (recentIllnessTextBox.Text != null && recentIllnessTextBox.Text.Trim().Equals("NO", StringComparison.OrdinalIgnoreCase))
            {
                recentIllnessCheckBox.Checked = true;
            }
            else
            {
                recentIllnessCheckBox.Checked = false;
            }

            if (recentMedicationTextBox.Text != null && recentMedicationTextBox.Text.Trim().Equals("NO", StringComparison.OrdinalIgnoreCase))
            {
                recentMedicationCheckBox.Checked = true;
            }
            else
            {
                recentMedicationCheckBox.Checked = false;
            }

            if (hospitalizationTextBox.Text != null && hospitalizationTextBox.Text.Trim().Equals("NO", StringComparison.OrdinalIgnoreCase))
            {
                hospitalizationCheckBox.Checked = true;
            }
            else
            {
                hospitalizationCheckBox.Checked = false;
            }

            if (surgeryTextBox.Text != null && surgeryTextBox.Text.Trim().Equals("NO", StringComparison.OrdinalIgnoreCase))
            {
                surgeryCheckBox.Checked = true;
            }
            else
            {
                surgeryCheckBox.Checked = false;
            }

            if (allergyTextBox.Text != null && allergyTextBox.Text.Trim().Equals("NO", StringComparison.OrdinalIgnoreCase))
            {
                allergyCheckBox.Checked = true;
            }
            else
            {
                allergyCheckBox.Checked = false;
            }

            if (immunizationTextBox.Text != null && immunizationTextBox.Text.Trim().Equals("NO", StringComparison.OrdinalIgnoreCase))
            {
                immunizationCheckBox.Checked = true;
            }
            else
            {
                immunizationCheckBox.Checked = false;
            }

            if (illnessInTheFamilyTextBox.Text != null && illnessInTheFamilyTextBox.Text.Trim().Equals("NO", StringComparison.OrdinalIgnoreCase))
            {
                illnessInTheFamilyCheckBox.Checked = true;
            }
            else
            {
                illnessInTheFamilyCheckBox.Checked = false;
            }

            //Physical Examination

            if (genAppearanceTextBox.Text != null && genAppearanceTextBox.Text.Trim().Equals("NORMAL", StringComparison.OrdinalIgnoreCase))
            {
                genAppearanceCheckBox.Checked = true;
            }
            else
            {
                genAppearanceCheckBox.Checked = false;
            }
            if (skinTextBox.Text != null && skinTextBox.Text.Trim().Equals("NORMAL", StringComparison.OrdinalIgnoreCase))
            {
                skinCheckBox.Checked = true;
            }
            else
            {
                skinCheckBox.Checked = false;
            }
            if (headNeckTextBox.Text != null && headNeckTextBox.Text.Trim().Equals("NORMAL", StringComparison.OrdinalIgnoreCase))
            {
                headNeckCheckBox.Checked = true;
            }
            else
            {
                headNeckCheckBox.Checked = false;
            }
            if (lungsTextBox.Text != null && lungsTextBox.Text.Trim().Equals("NORMAL", StringComparison.OrdinalIgnoreCase))
            {
                lungsCheckBox.Checked = true;
            }
            else
            {
                lungsCheckBox.Checked = false;
            }
            if (breastTextBox.Text != null && breastTextBox.Text.Trim().Equals("NORMAL", StringComparison.OrdinalIgnoreCase))
            {
                breastCheckBox.Checked = true;
            }
            else
            {
                breastCheckBox.Checked = false;
            }
            if (heartTextBox.Text != null && heartTextBox.Text.Trim().Equals("NORMAL", StringComparison.OrdinalIgnoreCase))
            {
                heartCheckBox.Checked = true;
            }
            else
            {
                heartCheckBox.Checked = false;
            }
            if (abdomenTextBox.Text != null && abdomenTextBox.Text.Trim().Equals("NORMAL", StringComparison.OrdinalIgnoreCase))
            {
                abdomenCheckBox.Checked = true;
            }
            else
            {
                abdomenCheckBox.Checked = false;
            }
            if (backSpineTextBox.Text != null && backSpineTextBox.Text.Trim().Equals("NORMAL", StringComparison.OrdinalIgnoreCase))
            {
                backSpineCheckBox.Checked = true;
            }
            else
            {
                backSpineCheckBox.Checked = false;
            }
            if (genitalsTextBox.Text != null && genitalsTextBox.Text.Trim().Equals("NORMAL", StringComparison.OrdinalIgnoreCase))
            {
                genitalsCheckBox.Checked = true;
            }
            else
            {
                genitalsCheckBox.Checked = false;
            }
            if (rectumTextBox.Text != null && rectumTextBox.Text.Trim().Equals("NORMAL", StringComparison.OrdinalIgnoreCase))
            {
                rectumCheckBox.Checked = true;
            }
            else
            {
                rectumCheckBox.Checked = false;
            }
            if (extremitiesTextBox.Text != null && extremitiesTextBox.Text.Trim().Equals("NORMAL", StringComparison.OrdinalIgnoreCase))
            {
                extremitiesCheckBox.Checked = true;
            }
            else
            {
                extremitiesCheckBox.Checked = false;
            }
            if (neuroTextBox.Text != null && neuroTextBox.Text.Trim().Equals("NORMAL", StringComparison.OrdinalIgnoreCase))
            {
                neuroCheckBox.Checked = true;
            }
            else
            {
                neuroCheckBox.Checked = false;
            }
        }
    }
    
}
