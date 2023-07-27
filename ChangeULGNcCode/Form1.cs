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

namespace ChangeULGNcCode
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Title = "代码读取";
            dialog.Filter = @"程序文件|*.NCP;*.txt";
            dialog.ShowDialog();
            string myfileName = dialog.FileName;
            if (myfileName.Trim() == "")
                return;
            this.richTextBox1.Clear();
            //StreamReader myReader = new StreamReader(myfileName,System.Text.Encoding.UTF8);
            //string line;
            //while ((line=myReader.ReadLine())!= null)
            //{
            //    this.richTextBox1.AppendText(line+"\n");

            //}
            //myReader.Close();
            richTextBox1.LoadFile(myfileName, RichTextBoxStreamType.PlainText);

           // textBox12.Text = myfileName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string response;
         // manualReset.Reset();//暂停Backgroundworker1
          //  button30.Text = "下载中...";
            // this.communication.GetResponse("&1", out response);
          //  this.communication.GetResponse("open prog 1", out response);
          //  this.communication.GetResponse("FRAX(x,z)", out response);
            // this.communication.GetResponse("clear", out response);
            int lineNumber = 0;
          //  listBox1.Items.Clear();
            richTextBox2.Clear();

            this.richTextBox2.AppendText("G90" + "\n");
            this.richTextBox2.AppendText("G01" + "\n");
            this.richTextBox2.AppendText("G54" + "\n");
            this.richTextBox2.AppendText("S" + this.textBox2.Text.Trim() + "\n");
            this.richTextBox2.AppendText("M04" + "\n");
            this.richTextBox2.AppendText("M08" + "\n");
            this.richTextBox2.AppendText("TA1" + "\n");
            this.richTextBox2.AppendText("TS1" + "\n");
            this.richTextBox2.AppendText("Z"+this.textBox3.Text.Trim()+"F50" + "\n");
            this.richTextBox2.AppendText("X-0.01" + "\n");


            if (this.checkBox1.Checked)
            {

                foreach (string line in richTextBox1.Lines)
                {

                    // this.communication.GetResponse("P1==" + lineNumber.ToString() + line, out response);


                    if (lineNumber >=16 && line.Contains("Z") && !line.Contains("G"))
                    {
                        if (lineNumber == 16)
                        {
                            // int x, y, z, c;



                            string result = line;
                            //  int x = result.IndexOf("X");

                            //  int y = result.IndexOf("Y");
                            //  int z = result.IndexOf("Z");
                            //  int c = result.IndexOf("C");
                            //  //      int f = result.IndexOf("F");
                            //  string strX = result.Substring(x + 1, y - x - 1);
                            //  string strY = result.Substring(y + 1, z - y - 1);
                            //  string strZ = result.Substring(z + 1, c - z - 1);
                            //  string strC = result.Substring(c + 1);
                            //  //  string str33 = result.Substring(z + 1, f - z - 1);
                            //  //     string str4 = result.Substring(f + 1);

                            //  //NC_Data[j, 0] = Convert.ToDouble(str1.Trim());
                            ////  NC_Data[j, 1] = Convert.ToDouble(str3.Trim());


                            //  //string Zvalue = line.Substring(z + 1);
                            // // double Zvalue = Convert.ToDouble(line.Substring(z + 1));


                            //  double Xvalue = Convert.ToDouble(strC);
                            //  double Yvalue = Convert.ToDouble(strC);
                            //  double Zvalue = Convert.ToDouble(strC);

                            //  double Cvalue = Convert.ToDouble(strC);


                            //  this.richTextBox2.AppendText("X" + strY + "Y" + strX + "Z" + strZ + "C" + strC + "\n");

                            int z = result.IndexOf("Z");

                            double Zvalue = Convert.ToDouble(line.Substring(z + 1));

                            this.richTextBox2.AppendText("Z" + Convert.ToString(Zvalue + 0.01) + "F" + this.textBox4.Text.Trim() + "\n");
                            this.richTextBox2.AppendText("Z" + Convert.ToString(Zvalue) + "F" + textBox1.Text + "\n");

                        }
                        else
                        {
                            string Result = line;


                            int b = Result.IndexOf("B");
                            string strfront = Result.Substring(0, b);

                            this.richTextBox2.AppendText(strfront + "\n");
                        }


                        //if (this.checkBox1.Checked)
                        //{


                        //    string result = line;


                        //    int B = result.IndexOf("B");
                        //    string strFront = result.Substring(1, B - 1);
                        //    this.richTextBox2.AppendText(strFront + "\n");

                        //}

                        //else


                    }



                    lineNumber++;


                }



            }
            else
            {
                foreach (string line in richTextBox1.Lines)
                {

                    // this.communication.GetResponse("P1==" + lineNumber.ToString() + line, out response);


                    if (lineNumber > 11 && line.Contains("Z") && !line.Contains("G"))
                    {
                        if (lineNumber == 12)
                        {
                            // int x, y, z, c;



                            string result = line;
                            //  int x = result.IndexOf("X");

                            //  int y = result.IndexOf("Y");
                            //  int z = result.IndexOf("Z");
                            //  int c = result.IndexOf("C");
                            //  //      int f = result.IndexOf("F");
                            //  string strX = result.Substring(x + 1, y - x - 1);
                            //  string strY = result.Substring(y + 1, z - y - 1);
                            //  string strZ = result.Substring(z + 1, c - z - 1);
                            //  string strC = result.Substring(c + 1);
                            //  //  string str33 = result.Substring(z + 1, f - z - 1);
                            //  //     string str4 = result.Substring(f + 1);

                            //  //NC_Data[j, 0] = Convert.ToDouble(str1.Trim());
                            ////  NC_Data[j, 1] = Convert.ToDouble(str3.Trim());


                            //  //string Zvalue = line.Substring(z + 1);
                            // // double Zvalue = Convert.ToDouble(line.Substring(z + 1));


                            //  double Xvalue = Convert.ToDouble(strC);
                            //  double Yvalue = Convert.ToDouble(strC);
                            //  double Zvalue = Convert.ToDouble(strC);

                            //  double Cvalue = Convert.ToDouble(strC);


                            //  this.richTextBox2.AppendText("X" + strY + "Y" + strX + "Z" + strZ + "C" + strC + "\n");

                            int z = result.IndexOf("Z");

                            double Zvalue = Convert.ToDouble(line.Substring(z + 1));

                            this.richTextBox2.AppendText("Z" + Convert.ToString(Zvalue + 0.01) + "F" + this.textBox4.Text.Trim() + "\n");
                            this.richTextBox2.AppendText("Z" + Convert.ToString(Zvalue) + "F" + textBox1.Text + "\n");

                        }


                        //if (this.checkBox1.Checked)
                        //{


                        //    string result = line;


                        //    int B = result.IndexOf("B");
                        //    string strFront = result.Substring(1, B - 1);
                        //    this.richTextBox2.AppendText(strFront + "\n");

                        //}

                        //else
                            this.richTextBox2.AppendText(line + "\n");
                    }



                    lineNumber++;


                }
            }






            this.richTextBox2.AppendText("Z" + this.textBox3.Text.Trim() + "F" + this.textBox4.Text.Trim() + "\n");
            this.richTextBox2.AppendText("X0" + "\n");
            this.richTextBox2.AppendText("M05" + "\n");
            this.richTextBox2.AppendText("M09" + "\n");
            this.richTextBox2.AppendText("M30" + "\n");
            MessageBox.Show("转换成功！");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "保存代码";
            saveFileDialog.Filter = "文本文件|*.txt";
            saveFileDialog.ShowDialog();
            string fileName = saveFileDialog.FileName;
            if (fileName == "")
                return;

            //清空文本
            FileStream fileStream = File.Open(fileName, FileMode.OpenOrCreate, FileAccess.Write);
            fileStream.Seek(0, SeekOrigin.Begin);
            fileStream.SetLength(0);
            fileStream.Close();

            //  FileStream fs = new FileStream(fileName, FileMode.Append);
            // StreamWriter wr = new StreamWriter(fs);
            richTextBox2.SaveFile(fileName, RichTextBoxStreamType.PlainText);
            MessageBox.Show("保存成功！");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.textBox1.Text = "1";
            this.textBox2.Text = "200";
            this.textBox3.Text = "10";
            this.textBox4.Text = "50";
        }
    }
}
