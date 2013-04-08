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
    public partial class ProgrammeSelectionWindow : Form
    {
        DetailsForm _parent;
        List<Programme> _programmeList;
        Academic _academic;
        List<Programme> _oldProgrammesLed;

        // Produces a form with a checklistbox that is populated with the programme list handed to it.
        public ProgrammeSelectionWindow(Academic academic, List<Programme> programmeList, DetailsForm parentForm)
        {
            _parent = parentForm;
            _programmeList = programmeList;
            _academic = academic;
            _oldProgrammesLed = academic.ProgrammesLed;

            InitializeComponent();
            foreach (Programme programme in programmeList)
            {
                if (!academic.ProgrammesLed.Contains(programme))
                {
                    checkedListBox1.Items.Add(programme.Name);
                }
            }            
        }

        // Adds the selected Programmes to the Academics ProgrammesLed and close this window.
        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.SelectedItems.Count; i++)
            {
                _academic.AddProgrammeLed(_programmeList.Find(x => x.Name == checkedListBox1.SelectedItems[i].ToString()));
            }
            this.Close();
            _parent.UpdateComboBoxes();
        }
    }
}
