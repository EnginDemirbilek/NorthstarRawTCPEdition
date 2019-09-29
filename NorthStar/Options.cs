using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NorthStar
{
    public partial class Settings : Form
    {

        public static List<string> listenerNames = new List<string>();
        public static bool listenerGo = false;
        public static bool killerGo = false;
        private static bool isExceptionOccured = false;
        
     

        public Settings()
        {
            
            InitializeComponent();
            tabControlSettings.SelectTab("tabPageListener");
            comboBoxListeners.Items.Add("All");
            foreach (string name in NorthStar.listenersNameList)
            {
                comboBoxListeners.Items.Add(name);
            }

        }
     
        private void Form3_Load(object sender, EventArgs e)
        {
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            
            int port = Convert.ToInt32(textBoxPort.Text);
            NorthStar.portToListen = port;
            NorthStar.encryptionKey = textBoxEncryptionKey.Text;
            NorthStar.listenerName = textBoxName.Text;
            
            try
            {
                if (NorthStar.listenerList.ContainsValue(port))
                {
                    MessageBox.Show("Listener with same Port Exists !");
                    textBoxPort.Text = "";
                    textBoxName.Text = "";
                    textBoxEncryptionKey.Text = "";
                }
                else
                {

                    NorthStar.listenersNameList.Add(textBoxName.Text);

                    NorthStar.listenerEncryptionKeyList.Add(textBoxName.Text, textBoxEncryptionKey.Text);
                
                    NorthStar.listenerInitialKeyList.Add(textBoxName.Text, textBoxInitialKey.Text);
                    NorthStar.listenerList.Add(textBoxName.Text, port);
                    NorthStar.listenerAllowedList.Add(textBoxName.Text, true);
                    NorthStar.payloadInitialKeyList.Add(textBoxName.Text, textBoxInitialKey.Text);
                    listenerGo = true;
                    comboBoxListeners.Items.Add(textBoxName.Text);
                    this.Close();

                }

            }
            catch
            {
                MessageBox.Show("Listener with same name Exists !");
                textBoxPort.Text = "";
                textBoxName.Text = "";
                textBoxEncryptionKey.Text = "";
            }
                       
        }



        private void button2_Click(object sender, EventArgs e)
        {

            NorthStar.comboxTemp = comboBoxListeners.Text;
            NorthStar.isKillClicked = true;
            killerGo = true;
            int count = NorthStar.listenersNameList.Count;
            int i = 0;
            List<string> temp = new List<string>();
            foreach (string listenerName in NorthStar.listenersNameList)
            {

                temp.Add(listenerName);
            }


            if (NorthStar.comboxTemp == "All")
            {
                foreach (string listenerName in temp)
                {
                   
                    NorthStar.listenerAllowedList[listenerName] = false;
                    NorthStar.listenerList.Remove(listenerName);
                    NorthStar.listenersNameList.Remove(listenerName);

                }
                this.Close();

            }
            else if (NorthStar.comboxTemp == "") {
                MessageBox.Show("Choose a listener");
            }
            else
            {

                NorthStar.listenerAllowedList[comboBoxListeners.Text] = false;
                NorthStar.listenerList.Remove(comboBoxListeners.Text);
                NorthStar.listenersNameList.Remove(comboBoxListeners.Text);

                this.Close();
            }
           
        }

        private void textBoxPort_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(textBoxPort.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                textBoxPort.Text = "";
            }
        }

        private void buttonConnectMysql_Click(object sender, EventArgs e)
        {
            MySqlConnection test = new MySqlConnection("datasource=" + textBoxOptionMysqlIp.Text + ";port=" + textBoxOptionMysqlPort.Text + ";Initial Catalog='northstar';" + "username=" + textBoxOptionMysqlUsername.Text + ";password=" + textBoxOptionMysqlPassword.Text);

                try
                {
                    test.Open();
                }
                catch
                {
                   MessageBox.Show("Couldn't connect");
                    isExceptionOccured = true;
                }

                if (!isExceptionOccured)
                {
                    NorthStar.mysqlIp = textBoxOptionMysqlIp.Text;
                  
                    NorthStar.isMysqlSetted = true;
                    NorthStar.conn = new MySqlConnection("datasource=" + textBoxOptionMysqlIp.Text + ";port=" + textBoxOptionMysqlPort.Text + ";Initial Catalog='northstar';" + "username=" + textBoxOptionMysqlUsername.Text + ";password=" + textBoxOptionMysqlPassword.Text);
                    MessageBox.Show("connected");              //  this.Hide();
                NorthStar.isMysqlUpdated = true;
                test.Close();
               
                   
                }
            }
        

       
    }
}
