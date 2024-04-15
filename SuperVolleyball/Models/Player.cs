using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ekz.Models;

public class Player {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [MaxLength(255)]
    public string FullName { get; set; }= string.Empty;

    public float Weight { get; set; }

    public float Height { get; set; }

    public DateTimeOffset GameStart { get; set; }= DateTimeOffset.Now.AddDays(3);
    public DateTimeOffset BirthDate { get; set; } = DateTimeOffset.Now.AddYears(-18);

    [ForeignKey(nameof(Team))]
    public int TeamId { get; set; }

    public Team? Team { get; set; } = null;
    
    [ForeignKey(nameof(Position))]
    public int PositionId { get; set; }

    public Position? Position { get; set; } = null;
}