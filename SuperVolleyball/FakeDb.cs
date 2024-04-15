using System;
using System.Collections.Generic;
using Ekz.Models;
using Microsoft.EntityFrameworkCore;

namespace Ekz;

public class FakeDb {
    public List<Player> Players { get; set; } = null!;
    public List<Position> Positions { get; set; } = null!;
    public List<Team> Teams { get; set; }

    public FakeDb() {
        Teams = new List<Team> {
            new Team { Name = "Команда А", Id = 1 },
            new Team { Name = "Команда Б", Id = 2 }
        };
        Positions = new List<Position>() {
            new Position() { Id = 1, Name = "Позиция 1" },
            new Position() { Id = 2, Name = "Позиция 2" },
            new Position() { Id = 3, Name = "Позиция 3" },
            new Position() { Id = 4, Name = "Позиция 4" },
            new Position() { Id = 5, Name = "Позиция 5" },
        };
        Players = new List<Player>() {
            new Player {
                Id = 1, FullName = "Игрок 1", TeamId = 1, PositionId = 1, Team = Teams[0], Position = Positions[0],
                Height = 175, Weight = 75, BirthDate = DateTimeOffset.Parse("01.01.2000"), GameStart = DateTimeOffset.Now
            },
            new Player {
                Id = 2, FullName = "Игрок 2", TeamId = 1, PositionId = 2, Team = Teams[0], Position = Positions[2],
                Height = 185, Weight = 85, BirthDate = DateTimeOffset.Parse("02.01.2000"), GameStart = DateTimeOffset.Now
            },
            new Player {
                Id = 3, FullName = "Игрок 3", TeamId = 1, PositionId = 3, Team = Teams[0], Position = Positions[3],
                Height = 175.22f, Weight = 72.2f, BirthDate = DateTimeOffset.Parse("03.01.2000"), GameStart = DateTimeOffset.Now
            },
        };
    }
}