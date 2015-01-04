/*
*
* Copyright (C) 2011-2014 Wang Shiliang
* All rights reserved
* filename : AddData.Designer.cs
* description : This file shows the user interface of the following fuctions:
								The user can add the new questions to the database. 
                The user need to input the type of the question, the name of the question, the question detail, the question template and
                the path of the video file of the question. 
                THe user can also look up the datebase of the all the questions. 
* created by Wang Shiliang at 6/2/2011 21:19:50
*
*/

namespace ToeflPractice
{
    partial class AddData
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
            this.typeSelectListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.detailTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.browseButton = new System.Windows.Forms.Button();
            this.mp3PathTextBox = new System.Windows.Forms.TextBox();
            this.exitButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.templateTextBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.createNewButton = new System.Windows.Forms.Button();
            this.ChangeButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // typeSelectListBox
            // 
            this.typeSelectListBox.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.typeSelectListBox.FormattingEnabled = true;
            this.typeSelectListBox.ItemHeight = 21;
            this.typeSelectListBox.Location = new System.Drawing.Point(274, 17);
            this.typeSelectListBox.Margin = new System.Windows.Forms.Padding(4);
            this.typeSelectListBox.Name = "typeSelectListBox";
            this.typeSelectListBox.Size = new System.Drawing.Size(92, 25);
            this.typeSelectListBox.Sorted = true;
            this.typeSelectListBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(26, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Input the type of the question:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(26, 54);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(197, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Input the question name:";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameTextBox.Location = new System.Drawing.Point(31, 78);
            this.nameTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.nameTextBox.Multiline = true;
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.nameTextBox.Size = new System.Drawing.Size(489, 74);
            this.nameTextBox.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(27, 167);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(200, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Input the question detail:";
            // 
            // detailTextBox
            // 
            this.detailTextBox.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detailTextBox.Location = new System.Drawing.Point(32, 193);
            this.detailTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.detailTextBox.Multiline = true;
            this.detailTextBox.Name = "detailTextBox";
            this.detailTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.detailTextBox.Size = new System.Drawing.Size(488, 155);
            this.detailTextBox.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(26, 611);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Set the path of mp3";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // browseButton
            // 
            this.browseButton.BackColor = System.Drawing.Color.LightGreen;
            this.browseButton.Font = new System.Drawing.Font("Georgia", 10.5F);
            this.browseButton.Location = new System.Drawing.Point(440, 609);
            this.browseButton.Margin = new System.Windows.Forms.Padding(4);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(77, 29);
            this.browseButton.TabIndex = 9;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = false;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // mp3PathTextBox
            // 
            this.mp3PathTextBox.Font = new System.Drawing.Font("Arial Unicode MS", 9F);
            this.mp3PathTextBox.Location = new System.Drawing.Point(189, 609);
            this.mp3PathTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.mp3PathTextBox.Name = "mp3PathTextBox";
            this.mp3PathTextBox.Size = new System.Drawing.Size(243, 28);
            this.mp3PathTextBox.TabIndex = 8;
            // 
            // exitButton
            // 
            this.exitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.exitButton.Font = new System.Drawing.Font("Georgia", 10.5F);
            this.exitButton.Location = new System.Drawing.Point(428, 659);
            this.exitButton.Margin = new System.Windows.Forms.Padding(4);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(77, 34);
            this.exitButton.TabIndex = 11;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(27, 362);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(224, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "Input the question template:";
            // 
            // templateTextBox
            // 
            this.templateTextBox.Font = new System.Drawing.Font("Arial Unicode MS", 9F);
            this.templateTextBox.Location = new System.Drawing.Point(31, 387);
            this.templateTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.templateTextBox.Multiline = true;
            this.templateTextBox.Name = "templateTextBox";
            this.templateTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.templateTextBox.Size = new System.Drawing.Size(486, 205);
            this.templateTextBox.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Location = new System.Drawing.Point(540, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(780, 625);
            this.panel1.TabIndex = 12;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 20;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(780, 625);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_RowHeaderMouseClick);
            // 
            // createNewButton
            // 
            this.createNewButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.createNewButton.Font = new System.Drawing.Font("Georgia", 10.5F);
            this.createNewButton.Location = new System.Drawing.Point(1097, 661);
            this.createNewButton.Margin = new System.Windows.Forms.Padding(4);
            this.createNewButton.Name = "createNewButton";
            this.createNewButton.Size = new System.Drawing.Size(102, 32);
            this.createNewButton.TabIndex = 11;
            this.createNewButton.Text = "Create new";
            this.createNewButton.UseVisualStyleBackColor = false;
            this.createNewButton.Click += new System.EventHandler(this.createNewButton_Click);
            // 
            // ChangeButton
            // 
            this.ChangeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.ChangeButton.Font = new System.Drawing.Font("Georgia", 10.5F);
            this.ChangeButton.Location = new System.Drawing.Point(68, 659);
            this.ChangeButton.Margin = new System.Windows.Forms.Padding(4);
            this.ChangeButton.Name = "ChangeButton";
            this.ChangeButton.Size = new System.Drawing.Size(89, 34);
            this.ChangeButton.TabIndex = 10;
            this.ChangeButton.Text = "Change";
            this.ChangeButton.UseVisualStyleBackColor = false;
            this.ChangeButton.Click += new System.EventHandler(this.changeButton_Click);
            // 
            // addButton
            // 
            this.addButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.addButton.Font = new System.Drawing.Font("Georgia", 10.5F);
            this.addButton.Location = new System.Drawing.Point(69, 660);
            this.addButton.Margin = new System.Windows.Forms.Padding(4);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(88, 34);
            this.addButton.TabIndex = 10;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = false;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // AddData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(230)))));
            this.ClientSize = new System.Drawing.Size(1348, 721);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.mp3PathTextBox);
            this.Controls.Add(this.createNewButton);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.ChangeButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.templateTextBox);
            this.Controls.Add(this.detailTextBox);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.typeSelectListBox);
            this.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Bold);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "AddData";
            this.Text = "Add Data";
            this.Load += new System.EventHandler(this.AddData_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox typeSelectListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox detailTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.TextBox mp3PathTextBox;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox templateTextBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button createNewButton;
        private System.Windows.Forms.Button ChangeButton;
        private System.Windows.Forms.Button addButton;

    }
}