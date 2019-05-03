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

namespace Test_0502
{
    public partial class Form1 : Form
    {
        string LoadFileName = string.Empty;
        List<string> ListLoadFileName = new List<string>();
        int CurrentImgNum = 0;

        public Form1()
        {
            InitializeComponent();
        }
        
        private void OpenFileDialog()
        {
            List<string> rList = new List<string>();

            using (OpenFileDialog opd = new OpenFileDialog())
            {
                // 기본 파일 타입 설정
                opd.DefaultExt = "All files";
                opd.Filter = "All files (*.*)|*.*";
                
                //다중선택
                //opd.Multiselect = false;
                opd.Multiselect = true;
                
                string strAppDir = Environment.GetFolderPath((Environment.SpecialFolder.MyDocuments));

                // 파일 불러오기를 했을 때 제일 처음에 열리는 디렉토리 설정
                opd.InitialDirectory = strAppDir;

                if(opd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        //if(opd.SafeFileName.LastIndexOf(".") > -1)
                        //{
                        //    MessageBox.Show("확장자가 존재하는 파일은 선택하실 수 없습니다.");

                        //    return;
                        //}

                        //단일 선택
                        //string fileName = opd.FileName;                        
                        //LoadFileName = fileName;

                        //다중 선택
                        if (ListLoadFileName.Count > 0)
                            ListLoadFileName = new List<string>();

                        for(int i = 0; i < opd.FileNames.Length; i++)
                        {
                            ListLoadFileName.Add(opd.FileNames[i]);
                        }

                        BtnCount.Text = string.Format("({0}/{1})", CurrentImgNum+1, opd.FileNames.Length);

                        //선택한 파일을 Open
                        //rList = ReadTextFileToList(fileName);
                    }
                    catch (System.Exception ex)
                    {
                    	MessageBox.Show(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                    }
                }
            }
        }
        /*
        private List<string> ReadTextFileToList(string fileName)
        {
            List<string> readStreamReaderList = new List<string>();
            using (FileStream iStream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                using(StreamReader reader = new StreamReader(iStream , Encoding.Default))
                {
                    reader.BaseStream.Seek(0, SeekOrigin.Begin);
                    while (reader.Peek() > -1)
                    {
                        readStreamReaderList.Add(reader.ReadLine());
                    }
                    reader.Close();
                    iStream.Close();
                }
            }
            return readStreamReaderList;
        }
        */
        private void LoadPictureBoxImg(string FileName)
        {
            pictureBox1.Load(FileName);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;            
        }

        private void BtnControl_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            int i = CurrentImgNum;
            if (button.Name == "BtnLeft")
                i--;
            else
                i++;

            if (i < 0)
                i = ListLoadFileName.Count - 1;
            else if (i > ListLoadFileName.Count - 1)
                i = 0;
            pictureBox1.Load(ListLoadFileName[i]);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            BtnCount.Text = string.Format("({0}/{1})", i + 1, ListLoadFileName.Count);
            CurrentImgNum = i;
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            int i = CurrentImgNum;
            i++;
            if (i > ListLoadFileName.Count - 1)
                i = 0;
            pictureBox1.Load(ListLoadFileName[i]);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            BtnCount.Text = string.Format("({0}/{1})", i + 1, ListLoadFileName.Count);
            CurrentImgNum = i;
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            int i = CurrentImgNum;
            if (e.Button == MouseButtons.Left)
                i--;
            else
                i++;

            if (i < 0)
                i = ListLoadFileName.Count - 1;
            else if (i > ListLoadFileName.Count - 1)
                i = 0;

            pictureBox1.Load(ListLoadFileName[i]);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            BtnCount.Text = string.Format("({0}/{1})", i + 1, ListLoadFileName.Count);
            CurrentImgNum = i;
        }

        private void LoadBtn_Img_Click(object sender, EventArgs e)
        {
            OpenFileDialog();
            if (ListLoadFileName[CurrentImgNum].Length > 0)
                LoadPictureBoxImg(ListLoadFileName[CurrentImgNum]);
        }
    }
}
