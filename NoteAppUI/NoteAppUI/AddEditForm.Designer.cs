namespace NoteAppUI
{
    partial class AddEditForm
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
            this.TitleBox = new System.Windows.Forms.TextBox();
            this.CategoryComboBox = new System.Windows.Forms.ComboBox();
            this.TextBox = new System.Windows.Forms.TextBox();
            this.LabelTitle = new System.Windows.Forms.Label();
            this.LabelCategory = new System.Windows.Forms.Label();
            this.LabelCreated = new System.Windows.Forms.Label();
            this.ModifiedLabel = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.OkButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TitleBox
            // 
            this.TitleBox.Location = new System.Drawing.Point(69, 17);
            this.TitleBox.Name = "TitleBox";
            this.TitleBox.Size = new System.Drawing.Size(719, 20);
            this.TitleBox.TabIndex = 0;
            this.TitleBox.TextChanged += new System.EventHandler(this.TitleBox_TextChanged);
            // 
            // CategoryComboBox
            // 
            this.CategoryComboBox.FormattingEnabled = true;
            this.CategoryComboBox.Location = new System.Drawing.Point(69, 43);
            this.CategoryComboBox.Name = "CategoryComboBox";
            this.CategoryComboBox.Size = new System.Drawing.Size(172, 21);
            this.CategoryComboBox.TabIndex = 1;
            this.CategoryComboBox.SelectedIndexChanged += new System.EventHandler(this.CategoryComboBox_SelectedIndexChanged);
            // 
            // TextBox
            // 
            this.TextBox.Location = new System.Drawing.Point(12, 96);
            this.TextBox.Multiline = true;
            this.TextBox.Name = "TextBox";
            this.TextBox.Size = new System.Drawing.Size(776, 312);
            this.TextBox.TabIndex = 2;
            this.TextBox.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // LabelTitle
            // 
            this.LabelTitle.AutoSize = true;
            this.LabelTitle.Location = new System.Drawing.Point(12, 20);
            this.LabelTitle.Name = "LabelTitle";
            this.LabelTitle.Size = new System.Drawing.Size(30, 13);
            this.LabelTitle.TabIndex = 3;
            this.LabelTitle.Text = "Title:";
            // 
            // LabelCategory
            // 
            this.LabelCategory.AutoSize = true;
            this.LabelCategory.Location = new System.Drawing.Point(12, 46);
            this.LabelCategory.Name = "LabelCategory";
            this.LabelCategory.Size = new System.Drawing.Size(52, 13);
            this.LabelCategory.TabIndex = 4;
            this.LabelCategory.Text = "Category:";
            // 
            // LabelCreated
            // 
            this.LabelCreated.AutoSize = true;
            this.LabelCreated.Location = new System.Drawing.Point(12, 72);
            this.LabelCreated.Name = "LabelCreated";
            this.LabelCreated.Size = new System.Drawing.Size(47, 13);
            this.LabelCreated.TabIndex = 5;
            this.LabelCreated.Text = "Created:";
            // 
            // ModifiedLabel
            // 
            this.ModifiedLabel.AutoSize = true;
            this.ModifiedLabel.Location = new System.Drawing.Point(225, 72);
            this.ModifiedLabel.Name = "ModifiedLabel";
            this.ModifiedLabel.Size = new System.Drawing.Size(50, 13);
            this.ModifiedLabel.TabIndex = 6;
            this.ModifiedLabel.Text = "Modified:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(69, 70);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(137, 20);
            this.dateTimePicker1.TabIndex = 7;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(281, 70);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(141, 20);
            this.dateTimePicker2.TabIndex = 8;
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // OkButton
            // 
            this.OkButton.Location = new System.Drawing.Point(632, 415);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 9;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(713, 415);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 10;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // AddEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.ModifiedLabel);
            this.Controls.Add(this.LabelCreated);
            this.Controls.Add(this.LabelCategory);
            this.Controls.Add(this.LabelTitle);
            this.Controls.Add(this.TextBox);
            this.Controls.Add(this.CategoryComboBox);
            this.Controls.Add(this.TitleBox);
            this.Name = "AddEditForm";
            this.Text = "Add/Edit Note";
            this.Load += new System.EventHandler(this.NewForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TitleBox;
        private System.Windows.Forms.ComboBox CategoryComboBox;
        private System.Windows.Forms.TextBox TextBox;
        private System.Windows.Forms.Label LabelTitle;
        private System.Windows.Forms.Label LabelCategory;
        private System.Windows.Forms.Label LabelCreated;
        private System.Windows.Forms.Label ModifiedLabel;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button CancelButton;
    }
}