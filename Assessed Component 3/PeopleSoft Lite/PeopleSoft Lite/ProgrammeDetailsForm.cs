﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SoftPeople_Lite
{
    public partial class ProgrammeDetailsForm : Form
    {
        List<Module> moduleList = new List<Module>();
        Programme _programme;
        DetailsForm _parentForm;

        // Displays a form that shows information about a program.
        public ProgrammeDetailsForm(Programme programme, DetailsForm parentForm)
        {
            InitializeComponent();
            _programme = programme;
            _parentForm = parentForm;

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

        // Displays details about each module in the programme.
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            panel1.Visible = true;
            textBox4.Text = moduleList[listBox1.SelectedIndex].ModuleLeader.Name;
            label9.Text = moduleList[listBox1.SelectedIndex].NumOfStudents.ToString();
        }

        // Show details form for  the academic who leads this programme.
        private void button2_Click(object sender, EventArgs e)
        {
            DetailsForm detailsForm = new DetailsForm(_programme.ProgramLeader, _parentForm.ParentForm);
            detailsForm.Show();
        }

        // Show details form for the academic who leads the selected module.
        private void button5_Click(object sender, EventArgs e)
        {
            DetailsForm detailsForm = new DetailsForm(moduleList[listBox1.SelectedIndex].ModuleLeader, _parentForm.ParentForm);
            detailsForm.Show();
        }
    }
}
