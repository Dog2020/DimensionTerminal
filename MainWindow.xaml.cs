using DConsole;

using System;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Documents;

namespace DimensionConsole
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public int FileCount = 0;
        public static MainWindow main = new MainWindow();
        public string command;
        public Level ConsoleLevel;
        object send = null;
        RoutedEventArgs rou = null;


        public MainWindow()
        {
            InitializeComponent();
            System.Windows.Input.Keyboard.Focus(InputCommand);
            Terminal.ConsolePurview.ConsoleLevel = Level.Guest;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            SaveLogs(send, rou);
            System.Environment.Exit(0);
        }

        private void InputDone(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                InitRun(send, rou);
            }
        }

        private void RunLogin(object sender, RoutedEventArgs e)
        {
            //Login login = new Login();
            //login.Show();
        }

        private void AboutCodeTools_Click(object sender, RoutedEventArgs e)
        {
            Terminal.ConsoleDebug.AddLog("AboutIsClick  result->YES", Operating.MenuClick);
            Terminal.Console.AppendForConsole(OutPut, Terminal.ConsoleFile.ReadFile(@"..\TerminalSettings\TerminalInfo.txt"));
        }

        private void ClearBox(object sender, RoutedEventArgs e)
        {
            Terminal.ConsoleDebug.AddLog("ClearInputBoxIsClick  result->YES", Operating.MenuClick);
            Terminal.Console.Clear(OutPut);
        }

        private void CopyAndOnBox(object sender, RoutedEventArgs e)
        {
            Terminal.ConsoleDebug.AddLog("CopyAndOnBoxIsClick  result->YES", Operating.MenuClick);
            IDataObject data = Clipboard.GetDataObject();
            if (data.GetDataPresent(DataFormats.Text))
            {
                InputCommand.Text = (string)data.GetData(DataFormats.Text);
            }
        }

        private void SaveLogs(object sender, RoutedEventArgs e)
        {
            Terminal.ConsoleDebug.AddLog("SaveLogsButtonIsClick  result->YES", Operating.MenuClick);
            if (!File.Exists(@"..\TerminalLog\Terminal.log"))
            {
                MessageBox.Show("[严重错误]：\n[尝试对Log文件进行写入时，发现文件已被移动或者删除]\n[源目录：..\\TerminalLog\\Terminal.log]", "严重的错误", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Terminal.ConsoleFile.WriteFile(@"..\TerminalLog\Terminal.log", Terminal.ConsoleDebug.Log);
            }
        }

        /// <summary>
        /// Run函数摘要：
        /// <para>负责整个Terminal的命令输入处理</para>
        /// </summary>
        private void InitRun(object sender, RoutedEventArgs e)
        {
            command = InputCommand.Text;
            //Guest权限可以操作的命令：
            if (command == "help")
            {
                if (!File.Exists(@"..\TerminalSettings\Help.txt"))
                {
                    MessageBox.Show("[严重错误]：\n[尝试帮助文件文件打开时，发现文件已被移动或者删除]\n[源目录：..\\TerminalSettings\\Help.txt]", "严重的错误", MessageBoxButton.OK, MessageBoxImage.Error);
                    Terminal.ConsoleDebug.AddLog("“HELP”, result->NO", Operating.CommandInput);
                }
                else
                {
                    string file = Terminal.ConsoleFile.ReadFile(@"..\TerminalSettings\Help.txt");
                    Terminal.Console.AppendForConsole(OutPut, file, AssemblyColor.WHITE);
                    Terminal.ConsoleDebug.AddLog("“HELP”, result->YES", Operating.CommandInput);
                }
            }
            else if (command == "clear")
            {
                Terminal.Console.Clear(OutPut);
                Terminal.Console.WriteForConsole(OutPut, "DimensionTerminal (c) Dimensionsoft Corporation | 可以输入help查看帮助或者通过菜单中的帮助来获得帮助\r\n———————————————————————————————————————————————————————————————————————————————————————————————————\r\n");
                Terminal.ConsoleDebug.AddLog("“CLEAR”, result->YES", Operating.CommandInput);
            }
            else if (command == "showInfo")
            {
                Terminal.Console.AppendForConsole(OutPut, Terminal.ConsoleFile.ReadFile(@"..\TerminalSettings\TerminalInfo.txt"));
            }
            else if (command == "saveLog")
            {
                SaveLogs(send, rou);
                Terminal.Console.AppendForConsole(OutPut, "[INFO][Savelog Done!]");
                Terminal.ConsoleDebug.AddLog("“SAVE LOG”, result->YES", Operating.CommandInput);
            }
            else if (command.Contains("writeFile "))
            {
                Terminal.ConsoleControl.COM_writeFile(InputCommand, OutPut, FileCount);
                Terminal.ConsoleDebug.AddLog("“WRITE FILE”, result->YES", Operating.CommandInput);
            }
            else if (command.Contains("readFile "))
            {
                Terminal.ConsoleControl.COM_readFile(InputCommand, OutPut);
                Terminal.ConsoleDebug.AddLog("“READ FILE”, result->YES", Operating.CommandInput);
            }
            else if (command.Contains("rename "))
            {
                Terminal.ConsoleControl.COM_rename(InputCommand, OutPut);
                Terminal.ConsoleDebug.AddLog("“RENAME DIR/FILE”, result->YES", Operating.CommandInput);
            }
            else if (command == "debug")
            {
                if (Terminal.ConsolePurview.ConsoleLevel == Level.Administrator)
                {
                    Terminal.Console.AppendForConsole(OutPut, "Debug", AssemblyColor.YELLOW);
                }
                else
                {
                    Terminal.Console.AppendForConsole(OutPut, "[错误]\n[你没有足够的权限来执行此操作！]", AssemblyColor.RED);
                    Terminal.ConsoleDebug.AddLog("“ERROR NO LEVEL”, result->NO", Operating.CommandInput);
                }
            }
            else
            {
                Terminal.Console.AppendForConsole(OutPut, "[错误]\n[不该输入一个未知的指令“" + InputCommand.Text + "”!]", AssemblyColor.RED);
                Terminal.ConsoleDebug.AddLog("“ERROR NO COMMAND”, result->NO", Operating.CommandInput);
            }
            OutPut.ScrollToEnd();
        }
    }
}
