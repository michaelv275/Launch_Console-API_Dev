using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using LaunchConsole_APIDev.Enums;

namespace LaunchConsole_APIDev
{
    public partial class OutputWindows : Form
    {
        ShellLauncher DevManager = new ShellLauncher();

        public OutputWindows()
        {
            InitializeComponent();

            DevManager.PowershellEventReceived += DevManager_PowershellEventReceived;
        }

        private void DevManager_PowershellEventReceived(object sender, Dictionary<DevComponent, string> args)
        {
            DevComponent componentType = args.Keys.FirstOrDefault();

            WriteToOutput(componentType, args[componentType]);
        }

        private void OutputWindows_Load(object sender, EventArgs e)
        {
            DevManager.StartDevEnvironment();
        }

        private void OutputWindows_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DevManager.DevEnvironmentTasks != null)
            {
                DevManager.KillEverything();
            }
        }

        private void RefreshFauxEngineButton_Click(object sender, EventArgs e)
        {
            DevManager.DevEnvironmentTasks.StartNew(() => DevManager.RefreshComponent(DevComponent.FauxEngine));
        }

        private void ReloadConsoleApiButton_Click(object sender, EventArgs e)
        {
            DevManager.DevEnvironmentTasks.StartNew(() => DevManager.RefreshComponent(DevComponent.ConsoleAPI));
        }

        private void WriteToOutput(DevComponent terminalType, string content)
        {
            TextBox terminal = null;

            switch (terminalType)
            {
                case DevComponent.ConsoleAPI:
                    terminal = ConsoleApiOutput;
                    break;
                case DevComponent.ConsoleWeb:
                    terminal = ConsoleWebOutput;
                    break;
                case DevComponent.FauxEngine:
                    terminal = FauxEngineOutput;
                    break;
            }

            if (terminal != null)
            {
                this.Invoke(new MethodInvoker(() =>
                {
                    terminal.AppendText(String.Format("{0}{1}", content, Environment.NewLine));
                }));
            }
        }
    }
}
