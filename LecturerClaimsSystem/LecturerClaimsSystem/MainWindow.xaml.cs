using System;
using System.Windows;
using System.Windows.Controls;

namespace LecturerClaimsSystem
{
    public partial class MainWindow : Window
    {
        // User controls for different views
        private LecturerDashboard lecturerDashboard;
        private AdminDashboard adminDashboard;

        public MainWindow()
        {
            InitializeComponent();

            // Initialize user controls
            lecturerDashboard = new LecturerDashboard();
            adminDashboard = new AdminDashboard();

            // Subscribe to logout events
            lecturerDashboard.LogoutRequested += Dashboard_LogoutRequested;
            adminDashboard.LogoutRequested += Dashboard_LogoutRequested;
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;
            string role = (RoleComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();

            // Simple validation
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(role))
            {
                ErrorText.Text = "Please fill in all fields";
                ErrorText.Visibility = Visibility.Visible;
                return;
            }

            // For demo purposes, any non-empty credentials will work
            ErrorText.Visibility = Visibility.Collapsed;

            // Show appropriate dashboard based on role
            if (role == "Lecturer")
            {
                this.Content = lecturerDashboard;
                this.Title = "Lecturer Claims System - Lecturer Dashboard";
                this.Width = 900;
                this.Height = 600;
            }
            else
            {
                adminDashboard.Initialize(role);
                this.Content = adminDashboard;
                this.Title = $"Lecturer Claims System - {role} Dashboard";
                this.Width = 900;
                this.Height = 600;
            }
        }

        private void Dashboard_LogoutRequested(object sender, EventArgs e)
        {
            // Reset to login screen
            this.Content = this.FindResource("MainGrid");
            this.Title = "Lecturer Claims System";
            this.Width = 400;
            this.Height = 500;

            // Clear login fields
            UsernameTextBox.Text = "";
            PasswordBox.Password = "";
            RoleComboBox.SelectedIndex = -1;
        }
    }
}