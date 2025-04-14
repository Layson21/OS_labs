using System;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace lab6
{
    public class Window
    {
        public nint hwnd { get; set; }
        public string Title { get; set; }
        public string ClassName { get; set; }
        public uint ProcessId { get; set; }
        public string ProcessName { get; set; }
        public bool IsVisible { get; set; }
        public int[] Coords { get; set; } 
        public int[] Size { get; set; }
    }

    public class Manager
    {
        public static List<Window> windows = new();

        public delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

        [DllImport("user32.dll")]
        private static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);

        [DllImport("user32.dll")]
        private static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll")]
        private static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

        [DllImport("user32.dll")]
        private static extern bool IsWindowVisible(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        [DllImport("user32.dll")]
        public static extern bool IsWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool SetWindowText(IntPtr hWnd, string lpString);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        public static string GetTitle(nint hWnd)
        {
            int length = GetWindowTextLength(hWnd);
            StringBuilder titleBuilder = new(length + 1);
            GetWindowText(hWnd, titleBuilder, titleBuilder.Capacity);
            return titleBuilder.ToString();
        }

        public static void GetWindows()
        {
            windows.Clear();

            EnumWindows((hWnd, lParam) =>
            {
                string title = GetTitle(hWnd);

                StringBuilder classBuilder = new(256);
                GetClassName(hWnd, classBuilder, classBuilder.Capacity);

                bool visible = IsWindowVisible(hWnd);

                GetWindowThreadProcessId(hWnd, out uint pid);
                string processName = null;
                try
                {
                    processName = Process.GetProcessById((int)pid).ProcessName;
                }
                catch { }

                GetWindowRect(hWnd, out RECT rect);

                windows.Add(new Window
                {
                    hwnd = hWnd,
                    Title = title,
                    ClassName = classBuilder.ToString(),
                    IsVisible = visible,
                    ProcessId = pid,
                    ProcessName = processName,
                    Coords = new[] { rect.Left, rect.Top},
                    Size = new[] { rect.Right - rect.Left, rect.Bottom - rect.Top }
                });

                return true;
            }, IntPtr.Zero);
        }
    }
}
