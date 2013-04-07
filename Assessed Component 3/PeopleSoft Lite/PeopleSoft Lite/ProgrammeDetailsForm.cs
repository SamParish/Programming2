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
    // Displays information about each program
    public partial class ProgrammeDetailsForm : Form
    {
        List<Module> moduleList = new List<Module>();

        public ProgrammeDetailsForm(Programme programme, DetailsForm parentForm)
        {
            InitializeComponent();

            textBox1.Text = programme.Name;
            textBox2.Text = programme.ProgramLeader.Name;
            textBox3.Text = programme.Length.ToString();
            label6.Text = programme.NumOfStudents.ToString();

            foreach (Module module in programme.ModulesList)
            {
                moduleList.Add(module);
                listBox1.Items.Add(module.Name);
            }
        }

        // Show the details of the module selected.
        private void button5_Click(object sender, EventArgs e)
        {

        }

        // Need to show a new form for the module details not display it in a panel.
        /*
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            panel1.Visible = true;
            textBox4.Text = moduleList[listBox1.SelectedIndex].ModuleLeader.Name;
            label9.Text = moduleList[listBox1.SelectedIndex].NumOfStudents.ToString();
        }       
         */
    }
}
