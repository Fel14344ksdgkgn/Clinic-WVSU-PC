using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Clinic_WVSU_PC
{
    public partial class addPatient : Form
    {
        private string selectedGender;
        // Define class-level variables to store the previous state
        private FormBorderStyle previousFormBorderStyle;
        private bool previousPictureBoxVisibility;


        private readonly string username;

        public addPatient(string username)
        {
            InitializeComponent();
            this.username = username;

        }




        private void courseCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void addPatient_Load(object sender, EventArgs e)
        {

        }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {

        }





        private void facultyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (facultyCheckBox.Checked)
            {
                nonTeachingCheckBox.Checked = false;
                studentCheckBox.Checked = false;
                categoryTextBox.Text = "FACULTY";
                courseLabel.Visible = false;
                courseCombobox.Visible = false;
                yearComboBox.Visible = false;
                sectionComboBox.Visible = false;
            }
            else if (facultyCheckBox.Checked.Equals(false))
            {
                categoryTextBox.Text = "";
            }
        }

        private void nonTeachingCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (nonTeachingCheckBox.Checked)
            {
                facultyCheckBox.Checked = false;
                studentCheckBox.Checked = false;
                categoryTextBox.Text = "NON-TEACHING";
                courseLabel.Visible = false;
                courseCombobox.Visible = false;
                yearComboBox.Visible = false;
                sectionComboBox.Visible = false;
            }
            else if (nonTeachingCheckBox.Checked.Equals(false))
            {
                categoryTextBox.Text = "";
            }
        }

        private void studentCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (studentCheckBox.Checked)
            {
                facultyCheckBox.Checked = false;
                nonTeachingCheckBox.Checked = false;
                categoryTextBox.Text = "STUDENT";
                courseLabel.Visible = true;
                courseCombobox.Visible = true;
                yearComboBox.Visible = true;
                sectionComboBox.Visible = true;
            }
            else if (studentCheckBox.Checked.Equals(false))
            {
                categoryTextBox.Text = "";
            }
        }

        private void maleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (maleCheckBox.Checked)
            {
                sexTextBox.Text = "M";
                femaleCheckBox.Checked = false;
                lastMensDateTimePicker.Visible= false;
                ageOnsetTextBox.Visible= false;
                forFemalesLabel.Visible= false;
                forlastmens.Visible= false;
                foronset.Visible= false;
            }
            else
            {
                lastMensDateTimePicker.Visible = true;
                ageOnsetTextBox.Visible = true;
                forFemalesLabel.Visible = true;
                forlastmens.Visible = true;
                foronset.Visible = true;
            }
        }

        private void femaleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (femaleCheckBox.Checked)
            {
                sexTextBox.Text = "F";
                maleCheckBox.Checked = false;
            }
        }
        private void recentIllnessCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (recentIllnessCheckBox.Checked)
            {
                recentIllnessTextBox.Text = "NO";
                recentIllnessTextBox.ReadOnly = true;
            }
            else
            {
                recentIllnessTextBox.ReadOnly = false;
                recentIllnessTextBox.Text = "";
            }
        }
        private void recentMedicationCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void hospitalizationCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (hospitalizationCheckBox.Checked)
            {
                hospitalizationTextBox.Text = "NO";
                hospitalizationTextBox.ReadOnly = true;
            }
            else
            {
                hospitalizationTextBox.ReadOnly = false;
                hospitalizationTextBox.Text = "";
            }
        }

        private void surgeryCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (surgeryCheckBox.Checked)
            {
                surgeryTextBox.Text = "NO";
                surgeryTextBox.ReadOnly = true;
            }
            else
            {
                surgeryTextBox.ReadOnly = false;
                surgeryTextBox.Text = "";
            }
        }

        private void allergyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (allergyCheckBox.Checked)
            {
                allergyTextBox.Text = "NO";
                allergyTextBox.ReadOnly = true;
            }
            else
            {
                allergyTextBox.ReadOnly = false;
                allergyTextBox.Text = "";
            }
        }

        private void immunizationCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (immunizationCheckBox.Checked)
            {
                immunizationTextBox.Text = "NO";
                immunizationTextBox.ReadOnly = true;
            }
            else
            {
                immunizationTextBox.ReadOnly = false;
                immunizationTextBox.Text = "";
            }
        }

        private void illnessIntheFamilyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (illnessIntheFamilyCheckBox.Checked)
            {
                illnessInTheFamilyTextBox.Text = "NO";
                illnessInTheFamilyTextBox.ReadOnly = true;
            }
            else
            {
                illnessInTheFamilyTextBox.ReadOnly = false;
                illnessInTheFamilyTextBox.Text = "";
            }
        }

        private void recentMedicationCheckBox_CheckedChanged_1(object sender, EventArgs e)
        {
            if (recentMedicationCheckBox.Checked)
            {
                recentMedicationTextBox.Text = "NO";
                recentMedicationTextBox.ReadOnly = true;
            }
            else
            {
                recentMedicationTextBox.ReadOnly = false;
                recentMedicationTextBox.Text = "";
            }
        }

        private void genAppearanceCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (genAppearanceCheckBox.Checked)
            {
                genAppearanceTextBox.Text = "NORMAL";
                genAppearanceTextBox.ReadOnly = true;
            }
            else
            {
                genAppearanceTextBox.ReadOnly = false;
                genAppearanceTextBox.Text = "";
            }
        }

        private void skinCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (skinCheckBox.Checked)
            {
                skinTextBox.Text = "NORMAL";
                skinTextBox.ReadOnly = true;
            }
            else
            {
                skinTextBox.ReadOnly = false;
                skinTextBox.Text = "";
            }
        }
        private void headNeckCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (headNeckCheckBox.Checked)
            {
                headNeckTextBox.Text = "NORMAL";
                headNeckTextBox.ReadOnly = true;
            }
            else
            {
                headNeckTextBox.ReadOnly = false;
                headNeckTextBox.Text = "";
            }
        }

        private void lungsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (lungsCheckBox.Checked)
            {
                lungsTextBox.Text = "NORMAL";
                lungsTextBox.ReadOnly = true;
            }
            else
            {
                lungsTextBox.ReadOnly = false;
                lungsTextBox.Text = "";
            }
        }

        private void breastCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (breastCheckBox.Checked)
            {
                breastTextBox.Text = "NORMAL";
                breastTextBox.ReadOnly = true;
            }
            else
            {
                breastTextBox.ReadOnly = false;
                breastTextBox.Text = "";
            }
        }

        private void heartCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (heartCheckBox.Checked)
            {
                heartTextBox.Text = "NORMAL";
                heartTextBox.ReadOnly = true;
            }
            else
            {
                heartTextBox.ReadOnly = false;
                heartTextBox.Text = "";
            }
        }

        private void abdomenCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (abdomenCheckBox.Checked)
            {
                abdomenTextBox.Text = "NORMAL";
                abdomenTextBox.ReadOnly = true;
            }
            else
            {
                abdomenTextBox.ReadOnly = false;
                abdomenTextBox.Text = "";
            }
        }
   

        private void backSpineCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (backSpineCheckBox.Checked)
            {
                backSpineTextBox.Text = "NORMAL";
                backSpineTextBox.ReadOnly = true;
            }
            else
            {
                backSpineTextBox.ReadOnly = false;
                backSpineTextBox.Text = "";
            }
        }

        private void genitalsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (genitalsCheckBox.Checked)
            {
                genitalsTextBox.Text = "NORMAL";
                genitalsTextBox.ReadOnly = true;
            }
            else
            {
                genitalsTextBox.ReadOnly = false;
                genitalsTextBox.Text = "";
            }
        }

        private void rectumCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (rectumCheckBox.Checked)
            {
                rectumTextBox.Text = "NORMAL";
                rectumTextBox.ReadOnly = true;
            }
            else
            {
                rectumTextBox.ReadOnly = false;
                rectumTextBox.Text = "";
            }
        }

        private void extremitiesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (extremitiesCheckBox.Checked)
            {
                extremitiesTextBox.Text = "NORMAL";
                extremitiesTextBox.ReadOnly = true;
            }
            else
            {
                extremitiesTextBox.ReadOnly = false;
                extremitiesTextBox.Text = "";
            }
        }

        private void neuroCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (neuroCheckBox.Checked)
            {
                neuroTextBox.Text = "NORMAL";
                neuroTextBox.ReadOnly = true;
            }
            else
            {
                neuroTextBox.ReadOnly = false;
                neuroTextBox.Text = "";
            }
        }

        private void dobDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            // Calculate age based on the selected birthdate
            DateTime birthdate = dobDateTimePicker.Value;
            DateTime today = DateTime.Today;
            int age = today.Year - birthdate.Year;

            // Adjust age if the birthday hasn't occurred yet this year
            if (birthdate.Date > today.AddYears(-age))
                age--;

            // Display the calculated age in the AgeTextBox
            ageTextBox.Text = age.ToString();
        }

        private void saveButton_Click_1(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                try
                {
                    // Patients Personal Information
                    string category = categoryTextBox.Text;
                    string name = nameTextBox.Text;
                    string dob = dobDateTimePicker.Value.ToString("MMMM d, yyyy");
                    string sex = sexTextBox.Text;
                    string civilStatus = civilStatComboBox.Text;
                    string phone = phoneTextBox.Text;
                    string address = addressTextBox.Text;
                    string pgname = pgTextBox.Text;
                    string course = courseCombobox.Text;
                    string year = yearComboBox.Text;
                    string section = sectionComboBox.Text;
                    string contactPerson = contactNameTextBox.Text;

                    if (category != "STUDENT")
                    {
                        course = "";
                        year = "";
                        section = "";
                    }

                    // Patients Medical History
                    string recentillness = recentIllnessTextBox.Text;
                    string recentMedications = recentMedicationTextBox.Text;
                    string hospitalization = hospitalizationTextBox.Text;
                    string surgery = surgeryTextBox.Text;
                    string allergy = allergyTextBox.Text;
                    string immunization = immunizationTextBox.Text;
                    string illnessinthefamily = illnessInTheFamilyTextBox.Text;
                    string ageofonset = ageOnsetTextBox.Text;
                    string dateoflastmenses = lastMensDateTimePicker.Value.ToString("MMMM d, yyyy");

                    // Patients Pnysical Examination
                    string bp = bpTextBox.Text;
                    string t = tempTextBox.Text;
                    string pr = prTextBox.Text;
                    string rr = rrTextBox.Text;
                    string ht = htTextBox.Text;
                    string wt = wtTextBox.Text;
                    string od = odTextBox.Text;
                    string os = osTextBox.Text;
                    string correctedod = correctedOdTextBox.Text;
                    string correctedos = correctedOsTextBox.Text;
                    string generalappearance = genAppearanceTextBox.Text;
                    string skin = skinTextBox.Text;
                    string headandneck = headNeckTextBox.Text;
                    string lungs = lungsTextBox.Text;
                    string breast = breastTextBox.Text;
                    string heart = heartTextBox.Text;
                    string abdomen = abdomenTextBox.Text;
                    string backandspine = backSpineTextBox.Text;
                    string genitals = genitalsTextBox.Text;
                    string rectum = rectumTextBox.Text;
                    string extremities = extremitiesTextBox.Text;
                    string neuro = neuroTextBox.Text;
                    string remarks = remarksTextBox.Text;




                    // Your SQLite connection string
                    string connectionString = @"Data Source=database.db;Version=3;";

           
                    
                    string insertPatientsInfoQuery = "INSERT INTO patientinfo (category, name, dob, sex, civilstatus, phone, address, pgname, course, year, section, contactperson) " +
                                         "VALUES (@category, @name, @dob, @sex, @civilStatus, @phone, @address, @pgname, @course, @year, @section, @contactPerson)";
 

                    
                    string insertMedicalHistoryQuery = "INSERT INTO medicalhistory (name,recentillness, recentmedications, hospitalization, surgery, allergy, immunization, illnessinthefamily, ageofonset, dateoflastmenses) " +
                                         "VALUES (@name, @recentillness, @recentmedications, @hospitalization, @surgery, @allergy, @immunization, @illnessinthefamily, @ageofonset, @dateoflastmenses)";

                    string insertPhysicalExaminationQuery = "INSERT INTO physicalexamination (name,bp, t, pr, rr, ht, wt, od, os, correctedod, correctedos, generalappearance, skin, headandneck, lungs, breast, heart, abdomen, backandspine, genitals, rectum, extremities, neuro, remarks) " +
                                         "VALUES (@name,@bp, @t, @pr, @rr, @ht, @wt, @od, @os, @correctedod, @correctedos, @generalappearance, @skin, @headandneck, @lungs, @breast, @heart, @abdomen, @backandspine, @genitals, @rectum, @extremities, @neuro, @remarks)";

                    using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                    {
                        connection.Open();

                        using (SQLiteCommand insertPatientInformationCommand = new SQLiteCommand(insertPatientsInfoQuery, connection))
                        {
                            // Add parameters for the values you want to insert
                            insertPatientInformationCommand.Parameters.AddWithValue("@category", category);
                            insertPatientInformationCommand.Parameters.AddWithValue("@name", name);
                            insertPatientInformationCommand.Parameters.AddWithValue("@dob", dob);
                            insertPatientInformationCommand.Parameters.AddWithValue("@sex", sex);
                            insertPatientInformationCommand.Parameters.AddWithValue("@civilStatus", civilStatus);
                            insertPatientInformationCommand.Parameters.AddWithValue("@phone", phone);
                            insertPatientInformationCommand.Parameters.AddWithValue("@address", address);
                            insertPatientInformationCommand.Parameters.AddWithValue("@pgname", pgname);
                            insertPatientInformationCommand.Parameters.AddWithValue("@course", course);
                            insertPatientInformationCommand.Parameters.AddWithValue("@year", year);
                            insertPatientInformationCommand.Parameters.AddWithValue("@section", section);
                            insertPatientInformationCommand.Parameters.AddWithValue("@contactPerson", contactPerson);

                            // Execute the query
                            insertPatientInformationCommand.ExecuteNonQuery();
                        }
                        using (SQLiteCommand insertMedicalHistoryCommand = new SQLiteCommand(insertMedicalHistoryQuery, connection))
                        {
                            // Add parameters for the values you want to insert
                            insertMedicalHistoryCommand.Parameters.AddWithValue("@name", name);
                            insertMedicalHistoryCommand.Parameters.AddWithValue("@recentillness", recentillness);
                            insertMedicalHistoryCommand.Parameters.AddWithValue("@recentmedications", recentMedications);
                            insertMedicalHistoryCommand.Parameters.AddWithValue("@hospitalization", hospitalization);
                            insertMedicalHistoryCommand.Parameters.AddWithValue("@surgery", surgery);
                            insertMedicalHistoryCommand.Parameters.AddWithValue("@allergy", allergy);
                            insertMedicalHistoryCommand.Parameters.AddWithValue("@immunization", immunization);
                            insertMedicalHistoryCommand.Parameters.AddWithValue("@illnessinthefamily", illnessinthefamily);
                            insertMedicalHistoryCommand.Parameters.AddWithValue("@ageofonset", ageofonset);
                            insertMedicalHistoryCommand.Parameters.AddWithValue("@dateoflastmenses", dateoflastmenses);


                            // Execute the query
                            insertMedicalHistoryCommand.ExecuteNonQuery();
                        }
                        using (SQLiteCommand insertPhysicalExaminationCommand = new SQLiteCommand(insertPhysicalExaminationQuery, connection))
                        {
                            // Add parameters for the values you want to insert
                            insertPhysicalExaminationCommand.Parameters.AddWithValue("@name", name);
                            insertPhysicalExaminationCommand.Parameters.AddWithValue("@bp", bp);
                            insertPhysicalExaminationCommand.Parameters.AddWithValue("@t", t);
                            insertPhysicalExaminationCommand.Parameters.AddWithValue("@pr", pr);
                            insertPhysicalExaminationCommand.Parameters.AddWithValue("@rr", rr);
                            insertPhysicalExaminationCommand.Parameters.AddWithValue("@ht", ht);
                            insertPhysicalExaminationCommand.Parameters.AddWithValue("@wt", wt);
                            insertPhysicalExaminationCommand.Parameters.AddWithValue("@od", od); // Corrected
                            insertPhysicalExaminationCommand.Parameters.AddWithValue("@os", os);
                            insertPhysicalExaminationCommand.Parameters.AddWithValue("@correctedod", correctedod);
                            insertPhysicalExaminationCommand.Parameters.AddWithValue("@correctedos", correctedos);
                            insertPhysicalExaminationCommand.Parameters.AddWithValue("@generalappearance", generalappearance);
                            insertPhysicalExaminationCommand.Parameters.AddWithValue("@skin", skin);
                            insertPhysicalExaminationCommand.Parameters.AddWithValue("@headandneck", headandneck);
                            insertPhysicalExaminationCommand.Parameters.AddWithValue("@lungs", lungs);
                            insertPhysicalExaminationCommand.Parameters.AddWithValue("@breast", breast);
                            insertPhysicalExaminationCommand.Parameters.AddWithValue("@heart", heart);
                            insertPhysicalExaminationCommand.Parameters.AddWithValue("@abdomen", abdomen);
                            insertPhysicalExaminationCommand.Parameters.AddWithValue("@backandspine", backandspine);
                            insertPhysicalExaminationCommand.Parameters.AddWithValue("@genitals", genitals);
                            insertPhysicalExaminationCommand.Parameters.AddWithValue("@rectum", rectum);
                            insertPhysicalExaminationCommand.Parameters.AddWithValue("@extremities", extremities);
                            insertPhysicalExaminationCommand.Parameters.AddWithValue("@neuro", neuro);
                            insertPhysicalExaminationCommand.Parameters.AddWithValue("@remarks", remarks);

                            // Execute the query
                            insertPhysicalExaminationCommand.ExecuteNonQuery();
                        }


                        // Show success message
                        MessageBox.Show("Medical Health record saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void nameTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(nameTextBox.Text))
            {
                e.Cancel = true;
                nameTextBox.Focus();
                errorProvider.SetError(nameTextBox, "Please enter Patient's name.");

            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(nameTextBox, null);
            }
        }


        private void categoryTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(categoryTextBox.Text))
            {
                e.Cancel = true;
                categoryTextBox.Focus();
                errorProvider.SetError(categoryTextBox, "Please select Patient's Category.");

            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(categoryTextBox, null);
            }
        }

        private void dobDateTimePicker_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(ageTextBox.Text))
            {
                e.Cancel = true;
                dobDateTimePicker.Focus();
                errorProvider.SetError(dobDateTimePicker, "Please select Patient's Date of Birth.");

            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(dobDateTimePicker, null);
            }
        }

        private void sexTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(sexTextBox.Text))
            {
                e.Cancel = true;
                sexTextBox.Focus();
                errorProvider.SetError(sexTextBox, "Please select Patient's Sex.");

            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(sexTextBox, null);
            }
        }

        private void civilStatComboBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(civilStatComboBox.Text))
            {
                e.Cancel = true;
                civilStatComboBox.Focus();
                errorProvider.SetError(civilStatComboBox, "Please select Patient's Civil Status.");

            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(civilStatComboBox, null);
            }
        }

        private void phoneTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(phoneTextBox.Text))
            {
                e.Cancel = true;
                phoneTextBox.Focus();
                errorProvider.SetError(phoneTextBox, "Please enter Patient's Emergency Contact Number.");

            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(phoneTextBox, null);
            }
        }

        private void addressTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(addressTextBox.Text))
            {
                e.Cancel = true;
                addressTextBox.Focus();
                errorProvider.SetError(addressTextBox, "Please enter Patient's Address.");

            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(phoneTextBox, null);
            }
        }

        private void pgTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(pgTextBox.Text))
            {
                e.Cancel = true;
                pgTextBox.Focus();
                errorProvider.SetError(pgTextBox, "Please enter Patient's Parent/Guardian.");

            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(phoneTextBox, null);
            }
        }

        private void contactNameTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(contactNameTextBox.Text))
            {
                e.Cancel = true;
                contactNameTextBox.Focus();
                errorProvider.SetError(contactNameTextBox, "Please enter Patient's Emergency Contact Person.");

            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(contactNameTextBox, null);
            }
        }

        private void sectionComboBox_Validating(object sender, CancelEventArgs e)
        {
            if (categoryTextBox.Text.Equals("STUDENT") && string.IsNullOrEmpty(courseCombobox.Text) && string.IsNullOrEmpty(yearComboBox.Text) && string.IsNullOrEmpty(sectionComboBox.Text))
            {
                e.Cancel = true;
                sectionComboBox.Focus();
                errorProvider.SetError(sectionComboBox, "Please select Patient's Course Year and Section.");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(sectionComboBox, null);
            }
        }

        private void recentIllnessTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(recentIllnessTextBox.Text))
            {
                e.Cancel = true;
                recentIllnessTextBox.Focus();
                errorProvider.SetError(recentIllnessTextBox, "Please enter Patient's Recent Illness.");

            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(recentIllnessTextBox, null);
            }
        }

        private void recentMedicationTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(recentMedicationTextBox.Text))
            {
                e.Cancel = true;
                recentMedicationTextBox.Focus();
                errorProvider.SetError(recentMedicationTextBox, "Please enter Patient's Recent Medication.");

            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(recentMedicationTextBox, null);
            }
        }

        private void hospitalizationTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(hospitalizationTextBox.Text))
            {
                e.Cancel = true;
                hospitalizationTextBox.Focus();
                errorProvider.SetError(hospitalizationTextBox, "Please enter Patient's Hospitalization.");

            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(hospitalizationTextBox, null);
            }
        }

        private void surgeryTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(surgeryTextBox.Text))
            {
                e.Cancel = true;
                surgeryTextBox.Focus();
                errorProvider.SetError(surgeryTextBox, "Please enter Patient's Surgery.");

            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(surgeryTextBox, null);
            }
        }

        private void allergyTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(allergyTextBox.Text))
            {
                e.Cancel = true;
                allergyTextBox.Focus();
                errorProvider.SetError(allergyTextBox, "Please enter Patient's Allergy.");

            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(allergyTextBox, null);
            }
        }

        private void immunizationTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(immunizationTextBox.Text))
            {
                e.Cancel = true;
                immunizationTextBox.Focus();
                errorProvider.SetError(immunizationTextBox, "Please enter Patient's Immunization.");

            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(immunizationTextBox, null);
            }
        }

        private void illnessInTheFamilyTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(illnessInTheFamilyTextBox.Text))
            {
                e.Cancel = true;
                illnessInTheFamilyTextBox.Focus();
                errorProvider.SetError(illnessInTheFamilyTextBox, "Please enter Patient's Recent Illness in the Family.");

            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(illnessInTheFamilyTextBox, null);
            }
        }


    }
}