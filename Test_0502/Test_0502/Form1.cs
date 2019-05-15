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
        List<string> ListLoadFileName = new List<string>();
        List<string> ListLoadFilePath = new List<string>();
        int nCurrentImgNum = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void init()
        {
            ListLoadFilePath = new List<string>();
            ListLoadFileName = new List<string>();
            nCurrentImgNum = 0;
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
                opd.Multiselect = true;
                
                string strAppDir = Environment.GetFolderPath((Environment.SpecialFolder.MyDocuments));

                // 파일 불러오기를 했을 때 제일 처음에 열리는 디렉토리 설정
                opd.InitialDirectory = strAppDir;

                if(opd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        //초기화
                        if (ListLoadFileName.Count > 0 || ListLoadFilePath.Count > 0)
                            init();

                        for(int i = 0; i < opd.FileNames.Length; i++)
                        {
                            ListLoadFilePath.Add(opd.FileNames[i]);
                            ListLoadFileName.Add(opd.SafeFileNames[i]);
                        }

                        UpdateBtnCount(nCurrentImgNum, ListLoadFilePath.Count);
                        UpdateFileName(nCurrentImgNum);

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
            pbImg.Load(FileName);
            pbImg.SizeMode = PictureBoxSizeMode.StretchImage;            
        }

        private void BtnControl_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;
            int i = nCurrentImgNum;
            if (button.Name == "BtnLeft")
                i--;
            else
                i++;

            if (i < 0)
                i = ListLoadFilePath.Count - 1;
            else if (i > ListLoadFilePath.Count - 1)
                i = 0;
            pbImg.Load(ListLoadFilePath[i]);
            pbImg.SizeMode = PictureBoxSizeMode.StretchImage;
            UpdateBtnCount(i, ListLoadFilePath.Count);
            UpdateFileName(i);
        }

        private void LoadBtn_Img_Click(object sender, EventArgs e)
        {
            OpenFileDialog();
            if (ListLoadFilePath.Count > 0)
            {
                LoadPictureBoxImg(ListLoadFilePath[nCurrentImgNum]);
                UpdateFileName(nCurrentImgNum);
            }
        }

        private void UpdateBtnCount(int nCurrentNum, int nMaxCount)
        {
            BtnCount.Text = string.Format("({0}/{1})", nCurrentNum + 1, nMaxCount);
            nCurrentImgNum = nCurrentNum;
        }

        private void pbImg_MouseClick(object sender, MouseEventArgs e)
        {
            int i = nCurrentImgNum;
            if (e.Button == MouseButtons.Left)
                i--;
            else
                i++;

            if (i < 0)
                i = ListLoadFilePath.Count - 1;
            else if (i > ListLoadFilePath.Count - 1)
                i = 0;

            pbImg.Load(ListLoadFilePath[i]);
            pbImg.SizeMode = PictureBoxSizeMode.StretchImage;
            UpdateBtnCount(i, ListLoadFilePath.Count);
            UpdateFileName(i);
        }

        private void UpdateFileName(int nCurrentNum)
        {
            tbFileName.Text = ListLoadFileName[nCurrentNum];
        }
    }
}
