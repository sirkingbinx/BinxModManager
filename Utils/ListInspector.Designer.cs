namespace PygmyModManager.Utils
{
    partial class ListInspector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListInspector));
            button1 = new Button();
            textBox1 = new TextBox();
            label1 = new Label();
            button2 = new Button();
            listTitle = new Label();
            listAuthor = new Label();
            listDescriptionLabel = new Label();
            listDescription = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(415, 300);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "OK";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(42, 300);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(286, 23);
            textBox1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 303);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 2;
            label1.Text = "URL:";
            // 
            // button2
            // 
            button2.Location = new Point(334, 300);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 3;
            button2.Text = "Inspect";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // listTitle
            // 
            listTitle.AutoSize = true;
            listTitle.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            listTitle.Location = new Point(12, 14);
            listTitle.Name = "listTitle";
            listTitle.Size = new Size(89, 30);
            listTitle.TabIndex = 4;
            listTitle.Text = "List Title";
            // 
            // listAuthor
            // 
            listAuthor.AutoSize = true;
            listAuthor.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            listAuthor.Location = new Point(15, 44);
            listAuthor.Name = "listAuthor";
            listAuthor.Size = new Size(107, 21);
            listAuthor.TabIndex = 5;
            listAuthor.Text = "by List Author";
            // 
            // listDescriptionLabel
            // 
            listDescriptionLabel.AutoSize = true;
            listDescriptionLabel.Location = new Point(15, 96);
            listDescriptionLabel.Name = "listDescriptionLabel";
            listDescriptionLabel.Size = new Size(70, 15);
            listDescriptionLabel.TabIndex = 6;
            listDescriptionLabel.Text = "Description:";
            // 
            // listDescription
            // 
            listDescription.Location = new Point(15, 111);
            listDescription.Name = "listDescription";
            listDescription.Size = new Size(469, 148);
            listDescription.TabIndex = 7;
            listDescription.Text = "Example";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(107, 14);
            label2.Name = "label2";
            label2.Size = new Size(107, 21);
            label2.TabIndex = 8;
            label2.Text = "by List Author";
            // 
            // ListInspector
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(496, 329);
            Controls.Add(label2);
            Controls.Add(listDescription);
            Controls.Add(listDescriptionLabel);
            Controls.Add(listAuthor);
            Controls.Add(listTitle);
            Controls.Add(button2);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ListInspector";
            Text = "Inspector";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox textBox1;
        private Label label1;
        private Button button2;
        private Label listTitle;
        private Label listAuthor;
        private Label listDescriptionLabel;
        private Label listDescription;
        private Label label2;
    }
}