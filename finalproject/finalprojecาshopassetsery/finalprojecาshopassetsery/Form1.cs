using System.Drawing.Printing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace finalprojecาshopassetsery
{
    public partial class Form1 : Form
    {
        public Font SnamDeklenchaya { get; private set; }
        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem11_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "CSV (*.csv) | *.csv";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string[] readAlline = File.ReadAllLines(ofd.FileName);

                string readAllText = File.ReadAllText(ofd.FileName);
                for (int i = 0; i < readAlline.Length; i++)
                {
                    string allDATARAW = readAlline[i];
                    string[] allDATASplited = allDATARAW.Split(',');
                    this.dataGridView1.Rows.Add(allDATASplited[0], allDATASplited[1], allDATASplited[2], allDATASplited[3], allDATASplited[4], allDATASplited[5], allDATASplited[6]);

                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "CSV(*.csv)|*.csv";
                bool fileError = false;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (!fileError)
                    {
                        try
                        {
                            int columnCount = dataGridView1.Columns.Count;
                            string column = "";
                            string[] outputCSV = new string[dataGridView1.Rows.Count + 1];
                            for (int i = 0; i < columnCount; i++)
                            {
                                column += dataGridView1.Columns[i].HeaderText.ToString() + ",";
                            }
                            outputCSV[0] += column;
                            for (int i = 1; (i - 1) < dataGridView1.Rows.Count; i++)
                            {
                                for (int j = 0; j < columnCount; j++)
                                {
                                    outputCSV[i] += dataGridView1.Rows[i - 1].Cells[j].Value.ToString() + ",";
                                }
                            }

                            File.WriteAllLines(saveFileDialog.FileName, outputCSV, Encoding.UTF8);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error :" + ex.Message);
                        }
                    }
                }
            }
        }

       

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void labelbrand_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string Code = textBoxcode.Text;
            string Day = textBoxday.Text;
            string List = textBoxlist.Text;
            string textbox1 = textBox1.Text;
            string Poduck = comboBox1.Text;
            string Accessories = comboBox2.Text;

            int n = dataGridView1.Rows.Add();
            dataGridView1.Rows[n].Cells[4].Value = textBoxcode.Text;
            dataGridView1.Rows[n].Cells[2].Value = textBoxday.Text;
            dataGridView1.Rows[n].Cells[3].Value = textBoxlist.Text;
            dataGridView1.Rows[n].Cells[5].Value = textBox1.Text;


            if (Poduck == "Pocket")
            {
                poduck pocket = new poduck();
                pocket.Pocket = Poduck;
                dataGridView1.Rows[n].Cells[0].Value = pocket.Pocket;
            }
            if (Poduck == "Watch")
            {
                poduck watch = new poduck();
                watch.Watch = Poduck;
                dataGridView1.Rows[n].Cells[0].Value = watch.Watch;
            }
            if (Poduck == "Sneakers")
            {
                poduck sneakers = new poduck();
                sneakers.Sneakers = Poduck;
                dataGridView1.Rows[n].Cells[0].Value = sneakers.Sneakers;
            }
            if (Poduck == "Bathingsuit")
            {
                poduck bathingsuit = new poduck();
                bathingsuit.Bathingsuit = Poduck;
                dataGridView1.Rows[n].Cells[0].Value = bathingsuit.Bathingsuit;
            }

            if (Accessories == "Gucci")
            {
                Accessories accessorie = new Accessories();
                accessorie.Gucci = Accessories;
                dataGridView1.Rows[n].Cells[1].Value = accessorie.Gucci;
            }
            if (Accessories == "Balenciaga")
            {
                Accessories accessorie = new Accessories();
                accessorie.Balenciaga = Accessories;
                dataGridView1.Rows[n].Cells[1].Value = accessorie.Balenciaga;
            }
            if (Accessories == "Fendi")
            {
                Accessories accessorie = new Accessories();
                accessorie.Fendi = Accessories;
                dataGridView1.Rows[n].Cells[1].Value = accessorie.Fendi;
            }
            if (Accessories == "Versace")
            {
                Accessories accessorie = new Accessories();
                accessorie.Versace = Accessories;
                dataGridView1.Rows[n].Cells[1].Value = accessorie.Versace;
            }


            dataGridView1.Rows[n].Cells[4].Value = Code;
            dataGridView1.Rows[n].Cells[2].Value = Day;
            dataGridView1.Rows[n].Cells[3].Value = List;
        } 
        
        
        private void button3_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void printDocument1_PrintPage_1(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawString("ใบสั่งซื้อ", new Font("SnamDeklenchaya", 20, FontStyle.Underline), Brushes.Red, new Point(370, 100));
            e.Graphics.DrawString("---------------------------------------------------------------------", new Font("Arial", 16, FontStyle.Regular), Brushes.Black, new Point(100, 150));
            e.Graphics.DrawString("สินค้าที่ต้องการ " + comboBox1.Text, new Font("SnamDeklenchaya", 16, FontStyle.Regular), Brushes.Black, new Point(100, 200));
            e.Graphics.DrawString(" จากแบนด์ " + comboBox2.Text, new Font("SnamDeklenchaya", 16, FontStyle.Regular), Brushes.Black, new Point(100, 250));
            e.Graphics.DrawString(" รหัสสินค้า " + textBoxcode.Text, new Font("SnamDeklenchaya", 16, FontStyle.Regular), Brushes.Black, new Point(100, 300));
            e.Graphics.DrawString("วันที่สั่ง" + textBoxday.Text, new Font("SnamDeklenchaya", 16, FontStyle.Regular), Brushes.Black, new Point(100, 350));
            e.Graphics.DrawString("---------------------------------------------------------------------", new Font("Arial", 16, FontStyle.Regular), Brushes.Black, new Point(100, 500));
        }
    }
    
}