using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApplicationCore.Models
{
    public class GameMode
    {
        public int GameModeId { get; set; }
        [Required]
        public string GameModeString { get; set; }
    }
}
