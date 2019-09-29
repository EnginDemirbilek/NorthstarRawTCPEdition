using System;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NorthStar
{
    partial class NorthStar
    {
      
        private System.ComponentModel.IContainer components = null;
        public static string date;
     
        



        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NorthStar));
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.buttonPayload = new System.Windows.Forms.Button();
            this.buttonBroadcast = new System.Windows.Forms.Button();
            this.listenerButton = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.botListDGV = new System.Windows.Forms.DataGridView();
            this.idColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Listener = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnSlaveId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNotes = new System.Windows.Forms.DataGridViewButtonColumn();
            this.textBoxCmd = new System.Windows.Forms.TextBox();
            this.buttonGeneralLogs = new System.Windows.Forms.Button();
            this.buttonExceptionLogs = new System.Windows.Forms.Button();
            this.textBoxExceptionLogs = new System.Windows.Forms.TextBox();
            this.textBoxGeneralLogs = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.botListDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Menu;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.buttonPayload);
            this.panel1.Controls.Add(this.buttonBroadcast);
            this.panel1.Controls.Add(this.listenerButton);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(190, 265);
            this.panel1.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button2.Dock = System.Windows.Forms.DockStyle.Top;
            this.button2.Enabled = false;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button2.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.DimGray;
            this.button2.Location = new System.Drawing.Point(0, 198);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(188, 66);
            this.button2.TabIndex = 15;
            this.button2.Text = "HELP / ABOUT";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // buttonPayload
            // 
            this.buttonPayload.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonPayload.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonPayload.FlatAppearance.BorderSize = 0;
            this.buttonPayload.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonPayload.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPayload.ForeColor = System.Drawing.Color.DimGray;
            this.buttonPayload.Location = new System.Drawing.Point(0, 132);
            this.buttonPayload.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonPayload.Name = "buttonPayload";
            this.buttonPayload.Size = new System.Drawing.Size(188, 66);
            this.buttonPayload.TabIndex = 14;
            this.buttonPayload.Text = "PAYLOAD";
            this.buttonPayload.UseVisualStyleBackColor = false;
            this.buttonPayload.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonBroadcast
            // 
            this.buttonBroadcast.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonBroadcast.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonBroadcast.FlatAppearance.BorderSize = 0;
            this.buttonBroadcast.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonBroadcast.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBroadcast.ForeColor = System.Drawing.Color.DimGray;
            this.buttonBroadcast.Location = new System.Drawing.Point(0, 66);
            this.buttonBroadcast.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonBroadcast.Name = "buttonBroadcast";
            this.buttonBroadcast.Size = new System.Drawing.Size(188, 66);
            this.buttonBroadcast.TabIndex = 13;
            this.buttonBroadcast.Text = "BROADCAST";
            this.buttonBroadcast.UseVisualStyleBackColor = false;
            this.buttonBroadcast.Click += new System.EventHandler(this.buttonBroadcast_Click);
            // 
            // listenerButton
            // 
            this.listenerButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.listenerButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.listenerButton.FlatAppearance.BorderSize = 0;
            this.listenerButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.listenerButton.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listenerButton.ForeColor = System.Drawing.Color.DimGray;
            this.listenerButton.Location = new System.Drawing.Point(0, 0);
            this.listenerButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listenerButton.Name = "listenerButton";
            this.listenerButton.Size = new System.Drawing.Size(188, 66);
            this.listenerButton.TabIndex = 0;
            this.listenerButton.Text = "OPTIONS";
            this.listenerButton.UseVisualStyleBackColor = false;
            this.listenerButton.Click += new System.EventHandler(this.listenerButton_Click);
            // 
            // botListDGV
            // 
            this.botListDGV.AllowUserToAddRows = false;
            this.botListDGV.AllowUserToDeleteRows = false;
            this.botListDGV.BackgroundColor = System.Drawing.SystemColors.Control;
            this.botListDGV.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.botListDGV.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Bodoni MT Black", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.botListDGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.botListDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idColumn,
            this.Listener,
            this.columnSlaveId,
            this.columnIP,
            this.columnDate,
            this.ColumnNotes});
            this.botListDGV.Location = new System.Drawing.Point(191, 1);
            this.botListDGV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.botListDGV.Name = "botListDGV";
            this.botListDGV.RowTemplate.Height = 24;
            this.botListDGV.Size = new System.Drawing.Size(756, 265);
            this.botListDGV.TabIndex = 4;
            this.botListDGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.botListDGV_CellContentClick);
            this.botListDGV.MouseClick += new System.Windows.Forms.MouseEventHandler(this.botListDGV_MouseClick);
            // 
            // idColumn
            // 
            this.idColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.idColumn.HeaderText = "ID";
            this.idColumn.Name = "idColumn";
            this.idColumn.Width = 51;
            // 
            // Listener
            // 
            this.Listener.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Listener.HeaderText = "Listener";
            this.Listener.Name = "Listener";
            // 
            // columnSlaveId
            // 
            this.columnSlaveId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.columnSlaveId.HeaderText = "SlaveId";
            this.columnSlaveId.Name = "columnSlaveId";
            // 
            // columnIP
            // 
            this.columnIP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.columnIP.HeaderText = "IP";
            this.columnIP.Name = "columnIP";
            // 
            // columnDate
            // 
            this.columnDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.columnDate.HeaderText = "JoinDate";
            this.columnDate.Name = "columnDate";
            // 
            // ColumnNotes
            // 
            this.ColumnNotes.HeaderText = "Notes";
            this.ColumnNotes.Name = "ColumnNotes";
            this.ColumnNotes.Text = "Notes";
            this.ColumnNotes.ToolTipText = "Notes";
            // 
            // textBoxCmd
            // 
            this.textBoxCmd.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.HistoryList;
            this.textBoxCmd.BackColor = System.Drawing.Color.MediumBlue;
            this.textBoxCmd.Dock = System.Windows.Forms.DockStyle.Right;
            this.textBoxCmd.Font = new System.Drawing.Font("Rubik", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCmd.ForeColor = System.Drawing.Color.White;
            this.textBoxCmd.Location = new System.Drawing.Point(966, 0);
            this.textBoxCmd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxCmd.Multiline = true;
            this.textBoxCmd.Name = "textBoxCmd";
            this.textBoxCmd.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxCmd.Size = new System.Drawing.Size(639, 671);
            this.textBoxCmd.TabIndex = 5;
            this.textBoxCmd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxCmd_KeyDown);
            // 
            // buttonGeneralLogs
            // 
            this.buttonGeneralLogs.Location = new System.Drawing.Point(5, 270);
            this.buttonGeneralLogs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonGeneralLogs.Name = "buttonGeneralLogs";
            this.buttonGeneralLogs.Size = new System.Drawing.Size(185, 31);
            this.buttonGeneralLogs.TabIndex = 6;
            this.buttonGeneralLogs.Text = "General Logs";
            this.buttonGeneralLogs.UseVisualStyleBackColor = true;
            this.buttonGeneralLogs.Click += new System.EventHandler(this.buttonGeneralLogs_Click);
            // 
            // buttonExceptionLogs
            // 
            this.buttonExceptionLogs.Enabled = false;
            this.buttonExceptionLogs.Location = new System.Drawing.Point(191, 270);
            this.buttonExceptionLogs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonExceptionLogs.Name = "buttonExceptionLogs";
            this.buttonExceptionLogs.Size = new System.Drawing.Size(181, 31);
            this.buttonExceptionLogs.TabIndex = 11;
            this.buttonExceptionLogs.Text = "Exception Logs";
            this.buttonExceptionLogs.UseVisualStyleBackColor = true;
            this.buttonExceptionLogs.Click += new System.EventHandler(this.buttonExceptionLogs_Click);
            // 
            // textBoxExceptionLogs
            // 
            this.textBoxExceptionLogs.BackColor = System.Drawing.SystemColors.MenuText;
            this.textBoxExceptionLogs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBoxExceptionLogs.ForeColor = System.Drawing.Color.Lime;
            this.textBoxExceptionLogs.Location = new System.Drawing.Point(0, 305);
            this.textBoxExceptionLogs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxExceptionLogs.Multiline = true;
            this.textBoxExceptionLogs.Name = "textBoxExceptionLogs";
            this.textBoxExceptionLogs.Size = new System.Drawing.Size(945, 366);
            this.textBoxExceptionLogs.TabIndex = 12;
            this.textBoxExceptionLogs.Visible = false;
            // 
            // textBoxGeneralLogs
            // 
            this.textBoxGeneralLogs.BackColor = System.Drawing.SystemColors.MenuText;
            this.textBoxGeneralLogs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxGeneralLogs.ForeColor = System.Drawing.Color.Lime;
            this.textBoxGeneralLogs.Location = new System.Drawing.Point(0, 304);
            this.textBoxGeneralLogs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxGeneralLogs.Multiline = true;
            this.textBoxGeneralLogs.Name = "textBoxGeneralLogs";
            this.textBoxGeneralLogs.Size = new System.Drawing.Size(945, 366);
            this.textBoxGeneralLogs.TabIndex = 13;
            // 
            // NorthStar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1605, 671);
            this.Controls.Add(this.textBoxGeneralLogs);
            this.Controls.Add(this.textBoxExceptionLogs);
            this.Controls.Add(this.buttonExceptionLogs);
            this.Controls.Add(this.buttonGeneralLogs);
            this.Controls.Add(this.textBoxCmd);
            this.Controls.Add(this.botListDGV);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "NorthStar";
            this.Text = "Project: NorthStar (Early Access) V 0.1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.botListDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void listenerKiller(int port)
        {
            TcpClient tc = new TcpClient();
            try
            {

                tc.Connect("localhost", port);
                tc.Close();
            }
            catch (Exception ex)
            {
               
            }

        }

       
       
        private void listenerButton_Click(object sender, EventArgs e)
        {

            //slavetempID değişkenin cell in içindeki değere ata.
            
            Settings obj = new Settings();
            obj.ShowDialog();
            int port;
            Task killTheListener;
            if (isMysqlSetted && isMysqlUpdated)
            {
                date = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                updateLogs("(" + date + ")" + " Connected MYSQL Service On: "+ mysqlIp);
                isMysqlUpdated = false;
            }


            Thread listener_thread = new Thread(new ThreadStart(listenerThread));
          
            if (!isKillClicked && Settings.listenerGo)
            {

                date = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                updateLogs("(" + date + ")" + " Listener: " + listenerName+ " is started on Port: "+ portToListen);
                Settings.listenerGo = false;
                listener_thread.Start();
               
            }
            else
            {
                isKillClicked = false;
                if (Settings.killerGo)
                {
                    if (comboxTemp == "All")
                    {
                        foreach (System.Collections.DictionaryEntry Item in listenerList)
                        {
                            port = (int)Item.Value;
                            killTheListener = Task.Run(() => listenerKiller(port));
                        }
                        date = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                        updateLogs("(" + date + ")" + " All Listeners are stopped ...");
                        Settings.killerGo = false;


                    }
                    else
                    {

                        if (comboxTemp.Length > 0)
                        {
                            port = (int)listenerList[comboxTemp];
                            date = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                            killTheListener = Task.Run(() => listenerKiller(port));
                            updateLogs("(" + date + ")" + " Listener: " + comboxTemp + " is stopped ...");
                            Settings.killerGo = false;

                        }
                    }


                }




            }
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button listenerButton;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.DataGridView botListDGV;
        private System.Windows.Forms.Button buttonBroadcast;
        private System.Windows.Forms.TextBox textBoxCmd;
        private System.Windows.Forms.Button buttonGeneralLogs;
        private System.Windows.Forms.Button buttonExceptionLogs;
        private System.Windows.Forms.TextBox textBoxExceptionLogs;
        private System.Windows.Forms.DataGridViewTextBoxColumn idColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Listener;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnSlaveId;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnDate;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnNotes;
        public System.Windows.Forms.TextBox textBoxGeneralLogs;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button buttonPayload;
    }
}

