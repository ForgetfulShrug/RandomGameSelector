//using IronXL; //Not anymore, Paid only and very slow

//For EPPlus
using OfficeOpenXml;
using System;
using System.IO;


using System.Data;
using System.Windows.Forms;
using System.Reflection.Emit;

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


        private void PullGameLists()
        {


            ////Was from working with IronExcel but was slow and paid 
            //Load Worksheet and convert to DataTable
            //WorkBook workBook = WorkBook.Load("Game_Lists.xlsx");
            //WorkSheet workSheet = workBook.GetWorkSheet("Games_List");
            //DataTable dataTable = workSheet.ToDataTable(true);



            ////Can be used to replace path with a chosen file
            //OpenFileDialog file = new OpenFileDialog(); //open dialog to choose file
            //if (file.ShowDialog() == DialogResult.OK) //if there is a file chosen by the user
            //{
            //    string fileExt = Path.GetExtension(file.FileName); //get the file extension
            //    if (fileExt.CompareTo(".xls") == 0 || fileExt.CompareTo(".xlsx") == 0)
            //    {
            try
            {
                //Replace path with path to 
                var path = @"Game_Lists.xlsx";
                var dataList = ExcelUtility.ExcelDataToDataTable(path, "Games_List", true);

                //remove unrecordable, Got this from somewhere don't remember where
                for (int i = dataList.Rows.Count - 1; i >= 0; i--)
                {
                    DataRow dr = dataList.Rows[i];
                    if (dr["Recordable"].ToString() != "yes")
                        dr.Delete();
                }
                dataList.AcceptChanges();

                while (dataList.Columns.Count > 3) // Remove Columns past #
                {
                    dataList.Columns.RemoveAt(3);
                }

                ////Originally used dataGrids to show data
                //dataGridView.Visible = true;

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


                //button2.Text = dataList.Rows[Bobb][0].ToString() + " \n" + dataList.Rows[Bobb][1].ToString();
                //= dataList.Rows[Bobb][0].ToString() + " \n" + dataList.Rows[Bobb][1].ToString();           
                //dataGridView.DataSource = dataList;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());

            }

            //    }
            //}
        }


        public Form1()
        {
            InitializeComponent();
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
            pictureBox1.Show();
            pictureBox2.Show();
            pictureBox3.Show();
            PullGameLists();
        }
    }
}