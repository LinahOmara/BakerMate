using BakerMate.WPF.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BakerMate.WPF.Services
{
    public class WindowService : IWindowService
    {
        public void ShowWindow(object viewModel)
        {
            var win = new Window();
            win.WindowStyle = WindowStyle.None;
            win.Content = viewModel;
            win.Show();
        }
    }
}
