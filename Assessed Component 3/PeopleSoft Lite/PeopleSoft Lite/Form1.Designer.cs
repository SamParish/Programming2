namespace SoftPeople_Lite
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.studentCheckbox = new System.Windows.Forms.CheckBox();
            this.staffCheckbox = new System.Windows.Forms.CheckBox();
            this.resultsListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.infoLabel1 = new System.Windows.Forms.Label();
            this.criteriaComboBox = new System.Windows.Forms.ComboBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.detailsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // studentCheckbox
            // 
            this.studentCheckbox.AutoSize = true;
            this.studentCheckbox.Location = new System.Drawing.Point(19, 130);
            this.studentCheckbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.studentCheckbox.Name = "studentCheckbox";
            this.studentCheckbox.Size = new System.Drawing.Size(79, 21);
            this.studentCheckbox.TabIndex = 0;
            this.studentCheckbox.Text = "Student";
            this.studentCheckbox.UseVisualStyleBackColor = true;
            // 
            // staffCheckbox
            // 
            this.staffCheckbox.AutoSize = true;
            this.staffCheckbox.Location = new System.Drawing.Point(104, 130);
            this.staffCheckbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.staffCheckbox.Name = "staffCheckbox";
            this.staffCheckbox.Size = new System.Drawing.Size(59, 21);
            this.staffCheckbox.TabIndex = 1;
            this.staffCheckbox.Text = "Staff";
            this.staffCheckbox.UseVisualStyleBackColor = true;
            // 
            // resultsListBox
            // 
            this.resultsListBox.FormattingEnabled = true;
            this.resultsListBox.ItemHeight = 16;
            this.resultsListBox.Location = new System.Drawing.Point(277, 50);
            this.resultsListBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.resultsListBox.Name = "resultsListBox";
            this.resultsListBox.Size = new System.Drawing.Size(215, 116);
            this.resultsListBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Moire", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(101, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(288, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Welcome to SoftPeople Query Centre";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(16, 102);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(223, 22);
            this.textBox1.TabIndex = 4;
            // 
            // infoLabel1
            // 
            this.infoLabel1.AutoSize = true;
            this.infoLabel1.Location = new System.Drawing.Point(13, 50);
            this.infoLabel1.Name = "infoLabel1";
            this.infoLabel1.Size = new System.Drawing.Size(226, 17);
            this.infoLabel1.TabIndex = 5;
            this.infoLabel1.Text = "Please enter search criteria below:";
            // 
            // criteriaComboBox
            // 
            this.criteriaComboBox.FormattingEnabled = true;
            this.criteriaComboBox.Items.AddRange(new object[] {
            "Name",
            "Identification Number"});
            this.criteriaComboBox.Location = new System.Drawing.Point(16, 71);
            this.criteriaComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.criteriaComboBox.Name = "criteriaComboBox";
            this.criteriaComboBox.Size = new System.Drawing.Size(223, 24);
            this.criteriaComboBox.TabIndex = 6;
            this.criteriaComboBox.Text = "Search by...";
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(16, 175);
            this.searchButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(108, 46);
            this.searchButton.TabIndex = 7;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(131, 175);
            this.resetButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(108, 46);
            this.resetButton.TabIndex = 8;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // detailsButton
            // 
            this.detailsButton.Location = new System.Drawing.Point(277, 175);
            this.detailsButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.detailsButton.Name = "detailsButton";
            this.detailsButton.Size = new System.Drawing.Size(215, 46);
            this.detailsButton.TabIndex = 9;
            this.detailsButton.Text = "Open Details Window";
            this.detailsButton.UseVisualStyleBackColor = true;
            this.detailsButton.Click += new System.EventHandler(this.detailsButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 251);
            this.Controls.Add(this.detailsButton);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.criteriaComboBox);
            this.Controls.Add(this.infoLabel1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.resultsListBox);
            this.Controls.Add(this.staffCheckbox);
            this.Controls.Add(this.studentCheckbox);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "SoftPeople Lite";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox studentCheckbox;
        private System.Windows.Forms.CheckBox staffCheckbox;
        private System.Windows.Forms.ListBox resultsListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label infoLabel1;
        private System.Windows.Forms.ComboBox criteriaComboBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Button detailsButton;
    }
}

