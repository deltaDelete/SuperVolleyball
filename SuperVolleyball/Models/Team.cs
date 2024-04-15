using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ekz.Models;

public class Team {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [MaxLength(255)] public string Name { get; set; } = string.Empty;
    
    public List<Player> Players { get; set; } = new List<Player>();
}