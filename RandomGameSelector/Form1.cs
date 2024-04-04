//using IronXL; //Not anymore, Paid only and very slow

//For EPPlus
using OfficeOpenXml;
using System;
using System.IO;

using System.Data;
using System.Windows.Forms;
using System.Reflection.Emit;
using Microsoft.VisualBasic.ApplicationServices;
using RandomGameSelector.Properties;
using Microsoft.VisualBasic;
using System.Reflection.Metadata;
using System.Xml.Linq;
using System.Data.Common;

namespace RandomGameSelector
{
    public partial class Form1 : Form
    {

        public class ExcelUtility //Taken from C# Corner because I don't know how to use EPPlus
        {
            public static DataTable ExcelDataToDataTable(string filePath, string sheetName, bool hasHeader = true)
            {
                var dt = new DataTable();
                var fi = new FileInfo(filePath);
                // Check if the file exists
                if (!fi.Exists)
                    throw new Exception("File " + filePath + " Does Not Exists");

                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                var xlPackage = new ExcelPackage(fi);
                // get the first worksheet in the workbook
                var worksheet = xlPackage.Workbook.Worksheets[sheetName];

                dt = worksheet.Cells[1, 1, worksheet.Dimension.End.Row, worksheet.Dimension.End.Column].ToDataTable(c =>
                {
                    c.FirstRowIsColumnNames = true;
                });

                return dt;
            }
        }


        public void CreateSettings() {
            
            try
            {
                //Pass the filepath and filename to the StreamWriter Constructor
                StreamWriter sw = new StreamWriter("Selector_Settings.txt");
                sw.WriteLine("Filename:Test_Game_Lists.xlsx");
                sw.WriteLine("Sheet:Games_List");
                sw.WriteLine("");
                sw.WriteLine("Column 1:Recordable");
                sw.WriteLine("Input 1:yes");
                sw.WriteLine("");
                sw.WriteLine("Column 2:System");
                sw.WriteLine("Input 2:Switch");
                sw.WriteLine("");
                sw.WriteLine("Column 3:Digital/Physical");
                sw.WriteLine("Input 3:Digital");
                sw.WriteLine("");
                sw.WriteLine("Column 4:AND");
                sw.WriteLine("Input 4:Both");
                sw.WriteLine("");
                sw.WriteLine("Place information from the xlsx file for the Filename, Sheet Name, Column name and required content of the cell.");
                sw.WriteLine("Put NA for ignored Columns except for the first");
                sw.WriteLine("Put AND for Column 4 for OR Operator with 3/4 options");
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


        public string[] PullSettings() {
            String[] Settings = new string[10];
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader("Selector_Settings.txt");
                //Read Filename, Sheet, Columns, and required Cell contents
                Settings[0] = sr.ReadLine().Replace("Filename:","").TrimStart(' ');
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


        private void PullGameLists()
        {

            //Initialize Settings;
            String[] Settings = new string[10];
            Settings = PullSettings();


            ////Was from working with IronExcel but was slow and paid 
            //Load Worksheet and convert to DataTable
            //WorkBook workBook = WorkBook.Load("Game_Lists.xlsx");
            //WorkSheet workSheet = workBook.GetWorkSheet("Games_List");
            //DataTable dataTable = workSheet.ToDataTable(true);

            try
            {
                //Replace path with path to 
                var path = Settings[0];
                var dataList = ExcelUtility.ExcelDataToDataTable(path, Settings[1], true);



                // Column 1 Check for Cell input and delete lacking rows
                for (int i = dataList.Rows.Count - 1; i >= 0; i--)
                {
                    DataRow dr = dataList.Rows[i];
                    if (dr[Settings[2]].ToString() != Settings[3])
                        dr.Delete();
                }
                dataList.AcceptChanges();


                //Check if NA for 2nd Column and if not check more Cells for input column
                if (Settings[4] != "NA") {

                    for (int i = dataList.Rows.Count - 1; i >= 0; i--)
                    {
                        DataRow dr = dataList.Rows[i];
                        if (dr[Settings[4]].ToString() != Settings[5])
                            dr.Delete();
                    }

                    dataList.AcceptChanges();

                }


                //Check if NA/AND for 3rd Column and if not check more Cells for input column
                if (Settings[6] != "NA" & Settings[8] != "AND")
                {

                    for (int i = dataList.Rows.Count - 1; i >= 0; i--)
                    {
                        DataRow dr = dataList.Rows[i];
                        if (dr[Settings[6]].ToString() != Settings[7])
                            dr.Delete();
                    }
                    dataList.AcceptChanges();

                }
                // If AND then check cell contents of column 3 against both inputs 3 and 4
                else if (Settings[6] == "AND") {
                    for (int i = dataList.Rows.Count - 1; i >= 0; i--)
                    {
                        DataRow dr = dataList.Rows[i];
                        if (dr[Settings[6]].ToString() != Settings[7] | dr[Settings[6]].ToString() != Settings[9] )
                            dr.Delete();
                    }
                    dataList.AcceptChanges();
                }

                // If not NA or AND then remove rows of cell not equal to input
                if (Settings[8] != "NA" & Settings[8] != "AND")
                {

                    for (int i = dataList.Rows.Count - 1; i >= 0; i--)
                    {
                        DataRow dr = dataList.Rows[i];
                        if (dr[Settings[8]].ToString() != Settings[9])
                            dr.Delete();
                    }

                    dataList.AcceptChanges();

                }


                // Remove Excess Columns
                while (dataList.Columns.Count > 3) // Remove Columns past #
                {
                    dataList.Columns.RemoveAt(3);
                }

                


                //Add Duplicate Prevention
                //Generating the random number and need the same for each row
                int RowNum = dataList.Rows.Count;
                Random rnd = new Random();
                int Bob = rnd.Next(RowNum);
                int Bobb = rnd.Next(RowNum);
                int Bobby = rnd.Next(RowNum);

                //Post to Labels
                label1.Text = dataList.Rows[Bob][0].ToString() + " \n" + dataList.Rows[Bob][1].ToString();
                label2.Text = dataList.Rows[Bobb][0].ToString() + " \n" + dataList.Rows[Bobb][1].ToString();
                label3.Text = dataList.Rows[Bobby][0].ToString() + " \n" + dataList.Rows[Bobby][1].ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());

            }

        }


        public Form1()
        {
            InitializeComponent();

            //Check for settings file and create if missing
            if (!File.Exists("Selector_Settings.txt"))
            {
                CreateSettings();
            }
            
            //Initial pull for random games
            PullGameLists();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e) //Pictures hide on click
        {
            pictureBox1.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox2.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            pictureBox3.Hide();
        }

        private void button1_Click(object sender, EventArgs e) //Showing pictures then rerolling choices
        {
            //Reset picture visibility and reroll random games
            pictureBox1.Show();
            pictureBox2.Show();
            pictureBox3.Show();
            PullGameLists();
        }
    }
}