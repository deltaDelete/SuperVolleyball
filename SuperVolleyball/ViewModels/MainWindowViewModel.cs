using Avalonia.Collections;
using Avalonia.Controls;

namespace Ekz.ViewModels;

public class MainWindowViewModel : ViewModelBase {
#pragma warning disable CA1822 // Mark members as static
    public string Greeting => "Welcome to Avalonia!";
#pragma warning restore CA1822 // Mark members as static

    public AvaloniaList<int> Items { get; set; } = new AvaloniaList<int>() {
        1, 2, 3, 4, 5
    };

    public MainWindowViewModel() {
    }
}