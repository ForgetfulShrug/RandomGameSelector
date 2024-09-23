using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using System.Reflection.Emit;
using System.Reflection.Metadata;
//using System.Reflection.Emit;
//using Microsoft.VisualBasic.ApplicationServices;
//using RandomGameSelector.Properties;
//using Microsoft.VisualBasic;
//using System.Reflection.Metadata;
//using System.Data.Common;

namespace RandomGameSelector
{
    public partial class Form2 : Form
    {
        //Pull Current Settings
        public string[] PullSettings()
        {
            String[] Settings = new string[20];
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader("Selector_Settings.txt");
                //Read Filename, Sheet, Columns, and required Cell contents
                Settings[0] = sr.ReadLine().Replace("Filename:", "").TrimStart(' ');
                Settings[1] = sr.ReadLine().Replace("Sheet:", "").TrimStart(' ');
                sr.ReadLine();
                Settings[2] = sr.ReadLine().Replace("Column 1:", "").TrimStart(' ');
                Settings[3] = sr.ReadLine().Replace("Input 1:", "").TrimStart(' ');
                sr.ReadLine();
                Settings[4] = sr.ReadLine().Replace("Column 2:", "").TrimStart(' ');
                Settings[5] = sr.ReadLine().Replace("Input 2:", "").TrimStart(' ');
                sr.ReadLine();
                Settings[6] = sr.ReadLine().Replace("Column 3:", "").TrimStart(' ');
                Settings[7] = sr.ReadLine().Replace("Input 3:", "").TrimStart(' ');
                sr.ReadLine();
                Settings[8] = sr.ReadLine().Replace("Column 4:", "").TrimStart(' ');
                Settings[9] = sr.ReadLine().Replace("Input 4:", "").TrimStart(' ');
                sr.ReadLine();
                Settings[10] = sr.ReadLine().Replace("Locked 1:", "").TrimStart(' ');
                Settings[11] = sr.ReadLine().Replace("Locked 2:", "").TrimStart(' ');
                Settings[12] = sr.ReadLine().Replace("Locked 3:", "").TrimStart(' ');
                Settings[13] = sr.ReadLine().Replace("Locked 4:", "").TrimStart(' ');
                sr.ReadLine();
                Settings[14] = sr.ReadLine().Replace("OR Row 2:", "").TrimStart(' ');
                Settings[15] = sr.ReadLine().Replace("OR Row 3:", "").TrimStart(' ');
                Settings[16] = sr.ReadLine().Replace("OR Row 4:", "").TrimStart(' ');
                sr.ReadLine();
                Settings[17] = sr.ReadLine().Replace("AND Row 2:", "").TrimStart(' ');
                Settings[18] = sr.ReadLine().Replace("AND Row 3:", "").TrimStart(' ');
                Settings[19] = sr.ReadLine().Replace("AND Row 4:", "").TrimStart(' ');

                sr.Close();
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
            return Settings;
        }

        private void WriteSettings(string[] WSettings)
        {

            //Write Current Settings
            textBox1.Text = WSettings[0].ToString();
            textBox2.Text = WSettings[1].ToString();
            textBox3.Text = WSettings[2].ToString();
            textBox4.Text = WSettings[3].ToString();
            textBox5.Text = WSettings[4].ToString();           //Write Current Settings
            textBox6.Text = WSettings[5].ToString();
            textBox7.Text = WSettings[6].ToString();
            textBox8.Text = WSettings[7].ToString();
            textBox9.Text = WSettings[8].ToString();
            textBox10.Text = WSettings[9].ToString();
            checkBox1.Checked = WSettings[10].Equals("True");
            checkBox2.Checked = WSettings[11].Equals("True");
            checkBox3.Checked = WSettings[12].Equals("True");
            checkBox4.Checked = WSettings[13].Equals("True");
            checkBox5.Checked = WSettings[14].Equals("True");
            checkBox6.Checked = WSettings[15].Equals("True");
            checkBox7.Checked = WSettings[16].Equals("True");
            checkBox8.Checked = WSettings[17].Equals("True");
            checkBox9.Checked = WSettings[18].Equals("True");
            checkBox10.Checked = WSettings[19].Equals("True");
        }

        private void SaveSettings()
        {

            try
            {
                //Pass the filepath and filename to the StreamWriter Constructor
                StreamWriter sw = new StreamWriter("Selector_Settings.txt");
                sw.WriteLine("Filename:" + textBox1.Text);
                sw.WriteLine("Sheet:" + textBox2.Text);
                sw.WriteLine("");
                sw.WriteLine("Column 1:" + textBox3.Text);
                sw.WriteLine("Input 1:" + textBox4.Text);
                sw.WriteLine("");
                sw.WriteLine("Column 2:" + textBox5.Text);
                sw.WriteLine("Input 2:" + textBox6.Text);
                sw.WriteLine("");
                sw.WriteLine("Column 3:" + textBox7.Text);
                sw.WriteLine("Input 3:" + textBox8.Text);
                sw.WriteLine("");
                sw.WriteLine("Column 4:" + textBox9.Text);
                sw.WriteLine("Input 4:" + textBox10.Text);
                sw.WriteLine("");
                sw.WriteLine("Locked 1:" + checkBox1.Checked);
                sw.WriteLine("Locked 2:" + checkBox2.Checked);
                sw.WriteLine("Locked 3:" + checkBox3.Checked);
                sw.WriteLine("Locked 4:" + checkBox4.Checked);
                sw.WriteLine("");
                sw.WriteLine("OR Row 2:" + checkBox5.Checked);
                sw.WriteLine("OR Row 3:" + checkBox6.Checked);
                sw.WriteLine("OR Row 4:" + checkBox7.Checked);
                sw.WriteLine("");
                sw.WriteLine("AND Row 2:" + checkBox8.Checked);
                sw.WriteLine("AND Row 3:" + checkBox9.Checked);
                sw.WriteLine("AND Row 4:" + checkBox10.Checked);
                sw.WriteLine("");
                sw.WriteLine("Place information from the xlsx file for the Filename, Sheet Name, Column name and required content of the cell.");
                sw.WriteLine("Input xlsx needs Title and Console in first two rows");

                //Close the file
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }

        }


        public Form2()
        {
            String[] Settings = new string[20];
            Settings = PullSettings();

            InitializeComponent();
            WriteSettings(Settings);

        }

        private void button1_Click(object sender, EventArgs e)
        {

            SaveSettings();
            String[] SettingsNew = new string[20];
            SettingsNew = PullSettings();
            WriteSettings(SettingsNew);

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) { textBox3.ReadOnly = true; }
            if (!checkBox1.Checked) { textBox3.ReadOnly = false; }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked) { textBox5.ReadOnly = true; }
            if (!checkBox2.Checked & !checkBox5.Checked & !checkBox8.Checked) { textBox5.ReadOnly = false; }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked) { textBox7.ReadOnly = true; }
            if (!checkBox3.Checked & !checkBox6.Checked & !checkBox9.Checked) { textBox7.ReadOnly = false; }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked) { textBox9.ReadOnly = true; }
            if (!checkBox4.Checked & !checkBox7.Checked & !checkBox10.Checked) { textBox9.ReadOnly = false; }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked) { textBox5.ReadOnly = true; }
            if (!checkBox2.Checked & !checkBox5.Checked & !checkBox8.Checked) { textBox5.ReadOnly = false; }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked) { textBox7.ReadOnly = true; }
            if (!checkBox3.Checked & !checkBox6.Checked & !checkBox9.Checked) { textBox7.ReadOnly = false; }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked) { textBox9.ReadOnly = true; }
            if (!checkBox4.Checked & !checkBox7.Checked & !checkBox10.Checked) { textBox9.ReadOnly = false; }
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox8.Checked) { textBox5.ReadOnly = true; }
            if (!checkBox2.Checked & !checkBox5.Checked & !checkBox8.Checked) { textBox5.ReadOnly = false; }
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox9.Checked) { textBox7.ReadOnly = true; }
            if (!checkBox3.Checked &!checkBox6.Checked & !checkBox9.Checked) { textBox7.ReadOnly = false; }
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox10.Checked) { textBox9.ReadOnly = true; }
            if (!checkBox4.Checked & !checkBox7.Checked & !checkBox10.Checked) { textBox9.ReadOnly = false; }
        }
    }
}

