namespace NorthStar.Properties
{
    partial class Notes
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
            this.buttonSaveNotes = new System.Windows.Forms.Button();
            this.richTextBoxNotes = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // buttonSaveNotes
            // 
            this.buttonSaveNotes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonSaveNotes.Location = new System.Drawing.Point(0, 552);
            this.buttonSaveNotes.Name = "buttonSaveNotes";
            this.buttonSaveNotes.Size = new System.Drawing.Size(800, 60);
            this.buttonSaveNotes.TabIndex = 1;
            this.buttonSaveNotes.Text = "SAVE";
            this.buttonSaveNotes.UseVisualStyleBackColor = true;
            this.buttonSaveNotes.Click += new System.EventHandler(this.buttonSaveNotes_Click);
            // 
            // richTextBoxNotes
            // 
            this.richTextBoxNotes.Dock = System.Windows.Forms.DockStyle.Top;
            this.richTextBoxNotes.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxNotes.Name = "richTextBoxNotes";
            this.richTextBoxNotes.Size = new System.Drawing.Size(800, 546);
            this.richTextBoxNotes.TabIndex = 2;
            this.richTextBoxNotes.Text = "";
            // 
            // Notes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 612);
            this.Controls.Add(this.richTextBoxNotes);
            this.Controls.Add(this.buttonSaveNotes);
            this.Name = "Notes";
            this.Text = "Notes";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonSaveNotes;
        private System.Windows.Forms.RichTextBox richTextBoxNotes;
    }
}