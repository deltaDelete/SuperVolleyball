using System;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using Avalonia.Collections;
using Avalonia.Controls;
using Ekz.Models;
using Ekz.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ReactiveUI;

namespace Ekz.ViewModels;

public class MainWindowViewModel : ViewModelBase {
    private Player? _selectedPlayer;
    private AvaloniaList<Player> _items = new AvaloniaList<Player>();
    private AvaloniaList<Position> _positions = new AvaloniaList<Position>();
    private AvaloniaList<Team> _teams = new();
    private string _searchText;
    private Position? _selectedPosition;
#pragma warning disable CA1822 // Mark members as static
    public string Greeting => "Welcome to Avalonia!";
#pragma warning restore CA1822 // Mark members as static

    public AvaloniaList<Player> Items {
        get => _items;
        set => this.RaiseAndSetIfChanged(ref _items, value);
    }

    public AvaloniaList<Position> Positions {
        get => _positions;
        set => this.RaiseAndSetIfChanged(ref _positions, value);
    }
    
    public AvaloniaList<Team> Teams {
        get => _teams;
        set => _teams = value;
    }

    public Player? SelectedPlayer {
        get => _selectedPlayer;
        set => this.RaiseAndSetIfChanged(ref _selectedPlayer, value);
    }

    public Position? SelectedPosition {
        get => _selectedPosition;
        set => this.RaiseAndSetIfChanged(ref _selectedPosition, value);
    }

    public string SearchText {
        get => _searchText;
        set => this.RaiseAndSetIfChanged(ref _searchText, value);
    }

    public ReactiveCommand<Unit, Unit> AddPlayerCommand { get; init; }
    public ReactiveCommand<Player?, Unit> RemovePlayerCommand { get; init; }
    public ReactiveCommand<Unit, Unit> ResetPositionCommand { get; init; }

    private FakeDb _db { get; set; } = new();

    public MainWindowViewModel() {
        AddPlayerCommand = ReactiveCommand.Create(() => { });
        RemovePlayerCommand = ReactiveCommand.Create<Player?>(RemovePlayer,
            this.WhenAnyValue(x => x.Items).Select(x => RoleSelectorWindow.Role == Role.Admin));
        ResetPositionCommand = ReactiveCommand.Create(() => {
            SelectedPosition = null;
        });

        InitLocalList();

        this.WhenAnyValue(x => x.SearchText)
            .DistinctUntilChanged()
            .WhereNotNull()
            .Subscribe(s => {
                var players = _db.Players
                    .Where(x => x.FullName.Contains(s, StringComparison.InvariantCultureIgnoreCase)).ToList();
                Items.Clear();
                Items.AddRange(players);
            });

        this.WhenAnyValue(x => x.SelectedPosition)
            .DistinctUntilChanged()
            .Subscribe(s => {
                if (s is null || s.Id == -1) {
                    InitLocalList();
                    return;
                }

                var players = _db.Players
                    .Where(x => x.Position.Id == s.Id).ToList();
                Items.Clear();
                Items.AddRange(players);
            });
    }

    public async void AddPlayer(Player player) {
        _db.Players.Add(player);
        InitLocalList();
    }

    private void RemovePlayer(Player? selectedPlayer) {
        if (selectedPlayer is null) {
            return;
        }

        _db.Players.RemoveAll(player => player.Id == selectedPlayer.Id);
        Items.Remove(selectedPlayer);
    }

    private void InitLocalList() {
        var players = _db.Players.ToList();
        Items.Clear();
        Items.AddRange(players);

        Positions.Clear();
        Positions.AddRange(_db.Positions.ToList());

        Teams.Clear();
        Teams.AddRange(_db.Teams.ToList());
    }
}