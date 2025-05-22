using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;

namespace _04_08_System
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void LaunchButton_Click(object sender, RoutedEventArgs e)
        {
            string processPath = ProcessPathTextBox.Text.Trim();
            string arguments = ArgumentsTextBox.Text.Trim();

            if (string.IsNullOrEmpty(processPath))
            {
                MessageBox.Show("Please enter a process to launch", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                LaunchButton.IsEnabled = false;
                StatusTextBlock.Text = $"Launching process: {processPath}...";
                ExitCodeTextBlock.Text = "";
                
                using (Process process = new Process())
                {
                    process.StartInfo.FileName = processPath;
                    if (!string.IsNullOrEmpty(arguments))
                    {
                        process.StartInfo.Arguments = arguments;
                    }
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.CreateNoWindow = false;

                    process.Start();
                    
                    await Task.Run(() => process.WaitForExit());

                    ExitCodeTextBlock.Text = $"Process exited with code: {process.ExitCode}";
                    StatusTextBlock.Text = $"Process completed: {processPath}";
                }
            }
            catch (Exception ex)
            {
                StatusTextBlock.Text = $"Error launching process: {ex.Message}";
                ExitCodeTextBlock.Text = "";
            }
            finally
            {
                LaunchButton.IsEnabled = true;
            }
        }
    }
}