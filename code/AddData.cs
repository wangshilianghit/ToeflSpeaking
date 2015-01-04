/*
*
* Copyright (C) 2011-2014 Wang Shiliang
* All rights reserved
* filename : AddData.cs
* description : The user can add the new questions to the database. 
                The user need to input the type of the question, the name of the question, the question detail, the question template and
                the path of the video file of the question. 
                THe user can also look up the datebase of the all the questions. 
* created by Wang Shiliang at 6/2/2011 21:19:50
*
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace ToeflPractice
{
    public partial class AddData : Form
    {
        private MainForm parent = null;
        private int questionNumber = 0;

        private DataSet questionDs;
        private SQLiteDatabase db;

        public AddData(MainForm form)
        {
            parent = form;  
            InitializeComponent();
            db = new SQLiteDatabase("toeflSpeaking.sqlite");     
        }

        private string CleanInput(string strIn)
        {
            // Replace invalid characters with empty strings. 
            return Regex.Replace(strIn, @"\'", "\""); 
        }

        private void UpdateDS()
        {
            string query = "select number, question_type, question_name, visited, detail, template, place from question order by number asc";
            questionDs = db.GetDataSet(query);
            this.dataGridView1.DataSource = questionDs.Tables[0].DefaultView;

            //Change cell font
            int columnNumber = 1;
            foreach (DataGridViewColumn c in this.dataGridView1.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Arial Unicode MS", 9F);
                if (columnNumber == 1)
                    c.Width = 80;
                else if (columnNumber == 2)
                    c.Width = 80;
                else if (columnNumber == 3)
                    c.Width = 518;
                else if (columnNumber == 4)
                    c.Width = 80;
                else
                    c.Width = 0;
                ++columnNumber;
            }
        }

        private void UpdateParentDS()
        {
            //we read the data from database to the dataset first      
            string query1 = "select question_name from question where visited >= 1 order by number asc";
            parent.TestDs = db.GetDataSet(query1);

            string query2 = "select question_name from question order by number asc";
            parent.WholeDs = db.GetDataSet(query2);


            parent.StartSpeakingButton.Enabled = false;
        }

        private void clearText()
        {
            nameTextBox.Clear();
            detailTextBox.Clear();
            templateTextBox.Clear();
            mp3PathTextBox.Clear();
        }

        private void AddData_Load(object sender, EventArgs e)
        {
            //set the list box
            for (int i = 1; i <= 6; ++i)
            {
                typeSelectListBox.Items.Add(i);
            }
            typeSelectListBox.SelectedItem = 1;

            //Update the Dataset
            UpdateDS();

            //get the question number
            string query = "select COUNT(*) from question";
            questionNumber = Int32.Parse(db.ExecuteScalar(query));

            //set the relevant button disabled
            ChangeButton.Visible = false;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
            UpdateParentDS();
            parent.Show();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < questionNumber)
            {
                questionNumber = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                typeSelectListBox.SelectedItem = dataGridView1.Rows[e.RowIndex].Cells[1].Value;
                nameTextBox.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                detailTextBox.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                templateTextBox.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                mp3PathTextBox.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                ChangeButton.Visible = true;
                addButton.Visible = false;
            }
        }

        //after we click the add button
        private void addButton_Click(object sender, EventArgs e)
        {
            ++questionNumber;
            //We insert the question to the database
            string question_type = typeSelectListBox.SelectedItem.ToString();
            string question_name = CleanInput(nameTextBox.Text);
            string detail = CleanInput(detailTextBox.Text);
            string template = CleanInput(templateTextBox.Text);
            string place = mp3PathTextBox.Text;
            if (question_type == "" || question_name == "" || detail == "" || template == "")
            {
                MessageBox.Show("Content not completed", "Warning");
                return;
            }

            string query = "insert into question(question_type,question_name,detail,template,place,number,visited) values('" + question_type + "','" + question_name + "','" + detail + "','" + template + "','" + place + "','" + questionNumber.ToString() + "',0)";
            db.ExecuteNonQuery(query);
            MessageBox.Show("Add Successful", "Sucess");

            UpdateDS();

            (parent.AllNumber)++;
            clearText();
        }
 
        private void createNewButton_Click(object sender, EventArgs e)
        {
            typeSelectListBox.SelectedItem = 1;
            clearText();
            ChangeButton.Visible = false;
            addButton.Visible = true;
        }

        //After we click the change button
        private void changeButton_Click(object sender, EventArgs e)
        {
            int question_type = Convert.ToInt32(typeSelectListBox.SelectedItem);
            string name = CleanInput(nameTextBox.Text);
            string detail = CleanInput(detailTextBox.Text);
            string template = CleanInput(templateTextBox.Text);
            string path = mp3PathTextBox.Text;

            string query = "update question set question_type = "+ question_type.ToString()+",question_name = '"+name+"',detail = '"+detail+"',template = '"+template+"',place = '"+path+"'" + "where number = "+ questionNumber.ToString();
            db.ExecuteNonQuery(query);

            typeSelectListBox.SelectedItem = 1;
            
            ChangeButton.Visible = false;
            addButton.Visible = true;
            MessageBox.Show("Change success","Message");

            UpdateDS();
            clearText();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            string query = "delete question where number = "+ questionNumber.ToString();
            db.ExecuteNonQuery(query);

            ChangeButton.Visible = false;
            addButton.Visible = true;
            MessageBox.Show("Delete success", "Message");

            UpdateDS();
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = "C:\\";
            dlg.Filter = "mp3文件|*.mp3";
            dlg.RestoreDirectory = true;
            dlg.FilterIndex = 1;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                mp3PathTextBox.Text = dlg.FileName;
            } 
        }
    }
}
