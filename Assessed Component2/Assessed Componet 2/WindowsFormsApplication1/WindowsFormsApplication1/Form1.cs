using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        LinkedQueue<int> queue = new LinkedQueue<int>();

        public Form1()
        {
            InitializeComponent();
        }   
        
        #region Utility Methods

        // Displays each item in the queue as a ListViewItem in the ListView.
        // Determines which is the front and which is the back and colours them appropriately.
        private void PopulateListView()
        {
            int i = 0;
            listView1.Items.Clear();
            foreach (int obj in queue)
            {
                string[] s = new string[1];
                s[0] = obj.ToString();
                ListViewItem item;

                // Front is also the end.
                if (i == 0 && queue.Count() == i + 1)
                {
                    item = new ListViewItem(s, 0, Color.White, Color.Purple, this.Font);                    
                }
                // Front of queue.
                else if (i == 0)
                {
                    item = new ListViewItem(s, 0, Color.White, Color.Blue, this.Font);
                }
                // End of the queue.
                else if (queue.Count() == i + 1)
                {
                    item = new ListViewItem(s, 0, Color.Black, Color.Red, this.Font);
                }
                else
                {
                    item = new ListViewItem(s, 0, Color.Black, Color.White, this.Font);
                }
                listView1.Items.Add(item);
                i++;
            }
        }

        //  Loads a queue of ints from a .txt file. The data must be deliminated by carriage returns.
        public void LoadFile()
        {
            Stream stream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            // Default directory.
            openFileDialog1.InitialDirectory = "T:\\Computer Science\\Year 1\\Programming 2\\Assessed Componet 2";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt" ;

            // Shows the load dialog window, if the user clicks ok proceedes with the rest of the method.
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((stream = openFileDialog1.OpenFile()) != null)
                    {
                        using (stream)
                        {
                            StreamReader reader = new StreamReader(stream);

                            // Refresh the old queue.
                            queue = new LinkedQueue<int>();

                            // temp variables.
                            string dataIn;
                            int invalidDataCount = 0;

                            do
                            {
                                dataIn = reader.ReadLine();
                                int currentInt;

                                // Try to parse the data, if it succedes enqueue it.
                                if (int.TryParse(dataIn, out currentInt))
                                {
                                    queue.Enqueue(currentInt);
                                }
                                else if (dataIn == null)
                                {
                                    // Don't do anything as its finished reading the file and The warning doesn't need to be displayed.
                                }
                                else
                                {
                                    // The data will be skipped, increment the invalid data count so we can later alert the user.
                                    invalidDataCount++;
                                }
                            }
                            while (dataIn != null);

                            // Close the streamReader.
                            reader.Close();

                            // If data was skipped alert the user.
                            if (invalidDataCount > 0)
                            {
                                MessageBox.Show(invalidDataCount + " items of data were skipped as they could not be loaded. \n please ensure the data is in the correct format.",
                                    "Warning:", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        } 
                        PopulateListView();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        // Save the current data in the queue to a .txt file.
        public void SaveFile()
        {
            Stream stream = null;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            // Default directory.
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt";
            saveFileDialog1.InitialDirectory = "T:\\Computer Science\\Year 1\\Programming 2\\Assessed Componet 2";

            // Shows a save dialog box, if the user clicks ok proceedes withe the method.
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((stream = saveFileDialog1.OpenFile()) != null)
                {
                    using (stream)
                    {
                        StreamWriter writer = new StreamWriter(stream);

                        foreach (int obj in queue)
                        {
                            writer.WriteLine(obj);
                        }
                        // Closes the streamWriter.
                        writer.Close();
                    }
                }
            }
        }

        // Takes data from the input Text box and enqueues it, also updates the listbox.
        public void Enqueue()
        {
            int input;
            if (int.TryParse(InputBox.Text, out input))
            {
                queue.Enqueue(input);
            }
            else
            {
                MessageBox.Show("You can only enqueue integer values. Please enter an integer.");
            }
            InputBox.Clear();
            PopulateListView();
        }
        #endregion

        #region Action called methods

        // Enqueues data to the queue and displays it in the listbox.
        private void EnqueueButton_Click(object sender, EventArgs e)
        {
            Enqueue();
        }

        // Runs the enqueue method from the enter key.
        private void InputBox_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                Enqueue();
            }
        }

        // Dequeues the data from the queue and displays it in the output box.
        private void DequeueButton_Click(object sender, EventArgs e)
        {
            try
            {
                outPutBox.Text = queue.Dequeue().ToString();
            }
            catch (NullReferenceException exception)
            {
                MessageBox.Show(exception.Message);
            }
            PopulateListView();
        }            

        // Loads a new queue after giving the option to save the current one.
        private void loadDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!queue.IsEmpty())
            {
                if (MessageBox.Show("Would you like to save the current queue first?",
                    "Queue Vizualiser", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SaveFile();
                }
            }
            LoadFile();
        }

        // Saves the file.
        private void saveDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (queue.IsEmpty())
            {
                if (MessageBox.Show("The current queue is empty. Are you sure you wish to save a blank file?",
                    "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SaveFile();
                }
            }
            else
            {
                SaveFile();
            }
        }

        // Exits the program.
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!queue.IsEmpty())
            {
                if (MessageBox.Show("Would you like to save the queue before quiting?",
                    "Queue Vizualiser", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SaveFile();
                }
            }
            Close();
        }

        // Creates a new instance of an empty queue. 
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!queue.IsEmpty())
            {
                if (MessageBox.Show("Would you like to save the current queue first?",
                    "Queue Vizualiser", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SaveFile();                    
                }                            
            }           
            queue = new LinkedQueue<int>();
            PopulateListView();
        }
        #endregion
    }
}
