using System.Diagnostics;
using System.Runtime.InteropServices;

// 指定プロセスのウィンドウの最小化・復元する
//
// Usage:
//   Invoke-MinimizeWindow.exe [プロセス名] [--toggle | --minimize | --restore]
// 
// Example usage:
//   :: リモートデスクトップ接続(mstsc.exe)のウィンドウをトグル (Minimize <--> Normal)
//   Invoke-MinimizeWindow.exe mstsc --toggle
//

class Program
{
    public static class NativeWindow
    {
        [DllImport("user32.dll")]
        public static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern bool IsIconic(IntPtr hWnd);
    }

    static void SetWindowState(IntPtr handle, int cmd)
    {
        NativeWindow.ShowWindowAsync(handle, cmd);
        if (cmd == 1 || cmd == 3 || cmd == 9)
        {
            NativeWindow.SetForegroundWindow(handle);
        }
    }

    static void Main(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: WindowControl.exe <ProcessName> <--restore|--minimize|--toggle>");
            return;
        }

        var processName = args[0];
        var mode = args[1].ToLower();
        var procs = Process.GetProcessesByName(processName);
        foreach (Process p in procs)
        {
            if (p.MainWindowHandle != IntPtr.Zero)
            {
                switch (mode)
                {
                    case "--toggle":
                        if (NativeWindow.IsIconic(p.MainWindowHandle))
                        {
                            SetWindowState(p.MainWindowHandle, 9); // SW_RESTORE
                        }
                        else
                        {
                            SetWindowState(p.MainWindowHandle, 6); // SW_MINIMIZE
                        }
                        break;
                    case "--restore":
                        SetWindowState(p.MainWindowHandle, 9);
                        break;
                    case "--minimize":
                        SetWindowState(p.MainWindowHandle, 6);
                        break;
                    default:
                        Console.WriteLine("Unknown mode: " + mode);
                        return;
                }
            }
        }
    }
}