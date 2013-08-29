/*
*
* Copyright (C) 2011-2014 Wang Shiliang
* All rights reserved
* filename : Form1.cs
* description : The software will automatically record what the user just said. 
                The user can set the preparation time, the response time of the question. The user can select the question from the question library. 
                After the user answer the question completely, he can find the wrong pronunciation by hearing the record. It is a very good way to 
                practice the oral English.
* created by Wang Shiliang at 6/1/2011 21:19:50
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
using System.Diagnostics;

using Microsoft.DirectX;
using Microsoft.DirectX.DirectSound;
using System.IO;


namespace ToeflSpeaking
{
    public partial class Form1 : Form
    {
        private RecordS sound_record;
        private MP3Player mp3;
        private int t = 0;
        private int state = 0;
        private int first = 0;
        private int[] a;
        
        private int tempNumber = 0;
        private string[] detailLibrary;
        private string[] templateLibrary;
        
        private bool isChanged = false;
        private bool isSelected = false;
        private bool isStarted = false;
        private SecondaryBuffer buf;

        private static int perSecond = 10;
        private int allNumber = 0;
        private int allVisitedNumber = 0;

        private DataSet testedLibraryDs;
        private DataSet wholeLibraryDs;
        private SQLiteDatabase db;

        private AddData form;

        public Form1()
        {
            InitializeComponent();
            sound_record = new RecordS();
            db = new SQLiteDatabase("toeflSpeaking.sqlite");
            a = new int[1000];

            form = new AddData(this);
        }
        public int First
        {
            get { return first; }
            set { first = value; }
        }
        public Button StartSpeakingButton
        {
            get { return startSpeakingButton; }
            set { startSpeakingButton = value; }
        }

        public int AllNumber
        {
            get { return allNumber; }
            set { allNumber = value; }
        }

        public DataSet TestDs
        {
            get { return testedLibraryDs; }
            set { wholeLibraryDs = value; }
        }

        public DataSet WholeDs
        {
            get { return wholeLibraryDs; }
            set { wholeLibraryDs = value; }
        }
        
        //set the first state of the component
        private void Initialize_Sate()
        {
            //set the relavent label invisible
            prepareResponseLabel.Visible = false;
            remainTimeLabel.Visible = false;
            remainNumberLabel.Visible = false;
            timeNumberLabel.Visible = false;
            timeNumberLabel.Visible = false;
            responseTimeLabel.Visible = false;
            allResponseTimeLabel.Visible = false;
            remainResponseTimeLabel.Visible = false;
            progressBar.Visible = false;
            stopSpeakingButton.Visible = false;
            playResponseButton.Enabled = false;
            stopResponseButton.Enabled = false;
            VisitedTimesLabel.Visible = false;
            VisitedTimesNumberLabel.Visible = false;
            //set the default library button
            libraryRadioButton.Checked = true;
        }

        //the state after we select a question
        private void permitStartState()
        {
            //set the start button enabled
            startSpeakingButton.Enabled = true;
            playResponseButton.Enabled = false;
        }

        //the state after we click the start button
        private void StartButton_State()
        {
            //set the checklistbox disenabled
            questionCheckedListBox.Enabled = false;
            this.remainResponseTimeLabel.ForeColor = Color.Black;
            prepareTimeListBox.Enabled = false;
            responseTimelistBox.Enabled = false;

            //set the maximum of the progress bar
            progressBar.Minimum = 0;
            progressBar.Maximum = Convert.ToInt32(prepareTimeListBox.SelectedItem) * 100;
            progressBar.Value = 0;

            //reset the label
            prepareSpeakLabel.Visible = false;
            prepareResponseLabel.Visible = true;
            remainTimeLabel.Visible = true;
            remainNumberLabel.Visible = true;
            timeNumberLabel.Visible = true;
            progressBar.Visible = true;
            startSpeakingButton.Visible = false;
            stopSpeakingButton.Visible = true;
            detailTextbox.Text = detailLibrary[1];
            //set the button 
            stopResponseButton.Enabled = false;
            startSpeakingButton.Enabled = false;
        }

        //the state when we click the stop speaking button
        private void StopSpeakingButton_State()
        {
            //set the relavent label invisible
            prepareResponseLabel.Visible = false;
            remainTimeLabel.Visible = false;
            remainNumberLabel.Visible = false;
            timeNumberLabel.Visible = false;
            timeNumberLabel.Visible = false;
            responseTimeLabel.Visible = false;
            allResponseTimeLabel.Visible = false;
            remainResponseTimeLabel.Visible = false;
            progressBar.Visible = false;
            stopSpeakingButton.Visible = false;
            responseTimeLabel.Visible = false;
            detailTextbox.Text = detailLibrary[1];

            //reset the label
            prepareSpeakLabel.Visible = true;
            startSpeakingButton.Visible = true;

            //set the checkedlistbox enabled
            questionCheckedListBox.Enabled = true;
            prepareTimeListBox.Enabled = true;
            responseTimelistBox.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mp3 = new MP3Player();
            //set the list box
            for (int i = 1; i <= 60;++i )
            {
                prepareTimeListBox.Items.Add(i);
                responseTimelistBox.Items.Add(i);
            }
            prepareTimeListBox.SelectedItem = 15;
            responseTimelistBox.SelectedItem = 45;
            //set the component state
            Initialize_Sate();
            
            //set the timer
            this.timer1.Enabled = false;
            this.timer1.Interval = 10;
            detailLibrary = new String[4];
            templateLibrary = new String[4];

            //we read the data from database to the dataset first      
            string query1 = "select question_name from question where visited >= 1 order by number asc";
            testedLibraryDs = db.GetDataSet(query1);
            
            string query2 = "select question_name from question order by number asc";
            wholeLibraryDs = db.GetDataSet(query2);

            //get the number of the question
            string query3 = "select COUNT(*) from question";
            string[] type = new String[1];
            type[0] = "int";
            String[] stringArray = db.getReaderString(query3, type, 1);
            allNumber = Convert.ToInt32(stringArray[0]);

            //get the number of the question
            string query4 = "select COUNT(*) from question where visited >=1";
            string[] type2 = new String[1];
            type2[0] = "int";
            String[] stringArray2 = db.getReaderString(query4, type, 1);
            allVisitedNumber = Convert.ToInt32(stringArray[0]);          

            //set the checked list box
            questionCheckedListBox.DataSource = wholeLibraryDs.Tables[0].DefaultView;
            questionCheckedListBox.DisplayMember = "question_name";
        }

        //计时函数
        public string GetAllTime(int time)
        {
            string  ss;  
            int s = time / 100; // 转化为秒

            //秒格式00
            if (s < 10)
            {
                ss = "0" + s.ToString();
            }
            else
            {
                ss = s.ToString();
            }
            //返回 mm:ss           
            return  ss;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //when the state is preparing for the response
            t = t + 1;//得到总的毫秒数
            ++progressBar.Value;
            if (t % perSecond == 0)
            {
                if (state == 0)
                {
                    //this.label13.Text = (listBox1.SelectedValue).ToString();
                    int allTime = Convert.ToInt32(prepareTimeListBox.SelectedItem);
                    int passTime = Convert.ToInt32(GetAllTime(t));
                    int value = allTime - passTime;
                    this.remainNumberLabel.Text = value.ToString();
                    this.timeNumberLabel.Text = (Convert.ToInt32(prepareTimeListBox.SelectedItem)).ToString();

                    if (value == 0)
                    {
                        state = 1;
                        t = 0;
                        progressBar.Value = 0;

                        //set the record name
                        int hour = System.DateTime.Now.Hour;
                        int minute = System.DateTime.Now.Minute;
                        int second = System.DateTime.Now.Second;
                        string record_file_name = "record\\"+tempNumber+"." + hour.ToString() + "-" + minute.ToString() + "-" + second.ToString() + ".wav";
                        sound_record.SetFileName(record_file_name);
                        //record the speaking
                        sound_record.RecStart();

                        //set the relavent button enabled
                        isStarted = true;
                    }
                }

                //when the state is response the question,then we change to another state
                else if (state == 1)
                {
                    prepareResponseLabel.Visible = false;
                    remainNumberLabel.Visible = false;
                    timeNumberLabel.Visible = false;
                    responseTimeLabel.Visible = true;
                    allResponseTimeLabel.Visible = true;
                    remainResponseTimeLabel.Visible = true;
                    int allTime = Convert.ToInt32(responseTimelistBox.SelectedItem);
                    int passTime = Convert.ToInt32(GetAllTime(t));
                    int value = allTime - passTime;
                    this.allResponseTimeLabel.Text = (Convert.ToInt32(responseTimelistBox.SelectedItem)).ToString();
                    this.remainResponseTimeLabel.Text = value.ToString();
                    progressBar.Maximum = Convert.ToInt32(responseTimelistBox.SelectedItem) * 100;

                    //if we have less than 10 seconds left
                    if (value <= 10)
                    {
                        this.remainResponseTimeLabel.ForeColor = Color.Red;
                    }

                    if (value == 0)
                    {
                        state = 2;
                        timer1.Stop();
                    }
                    
                    //when the time out
                    if (state == 2)
                    {
                        MessageBox.Show("Your time has expired","Time Out");
                        progressBar.Value = 0;
                        timer1.Enabled = false;
                    }
                }
            }
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (isChanged == false)
            {
                if (e.CurrentValue == CheckState.Checked)
                {
                    e.NewValue = CheckState.Checked;
                }
                else if (e.CurrentValue == CheckState.Unchecked)
                {
                    e.NewValue = CheckState.Unchecked;
                }
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ++first;
            if(first>=3)
            {
                permitStartState();

                int number = this.questionCheckedListBox.SelectedIndex + 1;
                tempNumber = number;
                
                //we read the detail and template of the question to the string array first                   
                string query = "select place,detail,question_type,visited from question where number = " + number.ToString();
                String[] stringArray = new String[10];
                String[] type = new String[5];
                type[0] = "string";
                type[1] = "string";
                type[2] = "int";
                type[3] = "int";
                stringArray = db.getReaderString(query, type, 4);

                detailLibrary[0] = stringArray[0];
                detailLibrary[1] = stringArray[1];


                string query2 = "select place,template,question_type,visited from question where number = " + number.ToString();
                String[] stringArray2 = new String[10];
                String[] type2 = new String[5];
                type2[0] = "string";
                type2[1] = "string";
                type2[2] = "int";
                type2[3] = "int";
                stringArray2 = db.getReaderString(query2, type2, 4);
                templateLibrary[0] = stringArray2[0];
                templateLibrary[1] = stringArray2[1];

                int type3 = Convert.ToInt32(stringArray[2]);
                isSelected = true;


                //set the relevant radio button
                if (type3 == 1)
                {
                    questionRadioButton1.Checked = true;
                }
                else if(type3 == 2)
                {
                    questionRadioButton2.Checked = true;
                }
                else if(type3 == 3)
                {
                    questionRadioButton3.Checked = true;
                }
                else if(type3 == 4)
                {
                    questionRadioButton4.Checked = true;
                }
                else if(type3 == 5)
                {
                    questionRadioButton5.Checked = true;
                }
                else if(type3 == 6)
                {
                    questionRadioButton6.Checked = true;
                }
             
                //set the relevant combo box
                mp3.FilePath = detailLibrary[0];

                //play the mp3 file  
                if (ignoreRespondcheckBox.Checked == false)
                {
                    mp3.Play();
                }
                //display the detail of the question
                detailTextbox.Text = detailLibrary[1];
            }
        }

        //if we select the question test in the past radio button
        private void TestedRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            questionCheckedListBox.DataSource = testedLibraryDs.Tables[0].DefaultView;
            questionCheckedListBox.DisplayMember = "question_name";
            VisitedTimesLabel.Visible = true;
            VisitedTimesNumberLabel.Visible = true;
            //VisitedTimesNumberLabel.Text = templateLibrary[3];
        }

        //if we select the whole ETS library radio button
        private void libraryRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            questionCheckedListBox.DataSource = wholeLibraryDs.Tables[0].DefaultView;
            questionCheckedListBox.DisplayMember = "question_name";
            VisitedTimesNumberLabel.Visible = false;
            VisitedTimesLabel.Visible = false;
        }


        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            detailTextbox.Clear();
            detailTextbox.Text = detailLibrary[1];
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            detailTextbox.Clear();
            detailTextbox.Text = templateLibrary[1];
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            detailTextbox.Clear();
        }

        private void ignoreRespondcheckBox_CheckedChanged(object sender, EventArgs e)
        {
            mp3.Stop();
        }

        //when we click the stop response button
        private void StopResponse_Click(object sender, EventArgs e)
        {
            buf.Stop();
            stopResponseButton.Enabled = false;
            questionCheckedListBox.Enabled = true;
        }


        //when we click the play response button
        private void playButton_Click(object sender, EventArgs e)
        {
            // DirectX方式播放音乐，但只能播放.wav文件
            Device dv = new Device();
            dv.SetCooperativeLevel(this, CooperativeLevel.Priority);
            string filePath = sound_record.getFileName();
            buf = new SecondaryBuffer(@filePath, dv);
            buf.Play(0, BufferPlayFlags.Default);
            stopResponseButton.Enabled = true;
            questionCheckedListBox.Enabled = false;
        }

        //when we click the next question button
        private void nextQuestionButton_Click(object sender, EventArgs e)
        {
            if (tempNumber < allNumber - 1 && libraryRadioButton.Checked == true)
            {
                this.questionCheckedListBox.SetSelected(tempNumber + 1, true);
            }
            else if (tempNumber < allVisitedNumber - 1 && testedRadioButton.Checked == true)
            {
                this.questionCheckedListBox.SetSelected(tempNumber + 1, true);
            }
        }

        //when we click the stop speaking button
        private void StopSpeakingButton_Click(object sender, EventArgs e)
        {
            isSelected = false;

            //change the state
            StopSpeakingButton_State();
            
            //stop the timer
            timer1.Stop();
            timer1.Enabled = false;
            if (isStarted == true)
            {
                sound_record.RecStop();
                isStarted = false;
                playResponseButton.Enabled = true;
            }
            t = 0;

            //save the question that has been answered make the relavent checklistbox item selected
            isChanged = true;
            questionCheckedListBox.SetItemChecked(tempNumber, true);
            isChanged = false;

            //save the question to the database            
            //We set the relevant question 
            int number = tempNumber;
            string query = "update question set visited = visited + 1 where number = " + number.ToString();
            db.ExecuteScalar(query);
        }

        //After we click the start button
        private void startSpeakingButton_Click(object sender, EventArgs e)
        {
            //if we haven't set the preparation time and the response time, pop up a dialog
            if (prepareTimeListBox.SelectedItems.Count == 0 || responseTimelistBox.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please set the time", "Warning");
                return;
            }

            //if we haven't select one item, pop up an dialog
            if (isSelected == false || tempNumber == 0)
            {
                MessageBox.Show("Please select a question", "Warning");
                return;
            }

            StartButton_State();

            //set the timer
            this.timer1.Enabled = true;
            timer1.Start();
            state = 0;

            //if we have select a file, and we set the responded question, then:
            if (mp3.FilePath != "" && ignoreRespondcheckBox.Checked == false)
            {
                //stop the current mp3 playing
                mp3.FilePath = "mp3\\temp.mp3";
                mp3.Play();
            }        
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void AddLibrary_Click(object sender, EventArgs e)
        {
            this.Hide();
            form.Show(); 
        }   
    }
}
