using System;
using System.Collections;
using Avalonia.Controls;
using Avalonia.Data;
using Avalonia.Layout;
using Avalonia.ReactiveUI;
using Ekz.Models;
using Ekz.ViewModels;
using ReactiveUI;

namespace Ekz.Views;

public partial class MainWindow : ReactiveWindow<MainWindowViewModel> {
    public MainWindow() {
        InitializeComponent();
        ViewModel = new();
        ViewModel.AddPlayerCommand.Subscribe(unit => {
            var context = new Player();
            DialogWindow dialog = new DialogWindow(new StackPanel() {
                Spacing = 8,
                Orientation = Orientation.Vertical,
                Children = {
                    new TextBox() {
                        Watermark = "Имя",
                        [!TextBox.TextProperty] = new Binding("FullName"),
                    },
                    new ComboBox() {
                        [!ComboBox.SelectedItemProperty] = new Binding("Position"),
                        [!ComboBox.SelectedValueProperty] = new Binding("PositionId"),
                        DisplayMemberBinding = new Binding("Name"),
                        SelectedValueBinding = new Binding("Id"),
                        HorizontalAlignment = HorizontalAlignment.Stretch,
                        ItemsSource = ViewModel.Positions
                    },
                    new NumericUpDown() {
                        Watermark = "Вес",
                        [!NumericUpDown.ValueProperty] = new Binding("Weight"),
                        Minimum = 10,
                        Maximum = 1000,
                    },
                    new NumericUpDown() {
                        Watermark = "Рост",
                        [!NumericUpDown.ValueProperty] = new Binding("Height"),
                        Minimum = 10,
                        Maximum = 1000,
                    },
                    new DatePicker() {
                        [!DatePicker.SelectedDateProperty] = new Binding("BirthDate"),
                        HorizontalAlignment = HorizontalAlignment.Stretch
                    },
                    new DatePicker() {
                        [!DatePicker.SelectedDateProperty] = new Binding("GameStart"),
                        HorizontalAlignment = HorizontalAlignment.Stretch
                    },
                    new ComboBox() {
                        [!ComboBox.SelectedItemProperty] = new Binding("Team"),
                        [!ComboBox.SelectedValueProperty] = new Binding("TeamId"),
                        DisplayMemberBinding = new Binding("Name"),
                        SelectedValueBinding = new Binding("Id"),
                        HorizontalAlignment = HorizontalAlignment.Stretch,
                        ItemsSource = ViewModel.Teams,
                    },
                }
            }) {
                DataContext = context
            };
            dialog.PART_ButtonCancel.IsVisible = false;
            dialog.PART_ButtonConfirm.Click += (sender, args) => {
                ViewModel.AddPlayer(context);
                dialog.Close();

                DialogWindow notificationDialog = new DialogWindow(new Label() { Content = "Успешно добавлен игрок" });
                notificationDialog.PART_ButtonCancel.IsVisible = false;
                notificationDialog.PART_ButtonConfirm.Click += (sender, args) => { notificationDialog.Close(); };
                notificationDialog.ShowDialog(this);
            };
            dialog.ShowDialog(this);
        });
        ViewModel.RemovePlayerCommand.Subscribe(unit => {
            DialogWindow dialog = new DialogWindow(new Label() { Content = "Удален игрок" });
            dialog.PART_ButtonCancel.IsVisible = false;
            dialog.PART_ButtonConfirm.Click += (sender, args) => { dialog.Close(); };
            dialog.ShowDialog(this);
        });
    }
}