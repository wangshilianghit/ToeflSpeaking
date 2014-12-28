/*
*
* Copyright (C) 2011-2014 Wang Shiliang
* All rights reserved
* filename : MainForm.cs
* description : The software will automatically record what the user just said. 
                The user can set the preparation time, the response time of the question. The user can select the question from the question library. 
                After the user answer the question completely, he can find the wrong pronunciation by hearing the record. It is a very good way to 
                practice the oral English.
* created by Shiliang Wang at 6/1/2011 21:19:50
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
using System.IO;
using NAudio.Wave;


namespace ToeflSpeaking
{
    public partial class MainForm : Form
    {
        private int tickCount = 0;
        private int curState = 0;    

        private int responseTime;
        private int prepTime;
        
        private int curQuestionNumber = 0;     //This variable used to store the actual number of question (not index) the user select. 
        private string[] detailLibrary;
        private string[] templateLibrary;
        
        private bool isSelected = false;       //Mark whether the user has select a question
   
        private int totalQuestionNum = 0;
        private int allVisitedNumber = 0;

        private DataSet testedLibraryDs;
        private DataSet wholeLibraryDs;
        private SQLiteDatabase db;

        private string directoryPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Toefl Speaking Practice\\Record");

        private AddData addDataForm;

        private WaveFileReader waveReader = null;

        private DirectSoundOut outputSound = null;

        private WaveIn waveSource = null;

        private WaveFileWriter waveFile = null;

        private String recordFileName = "";

        private const int TICKER_INTERVAL_MILLISECONDS = 200;    //The number of milliseconds that the ticker got triggered.
        
        private const int REFRESH_INTERVAL_MILLISECONDS = 200;  //The number of milliseconds that the GUI got refreshed. 

        public MainForm()
        {
            InitializeComponent();
            db = new SQLiteDatabase("toeflSpeaking.sqlite");

            //Create program record folder if doesn't exit.
            if (!Directory.Exists(directoryPath))
            {
                System.IO.Directory.CreateDirectory(directoryPath);
            }

            addDataForm = new AddData(this);
        }

        public Button StartSpeakingButton
        {
            get { return startSpeakingButton; }
            set { startSpeakingButton = value; }
        }

        public int AllNumber
        {
            get { return totalQuestionNum; }
            set { totalQuestionNum = value; }
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
        
        /*
            State 0: Default state after starting the program.
        */
        private void InitializeState()
        {
            curState = 0;
            //set the relavent label invisible
            prepareResponseLabel.Visible = false;
            remainTimeLabel.Visible = false;
            remainNumberLabel.Visible = false;
            timeNumberLabel.Visible = false;
            timeNumberLabel.Visible = false;
            responseTimeLabel.Visible = false;
            allResponseNumberLabel.Visible = false;
            remainResponseNumberLabel.Visible = false;
            progressBar.Visible = false;
            stopSpeakingButton.Visible = false;
            playResponseButton.Enabled = false;
            stopResponseButton.Enabled = false;
            VisitedTimesLabel.Visible = false;
            VisitedTimesNumberLabel.Visible = false;
            questionRadioButton1.Enabled = false;
            questionRadioButton2.Enabled = false;
            questionRadioButton3.Enabled = false;
            questionRadioButton4.Enabled = false;
            questionRadioButton5.Enabled = false;
            questionRadioButton6.Enabled = false;
            //set the default library button
            libraryRadioButton.Checked = true;
            DescriptionRadioButton.Select();
        }

        /*
         * State 1: After we select one question from the default state.
        */
        private void SelectQuestionState()
        {
            curState = 1;
            //set the start button enabled
            startSpeakingButton.Enabled = true;

            playResponseButton.Enabled = false;
            stopResponseButton.Enabled = false;
        }

        /*
         * State 2 -> State 1: After we click stop speaking button before it starts recording.
        */
        private void stopSpeakingState()
        {
            curState = 1;

            //set the relavent label invisible     
            prepareResponseLabel.Visible = false;
            remainTimeLabel.Visible = false;
            remainNumberLabel.Visible = false;
            timeNumberLabel.Visible = false;
            timeNumberLabel.Visible = false;
            responseTimeLabel.Visible = false;
            allResponseNumberLabel.Visible = false;
            remainResponseNumberLabel.Visible = false;
            progressBar.Visible = false;
            responseTimeLabel.Visible = false;
            stopSpeakingButton.Visible = false;

            prepareSpeakLabel.Visible = true;
            startSpeakingButton.Visible = true;

            //set the checkedlistbox enabled
            questionCheckedListBox.Enabled = true;
            prepTimeListBox.Enabled = true;
            rspTimelistBox.Enabled = true;
            startSpeakingButton.Enabled = true;

            isSelected = true;

            //stop the timer
            timer.Stop();
            timer.Enabled = false;

            tickCount = 0;
        }

        /*
         * State 1 -> State 2: After we click the start response button from State 1.
        */ 
        private void StartButtonState()
        {
            curState = 2;

            prepTime = Convert.ToInt32(prepTimeListBox.SelectedItem);
            responseTime = Convert.ToInt32(rspTimelistBox.SelectedItem);

            questionCheckedListBox.Enabled = false;
            prepTimeListBox.Enabled = false;
            rspTimelistBox.Enabled = false;

            //set the maximum of the progress bar
            progressBar.Minimum = 0;
            progressBar.Maximum = prepTime * 1000 / TICKER_INTERVAL_MILLISECONDS;
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
            startSpeakingButton.Enabled = false;

            timeNumberLabel.Text = (prepTime).ToString();

            //set the timer
            this.timer.Enabled = true;
            timer.Start();

            tickCount = 0;
        }

        /*
         *  State 2 -> State 3: The state after the prepare time in state 2.
         *  TODO:
        */
        private void StartRecordingState()
        {
            curState = 3;

            prepareResponseLabel.Visible = false;
            remainNumberLabel.Visible = false;
            timeNumberLabel.Visible = false;
            responseTimeLabel.Visible = true;
            allResponseNumberLabel.Visible = true;
            remainResponseNumberLabel.Visible = true;
            remainResponseNumberLabel.ForeColor = Color.Black;

            int passTime = Convert.ToInt32(GetSeconds(tickCount));
            int remainTime = responseTime - passTime;
            allResponseNumberLabel.Text = (responseTime).ToString();
            remainResponseNumberLabel.Text = remainTime.ToString();
            progressBar.Maximum = responseTime * 1000 / TICKER_INTERVAL_MILLISECONDS;

            tickCount = 0;
            progressBar.Value = 0;

            //set the record name
            int hour = System.DateTime.Now.Hour;
            int minute = System.DateTime.Now.Minute;
            int second = System.DateTime.Now.Second;
            recordFileName = directoryPath + "\\" +  hour.ToString() + "h-" + minute.ToString() + "m-" + second.ToString() + "s.wav";

            //record the speaking
            waveSource = new WaveIn();
            waveSource.WaveFormat = new WaveFormat(44100, 1);
            waveSource.DataAvailable += new EventHandler<WaveInEventArgs>(waveSource_DataAvailable);
            waveSource.RecordingStopped += new EventHandler<StoppedEventArgs>(waveSouce_RecordingStopped);

            waveFile = new WaveFileWriter(recordFileName, waveSource.WaveFormat);
            waveSource.StartRecording();
        }

        private void waveSource_DataAvailable(object sender, WaveInEventArgs e)
        {
            if (waveFile != null)
            {
                waveFile.Write(e.Buffer, 0, e.BytesRecorded);
                waveFile.Flush();
            }
        }

        private void waveSouce_RecordingStopped(object sender, StoppedEventArgs e)
        {
            DisposeWave();
        }

        /* 
         *  State 3 -> State 4: When we click the stop speaking button from State 3.
        */
        private void StopResponseState()
        {
            curState = 4;
            //set the relavent label invisible
            prepareResponseLabel.Visible = false;
            remainTimeLabel.Visible = false;
            remainNumberLabel.Visible = false;
            timeNumberLabel.Visible = false;
            timeNumberLabel.Visible = false;
            responseTimeLabel.Visible = false;
            allResponseNumberLabel.Visible = false;
            remainResponseNumberLabel.Visible = false;
            progressBar.Visible = false;
            stopSpeakingButton.Visible = false;
            responseTimeLabel.Visible = false;
            detailTextbox.Text = detailLibrary[1];

            //reset the label
            prepareSpeakLabel.Visible = true;
            startSpeakingButton.Visible = true;

            //set the checkedlistbox enabled
            questionCheckedListBox.Enabled = true;
            prepTimeListBox.Enabled = true;
            rspTimelistBox.Enabled = true;

            DescriptionRadioButton.Select();

            isSelected = false;

            waveSource.StopRecording();
            DisposeWave();
            playResponseButton.Enabled = true;

            //stop the timer
            timer.Stop();
            timer.Enabled = false;
    
            tickCount = 0;

            //save the question that has been answered make the relavent checklistbox item selected
            questionCheckedListBox.SetItemChecked(curQuestionNumber-1, true);

            //save the question to the database            
            int number = curQuestionNumber;
            string query = "update question set visited = visited + 1 where number = " + number.ToString();
            db.ExecuteScalar(query);
        }

        //This function is called when the MainForm is loading.    
        private void MainForm_Load(object sender, EventArgs e)
        {
            //set the list box
            for (int i = 1; i <= 60;++i )
            {
                prepTimeListBox.Items.Add(i);
                rspTimelistBox.Items.Add(i);
            }
            prepTimeListBox.SelectedItem = 15;
            rspTimelistBox.SelectedItem = 45;
            //set the component state
            InitializeState();
            
            //set the timer
            this.timer.Enabled = false;
            this.timer.Interval = TICKER_INTERVAL_MILLISECONDS;    
 
            detailLibrary = new String[4];
            templateLibrary = new String[4];

            //we read the data from database to the dataset first      
            string query1 = "select question_name from question where visited >= 1 order by number asc";
            testedLibraryDs = db.GetDataSet(query1);
            
            string query2 = "select question_name from question order by number asc";
            wholeLibraryDs = db.GetDataSet(query2);

            //get the number of all the questions from the database.
            string query3 = "select COUNT(*) from question";
            string[] typeArray = new String[1];
            typeArray[0] = "int";
            String[] questionArray = db.getReaderString(query3, typeArray, 1);
            totalQuestionNum = Convert.ToInt32(questionArray[0]);

            //get the number of the question
            string query4 = "select COUNT(*) from question where visited >=1";
            string[] type2 = new String[1];
            type2[0] = "int";
            String[] stringArray2 = db.getReaderString(query4, typeArray, 1);
            allVisitedNumber = Convert.ToInt32(questionArray[0]);          

            //set the checked list box
            questionCheckedListBox.DataSource = wholeLibraryDs.Tables[0].DefaultView;
            questionCheckedListBox.DisplayMember = "question_name";
        }

        private double GetSeconds(int count)
        {
            return count * TICKER_INTERVAL_MILLISECONDS * 0.001;
        }
        
        //This function is called by the timer.
        private void timer_Tick(object sender, EventArgs e)
        {
            tickCount = tickCount + 1;
            ++progressBar.Value;
            int tickTimes = REFRESH_INTERVAL_MILLISECONDS / TICKER_INTERVAL_MILLISECONDS;
            if (tickCount % tickTimes == 0)
            {
                //When the user is in state 2 (The state after we pressed the start speaking button)
                if (curState == 2)
                {
                    int passTime = Convert.ToInt32(GetSeconds(tickCount));
                    int remainTime = prepTime - passTime;
                    remainNumberLabel.Text = remainTime.ToString();
                    
                    if (remainTime == 0)
                    {
                        //Change from state 2 to state 3.
                        StartRecordingState();
                    }
                }

                //When the user is in state 3 (The state when it starts recording). 
                else if (curState == 3)
                {    
                    int passTime = Convert.ToInt32(GetSeconds(tickCount));
                    int remainTime = responseTime - passTime;
                    this.remainResponseNumberLabel.Text = remainTime.ToString();
                    
                    //if we have less than 10 seconds left
                    if (remainTime <= 10)
                    {
                        this.remainResponseNumberLabel.ForeColor = Color.Red;
                    }

                    //If the user didn't finish the response, then change the state to 4
                    if (remainTime == 0)
                    {
                        StopResponseState();
                        MessageBox.Show("Your time has expired", "Time Out");
                    }
                }
            }
        }

        //The funcion will be called when the user select one of the question from the question check list box
        private void questionChecked_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectQuestionState();

            int number = this.questionCheckedListBox.SelectedIndex + 1;
            curQuestionNumber = number;
                
            //Read the question detail from the database                  
            string query = "select place,detail,question_type,visited from question where number = " + number.ToString();
            String[] QnDescrArray = new String[4];
            String[] type = new String[4];
            type[0] = "string";
            type[1] = "string";
            type[2] = "int";
            type[3] = "int";
            QnDescrArray = db.getReaderString(query, type, 4);

            detailLibrary[0] = QnDescrArray[0];     //place
            detailLibrary[1] = QnDescrArray[1];     //detail

            //Read the question template from the database
            string query2 = "select place,template,question_type,visited from question where number = " + number.ToString();
            String[] qnTmlArray = new String[4];
            String[] type2 = new String[4];
            type2[0] = "string";
            type2[1] = "string";
            type2[2] = "int";
            type2[3] = "int";
            qnTmlArray = db.getReaderString(query2, type2, 4);
            templateLibrary[0] = qnTmlArray[0];
            templateLibrary[1] = qnTmlArray[1];

            int questionType = Convert.ToInt32(QnDescrArray[2]);    //question type
            isSelected = true;

            //set the relevant radio button
            if (questionType == 1)
            {
                questionRadioButton1.Checked = true;
            }
            else if (questionType == 2)
            {
                questionRadioButton2.Checked = true;
            }
            else if (questionType == 3)
            {
                questionRadioButton3.Checked = true;
            }
            else if (questionType == 4)
            {
                questionRadioButton4.Checked = true;
            }
            else if (questionType == 5)
            {
                questionRadioButton5.Checked = true;
            }
            else if (questionType == 6)
            {
                questionRadioButton6.Checked = true;
            }
            
            //display the detail of the question
            detailTextbox.Text = detailLibrary[1];   //detail
        }

        /*
         * This function used to avoid the CheckedClickbox control to change the checkbox status when clicking on 
         * an already selected item.
        */ 
        private void questionCheckedListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            //The only state ther user can change the checkbox status when clicking on an already selected item is in status 1  
            if (curState == 1)
            {
                if (e.NewValue == CheckState.Unchecked)
                    e.NewValue = CheckState.Checked;
                else
                    e.NewValue = CheckState.Unchecked;
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
            //mp3.Stop();
        }

        //when we click the stop response button
        private void stopResponse_Click(object sender, EventArgs e)
        {
            DisposeWave();
            stopResponseButton.Enabled = false;
            playResponseButton.Enabled = true;
            playResponseButton.Text = "Play Response";
            questionCheckedListBox.Enabled = true;
        }


        //We will play the .wav file when we click the play response button
        private void playButton_Click(object sender, EventArgs e)
        {
            //We we haven't started playing the response.
            if (waveReader == null)
            {
                waveReader = new NAudio.Wave.WaveFileReader(recordFileName);
                outputSound = new NAudio.Wave.DirectSoundOut();
                outputSound.Init(new NAudio.Wave.WaveChannel32(waveReader));
                outputSound.Play();
                playResponseButton.Text = "Pause Response";
                stopResponseButton.Enabled = true;
                questionCheckedListBox.Enabled = false;
            }
            else
            {
                if (outputSound.PlaybackState == NAudio.Wave.PlaybackState.Playing)
                {
                    outputSound.Pause();
                    playResponseButton.Text = "Play Response";
                }
                else if (outputSound.PlaybackState == NAudio.Wave.PlaybackState.Paused)
                {
                    outputSound.Play();
                    playResponseButton.Text = "Pause Response";
                }
            }
        }

        //The call back function when we click the next question button
        private void nextQuestionButton_Click(object sender, EventArgs e)
        {
            if (curQuestionNumber < totalQuestionNum && libraryRadioButton.Checked == true)
            {
                this.questionCheckedListBox.SetSelected(curQuestionNumber, true);
            }
            else if (curQuestionNumber < allVisitedNumber && testedRadioButton.Checked == true)
            {
                this.questionCheckedListBox.SetSelected(curQuestionNumber, true);
            }
        }

        //when we click the stop speaking button
        private void StopSpeakingButton_Click(object sender, EventArgs e)
        {
            //If it hasn't started recorded yet
            if (curState == 2)
            {
                //Return to the state from 2 to 1
                stopSpeakingState();
            }
            //If it has already recorded the speaking
            else if (curState == 3)
            {
                //change the state from 3 to 4
                StopResponseState();
            }
        }

        //After we click the start button
        private void startSpeakingButton_Click(object sender, EventArgs e)
        {
            //if we haven't set the preparation time and the response time, pop up a dialog
            if (prepTimeListBox.SelectedItems.Count == 0 || rspTimelistBox.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please set the time", "Warning");
                return;
            }

            //if we haven't select one item, pop up an dialog
            if (isSelected == false || curQuestionNumber == 0)
            {
                MessageBox.Show("Please select a question", "Warning");
                return;
            }

            StartButtonState();
        }

        private void DisposeWave()
        {
            if (outputSound != null)
            {
                if (outputSound.PlaybackState == NAudio.Wave.PlaybackState.Playing)
                {
                    outputSound.Stop();
                }
                outputSound.Dispose();
                outputSound = null;
            }
            if (waveReader != null)
            {
                waveReader.Dispose();
                waveReader = null;
            }
            if (waveSource != null)
            {
                waveSource.Dispose();
                waveSource = null;
            }
            if (waveFile != null)
            {
                waveFile.Dispose();
                waveFile = null;
            }
        }

        //This function is called when the MainForm is closed.
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            DisposeWave();
            Application.Exit();
        }

        private void AddLibrary_Click(object sender, EventArgs e)
        {
            this.Hide();
            addDataForm.Show();
        }


    }
}
