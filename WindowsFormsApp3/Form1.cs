using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace WindowsFormsApp3
{

    public partial class Form1 : Form
    {
        [Serializable]
        public class GridText
        {
            public object[,] Text { get; set; }
        }


        public Form1()
        {
            InitializeComponent();
            var col = dataGridView1.Columns[2] as IColorFormat;
            col.ColorFormats = new[]
            {
                 new ColorFormat()
                 {

                    Color = Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))),
                     Predicate = (d) =>
                     {
                        var ts = d -  DateTime.Today;
                                return ts.TotalDays < 0 && ts < TimeSpan.FromDays(0);
                     },
                     Color1 = Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))),
                    Predicate1 = (d) =>
                    {
                        var ts = d - DateTime.Today;
                        return ts.TotalDays < 0 && ts < TimeSpan.FromDays(0);
                    }

                 },


            };
        }






       

        private void Form1_Load(object sender, EventArgs e)
        {

            dataGridView1.Rows.Clear();

            GridText gridText = new GridText();
            FileStream fs = new FileStream("list.txt", FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();

            gridText.Text = (object[,])formatter.Deserialize(fs);

            for (int i = 0; i < gridText.Text.GetLength(0); i++)
            {
                dataGridView1.Rows.Add();

                for (int j = 0; j < gridText.Text.GetLength(1); j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = gridText.Text[i, j];

                }
            }
            dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 2);
            fs.Close();


            dataGridView1.Sort(dataGridView1.Columns[2], ListSortDirection.Ascending);

        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {

                GridText gridText = new GridText();
                gridText.Text = new object[dataGridView1.RowCount, dataGridView1.ColumnCount];


                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    {
                        if (dataGridView1.Rows[i].Cells[j].Value != null)
                        {

                            gridText.Text[i, j] = (object)dataGridView1.Rows[i].Cells[j].Value;

                        }

                    }
                }



                FileStream fs = new FileStream("list.txt", FileMode.Create);
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, gridText.Text);

                fs.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Сохранить не удалось", "Ошибка");
            }


        }



        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Изменять можно", "Внимание");
            /*
            for (int currentRow = 0; currentRow < dataGridView1.Rows.Count - 1; currentRow++)
            {
                
                
                bool duplicateRow = false;
                DataGridViewRow rowToCompare = dataGridView1.Rows[currentRow];
                for (int otherRow = currentRow + 1; otherRow < dataGridView1.Rows.Count; otherRow++)
                {
                    DataGridViewRow row = dataGridView1.Rows[otherRow];

                    if (rowToCompare.Cells[1].ValueType.Equals(row.Cells[1].ValueType))
                    {
                        if (duplicateRow)
                        {
                            rowToCompare.DefaultCellStyle.BackColor = System.Drawing.Color.Red;
                        }
                        else
                        {
                            dataGridView1.Rows[1].Cells[1].Style.BackColor = System.Drawing.Color.Blue;
                        }
                        duplicateRow = true;
                    }   
                    else
                    {
                        duplicateRow = false;
                    }
                }
               
            }
                */
        }

        private void созранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {


            try
            {
                GridText gridText = new GridText();
                gridText.Text = new object[dataGridView1.RowCount, dataGridView1.ColumnCount];

                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    {
                        if (dataGridView1.Rows[i].Cells[j].Value != null)
                        {
                            gridText.Text[i, j] = (object)dataGridView1.Rows[i].Cells[j].Value;

                        }


                    }
                }



                FileStream fs = new FileStream("list.txt", FileMode.Create);
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, gridText.Text);
                MessageBox.Show("Программа сохранена", "Внимание");
                fs.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Сохранить не удалось", "Ошибка" + ex.InnerException);
            }

        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }


}
