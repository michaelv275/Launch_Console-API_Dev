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

        private void RefreshTerminal_Click (object sender, EventArgs e)
        {
            Button activeButton = sender as Button;
            List<string> commands = new List<string>() { "rs" };

            if (activeButton != null)
            {
                DevComponent terminalContext = GetCallingContextType(activeButton);

                if (terminalContext != DevComponent.None)
                {
                    DevManager.DevEnvironmentTasks.StartNew(() => DevManager.SendCommand(terminalContext, commands));
                }       
            } 
        }

        private void ClearTerminal_Click(object sender, EventArgs e)
        {
            Button activeButton = sender as Button;

            if (activeButton != null)
            {
                DevComponent terminalContext = GetCallingContextType(activeButton);

                TextBox terminalToClear = GetTerminal(terminalContext);

                if (terminalToClear != null)
                {
                    Action ClearTerminalText = () =>{ terminalToClear.Text = String.Empty; };

                    InvokeOnUIThread(ClearTerminalText);
                }
            }
        }

        private void WriteToOutput(DevComponent terminalType, string content)
        {
            TextBox terminal = null;
            string decodedContent = DecodeLinuxCharacters(content);

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
                try
                {
                    Action AddLineToterminal = () => { terminal.AppendText(String.Format("{0}{1}", decodedContent, Environment.NewLine)); };

                    InvokeOnUIThread(AddLineToterminal);
                }
                catch (ObjectDisposedException)
                {
                    //Do nothing. The app was just closed.
                }
               
            }
        }

        private string DecodeLinuxCharacters(string originalText)
        {
            string decodedText = originalText;
            
            //empty is ok, null is bad
            if (originalText != null)
            {
                //remove non ascii characters
                decodedText = Regex.Replace(decodedText, @"[^\u0000-\u007F]", String.Empty);

                //Remove the characters that Windows terminal could not decipher (they were just linux shell colors)
                decodedText = Regex.Replace(decodedText, @"\u001b\[[0-9]+m", String.Empty);
            }

            return decodedText;
        }

        private TextBox GetTerminal(DevComponent terminalType)
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

            return terminal;
        }

        private DevComponent GetCallingContextType(Button clickedButton)
        {
            DevComponent componentType = DevComponent.None;

            try
            {
                string buttonTag = clickedButton.Tag.ToString();

                if (!String.IsNullOrEmpty(buttonTag))
                {
                    string buttonTagText = buttonTag.ToLower();

                    switch (buttonTagText)
                    {
                        case "faux":
                            componentType = DevComponent.FauxEngine;
                            break;
                        case "api":
                            componentType = DevComponent.ConsoleAPI;
                            break;
                        case "web":
                            componentType = DevComponent.ConsoleWeb;
                            break;
                    }
                }

            }
            catch (Exception ex)
            {

            }

            return componentType;
        }

        private void InvokeOnUIThread(Action actiontoPerform)
        {
            this.Invoke(new MethodInvoker(() =>
            {
                actiontoPerform.Invoke();
            }));
        }
    }
}
