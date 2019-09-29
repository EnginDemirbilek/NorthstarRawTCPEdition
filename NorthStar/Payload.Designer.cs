namespace NorthStar
{
    partial class Payload
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
            this.textBoxListenerIp = new System.Windows.Forms.TextBox();
            this.textBoxListenerPort = new System.Windows.Forms.TextBox();
            this.textBoxInKey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonGeneratePayload = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxExeName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxPayload = new System.Windows.Forms.TextBox();
            this.listenerCheckBox = new System.Windows.Forms.CheckBox();
            this.textBoxEncrypt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxListenerIp
            // 
            this.textBoxListenerIp.Location = new System.Drawing.Point(130, 89);
            this.textBoxListenerIp.Name = "textBoxListenerIp";
            this.textBoxListenerIp.Size = new System.Drawing.Size(163, 22);
            this.textBoxListenerIp.TabIndex = 1;
            // 
            // textBoxListenerPort
            // 
            this.textBoxListenerPort.Location = new System.Drawing.Point(130, 136);
            this.textBoxListenerPort.Name = "textBoxListenerPort";
            this.textBoxListenerPort.Size = new System.Drawing.Size(163, 22);
            this.textBoxListenerPort.TabIndex = 2;
            // 
            // textBoxInKey
            // 
            this.textBoxInKey.Location = new System.Drawing.Point(130, 174);
            this.textBoxInKey.Name = "textBoxInKey";
            this.textBoxInKey.Size = new System.Drawing.Size(163, 22);
            this.textBoxInKey.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Listener IP: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Listener Port:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Initial Key:";
            // 
            // buttonGeneratePayload
            // 
            this.buttonGeneratePayload.Location = new System.Drawing.Point(130, 308);
            this.buttonGeneratePayload.Name = "buttonGeneratePayload";
            this.buttonGeneratePayload.Size = new System.Drawing.Size(115, 34);
            this.buttonGeneratePayload.TabIndex = 6;
            this.buttonGeneratePayload.Text = "GENERATE";
            this.buttonGeneratePayload.UseVisualStyleBackColor = true;
            this.buttonGeneratePayload.Click += new System.EventHandler(this.buttonGeneratePayload_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 256);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Exe Name:";
            // 
            // textBoxExeName
            // 
            this.textBoxExeName.Location = new System.Drawing.Point(130, 251);
            this.textBoxExeName.Name = "textBoxExeName";
            this.textBoxExeName.Size = new System.Drawing.Size(163, 22);
            this.textBoxExeName.TabIndex = 5;
            this.textBoxExeName.TextChanged += new System.EventHandler(this.textBoxExeName_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(80, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(192, 18);
            this.label5.TabIndex = 11;
            this.label5.Text = "PAYLOAD GENERATOR";
            // 
            // textBoxPayload
            // 
            this.textBoxPayload.BackColor = System.Drawing.SystemColors.MenuBar;
            this.textBoxPayload.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxPayload.Location = new System.Drawing.Point(130, 402);
            this.textBoxPayload.Name = "textBoxPayload";
            this.textBoxPayload.Size = new System.Drawing.Size(115, 15);
            this.textBoxPayload.TabIndex = 12;
            // 
            // listenerCheckBox
            // 
            this.listenerCheckBox.AutoSize = true;
            this.listenerCheckBox.Location = new System.Drawing.Point(130, 360);
            this.listenerCheckBox.Name = "listenerCheckBox";
            this.listenerCheckBox.Size = new System.Drawing.Size(106, 21);
            this.listenerCheckBox.TabIndex = 13;
            this.listenerCheckBox.Text = "Set Listener";
            this.listenerCheckBox.UseVisualStyleBackColor = true;
            // 
            // textBoxEncrypt
            // 
            this.textBoxEncrypt.Location = new System.Drawing.Point(130, 213);
            this.textBoxEncrypt.Name = "textBoxEncrypt";
            this.textBoxEncrypt.Size = new System.Drawing.Size(163, 22);
            this.textBoxEncrypt.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 213);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 17);
            this.label6.TabIndex = 15;
            this.label6.Text = "Encryption Key:";
            // 
            // Payload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 481);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxEncrypt);
            this.Controls.Add(this.listenerCheckBox);
            this.Controls.Add(this.textBoxPayload);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxExeName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonGeneratePayload);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxInKey);
            this.Controls.Add(this.textBoxListenerPort);
            this.Controls.Add(this.textBoxListenerIp);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Payload";
            this.Text = "Payload";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxListenerIp;
        private System.Windows.Forms.TextBox textBoxListenerPort;
        private System.Windows.Forms.TextBox textBoxInKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonGeneratePayload;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxExeName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxPayload;
        private System.Windows.Forms.CheckBox listenerCheckBox;
        private System.Windows.Forms.TextBox textBoxEncrypt;
        private System.Windows.Forms.Label label6;
    }
}