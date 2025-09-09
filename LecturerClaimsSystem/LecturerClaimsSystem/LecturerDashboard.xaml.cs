using System;
using System.Windows;
using System.Windows.Controls;

namespace LecturerClaimsSystem
{
    public partial class LecturerDashboard : UserControl
    {
        public event EventHandler LogoutRequested;

        public LecturerDashboard()
        {
            InitializeComponent();
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            LogoutRequested?.Invoke(this, EventArgs.Empty);
        }
    }
}