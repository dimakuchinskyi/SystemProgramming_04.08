using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;

namespace System_ex2
{
    public partial class MainWindow : Window
    {
        private Process _childProcess;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void UpdateUI(bool processRunning)
        {
            LaunchAndWaitButton.IsEnabled = !processRunning;
            LaunchButton.IsEnabled = !processRunning;
            KillProcessButton.IsEnabled = processRunning;
        }

        private async void LaunchAndWaitButton_Click(object sender, RoutedEventArgs e)
        {
            await LaunchProcess(true);
        }

        private async void LaunchButton_Click(object sender, RoutedEventArgs e)
        {
            await LaunchProcess(WaitForExitCheckBox.IsChecked ?? false);
        }

        private async Task LaunchProcess(bool waitForExit)
        {
            string processPath = ProcessPathTextBox.Text.Trim();
            string arguments = ArgumentsTextBox.Text.Trim();

            if (string.IsNullOrEmpty(processPath))
            {
                MessageBox.Show("Please enter a process to launch", "Error", 
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                UpdateUI(false);
                StatusTextBlock.Text = $"Launching process: {processPath}...";
                ExitCodeTextBlock.Text = "";

                _childProcess = new Process();
                _childProcess.StartInfo.FileName = processPath;
                _childProcess.StartInfo.Arguments = arguments;
                _childProcess.StartInfo.UseShellExecute = false;
                _childProcess.StartInfo.CreateNoWindow = false;
                _childProcess.EnableRaisingEvents = true;
                _childProcess.Exited += (s, ev) => 
                {
                    Dispatcher.Invoke(() =>
                    {
                        ExitCodeTextBlock.Text = $"Process exited with code: {_childProcess.ExitCode}";
                        StatusTextBlock.Text = $"Process completed: {processPath}";
                        _childProcess = null;
                        UpdateUI(false);
                    });
                };

                _childProcess.Start();
                UpdateUI(true);

                if (waitForExit)
                {
                    StatusTextBlock.Text = $"Waiting for process to complete...";
                    await Task.Run(() => _childProcess.WaitForExit());
                }
                else
                {
                    StatusTextBlock.Text = $"Process started (PID: {_childProcess.Id})";
                }
            }
            catch (Exception ex)
            {
                StatusTextBlock.Text = $"Error: {ex.Message}";
                ExitCodeTextBlock.Text = "";
                _childProcess?.Dispose();
                _childProcess = null;
                UpdateUI(false);
            }
        }

        private void KillProcessButton_Click(object sender, RoutedEventArgs e)
        {
            if (_childProcess != null && !_childProcess.HasExited)
            {
                try
                {
                    _childProcess.Kill();
                    StatusTextBlock.Text = $"Process was forcefully terminated";
                    ExitCodeTextBlock.Text = "";
                }
                catch (Exception ex)
                {
                    StatusTextBlock.Text = $"Error killing process: {ex.Message}";
                }
                finally
                {
                    _childProcess?.Dispose();
                    _childProcess = null;
                    UpdateUI(false);
                }
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            _childProcess?.Dispose();
            base.OnClosed(e);
        }
    }
}