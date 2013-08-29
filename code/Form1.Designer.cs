/*
*
* Copyright (C) 2011-2014 Wang Shiliang
* All rights reserved
* filename : Form1.Designer.cs
* description : This codes shows the user interface of the following function:
								The software will automatically record what the user just said. 
                The user can set the preparation time, the response time of the question. The user can select the question from the question library. 
                After the user answer the question completely, he can find the wrong pronunciation by hearing the record. It is a very good way to 
                practice the oral English.
* created by Wang Shiliang at 6/1/2011 20:19:50
*
*/
namespace ToeflSpeaking
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.ignoreRespondcheckBox = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.questionRadioButton6 = new System.Windows.Forms.RadioButton();
            this.questionRadioButton3 = new System.Windows.Forms.RadioButton();
            this.questionRadioButton5 = new System.Windows.Forms.RadioButton();
            this.questionRadioButton4 = new System.Windows.Forms.RadioButton();
            this.questionRadioButton2 = new System.Windows.Forms.RadioButton();
            this.questionRadioButton1 = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.prepareTimeListBox = new System.Windows.Forms.ListBox();
            this.responseTimelistBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.testedRadioButton = new System.Windows.Forms.RadioButton();
            this.libraryRadioButton = new System.Windows.Forms.RadioButton();
            this.panel5 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.indicateResponseLabel = new System.Windows.Forms.Label();
            this.questionCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.detailTextbox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.playResponseButton = new System.Windows.Forms.Button();
            this.startSpeakingButton = new System.Windows.Forms.Button();
            this.prepareSpeakLabel = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.prepareResponseLabel = new System.Windows.Forms.Label();
            this.responseTimeLabel = new System.Windows.Forms.Label();
            this.remainTimeLabel = new System.Windows.Forms.Label();
            this.remainNumberLabel = new System.Windows.Forms.Label();
            this.remainResponseTimeLabel = new System.Windows.Forms.Label();
            this.timeNumberLabel = new System.Windows.Forms.Label();
            this.allResponseTimeLabel = new System.Windows.Forms.Label();
            this.stopSpeakingButton = new System.Windows.Forms.Button();
            this.DescriptionRadioButton = new System.Windows.Forms.RadioButton();
            this.TemplateRadioButton = new System.Windows.Forms.RadioButton();
            this.NothingRadioButton = new System.Windows.Forms.RadioButton();
            this.panel7 = new System.Windows.Forms.Panel();
            this.VisitedTimesNumberLabel = new System.Windows.Forms.Label();
            this.VisitedTimesLabel = new System.Windows.Forms.Label();
            this.stopResponseButton = new System.Windows.Forms.Button();
            this.nextQuestionButton = new System.Windows.Forms.Button();
            this.addLibraryButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel8);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(20, 44);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1312, 111);
            this.panel1.TabIndex = 4;
            // 
            // panel8
            // 
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8.Controls.Add(this.ignoreRespondcheckBox);
            this.panel8.Controls.Add(this.label8);
            this.panel8.Location = new System.Drawing.Point(867, 4);
            this.panel8.Margin = new System.Windows.Forms.Padding(4);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(443, 102);
            this.panel8.TabIndex = 3;
            // 
            // ignoreRespondcheckBox
            // 
            this.ignoreRespondcheckBox.AutoSize = true;
            this.ignoreRespondcheckBox.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Bold);
            this.ignoreRespondcheckBox.Location = new System.Drawing.Point(41, 37);
            this.ignoreRespondcheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.ignoreRespondcheckBox.Name = "ignoreRespondcheckBox";
            this.ignoreRespondcheckBox.Size = new System.Drawing.Size(253, 24);
            this.ignoreRespondcheckBox.TabIndex = 4;
            this.ignoreRespondcheckBox.Text = "Ignore Responded Questions ";
            this.ignoreRespondcheckBox.UseVisualStyleBackColor = true;
            this.ignoreRespondcheckBox.CheckedChanged += new System.EventHandler(this.ignoreRespondcheckBox_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(4, -3);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 20);
            this.label8.TabIndex = 3;
            this.label8.Text = "Option:";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.questionRadioButton6);
            this.panel3.Controls.Add(this.questionRadioButton3);
            this.panel3.Controls.Add(this.questionRadioButton5);
            this.panel3.Controls.Add(this.questionRadioButton4);
            this.panel3.Controls.Add(this.questionRadioButton2);
            this.panel3.Controls.Add(this.questionRadioButton1);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Location = new System.Drawing.Point(459, 4);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(379, 102);
            this.panel3.TabIndex = 3;
            // 
            // questionRadioButton6
            // 
            this.questionRadioButton6.AutoSize = true;
            this.questionRadioButton6.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Bold);
            this.questionRadioButton6.Location = new System.Drawing.Point(168, 75);
            this.questionRadioButton6.Margin = new System.Windows.Forms.Padding(4);
            this.questionRadioButton6.Name = "questionRadioButton6";
            this.questionRadioButton6.Size = new System.Drawing.Size(104, 24);
            this.questionRadioButton6.TabIndex = 4;
            this.questionRadioButton6.TabStop = true;
            this.questionRadioButton6.Text = "question6";
            this.questionRadioButton6.UseVisualStyleBackColor = true;
            // 
            // questionRadioButton3
            // 
            this.questionRadioButton3.AutoSize = true;
            this.questionRadioButton3.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Bold);
            this.questionRadioButton3.Location = new System.Drawing.Point(33, 75);
            this.questionRadioButton3.Margin = new System.Windows.Forms.Padding(4);
            this.questionRadioButton3.Name = "questionRadioButton3";
            this.questionRadioButton3.Size = new System.Drawing.Size(104, 24);
            this.questionRadioButton3.TabIndex = 4;
            this.questionRadioButton3.TabStop = true;
            this.questionRadioButton3.Text = "question3";
            this.questionRadioButton3.UseVisualStyleBackColor = true;
            // 
            // questionRadioButton5
            // 
            this.questionRadioButton5.AutoSize = true;
            this.questionRadioButton5.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Bold);
            this.questionRadioButton5.Location = new System.Drawing.Point(168, 47);
            this.questionRadioButton5.Margin = new System.Windows.Forms.Padding(4);
            this.questionRadioButton5.Name = "questionRadioButton5";
            this.questionRadioButton5.Size = new System.Drawing.Size(104, 24);
            this.questionRadioButton5.TabIndex = 4;
            this.questionRadioButton5.TabStop = true;
            this.questionRadioButton5.Text = "question5";
            this.questionRadioButton5.UseVisualStyleBackColor = true;
            // 
            // questionRadioButton4
            // 
            this.questionRadioButton4.AutoSize = true;
            this.questionRadioButton4.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Bold);
            this.questionRadioButton4.Location = new System.Drawing.Point(168, 20);
            this.questionRadioButton4.Margin = new System.Windows.Forms.Padding(4);
            this.questionRadioButton4.Name = "questionRadioButton4";
            this.questionRadioButton4.Size = new System.Drawing.Size(104, 24);
            this.questionRadioButton4.TabIndex = 4;
            this.questionRadioButton4.TabStop = true;
            this.questionRadioButton4.Text = "question4";
            this.questionRadioButton4.UseVisualStyleBackColor = true;
            // 
            // questionRadioButton2
            // 
            this.questionRadioButton2.AutoSize = true;
            this.questionRadioButton2.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Bold);
            this.questionRadioButton2.Location = new System.Drawing.Point(33, 47);
            this.questionRadioButton2.Margin = new System.Windows.Forms.Padding(4);
            this.questionRadioButton2.Name = "questionRadioButton2";
            this.questionRadioButton2.Size = new System.Drawing.Size(104, 24);
            this.questionRadioButton2.TabIndex = 4;
            this.questionRadioButton2.TabStop = true;
            this.questionRadioButton2.Text = "question2";
            this.questionRadioButton2.UseVisualStyleBackColor = true;
            // 
            // questionRadioButton1
            // 
            this.questionRadioButton1.AutoSize = true;
            this.questionRadioButton1.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Bold);
            this.questionRadioButton1.Location = new System.Drawing.Point(33, 20);
            this.questionRadioButton1.Margin = new System.Windows.Forms.Padding(4);
            this.questionRadioButton1.Name = "questionRadioButton1";
            this.questionRadioButton1.Size = new System.Drawing.Size(104, 24);
            this.questionRadioButton1.TabIndex = 4;
            this.questionRadioButton1.TabStop = true;
            this.questionRadioButton1.Text = "question1";
            this.questionRadioButton1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, -3);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Question Type:";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.prepareTimeListBox);
            this.panel2.Controls.Add(this.responseTimelistBox);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(0, 4);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(429, 102);
            this.panel2.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, -1);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Time Setting:";
            // 
            // prepareTimeListBox
            // 
            this.prepareTimeListBox.Font = new System.Drawing.Font("Calibri", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prepareTimeListBox.FormattingEnabled = true;
            this.prepareTimeListBox.ItemHeight = 21;
            this.prepareTimeListBox.Location = new System.Drawing.Point(201, 23);
            this.prepareTimeListBox.Margin = new System.Windows.Forms.Padding(4);
            this.prepareTimeListBox.Name = "prepareTimeListBox";
            this.prepareTimeListBox.Size = new System.Drawing.Size(104, 25);
            this.prepareTimeListBox.TabIndex = 1;
            // 
            // responseTimelistBox
            // 
            this.responseTimelistBox.Font = new System.Drawing.Font("Calibri", 10.5F);
            this.responseTimelistBox.FormattingEnabled = true;
            this.responseTimelistBox.ItemHeight = 21;
            this.responseTimelistBox.Location = new System.Drawing.Point(201, 61);
            this.responseTimelistBox.Margin = new System.Windows.Forms.Padding(4);
            this.responseTimelistBox.Name = "responseTimelistBox";
            this.responseTimelistBox.Size = new System.Drawing.Size(104, 25);
            this.responseTimelistBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(32, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Preparation time(s)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(32, 67);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Response time(s)";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.testedRadioButton);
            this.panel4.Controls.Add(this.libraryRadioButton);
            this.panel4.Location = new System.Drawing.Point(20, 163);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1311, 50);
            this.panel4.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(1, -1);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(193, 20);
            this.label5.TabIndex = 3;
            this.label5.Text = "Choose Question Library";
            // 
            // testedRadioButton
            // 
            this.testedRadioButton.AutoSize = true;
            this.testedRadioButton.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Bold);
            this.testedRadioButton.Location = new System.Drawing.Point(76, 20);
            this.testedRadioButton.Margin = new System.Windows.Forms.Padding(4);
            this.testedRadioButton.Name = "testedRadioButton";
            this.testedRadioButton.Size = new System.Drawing.Size(234, 24);
            this.testedRadioButton.TabIndex = 4;
            this.testedRadioButton.Text = "Question tested in the past";
            this.testedRadioButton.UseVisualStyleBackColor = true;
            this.testedRadioButton.CheckedChanged += new System.EventHandler(this.TestedRadioButton_CheckedChanged);
            // 
            // libraryRadioButton
            // 
            this.libraryRadioButton.AutoSize = true;
            this.libraryRadioButton.Checked = true;
            this.libraryRadioButton.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Bold);
            this.libraryRadioButton.Location = new System.Drawing.Point(613, 20);
            this.libraryRadioButton.Margin = new System.Windows.Forms.Padding(4);
            this.libraryRadioButton.Name = "libraryRadioButton";
            this.libraryRadioButton.Size = new System.Drawing.Size(146, 24);
            this.libraryRadioButton.TabIndex = 4;
            this.libraryRadioButton.TabStop = true;
            this.libraryRadioButton.Text = "The ETS Library";
            this.libraryRadioButton.UseVisualStyleBackColor = true;
            this.libraryRadioButton.CheckedChanged += new System.EventHandler(this.libraryRadioButton_CheckedChanged);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.pictureBox1);
            this.panel5.Controls.Add(this.indicateResponseLabel);
            this.panel5.Controls.Add(this.questionCheckedListBox);
            this.panel5.Controls.Add(this.label6);
            this.panel5.Location = new System.Drawing.Point(20, 221);
            this.panel5.Margin = new System.Windows.Forms.Padding(4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1312, 185);
            this.panel5.TabIndex = 5;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.Location = new System.Drawing.Point(1068, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(13, 17);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // indicateResponseLabel
            // 
            this.indicateResponseLabel.AutoSize = true;
            this.indicateResponseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.indicateResponseLabel.Location = new System.Drawing.Point(1085, 4);
            this.indicateResponseLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.indicateResponseLabel.Name = "indicateResponseLabel";
            this.indicateResponseLabel.Size = new System.Drawing.Size(192, 18);
            this.indicateResponseLabel.TabIndex = 5;
            this.indicateResponseLabel.Text = "indicate responded question";
            // 
            // questionCheckedListBox
            // 
            this.questionCheckedListBox.Font = new System.Drawing.Font("Cambria", 12F);
            this.questionCheckedListBox.FormattingEnabled = true;
            this.questionCheckedListBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.questionCheckedListBox.Location = new System.Drawing.Point(0, 24);
            this.questionCheckedListBox.Margin = new System.Windows.Forms.Padding(4);
            this.questionCheckedListBox.Name = "questionCheckedListBox";
            this.questionCheckedListBox.Size = new System.Drawing.Size(1311, 134);
            this.questionCheckedListBox.TabIndex = 4;
            this.questionCheckedListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBox1_ItemCheck);
            this.questionCheckedListBox.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(4, 1);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(162, 20);
            this.label6.TabIndex = 3;
            this.label6.Text = "Question Collection:";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.detailTextbox);
            this.panel6.Location = new System.Drawing.Point(20, 447);
            this.panel6.Margin = new System.Windows.Forms.Padding(4);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1312, 159);
            this.panel6.TabIndex = 5;
            // 
            // detailTextbox
            // 
            this.detailTextbox.Font = new System.Drawing.Font("Cambria", 12F);
            this.detailTextbox.Location = new System.Drawing.Point(0, 0);
            this.detailTextbox.Margin = new System.Windows.Forms.Padding(4);
            this.detailTextbox.Multiline = true;
            this.detailTextbox.Name = "detailTextbox";
            this.detailTextbox.ReadOnly = true;
            this.detailTextbox.Size = new System.Drawing.Size(1311, 156);
            this.detailTextbox.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(551, 427);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(250, 15);
            this.label7.TabIndex = 3;
            this.label7.Text = "Details of Current Question";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // playResponseButton
            // 
            this.playResponseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(255)))), ((int)(((byte)(220)))));
            this.playResponseButton.Font = new System.Drawing.Font("Georgia", 9.5F);
            this.playResponseButton.Location = new System.Drawing.Point(972, 43);
            this.playResponseButton.Margin = new System.Windows.Forms.Padding(4);
            this.playResponseButton.Name = "playResponseButton";
            this.playResponseButton.Size = new System.Drawing.Size(161, 31);
            this.playResponseButton.TabIndex = 3;
            this.playResponseButton.Text = "Play Response";
            this.playResponseButton.UseVisualStyleBackColor = false;
            this.playResponseButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // startSpeakingButton
            // 
            this.startSpeakingButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.startSpeakingButton.Font = new System.Drawing.Font("Georgia", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startSpeakingButton.Location = new System.Drawing.Point(364, 175);
            this.startSpeakingButton.Margin = new System.Windows.Forms.Padding(4);
            this.startSpeakingButton.Name = "startSpeakingButton";
            this.startSpeakingButton.Size = new System.Drawing.Size(576, 43);
            this.startSpeakingButton.TabIndex = 6;
            this.startSpeakingButton.Text = "Start Speaking";
            this.startSpeakingButton.UseVisualStyleBackColor = false;
            this.startSpeakingButton.Click += new System.EventHandler(this.startSpeakingButton_Click);
            // 
            // prepareSpeakLabel
            // 
            this.prepareSpeakLabel.AutoSize = true;
            this.prepareSpeakLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.prepareSpeakLabel.Location = new System.Drawing.Point(367, 105);
            this.prepareSpeakLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.prepareSpeakLabel.Name = "prepareSpeakLabel";
            this.prepareSpeakLabel.Size = new System.Drawing.Size(496, 18);
            this.prepareSpeakLabel.TabIndex = 7;
            this.prepareSpeakLabel.Text = "When you are ready,Click the button below to start speaking and recording";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(359, 91);
            this.progressBar.Margin = new System.Windows.Forms.Padding(4);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(581, 31);
            this.progressBar.TabIndex = 8;
            // 
            // prepareResponseLabel
            // 
            this.prepareResponseLabel.AutoSize = true;
            this.prepareResponseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.prepareResponseLabel.Location = new System.Drawing.Point(541, 57);
            this.prepareResponseLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.prepareResponseLabel.Name = "prepareResponseLabel";
            this.prepareResponseLabel.Size = new System.Drawing.Size(137, 18);
            this.prepareResponseLabel.TabIndex = 9;
            this.prepareResponseLabel.Text = "Preparing response";
            this.prepareResponseLabel.Visible = false;
            // 
            // responseTimeLabel
            // 
            this.responseTimeLabel.AutoSize = true;
            this.responseTimeLabel.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Bold);
            this.responseTimeLabel.Location = new System.Drawing.Point(541, 57);
            this.responseTimeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.responseTimeLabel.Name = "responseTimeLabel";
            this.responseTimeLabel.Size = new System.Drawing.Size(142, 20);
            this.responseTimeLabel.TabIndex = 9;
            this.responseTimeLabel.Text = "Response time(s):";
            this.responseTimeLabel.Visible = false;
            // 
            // remainTimeLabel
            // 
            this.remainTimeLabel.AutoSize = true;
            this.remainTimeLabel.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Bold);
            this.remainTimeLabel.Location = new System.Drawing.Point(541, 133);
            this.remainTimeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.remainTimeLabel.Name = "remainTimeLabel";
            this.remainTimeLabel.Size = new System.Drawing.Size(151, 20);
            this.remainTimeLabel.TabIndex = 9;
            this.remainTimeLabel.Text = "Remaining time(s):";
            // 
            // remainNumberLabel
            // 
            this.remainNumberLabel.AutoSize = true;
            this.remainNumberLabel.Location = new System.Drawing.Point(700, 133);
            this.remainNumberLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.remainNumberLabel.Name = "remainNumberLabel";
            this.remainNumberLabel.Size = new System.Drawing.Size(0, 17);
            this.remainNumberLabel.TabIndex = 11;
            // 
            // remainResponseTimeLabel
            // 
            this.remainResponseTimeLabel.AutoSize = true;
            this.remainResponseTimeLabel.Location = new System.Drawing.Point(696, 133);
            this.remainResponseTimeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.remainResponseTimeLabel.Name = "remainResponseTimeLabel";
            this.remainResponseTimeLabel.Size = new System.Drawing.Size(0, 17);
            this.remainResponseTimeLabel.TabIndex = 11;
            // 
            // timeNumberLabel
            // 
            this.timeNumberLabel.AutoSize = true;
            this.timeNumberLabel.Location = new System.Drawing.Point(700, 57);
            this.timeNumberLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.timeNumberLabel.Name = "timeNumberLabel";
            this.timeNumberLabel.Size = new System.Drawing.Size(0, 17);
            this.timeNumberLabel.TabIndex = 11;
            // 
            // allResponseTimeLabel
            // 
            this.allResponseTimeLabel.AutoSize = true;
            this.allResponseTimeLabel.Location = new System.Drawing.Point(700, 57);
            this.allResponseTimeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.allResponseTimeLabel.Name = "allResponseTimeLabel";
            this.allResponseTimeLabel.Size = new System.Drawing.Size(0, 17);
            this.allResponseTimeLabel.TabIndex = 11;
            // 
            // stopSpeakingButton
            // 
            this.stopSpeakingButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.stopSpeakingButton.Font = new System.Drawing.Font("Georgia", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stopSpeakingButton.Location = new System.Drawing.Point(357, 173);
            this.stopSpeakingButton.Margin = new System.Windows.Forms.Padding(4);
            this.stopSpeakingButton.Name = "stopSpeakingButton";
            this.stopSpeakingButton.Size = new System.Drawing.Size(583, 45);
            this.stopSpeakingButton.TabIndex = 12;
            this.stopSpeakingButton.Text = "Stop Speaking";
            this.stopSpeakingButton.UseVisualStyleBackColor = false;
            this.stopSpeakingButton.Click += new System.EventHandler(this.StopSpeakingButton_Click);
            // 
            // DescriptionRadioButton
            // 
            this.DescriptionRadioButton.AutoSize = true;
            this.DescriptionRadioButton.Checked = true;
            this.DescriptionRadioButton.Font = new System.Drawing.Font("Verdana", 7.5F);
            this.DescriptionRadioButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.DescriptionRadioButton.Location = new System.Drawing.Point(783, 5);
            this.DescriptionRadioButton.Margin = new System.Windows.Forms.Padding(4);
            this.DescriptionRadioButton.Name = "DescriptionRadioButton";
            this.DescriptionRadioButton.Size = new System.Drawing.Size(206, 20);
            this.DescriptionRadioButton.TabIndex = 15;
            this.DescriptionRadioButton.TabStop = true;
            this.DescriptionRadioButton.Text = "Show Question Description";
            this.DescriptionRadioButton.UseVisualStyleBackColor = true;
            this.DescriptionRadioButton.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // TemplateRadioButton
            // 
            this.TemplateRadioButton.AutoSize = true;
            this.TemplateRadioButton.Font = new System.Drawing.Font("Verdana", 7.5F);
            this.TemplateRadioButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.TemplateRadioButton.Location = new System.Drawing.Point(1024, 5);
            this.TemplateRadioButton.Margin = new System.Windows.Forms.Padding(4);
            this.TemplateRadioButton.Name = "TemplateRadioButton";
            this.TemplateRadioButton.Size = new System.Drawing.Size(130, 20);
            this.TemplateRadioButton.TabIndex = 15;
            this.TemplateRadioButton.TabStop = true;
            this.TemplateRadioButton.Text = "Show Template";
            this.TemplateRadioButton.UseVisualStyleBackColor = true;
            this.TemplateRadioButton.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // NothingRadioButton
            // 
            this.NothingRadioButton.AutoSize = true;
            this.NothingRadioButton.Font = new System.Drawing.Font("Verdana", 7.5F);
            this.NothingRadioButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.NothingRadioButton.Location = new System.Drawing.Point(1176, 4);
            this.NothingRadioButton.Margin = new System.Windows.Forms.Padding(4);
            this.NothingRadioButton.Name = "NothingRadioButton";
            this.NothingRadioButton.Size = new System.Drawing.Size(120, 20);
            this.NothingRadioButton.TabIndex = 15;
            this.NothingRadioButton.TabStop = true;
            this.NothingRadioButton.Text = "Show Nothing";
            this.NothingRadioButton.UseVisualStyleBackColor = true;
            this.NothingRadioButton.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.VisitedTimesNumberLabel);
            this.panel7.Controls.Add(this.VisitedTimesLabel);
            this.panel7.Controls.Add(this.NothingRadioButton);
            this.panel7.Controls.Add(this.TemplateRadioButton);
            this.panel7.Controls.Add(this.DescriptionRadioButton);
            this.panel7.Controls.Add(this.stopSpeakingButton);
            this.panel7.Controls.Add(this.allResponseTimeLabel);
            this.panel7.Controls.Add(this.timeNumberLabel);
            this.panel7.Controls.Add(this.remainResponseTimeLabel);
            this.panel7.Controls.Add(this.remainNumberLabel);
            this.panel7.Controls.Add(this.remainTimeLabel);
            this.panel7.Controls.Add(this.responseTimeLabel);
            this.panel7.Controls.Add(this.prepareResponseLabel);
            this.panel7.Controls.Add(this.progressBar);
            this.panel7.Controls.Add(this.prepareSpeakLabel);
            this.panel7.Controls.Add(this.startSpeakingButton);
            this.panel7.Controls.Add(this.stopResponseButton);
            this.panel7.Controls.Add(this.playResponseButton);
            this.panel7.Location = new System.Drawing.Point(19, 613);
            this.panel7.Margin = new System.Windows.Forms.Padding(4);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1312, 261);
            this.panel7.TabIndex = 7;
            // 
            // VisitedTimesNumberLabel
            // 
            this.VisitedTimesNumberLabel.AutoSize = true;
            this.VisitedTimesNumberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.VisitedTimesNumberLabel.Location = new System.Drawing.Point(145, 12);
            this.VisitedTimesNumberLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.VisitedTimesNumberLabel.Name = "VisitedTimesNumberLabel";
            this.VisitedTimesNumberLabel.Size = new System.Drawing.Size(0, 20);
            this.VisitedTimesNumberLabel.TabIndex = 16;
            // 
            // VisitedTimesLabel
            // 
            this.VisitedTimesLabel.AutoSize = true;
            this.VisitedTimesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.VisitedTimesLabel.Location = new System.Drawing.Point(8, 11);
            this.VisitedTimesLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.VisitedTimesLabel.Name = "VisitedTimesLabel";
            this.VisitedTimesLabel.Size = new System.Drawing.Size(116, 20);
            this.VisitedTimesLabel.TabIndex = 10;
            this.VisitedTimesLabel.Text = "Visited Times:";
            // 
            // stopResponseButton
            // 
            this.stopResponseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(255)))), ((int)(((byte)(220)))));
            this.stopResponseButton.Font = new System.Drawing.Font("Georgia", 9.5F);
            this.stopResponseButton.Location = new System.Drawing.Point(1141, 43);
            this.stopResponseButton.Margin = new System.Windows.Forms.Padding(4);
            this.stopResponseButton.Name = "stopResponseButton";
            this.stopResponseButton.Size = new System.Drawing.Size(161, 31);
            this.stopResponseButton.TabIndex = 3;
            this.stopResponseButton.Text = "Stop Response";
            this.stopResponseButton.UseVisualStyleBackColor = false;
            this.stopResponseButton.Click += new System.EventHandler(this.StopResponse_Click);
            // 
            // nextQuestionButton
            // 
            this.nextQuestionButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(255)))));
            this.nextQuestionButton.Font = new System.Drawing.Font("Georgia", 10.5F);
            this.nextQuestionButton.Location = new System.Drawing.Point(20, 405);
            this.nextQuestionButton.Margin = new System.Windows.Forms.Padding(4);
            this.nextQuestionButton.Name = "nextQuestionButton";
            this.nextQuestionButton.Size = new System.Drawing.Size(141, 33);
            this.nextQuestionButton.TabIndex = 8;
            this.nextQuestionButton.Text = "Next Question";
            this.nextQuestionButton.UseVisualStyleBackColor = false;
            this.nextQuestionButton.Click += new System.EventHandler(this.nextQuestionButton_Click);
            // 
            // addLibraryButton
            // 
            this.addLibraryButton.BackColor = System.Drawing.Color.LightGreen;
            this.addLibraryButton.Font = new System.Drawing.Font("Georgia", 10.5F);
            this.addLibraryButton.Location = new System.Drawing.Point(1143, 8);
            this.addLibraryButton.Margin = new System.Windows.Forms.Padding(4);
            this.addLibraryButton.Name = "addLibraryButton";
            this.addLibraryButton.Size = new System.Drawing.Size(189, 32);
            this.addLibraryButton.TabIndex = 9;
            this.addLibraryButton.Text = "Add Library";
            this.addLibraryButton.UseVisualStyleBackColor = false;
            this.addLibraryButton.Click += new System.EventHandler(this.AddLibrary_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(230)))));
            this.ClientSize = new System.Drawing.Size(1348, 883);
            this.Controls.Add(this.addLibraryButton);
            this.Controls.Add(this.nextQuestionButton);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.HelpButton = true;
            this.Location = new System.Drawing.Point(100, 20);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Oral English Practicing";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton questionRadioButton1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox prepareTimeListBox;
        private System.Windows.Forms.ListBox responseTimelistBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton questionRadioButton6;
        private System.Windows.Forms.RadioButton questionRadioButton3;
        private System.Windows.Forms.RadioButton questionRadioButton5;
        private System.Windows.Forms.RadioButton questionRadioButton4;
        private System.Windows.Forms.RadioButton questionRadioButton2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton testedRadioButton;
        private System.Windows.Forms.RadioButton libraryRadioButton;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox detailTextbox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckedListBox questionCheckedListBox;
        private System.Windows.Forms.Label indicateResponseLabel;
        private System.Windows.Forms.Button playResponseButton;
        private System.Windows.Forms.Button startSpeakingButton;
        private System.Windows.Forms.Label prepareSpeakLabel;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label prepareResponseLabel;
        private System.Windows.Forms.Label responseTimeLabel;
        private System.Windows.Forms.Label remainTimeLabel;
        private System.Windows.Forms.Label remainNumberLabel;
        private System.Windows.Forms.Label remainResponseTimeLabel;
        private System.Windows.Forms.Label timeNumberLabel;
        private System.Windows.Forms.Label allResponseTimeLabel;
        private System.Windows.Forms.Button stopSpeakingButton;
        private System.Windows.Forms.RadioButton DescriptionRadioButton;
        private System.Windows.Forms.RadioButton TemplateRadioButton;
        private System.Windows.Forms.RadioButton NothingRadioButton;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox ignoreRespondcheckBox;
        private System.Windows.Forms.Button nextQuestionButton;
        private System.Windows.Forms.Button addLibraryButton;
        private System.Windows.Forms.Button stopResponseButton;
        private System.Windows.Forms.Label VisitedTimesNumberLabel;
        private System.Windows.Forms.Label VisitedTimesLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

