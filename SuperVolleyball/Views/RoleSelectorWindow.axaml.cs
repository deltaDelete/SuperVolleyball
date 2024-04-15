using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Ekz.Models;
using Ekz.ViewModels;

namespace Ekz.Views;

public partial class RoleSelectorWindow : Window {
    public RoleSelectorWindow() {
        InitializeComponent();
    }
    
    public static Role Role { get; protected set; }

    private void AdministratorButtonClick(object? sender, RoutedEventArgs e) {
        Role = Role.Admin;
        OpenMainWindow();
    }

    private void ManagerButtonClick(object? sender, RoutedEventArgs e) {
        Role = Role.Manager;
        OpenMainWindow();
    }

    private void OpenMainWindow() {
        MainWindow window = new MainWindow();
        window.Show();
        (App.Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime).MainWindow = window;
        Close();
    }

}
