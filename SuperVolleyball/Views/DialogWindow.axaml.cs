using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Ekz.Views;

public partial class DialogWindow : Window {
    public DialogWindow(object? content) {
        InitializeComponent();
        PART_Content.Content = content;
    }
}