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
    public partial class ModuleSelectionWindow : Form
    {
        DetailsForm _parent;
        List<Module> _moduleList;
        Academic _academic;

        // Produces a form with a checklistbox that is populated with the module list handed to it.
        public ModuleSelectionWindow(Academic academic, List<Module> moduleList, DetailsForm parentForm)
        {
            _parent = parentForm;
            _moduleList = moduleList;
            _academic = academic;

            InitializeComponent();

            foreach (Module module in moduleList)
            {
                if (!academic.ModulesLed.Contains(module))
                {
                    checkedListBox1.Items.Add(module.Name);
                }
            }            
        }

        // Adds the selected modules to the Academic.
        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.SelectedItems.Count; i++)
            {
                _academic.AddModuleLed(_moduleList.Find(x => x.Name == checkedListBox1.SelectedItems[i].ToString()));
            }            
        }
    }
}
