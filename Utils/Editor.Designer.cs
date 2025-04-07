namespace PygmyModManager.Utils
{
    partial class Editor
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Editor));
            closeButton = new Button();
            fileLabel = new Label();
            openFileBtn = new Button();
            fileLocationBox = new TextBox();
            openFileDialog1 = new OpenFileDialog();
            fileContentBox = new TextBox();
            contextMenuStrip1 = new ContextMenuStrip(components);
            cutToolStripMenuItem = new ToolStripMenuItem();
            copyToolStripMenuItem = new ToolStripMenuItem();
            pasteToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            openToolStripMenuItem = new ToolStripMenuItem();
            saveChangesToolStripMenuItem = new ToolStripMenuItem();
            saveFileDialog1 = new SaveFileDialog();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // closeButton
            // 
            closeButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            closeButton.Location = new Point(434, 510);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(72, 23);
            closeButton.TabIndex = 0;
            closeButton.Text = "Close";
            closeButton.UseVisualStyleBackColor = true;
            closeButton.Click += closeButton_Click;
            // 
            // fileLabel
            // 
            fileLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            fileLabel.AutoSize = true;
            fileLabel.Location = new Point(6, 515);
            fileLabel.Name = "fileLabel";
            fileLabel.Size = new Size(28, 15);
            fileLabel.TabIndex = 1;
            fileLabel.Text = "File:";
            // 
            // openFileBtn
            // 
            openFileBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            openFileBtn.Location = new Point(404, 510);
            openFileBtn.Name = "openFileBtn";
            openFileBtn.Size = new Size(24, 23);
            openFileBtn.TabIndex = 2;
            openFileBtn.Text = "..";
            openFileBtn.UseVisualStyleBackColor = true;
            openFileBtn.Click += openFileBtn_Click;
            // 
            // fileLocationBox
            // 
            fileLocationBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            fileLocationBox.Location = new Point(35, 510);
            fileLocationBox.Name = "fileLocationBox";
            fileLocationBox.ReadOnly = true;
            fileLocationBox.Size = new Size(363, 23);
            fileLocationBox.TabIndex = 3;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog";
            // 
            // fileContentBox
            // 
            fileContentBox.AcceptsReturn = true;
            fileContentBox.AcceptsTab = true;
            fileContentBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            fileContentBox.ContextMenuStrip = contextMenuStrip1;
            fileContentBox.Font = new Font("Courier New", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            fileContentBox.Location = new Point(0, 0);
            fileContentBox.Multiline = true;
            fileContentBox.Name = "fileContentBox";
            fileContentBox.ScrollBars = ScrollBars.Both;
            fileContentBox.Size = new Size(512, 507);
            fileContentBox.TabIndex = 4;
            fileContentBox.TextChanged += fileContentBox_TextChanged;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { cutToolStripMenuItem, copyToolStripMenuItem, pasteToolStripMenuItem, toolStripSeparator1, openToolStripMenuItem, saveChangesToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(104, 120);
            // 
            // cutToolStripMenuItem
            // 
            cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            cutToolStripMenuItem.Size = new Size(103, 22);
            cutToolStripMenuItem.Text = "Cut";
            cutToolStripMenuItem.Click += cutToolStripMenuItem_Click;
            // 
            // copyToolStripMenuItem
            // 
            copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            copyToolStripMenuItem.Size = new Size(103, 22);
            copyToolStripMenuItem.Text = "Copy";
            copyToolStripMenuItem.Click += copyToolStripMenuItem_Click;
            // 
            // pasteToolStripMenuItem
            // 
            pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            pasteToolStripMenuItem.Size = new Size(103, 22);
            pasteToolStripMenuItem.Text = "Paste";
            pasteToolStripMenuItem.Click += pasteToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(100, 6);
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(103, 22);
            openToolStripMenuItem.Text = "Open";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // saveChangesToolStripMenuItem
            // 
            saveChangesToolStripMenuItem.Name = "saveChangesToolStripMenuItem";
            saveChangesToolStripMenuItem.Size = new Size(103, 22);
            saveChangesToolStripMenuItem.Text = "Save";
            saveChangesToolStripMenuItem.Click += saveChangesToolStripMenuItem_Click;
            // 
            // Editor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(511, 537);
            Controls.Add(fileContentBox);
            Controls.Add(fileLocationBox);
            Controls.Add(openFileBtn);
            Controls.Add(fileLabel);
            Controls.Add(closeButton);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Editor";
            Text = "Text Editor";
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button closeButton;
        private Label fileLabel;
        private Button openFileBtn;
        private TextBox fileLocationBox;
        private OpenFileDialog openFileDialog1;
        private TextBox fileContentBox;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem cutToolStripMenuItem;
        private ToolStripMenuItem copyToolStripMenuItem;
        private ToolStripMenuItem pasteToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem saveChangesToolStripMenuItem;
        private SaveFileDialog saveFileDialog1;
        private ToolStripMenuItem openToolStripMenuItem;
    }
}