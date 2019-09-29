using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NorthStar
{
    public partial class Notes : Form
    {
        public static string slaveip;
        public MySqlCommand command = new MySqlCommand();

        public Notes()
        {
            InitializeComponent();
            showNotes();

        }

        private bool CheckIP()
        {
            string a = slaveip;

            string sql = "SELECT * FROM notes WHERE ip = @a";
            if (NorthStar.isMysqlSetted)
            {
                using (NorthStar.conn)
                {
                    NorthStar.conn.Open();
                    using (NorthStar.conn)
                    {
                        command = new MySqlCommand(sql, NorthStar.conn);
                        command.Parameters.AddWithValue("@a", a);
                        int result = Convert.ToInt32(command.ExecuteScalar());
                        if (result > 0)
                        {
                            NorthStar.conn.Close();
                            return true;

                        }
                        else
                        {
                            NorthStar.conn.Close();
                            return false;
                        }
                    }
                }
            }
            else
            {
                if (NorthStar.notes.ContainsKey(slaveip))
                {
                    return true;
                }
                else
                    return false;
            }

        }

        public void updateNotes(string value)
        {


            if (CheckIP())
            {
                string note_query = "update notes set noteValue=@VALUE, date=NOW() where ip = @ip"; //Dumduz sql veri tabanı güncelleme.

                if (NorthStar.isMysqlSetted)
                {

                    command = new MySqlCommand(note_query, NorthStar.conn);
                    try
                    {
                        NorthStar.conn.Open();
                        command.Parameters.AddWithValue("@VALUE", value);
                        command.Parameters.AddWithValue("@ip", slaveip);

                        command.ExecuteNonQuery();
                        textBoxSave.Text = "Note Updated !";
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Something Happened");
                    }

                    NorthStar.conn.Close();
                }
                else
                {
                    NorthStar.notes[slaveip] = value;
                    textBoxSave.Text = "Note Updated Temprorariliy!";

                }
            }
            else
            {
                string note_query = "insert into notes(noteValue, date, ip) value(@VALUE, NOW(), @ip)"; //Dumduz sql veri tabanı güncelleme.

                if (NorthStar.isMysqlSetted)
                {

                    command = new MySqlCommand(note_query, NorthStar.conn);
                    try
                    {
                        NorthStar.conn.Open();
                        command.Parameters.AddWithValue("@VALUE", value);
                        command.Parameters.AddWithValue("@ip", slaveip);

                        command.ExecuteNonQuery();
                        textBoxSave.Text = "Note Saved !";

                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Something Happened");
                    }
                    NorthStar.conn.Close();

                }
                else
                {
                    NorthStar.notes.Add(slaveip, value);
                    textBoxSave.Text = "Note Saved Temprorarily!";

                }

            }
        }

        public void showNotes()
        {
            
            string note_query = "SELECT noteValue from notes where ip = '" + slaveip + "'"; //Dumduz sql veri tabanı güncelleme.

            if (NorthStar.isMysqlSetted)
            {
               
                command = new MySqlCommand(note_query, NorthStar.conn);
                try
                {
                    NorthStar.conn.Open();
                    MySqlDataReader dr = command.ExecuteReader();
                    if (dr.Read())
                    {
                        richTextBoxNotes.Text = dr.GetValue(0).ToString();
                    }
                }
                catch (Exception ex)
                {


                }
                NorthStar.conn.Close();

            }
            else
            {
                richTextBoxNotes.Text = (string)NorthStar.notes[slaveip];

            }

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            updateNotes(richTextBoxNotes.Text);
        }
    }
}
