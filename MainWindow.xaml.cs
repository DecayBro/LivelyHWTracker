using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Win32;
using Windows.Win32.Foundation;
using Windows.Win32.UI.WindowsAndMessaging;
using NotifyIcon;
using static NotifyIcon.NotifyIconTools;
using System.Runtime.InteropServices;
// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace LivelyHWTracker
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            hWndMain = WinRT.Interop.WindowNative.GetWindowHandle(this);
            string sDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string sIconFile = sDirectory + @"Assets\butterfly.ico";
            m_hIcon = LoadImage(IntPtr.Zero, sIconFile, IMAGE_ICON, 32, 32, LR_LOADFROMFILE);
        }

        private void Window_Closed(object sender, WindowEventArgs args)
        {
            TrayMessage(hWndMain, "Lively HWTracker", m_hIcon, IntPtr.Zero, NIM.ADD, NIIF.NONE, null, null, 0);
            args.Handled = true;
            PInvoke.ShowWindow(new HWND(hWndMain), 0);
        }

        [DllImport("User32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern IntPtr LoadImage(IntPtr hInst, string lpszName, UInt32 uType, int cxDesired, int cyDesired, UInt32 fuLoad);
        public const int IMAGE_ICON = 1;
        public const int LR_LOADFROMFILE = 0x00000010;
        private IntPtr hWndMain = IntPtr.Zero;
        private IntPtr m_hIcon = IntPtr.Zero;
    }
}
