using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SoftPeople_Lite
{
    // Show details for selected person.
    public partial class DetailsForm : Form
    {
        Person _person;
        Form1 _parent;

        public DetailsForm(Person person, Form1 parent)
        {
            InitializeComponent();

            _person = person;
            _parent = parent;
            nameTextBox.Text = person.GetDetails()[0];
            IDtextBox.Text = person.GetDetails()[1];
            dobTextBox.Text = person.GetDetails()[2];
            homeAddTextBox.Text = person.GetDetails()[3];

            if (person is Student)
            {                
                Student student = person as Student;
                
                label5.Text = "Term Address:";
                TextBox5.Text = student.GetDetails()[4];
                label6.Text = "Programme:";
                TextBox6.Text = student.GetDetails()[5];
                button5.Text = "Show Details";
                label7.Text = "Year of study:";
                TextBox7.Text = student.GetDetails()[6];
                label8.Visible = false;
                button7.Visible = false;
                comboBox1.Visible = false;
                comboBox2.Visible = false;
            }

            else if (person is Academic)
            {
                Academic academic = person as Academic;

                label5.Text = "Office:";
                TextBox5.Text = academic.GetDetails()[4];
                label6.Text = "School:";
                TextBox6.Text = academic.GetDetails()[5];
                label7.Text = "Modules Led:";
                TextBox7.Visible = false;
                foreach (Module module in academic.ModulesLed)
                {
                    comboBox2.Items.Add(module.Name);
                }
                comboBox2.SelectedIndex = 0;
                button6.Text = "Details";

                label8.Text = "ProgrammesLed:";
                foreach (Programme programme in academic.ProgrammesLed)
                {
                    comboBox1.Items.Add(programme.Name);
                }
                comboBox1.SelectedIndex = 0;
                button7.Text = "Details";
            }
            else if (person is Admin)
            {
                Admin admin = person as Admin;
                label5.Text = "Office:";
                TextBox5.Text = admin.GetDetails()[4];
                label6.Text = "Role:";
                TextBox6.Text = admin.GetDetails()[5];
                label7.Visible = false;
                button6.Visible = false;
                TextBox7.Visible = false;
                label8.Visible = false;
                button7.Visible = false;
                comboBox1.Visible = false;
                comboBox2.Visible = false;
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            _parent.UpdateResults();
            this.Close();
        }


        /// <summary>
        /// On the first click this button enables the user to edit the textbox.
        /// A second click commits the changes to the persons name and reverts the buttons state.
        /// </summary>
        private void nameCommitButton_Click(object sender, EventArgs e)
        {
            if (nameTextBox.ReadOnly == true)
            {
                nameTextBox.ReadOnly = false;
                nameCommitButton.Text = "Commit";
            }
            else
            {
                try
                {
                    _person.ChangeName(nameTextBox.Text);
                    nameTextBox.ReadOnly = true;
                    nameCommitButton.Text = "Edit";
                }
                catch (FormatException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (IDtextBox.ReadOnly == true)
            {
                IDtextBox.ReadOnly = false;
                IDButton.Text = "Commit";
            }
            else
            {
                try
                {
                    int result;
                    if (_person is Student)
                    {
                        Student student = _person as Student;
                        if (int.TryParse(IDtextBox.Text, out result))
                        {
                            student.IdentificationNumber = (result);
                        }
                    }
                    else if (_person is Staff)
                    {
                        Staff staff = _person as Staff;
                        if (int.TryParse(IDtextBox.Text, out result))
                        {
                            staff.IdentificationNumber = (result);
                        }
                    }
                    IDtextBox.ReadOnly = true;
                    IDButton.Text = "Edit";
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ( dobTextBox.ReadOnly == true)
            {
                dobTextBox.ReadOnly = false;
                DoBButton.Text = "Commit";
            }
            else
            {
                try
                {
                    _person.SetDoB(dobTextBox.Text);
                    dobTextBox.ReadOnly = true;
                    DoBButton.Text = "Edit";
                }
                catch (FormatException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void AddressButton_Click(object sender, EventArgs e)
        {
            if (homeAddTextBox.ReadOnly == true)
            {
                homeAddTextBox.ReadOnly = false;
                AddressButton.Text = "Commit";
            }
            else
            {
                _person.Address = homeAddTextBox.Text;
                homeAddTextBox.ReadOnly = true;
                AddressButton.Text = "Edit";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (TextBox5.ReadOnly == true)
            {
                TextBox5.ReadOnly = false;
                button4.Text = "Commit";
            }
            else
            {
                if (_person is Student)
                {
                    Student student = _person as Student;
                    student.TermAddress = TextBox5.Text;
                }
                else if (_person is Staff)
                {
                    Staff staff = _person as Staff;
                    staff.Office = TextBox5.Text;
                }
                TextBox5.ReadOnly = true;
                button4.Text = "Edit";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (_person is Student)
            {
                Student student = _person as Student;
                ProgrammeDetailsForm programDetailsForm = new ProgrammeDetailsForm(student.ProgramOfStudy, this);
                programDetailsForm.Show();
            }
            else if (TextBox6.ReadOnly == true)
            {
                TextBox6.ReadOnly = false;
                button5.Text = "Commit";                
            }
            else
            {
                TextBox6.ReadOnly = true;
                button5.Text = "Edit";
                if (_person is Academic)
                {
                    Academic academic = _person as Academic;
                    academic.School = TextBox6.Text;
                }
                else
                {
                    Admin admin = _person as Admin;
                    admin.Role = TextBox6.Text;
                }
            }            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (_person is Student)
            {
                Student student = _person as Student;

                if (TextBox7.ReadOnly == true)
                {
                    button6.Text = "Commit";
                    TextBox6.ReadOnly = false;
                }
                else
                {
                    button6.Text = "Edit";
                    TextBox7.ReadOnly = true;
                    int result;

                    // set the students year of study to what is in the text box if its a number.
                    if (int.TryParse(TextBox7.Text, out result))
                    {
                        student.YearOfStudy = result;
                    }
                }
            }
            else
            {
                Academic academic = _person as Academic;
                
                // 

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

    }
}
