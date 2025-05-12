namespace PygmyModManager.Pages
{
    partial class Preferences
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Preferences));
            button1 = new Button();
            tabControl1 = new TabControl();
            sourcesPrefPage = new TabPage();
            getGitHubReleases = new CheckBox();
            linkLabel1 = new LinkLabel();
            sourcesListVisual = new ListView();
            sourceHelpLabel = new Label();
            sourcesAddTxtVisual = new TextBox();
            sourcesAddBtnVisual = new Button();
            label1 = new Label();
            prefLoadSourcesOnStartup = new CheckBox();
            gtPrefPage = new TabPage();
            button2 = new Button();
            label3 = new Label();
            gameLabel = new Label();
            textBox1 = new TextBox();
            custombutton = new RadioButton();
            oculusbtn = new RadioButton();
            steambtn = new RadioButton();
            label2 = new Label();
            appearancePrefPage = new TabPage();
            modMgrDisplayName = new TextBox();
            modMgrDisplayNameLabel = new Label();
            infoLabel = new Label();
            tabControl1.SuspendLayout();
            sourcesPrefPage.SuspendLayout();
            gtPrefPage.SuspendLayout();
            appearancePrefPage.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(333, 423);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "Close";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(sourcesPrefPage);
            tabControl1.Controls.Add(gtPrefPage);
            tabControl1.Controls.Add(appearancePrefPage);
            tabControl1.Location = new Point(1, 2);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(412, 418);
            tabControl1.TabIndex = 1;
            // 
            // sourcesPrefPage
            // 
            sourcesPrefPage.Controls.Add(getGitHubReleases);
            sourcesPrefPage.Controls.Add(linkLabel1);
            sourcesPrefPage.Controls.Add(sourcesListVisual);
            sourcesPrefPage.Controls.Add(sourceHelpLabel);
            sourcesPrefPage.Controls.Add(sourcesAddTxtVisual);
            sourcesPrefPage.Controls.Add(sourcesAddBtnVisual);
            sourcesPrefPage.Controls.Add(label1);
            sourcesPrefPage.Controls.Add(prefLoadSourcesOnStartup);
            sourcesPrefPage.Location = new Point(4, 24);
            sourcesPrefPage.Name = "sourcesPrefPage";
            sourcesPrefPage.Padding = new Padding(3);
            sourcesPrefPage.Size = new Size(404, 390);
            sourcesPrefPage.TabIndex = 0;
            sourcesPrefPage.Text = "Sources";
            sourcesPrefPage.UseVisualStyleBackColor = true;
            // 
            // getGitHubReleases
            // 
            getGitHubReleases.AutoSize = true;
            getGitHubReleases.Checked = true;
            getGitHubReleases.CheckState = CheckState.Checked;
            getGitHubReleases.Location = new Point(11, 303);
            getGitHubReleases.Name = "getGitHubReleases";
            getGitHubReleases.Size = new Size(181, 19);
            getGitHubReleases.TabIndex = 8;
            getGitHubReleases.Text = "Get Updates from GitHub API";
            getGitHubReleases.UseVisualStyleBackColor = true;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(7, 249);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(226, 15);
            linkLabel1.TabIndex = 7;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "You can also edit the sources file yourself.";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // sourcesListVisual
            // 
            sourcesListVisual.CheckBoxes = true;
            sourcesListVisual.Location = new Point(7, 32);
            sourcesListVisual.Name = "sourcesListVisual";
            sourcesListVisual.Size = new Size(389, 185);
            sourcesListVisual.TabIndex = 6;
            sourcesListVisual.UseCompatibleStateImageBehavior = false;
            sourcesListVisual.View = View.List;
            // 
            // sourceHelpLabel
            // 
            sourceHelpLabel.AutoSize = true;
            sourceHelpLabel.Location = new Point(11, 353);
            sourceHelpLabel.Name = "sourceHelpLabel";
            sourceHelpLabel.Size = new Size(382, 30);
            sourceHelpLabel.TabIndex = 5;
            sourceHelpLabel.Text = "To remove a source, uncheck it. Press \"Close\" to save your changes and\r\nclose preferences.";
            // 
            // sourcesAddTxtVisual
            // 
            sourcesAddTxtVisual.Location = new Point(7, 223);
            sourcesAddTxtVisual.Name = "sourcesAddTxtVisual";
            sourcesAddTxtVisual.Size = new Size(327, 23);
            sourcesAddTxtVisual.TabIndex = 4;
            // 
            // sourcesAddBtnVisual
            // 
            sourcesAddBtnVisual.Location = new Point(339, 223);
            sourcesAddBtnVisual.Name = "sourcesAddBtnVisual";
            sourcesAddBtnVisual.Size = new Size(57, 23);
            sourcesAddBtnVisual.TabIndex = 3;
            sourcesAddBtnVisual.Text = "Add";
            sourcesAddBtnVisual.UseVisualStyleBackColor = true;
            sourcesAddBtnVisual.Click += sourcesAddBtnVisual_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(168, 11);
            label1.Name = "label1";
            label1.Size = new Size(65, 15);
            label1.TabIndex = 2;
            label1.Text = "All Sources";
            // 
            // prefLoadSourcesOnStartup
            // 
            prefLoadSourcesOnStartup.AutoSize = true;
            prefLoadSourcesOnStartup.Checked = true;
            prefLoadSourcesOnStartup.CheckState = CheckState.Checked;
            prefLoadSourcesOnStartup.Location = new Point(11, 278);
            prefLoadSourcesOnStartup.Name = "prefLoadSourcesOnStartup";
            prefLoadSourcesOnStartup.Size = new Size(154, 19);
            prefLoadSourcesOnStartup.TabIndex = 0;
            prefLoadSourcesOnStartup.Text = "Load Sources on Startup";
            prefLoadSourcesOnStartup.UseVisualStyleBackColor = true;
            // 
            // gtPrefPage
            // 
            gtPrefPage.Controls.Add(button2);
            gtPrefPage.Controls.Add(label3);
            gtPrefPage.Controls.Add(gameLabel);
            gtPrefPage.Controls.Add(textBox1);
            gtPrefPage.Controls.Add(custombutton);
            gtPrefPage.Controls.Add(oculusbtn);
            gtPrefPage.Controls.Add(steambtn);
            gtPrefPage.Controls.Add(label2);
            gtPrefPage.Location = new Point(4, 24);
            gtPrefPage.Name = "gtPrefPage";
            gtPrefPage.Size = new Size(404, 390);
            gtPrefPage.TabIndex = 2;
            gtPrefPage.Text = "Gorilla Tag";
            gtPrefPage.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(10, 334);
            button2.Name = "button2";
            button2.Size = new Size(389, 23);
            button2.TabIndex = 7;
            button2.Text = "Open Install Directory";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(9, 106);
            label3.Name = "label3";
            label3.Size = new Size(383, 30);
            label3.TabIndex = 6;
            label3.Text = "PygmyModManager will try to load this version of the game before any\r\nother installs it may find.\r\n";
            // 
            // gameLabel
            // 
            gameLabel.AutoSize = true;
            gameLabel.Location = new Point(9, 367);
            gameLabel.Name = "gameLabel";
            gameLabel.Size = new Size(76, 15);
            gameLabel.TabIndex = 5;
            gameLabel.Text = "Path Loaded:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(87, 363);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(312, 23);
            textBox1.TabIndex = 4;
            textBox1.WordWrap = false;
            // 
            // custombutton
            // 
            custombutton.AutoSize = true;
            custombutton.Location = new Point(10, 78);
            custombutton.Name = "custombutton";
            custombutton.Size = new Size(100, 19);
            custombutton.TabIndex = 3;
            custombutton.TabStop = true;
            custombutton.Text = "Custom (N/A)";
            custombutton.UseVisualStyleBackColor = true;
            // 
            // oculusbtn
            // 
            oculusbtn.AutoSize = true;
            oculusbtn.Location = new Point(10, 53);
            oculusbtn.Name = "oculusbtn";
            oculusbtn.Size = new Size(83, 19);
            oculusbtn.TabIndex = 2;
            oculusbtn.TabStop = true;
            oculusbtn.Text = "Oculus Rift";
            oculusbtn.UseVisualStyleBackColor = true;
            // 
            // steambtn
            // 
            steambtn.AutoSize = true;
            steambtn.Location = new Point(10, 28);
            steambtn.Name = "steambtn";
            steambtn.Size = new Size(58, 19);
            steambtn.TabIndex = 1;
            steambtn.TabStop = true;
            steambtn.Text = "Steam";
            steambtn.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(8, 9);
            label2.Name = "label2";
            label2.Size = new Size(126, 15);
            label2.TabIndex = 0;
            label2.Text = "Game Load Preference";
            // 
            // appearancePrefPage
            // 
            appearancePrefPage.Controls.Add(modMgrDisplayName);
            appearancePrefPage.Controls.Add(modMgrDisplayNameLabel);
            appearancePrefPage.Location = new Point(4, 24);
            appearancePrefPage.Name = "appearancePrefPage";
            appearancePrefPage.Padding = new Padding(3);
            appearancePrefPage.Size = new Size(404, 390);
            appearancePrefPage.TabIndex = 1;
            appearancePrefPage.Text = "Appearance";
            appearancePrefPage.UseVisualStyleBackColor = true;
            // 
            // modMgrDisplayName
            // 
            modMgrDisplayName.Location = new Point(96, 8);
            modMgrDisplayName.MaxLength = 60;
            modMgrDisplayName.Name = "modMgrDisplayName";
            modMgrDisplayName.Size = new Size(302, 23);
            modMgrDisplayName.TabIndex = 1;
            // 
            // modMgrDisplayNameLabel
            // 
            modMgrDisplayNameLabel.AutoSize = true;
            modMgrDisplayNameLabel.Location = new Point(9, 12);
            modMgrDisplayNameLabel.Name = "modMgrDisplayNameLabel";
            modMgrDisplayNameLabel.Size = new Size(83, 15);
            modMgrDisplayNameLabel.TabIndex = 0;
            modMgrDisplayNameLabel.Text = "Display Name:";
            // 
            // infoLabel
            // 
            infoLabel.AutoSize = true;
            infoLabel.Location = new Point(7, 426);
            infoLabel.Name = "infoLabel";
            infoLabel.Size = new Size(0, 15);
            infoLabel.TabIndex = 2;
            // 
            // Preferences
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(413, 450);
            ControlBox = false;
            Controls.Add(infoLabel);
            Controls.Add(tabControl1);
            Controls.Add(button1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Preferences";
            Text = "Preferences";
            tabControl1.ResumeLayout(false);
            sourcesPrefPage.ResumeLayout(false);
            sourcesPrefPage.PerformLayout();
            gtPrefPage.ResumeLayout(false);
            gtPrefPage.PerformLayout();
            appearancePrefPage.ResumeLayout(false);
            appearancePrefPage.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TabControl tabControl1;
        private TabPage sourcesPrefPage;
        private TabPage appearancePrefPage;
        private CheckBox prefLoadSourcesOnStartup;
        private Label sourceHelpLabel;
        private TextBox sourcesAddTxtVisual;
        private Button sourcesAddBtnVisual;
        private Label label1;
        private Label infoLabel;
        private ListView sourcesListVisual;
        private TextBox modMgrDisplayName;
        private Label modMgrDisplayNameLabel;
        private LinkLabel linkLabel1;
        private TabPage gtPrefPage;
        private Label gameLabel;
        private TextBox textBox1;
        private RadioButton custombutton;
        private RadioButton oculusbtn;
        private RadioButton steambtn;
        private Label label2;
        private Label label3;
        private Button button2;
        private CheckBox getGitHubReleases;
    }
}