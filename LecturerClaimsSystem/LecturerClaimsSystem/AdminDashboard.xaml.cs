using System;
using System.Windows;
using System.Windows.Controls;

namespace LecturerClaimsSystem
{
    public partial class AdminDashboard : UserControl
    {
        public event EventHandler LogoutRequested;

        public AdminDashboard()
        {
            InitializeComponent();
        }

        public void Initialize(string role)
        {
            DashboardTitle.Text = $"{role} Dashboard";
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            LogoutRequested?.Invoke(this, EventArgs.Empty);
        }
    }
}