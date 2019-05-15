﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Threading;
using System.Windows.Threading;

namespace WpfApp7
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        //백그라운드 워커 선언
        private BackgroundWorker myThread;

        //짝수의 합을 저장할 인스턴스 변수
        int sum = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            //백그라운드 워커 초기화
            //작업의 진행율이 바뀔 때 ProgressChanged 이벤트 발생여부
            //작업 취소 가능여부 true로 설정
            myThread = new BackgroundWorker()
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true            
            };

            //해야할 작업을 실행할 메소드 정의
            myThread.DoWork += myThread_DoWork;

            //UI쪽에 진행사항 보여주기
            //WorkerReportsProgress 속성값이 true일때만 이벤트 발생
            myThread.ProgressChanged += myThread_ProgressChanged;

            //작업이 완료되었을 때 실행할 콜백메소드 정의
            myThread.RunWorkerCompleted += myThread_RunWorkerCompleted;

            MessageBox.Show("Worker 초기화");
        }

        //백그라운드 워커가 진행하는 작업
        //DoWork 이벤트 처리 메소드에서 lstNumber.Items.Add(i)의 같은 코드를
        //직접 실행시키면 '' 오류발생
        private void myThread_DoWork(object sender, DoWorkEventArgs e)
        {
            int count = (int)e.Argument;
            for (int i = 1; i <= count; i++)
            {
                if(myThread.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                else
                {
                    Thread.Sleep(100);
                    this.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                        (ThreadStart)delegate()
                        {
                            if(i%2 ==0)
                            {
                                sum += i;
                                e.Result = sum;
                                lstNumber.Items.Add(i);
                            }
                        }
                        );
                    myThread.ReportProgress(i);
                }
            }
        }
        
        //작업 완료
        private void myThread_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
                MessageBox.Show("작업 취소.");
            else if (e.Error != null)
                MessageBox.Show("에러발생." + e.Error);
            else
            {
                lblSum.Content = ((int)e.Result).ToString();
                MessageBox.Show("작업완료");
            }
        }

        //작업의 진행률이 바뀔때 발생.
        private void myThread_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressbar.Value = e.ProgressPercentage;
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            int num;

            if(!int.TryParse(txtNumber.Text, out num))
            {
                MessageBox.Show("숫자를 입력하세요");
                return;
            }
            sum = 0;
            progressbar.Maximum = num;
            lstNumber.Items.Clear();
            myThread.RunWorkerAsync(num);
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            myThread.CancelAsync();
        }

    }
}
