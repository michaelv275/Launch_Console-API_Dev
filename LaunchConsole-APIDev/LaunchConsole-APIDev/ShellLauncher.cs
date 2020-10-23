using LaunchConsole_APIDev.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace LaunchConsole_APIDev
{
    public class ShellLauncher
    {
        public event EventHandler<Dictionary<DevComponent, string>> PowershellEventReceived;

        public const string FauxEngineLocation = @"C:\Dispel\DispelRepos\faux-engine";
        public const string ConsoleAPILocation = @"C:\Dispel\DispelRepos\console-api\Branches\Master";
        public const string ConsoleWebLocation = @"C:\Dispel\DispelRepos\console-web";

        public Process FauxEngineProcess = null;
        public Process ConsoleAPIProcess = null;
        public Process ConsoleWebProcess = null;
        public Process RedisServerProcess = null;

        public TaskFactory DevEnvironmentTasks = null;

        public void OnPowershellEventReceived(DevComponent componentType, string message)
        {
            Dictionary<DevComponent, string> eventMessage = new Dictionary<DevComponent, string>()
            {
                { componentType, message }
            };

            PowershellEventReceived?.Invoke(this, eventMessage);
        }

        public void StartDevEnvironment()
        {
            DevEnvironmentTasks = new TaskFactory();

            DevEnvironmentTasks.StartNew(StartRedisServer);
            Task.Delay(2500).Wait();

            DevEnvironmentTasks.StartNew(StartFauxEngine);
            DevEnvironmentTasks.StartNew(StartConsoleAPI);
            DevEnvironmentTasks.StartNew(StartConsoleWeb);
        }

        public void RefreshComponent(DevComponent terminalType)
        {
            Process matchingTerminalProcess = null;
            List<string> commands = new List<string>()
            {
                "rs"
            };

            switch (terminalType)
            {
                case DevComponent.ConsoleAPI:
                    matchingTerminalProcess = ConsoleAPIProcess;
                    break;
                case DevComponent.ConsoleWeb:
                    matchingTerminalProcess = ConsoleWebProcess;
                    break;
                case DevComponent.FauxEngine:
                    matchingTerminalProcess = FauxEngineProcess;
                    break;
            }

            ExecuteCommands(commands, terminalType, ref matchingTerminalProcess, false);
        }

        public void KillEverything()
        {
            KillRedisServer();

            KillNode();
            KillLinuxDistros();

            FauxEngineProcess?.Kill();
            ConsoleAPIProcess?.Kill();
            ConsoleWebProcess?.Kill();
        }

        private void KillLinuxDistros()
        {
            Process commandLineProcess = new Process();

            commandLineProcess.StartInfo = new ProcessStartInfo()
            {
                FileName = "cmd.exe",
                CreateNoWindow = true,
                RedirectStandardInput = true,
                UseShellExecute = false,
                WindowStyle = ProcessWindowStyle.Hidden,
            };

            commandLineProcess.Start();

            //execute the commands. The outputs will be handled asynchronously
            commandLineProcess.StandardInput.WriteLine("TaskKill /IM wsl.exe /F");
            commandLineProcess.StandardInput.Flush();
            commandLineProcess.StandardInput.WriteLine("TaskKill /IM wslhost.exe /F");
            commandLineProcess.StandardInput.Flush();

            commandLineProcess.StandardInput.Dispose();

            commandLineProcess.WaitForExit();
        }

        private void KillNode()
        {
            Process commandLineProcess = new Process();

            commandLineProcess.StartInfo = new ProcessStartInfo()
            {
                FileName = "cmd.exe",
                CreateNoWindow = true,
                RedirectStandardInput = true,
                UseShellExecute = false,
                WindowStyle = ProcessWindowStyle.Hidden,
            };

            commandLineProcess.Start();

            //execute the commands. The outputs will be handled asynchronously
            commandLineProcess.StandardInput.WriteLine("wsl pkill node");
            commandLineProcess.StandardInput.Flush();

            commandLineProcess.StandardInput.Dispose();

            commandLineProcess.WaitForExit();
        }

        private void StartRedisServer()
        {
            Process emptyProcess = null;
            List<string> powershellCommands = new List<string>()
            {
                "wsl redis-server",
            };

            ExecuteCommands(powershellCommands, DevComponent.RedisServer, ref emptyProcess, false);
        }

        private void StartConsoleAPI()
        {
            List<string> powershellCommands = new List<string>()
            {
                String.Format("cd {0}", ConsoleAPILocation),
                "wsl npm run develop"
            };

            ExecuteCommands(powershellCommands, DevComponent.ConsoleAPI, ref ConsoleAPIProcess, false);
        }

        private void StartFauxEngine()
        {
            List<string> powershellCommands = new List<string>()
            {
                String.Format("cd {0}", FauxEngineLocation),
                "wsl npm run develop"
            };

            ExecuteCommands(powershellCommands, DevComponent.FauxEngine, ref FauxEngineProcess, false);
        }

        private void StartConsoleWeb()
        {
            List<string> powershellCommands = new List<string>()
            {
                String.Format("cd {0}", ConsoleWebLocation),
                "wsl npm run develop"
            };

            ExecuteCommands(powershellCommands, DevComponent.ConsoleWeb, ref ConsoleWebProcess, false);
        }

        private void KillRedisServer()
        {
            //send the shutdown command
            Process emptyProcess = null;
            List<string> shutdownCommand = new List<string>()
            {
                "wsl redis-server shutdown"
            };

            ExecuteCommands(shutdownCommand, DevComponent.RedisServer, ref emptyProcess, true);
        }

        private void ExecuteCommands(List<string> commands, DevComponent component, ref Process activeProcess, bool shouldCloseInput)
        {
            Process commandLineProcess = activeProcess ?? new Process();

            if (activeProcess is null)
            {
                commandLineProcess.StartInfo = new ProcessStartInfo()
                {
                    FileName = "cmd.exe",
                    CreateNoWindow = true,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    WindowStyle = ProcessWindowStyle.Hidden,
                };

                //Set the handlers for the data received.
                commandLineProcess.OutputDataReceived += (o, e) => OnPowershellEventReceived(component, e.Data);
                commandLineProcess.ErrorDataReceived += (o, e) => OnPowershellEventReceived(component, e.Data);
                commandLineProcess.Start();
            }

            foreach (string command in commands)
            {
                //execute the commands. The outputs will be handled asynchronously
                commandLineProcess.StandardInput.WriteLine("{0}", command);
                commandLineProcess.StandardInput.Flush();
            }

            if (shouldCloseInput)
            {
                commandLineProcess.StandardInput.Dispose();
            }

            if (activeProcess is null)
            {
                commandLineProcess.BeginOutputReadLine();
                commandLineProcess.BeginErrorReadLine();

                activeProcess = commandLineProcess;
            }

            commandLineProcess.WaitForExit();
        }
    }
}
