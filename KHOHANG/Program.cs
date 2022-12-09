using DataLayer;
using DevExpress.LookAndFeel;
using DevExpress.Skins;
using DevExpress.UserSkins;
using DevExpress.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace KHOHANG
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            BonusSkins.Register();
            SkinManager.EnableFormSkins();
            UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");

            if (File.Exists("connectdb.dba"))
            {
                string conStr = "";
                BinaryFormatter bf = new BinaryFormatter();
                FileStream fs = File.Open("connectdb.dba", FileMode.Open, FileAccess.Read);   
                connect cp = (connect)bf.Deserialize(fs);
                string servername = Encryptor.Decrypt(cp.servername, "qwertyuiop", true);
                string username = Encryptor.Decrypt(cp.username, "qwertyuiop", true);
                string password = Encryptor.Decrypt(cp.passwd, "qwertyuiop", true);
                string database = Encryptor.Decrypt(cp.database, "qwertyuiop", true);
                conStr += "Data Source" + servername + ";Initial Catalog" + database + "; User ID = " + username + "; Password" + password + ";";
                connoi = conStr;
                SqlConnection con = new SqlConnection(conStr);

                try
                {
                    con.Open();
                   
                }
                catch
                {
                    MessageBox.Show("Không thể kết nối CSDL. ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    fs.Close();
                }
                Application.Run(new MainForm());
                con.Close();
                fs.Close();
            }
            else
            {
                Application.Run(new MainForm());
            }
        }
        public static string connoi = "";
    }
}
