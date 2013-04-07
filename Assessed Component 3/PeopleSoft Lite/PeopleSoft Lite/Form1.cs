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
    public partial class Form1 : Form
    {
        PeopleList peopleList = new PeopleList();
        List<Programme> ProgrammeList = new List<Programme>();
        List<Person> resultsList = new List<Person>();
        List<Module> moduleList = new List<Module>();

        public Form1()
        {
            InitializeComponent();
            PopulateData();
        }

        private void PopulateData()
        {
            Programme programme;
            Academic academic;
            Student student;
            Admin admin;
            Module module;

            // Create Academic staff examples, assign them a course if applicable and then add them to the people list.
            academic = new Academic("Dave Vhooris", 1001636, new DateTime(1974, 3, 28), "I dont know!", "E504", "BCL");
            peopleList.Add(academic);            
            academic = new Academic("Wayne Rippin", 1174983, new DateTime(1967, 6, 17), "SomeWhere!", "E504", "BCL");
            peopleList.Add(academic);            
            academic = new Academic("Tommy Thompson", 1079975, new DateTime(1983, 4, 6), "AnothePlace", "E504", "BCL");
            peopleList.Add(academic);             
            academic = new Academic("That Lecturer", 1271636, new DateTime(1975, 9, 21), "I dont know!", "E707", "CBL");
            peopleList.Add(academic); 

            // Create Modules
            module = new Module("Foundations of Computer Science", peopleList.Find(x => x.Name == "Wayne Rippin") as Academic);
            moduleList.Add(module);
            module = new Module("Programming 1", peopleList.Find(x => x.Name == "Tommy Thompson") as Academic);
            moduleList.Add(module);

            // Create Programmes
            programme = new Programme("Computer Science", peopleList.Find(x => x.Name == "Wayne Rippin")as Academic, 4);
            programme.ModulesList.Add(moduleList.Find( x => x.Name == "Programming 1"));
            programme.ModulesList.Add(moduleList.Find( x => x.Name == "Foundations of Computer Science"));
            ProgrammeList.Add(programme);
            programme = new Programme("Computer Games Programming", peopleList.Find(x => x.Name == "Tommy Thompson") as Academic, 4);
            programme.ModulesList.Add(moduleList.Find( x => x.Name == "Programming 1"));
            programme.ModulesList.Add(moduleList.Find( x => x.Name == "Foundations of Computer Science"));
            ProgrammeList.Add(programme);

            // Create Students            
            student = new Student("Samuel Parish", 100186328, new DateTime(1991, 8, 6), "62 Church Street, Horsley, Derby", "62 Church Street, Horsley, Derby", ProgrammeList.Find(x => x.Name == "Computer Science"), 1);
            peopleList.Add(student);
            student = new Student("John Odi", 100243528, new DateTime(1993, 10, 17), "Somewhere, Nottingham", "Somewhere, Nottingham", ProgrammeList.Find(x => x.Name == "Computer Science"), 1);
            peopleList.Add(student);
            student = new Student("Reece Beardsall", 100178539, new DateTime(1993, 10, 17), "Barnsley", "Peak Court", ProgrammeList.Find(x => x.Name == "Computer Games Programming"), 1);
            peopleList.Add(student);
            

            // Create admin staff examples.
            admin = new Admin("Admin staff1", 2777743, new DateTime(1970, 9, 22), "A house", "E775", "Something vital but boring.");
            peopleList.Add(admin);
        }

        public void UpdateResults()
        {
            resultsListBox.Items.Clear();
            foreach (Person person in resultsList)
            {
                resultsListBox.Items.Add(person.Name + " " + person.IdentificationNumber);
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            if (criteriaComboBox.SelectedItem != null)
            {
                IEnumerable<Person> people;

                resultsList.Clear();

                // Sets whether to serach for staff or students based on teh sate of the check boxes.
                if (staffCheckbox.Checked && studentCheckbox.Checked)
                {
                    people = peopleList;
                }
                else if (staffCheckbox.Checked)
                {
                    people = peopleList.GetAllStaff();
                }
                else if (studentCheckbox.Checked)
                {
                    people = peopleList.GetAllStudents();
                }
                else
                {
                    MessageBox.Show("Please select whether to search students, staff or both.");
                    return;
                }

                // Searches through the list and adds each instance of person that matches teh criteria to the results box.
                foreach (Person currentPerson in people)
                {
                    if (criteriaComboBox.SelectedItem.Equals("Name"))
                    {
                        if (currentPerson.HasName(textBox1.Text))
                        {
                            resultsList.Add(currentPerson);                            
                        }
                    }
                    else if (criteriaComboBox.SelectedItem.Equals("Identification Number"))
                    {
                        int input;
                        int.TryParse(textBox1.Text, out input);
                        if (currentPerson.HasID(input))
                        {
                            resultsList.Add(currentPerson);                            
                        }
                    }
                }

                UpdateResults();
            }
            else
            {
                MessageBox.Show("Please select criteria to search by.");
            }
        }

        // returns the query panel to is default state.
        private void resetButton_Click(object sender, EventArgs e)
        {
            resultsList.Clear();
            UpdateResults();
            studentCheckbox.Checked = false;
            staffCheckbox.Checked = false;            
            criteriaComboBox.SelectedItem = null;
            criteriaComboBox.Text = "Search by...";
            textBox1.Text = "";
        }

        /// <summary>
        /// Opens a new form containing all the information about the individual selected.
        /// This information can be edited at a button press.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void detailsButton_Click(object sender, EventArgs e)
        {
            try
            {
                DetailsForm detailsForm = new DetailsForm(resultsList[resultsListBox.SelectedIndex], this);
                detailsForm.Show();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                MessageBox.Show("Please select a person to view details of.");
            }
        }
    }
}
