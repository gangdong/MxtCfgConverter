using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MxtCfgConverter
{
    public partial class MainForm : Form
    {

        private string fileName;
        private StringBuilder cfgData = new StringBuilder();
        private StreamReader sR;
        private StreamWriter sW;



        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void importBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDlg = new OpenFileDialog();

            openFileDlg.Title = "Choose File";
            openFileDlg.Filter = "raw文件|*.raw";
            openFileDlg.Multiselect = false;
            openFileDlg.InitialDirectory = "D:\\";

            if (openFileDlg.ShowDialog() == DialogResult.OK)
            {

                fileNameTextBox.Text = openFileDlg.FileName;

            }

        }

        private void convertBtn_Click(object sender, EventArgs e)
        {



            if (fileNameTextBox.Text == "")
            {

                MessageBox.Show("请选择文件");

            }
            else
            {

                fileName = fileNameTextBox.Text;

                cfgData.Clear();
                sR = File.OpenText(fileName);
                string nextLine;
                int lineIndex = 0;

                while ((nextLine = sR.ReadLine()) != null)
                {
                    //line index start from 1
                    lineIndex++;

                    if ((lineIndex == 1) && (nextLine != "OBP_RAW V1"))
                    {
                        MessageBox.Show("无效的文件格式");
                    }
                    else if (lineIndex == 2)
                    {
                        if (nextLine.Length != 20)
                        {

                        }
                        else
                        {

                            string[] tmp = nextLine.Split(' ');
                            for (int i = 0; i < tmp.Length; i++)
                            {

                                string local = "0x" + tmp[i] + ", ";
                                cfgData.Append(local);

                            }
                            cfgData.Append("\r\n");
                        }
                    }
                    else if ((lineIndex == 3) || (lineIndex == 4))
                    {

                        if (nextLine.Length != 6)
                        {

                        }
                        else
                        {

                            for (int i = 0; i < 3; i++)
                            {
                                string t = "0x" + nextLine.Substring(2 * i, 2) + ", ";
                                cfgData.Append(t);
                            }

                            cfgData.Append("\r\n");

                        }
                    }
                    else if(lineIndex > 4){

                        string[] tmp = nextLine.Split(' ');
                        for (int i = 0; i < tmp.Length; i++) {

                            if (i < 3) {
                                string str = "0x" + tmp[i].Substring(0, 2) + ", ";
                                cfgData.Append(str);
                                str = "0x" + tmp[i].Substring(2, 2) + ", ";
                                cfgData.Append(str);
                            }
                            else {
                                cfgData.Append("0x" + tmp[i] + ", ");
                            }
                            

                        }
                        cfgData.Append("\r\n");

                    }

            statusTextBox.Text = cfgData.ToString();

        }

                sR.Close();
    }

 }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDlg = new SaveFileDialog();

            saveFileDlg.Title = "Choose File";
            saveFileDlg.Filter = "h文件|*.h";
            saveFileDlg.FilterIndex = 1;
            saveFileDlg.InitialDirectory = "D:\\";
            saveFileDlg.RestoreDirectory = true;
            

            if (saveFileDlg.ShowDialog() == DialogResult.OK)
            {

                string saveFileName = saveFileDlg.FileName;
                FileInfo saveFile = new FileInfo(saveFileName);
                sW = saveFile.CreateText();

                string prx = "#ifndef _ATMEL_MXT_CFG_H \r\n"+ "#define _ATMEL_MXT_CFG_H \r\n"+ "const unsigned char mxt_cfg_data[] = { \r\n";
                string suf = "};\r\n" + "#endif";
                sW.WriteLine(prx+cfgData+suf);
                sW.Close();

                MessageBox.Show("File Saved!\n"+saveFileName,"File Save Confirmation",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            string aboutText = "Raw2Array Converter, one of MXT Touch series tool, convert the Raw format configuration file to hex data array.\n\nVersion: V1.0.00\nAuthor: daviddong@solomon-systech.com\nDate: 2018-2-1";
            MessageBox.Show(aboutText, "Raw to Array Converter", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
