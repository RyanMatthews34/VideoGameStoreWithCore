using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VideoGameStoreWithCore.Model
{
    [Table("PlayerInfo")]
    public partial class PlayerInfo
    {
        [Key]
        public int PlayerID { get; set; }

        [Required]
        [StringLength(50)]
        public string PlayerName { get; set; }

        public int PlayerScore { get; set; }

        public int PlayerTimePlayed { get; set; }

        public int VideoGameID { get; set; }
    }
}