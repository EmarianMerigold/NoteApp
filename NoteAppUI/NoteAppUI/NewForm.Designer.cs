﻿namespace NoteAppUI
{
    partial class NewForm
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
            this.SuspendLayout();
            // 
            // TitleBox
            // 
            this.TitleBox.Location = new System.Drawing.Point(69, 17);
            this.TitleBox.Name = "TitleBox";
            this.TitleBox.Size = new System.Drawing.Size(719, 20);
            this.TitleBox.TabIndex = 0;
            this.TitleBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // CategoryComboBox
            // 
            this.CategoryComboBox.FormattingEnabled = true;
            this.CategoryComboBox.Location = new System.Drawing.Point(69, 43);
            this.CategoryComboBox.Name = "CategoryComboBox";
            this.CategoryComboBox.Size = new System.Drawing.Size(172, 21);
            this.CategoryComboBox.TabIndex = 1;
            // 
            // TextBox
            // 
            this.TextBox.Location = new System.Drawing.Point(12, 93);
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
            this.LabelCreated.Location = new System.Drawing.Point(13, 74);
            this.LabelCreated.Name = "LabelCreated";
            this.LabelCreated.Size = new System.Drawing.Size(47, 13);
            this.LabelCreated.TabIndex = 5;
            this.LabelCreated.Text = "Created:";
            // 
            // NewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.LabelCreated);
            this.Controls.Add(this.LabelCategory);
            this.Controls.Add(this.LabelTitle);
            this.Controls.Add(this.TextBox);
            this.Controls.Add(this.CategoryComboBox);
            this.Controls.Add(this.TitleBox);
            this.Name = "NewForm";
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
    }
}