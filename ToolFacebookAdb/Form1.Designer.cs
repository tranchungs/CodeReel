namespace ToolFacebookAdb
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            button2 = new Button();
            button4 = new Button();
            cbRegPage = new CheckBox();
            cbXemReels = new CheckBox();
            cbDangReel = new CheckBox();
            mainListView = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            txtThread = new TextBox();
            label5 = new Label();
            button3 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(959, 387);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(173, 29);
            button1.TabIndex = 0;
            button1.Text = "Run";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(982, 9);
            button2.Name = "button2";
            button2.Size = new Size(150, 32);
            button2.TabIndex = 1;
            button2.Text = "InitLD2";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button4
            // 
            button4.Location = new Point(12, 12);
            button4.Name = "button4";
            button4.Size = new Size(149, 29);
            button4.TabIndex = 3;
            button4.Text = "Load Config";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // cbRegPage
            // 
            cbRegPage.AutoSize = true;
            cbRegPage.Location = new Point(12, 392);
            cbRegPage.Margin = new Padding(3, 4, 3, 4);
            cbRegPage.Name = "cbRegPage";
            cbRegPage.Size = new Size(93, 24);
            cbRegPage.TabIndex = 20;
            cbRegPage.Text = "Reg Page";
            cbRegPage.UseVisualStyleBackColor = true;
            // 
            // cbXemReels
            // 
            cbXemReels.AutoSize = true;
            cbXemReels.Location = new Point(111, 392);
            cbXemReels.Margin = new Padding(3, 4, 3, 4);
            cbXemReels.Name = "cbXemReels";
            cbXemReels.Size = new Size(100, 24);
            cbXemReels.TabIndex = 21;
            cbXemReels.Text = "Xem Reels";
            cbXemReels.UseVisualStyleBackColor = true;
            // 
            // cbDangReel
            // 
            cbDangReel.AutoSize = true;
            cbDangReel.Location = new Point(233, 392);
            cbDangReel.Margin = new Padding(3, 4, 3, 4);
            cbDangReel.Name = "cbDangReel";
            cbDangReel.Size = new Size(106, 24);
            cbDangReel.TabIndex = 22;
            cbDangReel.Text = "Đăng Reels";
            cbDangReel.UseVisualStyleBackColor = true;
            // 
            // mainListView
            // 
            mainListView.CheckBoxes = true;
            mainListView.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4, columnHeader5 });
            mainListView.GridLines = true;
            mainListView.Location = new Point(8, 53);
            mainListView.Name = "mainListView";
            mainListView.Size = new Size(1135, 327);
            mainListView.TabIndex = 25;
            mainListView.UseCompatibleStateImageBehavior = false;
            mainListView.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Index";
            columnHeader1.Width = 80;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "VIA";
            columnHeader2.TextAlign = HorizontalAlignment.Center;
            columnHeader2.Width = 500;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Page";
            columnHeader3.TextAlign = HorizontalAlignment.Center;
            columnHeader3.Width = 180;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Folder";
            columnHeader4.TextAlign = HorizontalAlignment.Center;
            columnHeader4.Width = 180;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "VPN";
            columnHeader5.TextAlign = HorizontalAlignment.Center;
            columnHeader5.Width = 180;
            // 
            // txtThread
            // 
            txtThread.Location = new Point(751, 389);
            txtThread.Name = "txtThread";
            txtThread.Size = new Size(125, 27);
            txtThread.TabIndex = 26;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(690, 393);
            label5.Name = "label5";
            label5.Size = new Size(55, 20);
            label5.TabIndex = 27;
            label5.Text = "Thread";
            // 
            // button3
            // 
            button3.Location = new Point(420, 391);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 28;
            button3.Text = "Test";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click_1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1171, 436);
            Controls.Add(button3);
            Controls.Add(label5);
            Controls.Add(txtThread);
            Controls.Add(mainListView);
            Controls.Add(cbDangReel);
            Controls.Add(cbXemReels);
            Controls.Add(cbRegPage);
            Controls.Add(button4);
            Controls.Add(button2);
            Controls.Add(button1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button4;
        private CheckBox cbRegPage;
        private CheckBox cbXemReels;
        private CheckBox cbDangReel;
        private ListView mainListView;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private TextBox txtThread;
        private Label label5;
        private Button button3;
    }
}