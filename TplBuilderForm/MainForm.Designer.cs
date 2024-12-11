namespace TplBuilderForm
{
    partial class MainForm
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
            label1 = new Label();
            NameSpaceTextBox = new TextBox();
            FilePathTextBox = new TextBox();
            label2 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(25, 112);
            button1.Name = "button1";
            button1.Size = new Size(359, 29);
            button1.TabIndex = 0;
            button1.Text = "Generate";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 25);
            label1.Name = "label1";
            label1.Size = new Size(60, 20);
            label1.TabIndex = 1;
            label1.Text = "FilePath";
            // 
            // NameSpaceTextBox
            // 
            NameSpaceTextBox.Location = new Point(118, 68);
            NameSpaceTextBox.Name = "NameSpaceTextBox";
            NameSpaceTextBox.Size = new Size(266, 27);
            NameSpaceTextBox.TabIndex = 2;
            // 
            // FilePathTextBox
            // 
            FilePathTextBox.Location = new Point(118, 25);
            FilePathTextBox.Name = "FilePathTextBox";
            FilePathTextBox.Size = new Size(266, 27);
            FilePathTextBox.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 68);
            label2.Name = "label2";
            label2.Size = new Size(89, 20);
            label2.TabIndex = 4;
            label2.Text = "NameSpace";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(FilePathTextBox);
            Controls.Add(NameSpaceTextBox);
            Controls.Add(label1);
            Controls.Add(button1);
            Name = "MainForm";
            Text = "MainForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private Label label2;
        private TextBox NameSpaceTextBox;
        private TextBox FilePathTextBox;
    }
}
