using System;
using System.Diagnostics;
using System.IO;
using System.Windows;

namespace System_04._08_ex4
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string filePath = FilePathTextBox.Text;
            string searchWord = WordTextBox.Text;

            if (string.IsNullOrWhiteSpace(filePath) || string.IsNullOrWhiteSpace(searchWord))
            {
                MessageBox.Show("Please enter both file path and search word", "Error", 
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!File.Exists(filePath))
            {
                MessageBox.Show("File does not exist", "Error", 
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                string childProcessPath = Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    "WordCounter.exe");

                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = childProcessPath,
                    Arguments = $"\"{filePath}\" \"{searchWord}\"",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                };

                using (Process process = new Process { StartInfo = startInfo })
                {
                    process.Start();
                    string output = process.StandardOutput.ReadToEnd();
                    process.WaitForExit();

                    MessageBox.Show(output, "Search Results", 
                        MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", 
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}