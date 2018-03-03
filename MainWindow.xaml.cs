using System;
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
using Microsoft.Win32;
using System.IO;
using System.ComponentModel;

namespace NotePad
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private bool emptyTextBox()
        {
            if (myTextBox.Text == "")
                return true;
            else
                return false;
        }
        private void SaveMeassageProcess()
        {
            string messageBoxText = "기존 내용을 저장하시겠습니까?";
            string caption = "저장 체크";
            MessageBoxButton button = MessageBoxButton.YesNo;
            MessageBoxImage icon = MessageBoxImage.Warning;

            // Display message box
            MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);

            // Process message box results
            switch (result)
            {
                case MessageBoxResult.Yes:
                    // User pressed Yes button;
                    btnSaveFile_Click();
                    break;
                case MessageBoxResult.No:
                    // User pressed No button
                    myTextBox.Text = "";
                    break;
            }
        }
        private void mnuNew_Click(object sender, RoutedEventArgs e)
        {
            if (!emptyTextBox())
            {
                SaveMeassageProcess();
            }

        }
        private void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (openFileDialog.ShowDialog() == true)
                myTextBox.Text = File.ReadAllText(openFileDialog.FileName, Encoding.UTF8);
        }
        private void btnSaveFile_Click()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text file (*.txt)|*.txt|C# file (*.cs)|*.cs";
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (saveFileDialog.ShowDialog() == true)
                File.WriteAllText(saveFileDialog.FileName, myTextBox.Text);
        }
        private void btnSaveFile_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text file (*.txt)|*.txt|C# file (*.cs)|*.cs";
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (saveFileDialog.ShowDialog() == true)
                File.WriteAllText(saveFileDialog.FileName, myTextBox.Text);
        }
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        
        void DataWindow_Closing(object sender, CancelEventArgs e)
        {
            //MessageBox.Show("Closing called");
            if (!emptyTextBox())
            {
                SaveMeassageProcess();
            }
        }
    }
}
