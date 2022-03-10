using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Win32;
using System.Threading;





namespace WoW
{
    public partial class MainWindow : Window
    {
        string wayOut = "";
        string wayIn = "";

        
        Thread thread;
        private void cmbPriorityThread1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (!thread.IsAlive)
                    thread = new Thread(EmptyFunc);
                switch (cmbPriorityThread1.SelectedIndex)
                {
                    case 0:
                        thread.Priority = ThreadPriority.Lowest;
                        break;
                    case 1:
                        thread.Priority = ThreadPriority.BelowNormal;
                        break;
                    case 2:
                        thread.Priority = ThreadPriority.Normal;
                        break;
                    case 3:
                        thread.Priority = ThreadPriority.AboveNormal;
                        break;
                    case 4:
                        thread.Priority = ThreadPriority.Highest;
                        break;
                    default:
                        thread.Priority = ThreadPriority.Lowest;
                        break;
                }
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void EmptyFunc() { }


        private void cmbSelectedMode_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnStart.IsEnabled = true;
            btnInfoFile.IsEnabled = false;
            btnRenameFile.IsEnabled = false;
            chWay1_selected.IsChecked = false;
            chWay2_selected.IsChecked = false;
        }



        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
        public MainWindow()
        {
            InitializeComponent();
            thread = new Thread(EmptyFunc);
            cmbPriorityThread1.SelectedIndex = 0;
            cmbSelectedMode.SelectedIndex = 0;
        }





// работа с путями
        private void ButtonWayOut_Click(object sender, RoutedEventArgs e)
        {
            if (cmbSelectedMode.SelectedIndex == 0)
                wayOut = chooseFile();
            else if (cmbSelectedMode.SelectedIndex == 1)
                wayOut = funcs1.chooseDirectory();

            chWay1_selected.IsChecked = true;
            btnInfoFile.IsEnabled = true;
            btnRenameFile.IsEnabled = true;
        }
        private void ButtonWayIn_Click(object sender, RoutedEventArgs e)
        {
            wayIn = funcs1.chooseDirectory();

            chWay2_selected.IsChecked = true;
            btnStart.IsEnabled = true;
        }

        public string chooseFile()
        {
            OpenFileDialog ofd1 = new OpenFileDialog();
            ofd1.Title = "выберите файл";
            ofd1.Multiselect = false;
            if (Directory.Exists(wayOut))
                ofd1.InitialDirectory = wayOut;

            if (ofd1.ShowDialog() == true)
            { return ofd1.FileName; }
            else return "";
        }

// осн алгоритм
        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();      
            Directory.CreateDirectory(destDirName);

            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string tempPath = Path.Combine(destDirName, file.Name);
                file.CopyTo(tempPath, false);
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string tempPath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, tempPath, copySubDirs);
                }
            }
        }

        private void fdCopyFile()
        {
            try
            {
                File.Copy(wayOut, wayIn + funcs1.parseWay(wayOut), false);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void fdCopyDirectory()
        {
            try
            {
                DirectoryCopy(wayOut, wayIn + funcs1.parseWay(wayOut), true);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }


        private void fdMoveFile()
        {
            try
            {
                File.Move(wayOut, wayIn + funcs1.parseWay(wayOut));
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }
        private void fdMoveDirectory()
        {
            try
            {
                Directory.Move(wayOut, wayIn + funcs1.parseWay(wayOut));
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }

        private void fdDeleteFile()
        {
            try
            {
                File.Delete(wayOut);

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void fdDeleteDirectory()
        {
            try
            {
                Directory.Delete(wayOut, true);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }


        private void fdRename()
        {
            if (TextNewName.Text == "")
            {
                MessageBox.Show("Введите имя");
                return;
            }
            try
            {
                if (cmbSelectedMode.SelectedIndex == 0)
                    File.Move(wayOut,funcs1.parseDirectory(wayOut, TextNewName.Text, true));
                if (cmbSelectedMode.SelectedIndex == 1)
                    Directory.Move(wayOut,funcs1.parseDirectory(wayOut, TextNewName.Text, false));
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void fdInfo()
        {
            try
            {
                if (cmbSelectedMode.SelectedIndex == 0)
                {
                    FileInfo fileInfo = new FileInfo(wayOut);
                    lName.Content = "Имя: " + fileInfo.Name.ToString();
                    lSize.Content = "Размер: " + fileInfo.Length.ToString();
                    lCreateTime.Content = "Время создания: " + fileInfo.CreationTime.ToString();
                }
                else if (cmbSelectedMode.SelectedIndex == 1)
                {
                    long size = 0;
                    DirectoryInfo directoryInfo = new DirectoryInfo(wayOut);
                    foreach (var file in directoryInfo.GetFiles())//
                    {
                        FileInfo fileInfo = new FileInfo(file.FullName);
                        size += fileInfo.Length;
                    }

                    lName.Content = "Имя: " + directoryInfo.Name.ToString();
                    lSize.Content = "Размер: " + size.ToString();
                    lCreateTime.Content = "Время создания: " + directoryInfo.CreationTime.ToString();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }



        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            switch (cmbSelectedAction.SelectedIndex)
            {
                case 0:
                    {
                        if (cmbSelectedMode.SelectedIndex == 0)
                            thread = new Thread(fdCopyFile);
                        else if (cmbSelectedMode.SelectedIndex == 1)
                            thread = new Thread(fdCopyDirectory);

                        thread.Start();
                    }
                    break;
                case 1:
                    {
                        if (cmbSelectedMode.SelectedIndex == 0)
                            thread = new Thread(fdMoveFile);
                        if (cmbSelectedMode.SelectedIndex == 1)
                            thread = new Thread(fdMoveDirectory);

                        thread.Start();
                    }
                    break;
                case 2:
                    {
                        if (MessageBox.Show("Удалить?", "...",
                            MessageBoxButton.OKCancel,
                            MessageBoxImage.Question,
                            MessageBoxResult.Cancel,
                            MessageBoxOptions.ServiceNotification) != MessageBoxResult.OK)
                        { return; }

                        if (cmbSelectedMode.SelectedIndex == 0)
                            thread = new Thread(fdDeleteFile);
                        if (cmbSelectedMode.SelectedIndex == 1)
                            thread = new Thread(fdDeleteDirectory);

                        thread.Start();
                    }
                    thread.Priority = ThreadPriority.Normal;
                    break;
            }
        }

       

        private void btnRenameFile_Click(object sender, RoutedEventArgs e)
        {
            fdRename();
        }

        private void btnInfoFile_Click(object sender, RoutedEventArgs e)
        {
            fdInfo();
        }


    }
}
