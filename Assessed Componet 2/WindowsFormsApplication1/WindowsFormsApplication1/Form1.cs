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

        public Form1()
        {
            InitializeComponent();
        }

        LinkedQueue<int> queue = new LinkedQueue<int>();

        // Displays each item in the queue as a ListViewItem in the ListView.
        private void PopulateListView()
        {
            bool isFirst = true;
            listView1.Items.Clear();
            foreach (int obj in queue)
            {
                string[] s = new string[1];
                s[0] = obj.ToString();
                ListViewItem item;

                if (isFirst)
                {                    
                    item = new ListViewItem(s, 0, Color.White, Color.Blue, this.Font);                    
                }
                else
                {                    
                    item = new ListViewItem(s, 0, Color.Black, Color.White, this.Font);
                }
                listView1.Items.Add(item);
                isFirst = false;
            }
        }

        // Enqueues data to the queue and displays it in the listbox.
        private void EnqueueButton_Click(object sender, EventArgs e)
        {
            int input;
            if (int.TryParse(InputBox.Text, out input))
            {
                queue.Enqueue(input);
            }
            else
            {
                MessageBox.Show("You can only enque integer values. Please enter an integer.");
            }
            InputBox.Clear();
            PopulateListView();
        }

        // Runs the enqueue method from the enter key.
        private void InputBox_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                int input;
                if (int.TryParse(InputBox.Text, out input))
                {
                    queue.Enqueue(input);
                }
                else
                {
                    MessageBox.Show("You can only enque integer values. Please enter an integer.");
                }
                InputBox.Clear();
                PopulateListView();
            }
        }

        // Dequeues the data from the queue and displays it in the output box.
        private void DequeueButton_Click(object sender, EventArgs e)
        {
            try
            {
                outPutBox.Text = queue.Dequeue().ToString();
                //listBox1.Items.RemoveAt(0);
            }
            catch (NullReferenceException exception)
            {
                MessageBox.Show(exception.Message);
            }
            PopulateListView();
        }            

        // Loads a queue of ints from a .txt file. The data must be deliminated by carriage returns.
        private void loadDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream stream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "T:\\Computer Science\\Year 1\\Programming 2\\Assessed Componet 2";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt" ;            

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((stream = openFileDialog1.OpenFile()) != null)
                    {
                        using (stream)
                        {
                            StreamReader reader = new StreamReader(stream);
                            queue = new LinkedQueue<int>();
                            string dataIn;
                            do
                            {
                                dataIn = reader.ReadLine();
                                int currentInt;
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
                                    MessageBox.Show("Some of the data from the file could not be read.\n Please ensure the data is in the correct format.", "Warning: ");
                                }
                            }
                            while (dataIn != null);
                            // Close the streamReader.
                            reader.Close();
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
        private void saveDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream stream = null;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt";
            saveFileDialog1.InitialDirectory = "T:\\Computer Science\\Year 1\\Programming 2\\Assessed Componet 2";
            
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

        // Exits the program.
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            queue = new LinkedQueue<int>();
            PopulateListView();
        }
    }
}
