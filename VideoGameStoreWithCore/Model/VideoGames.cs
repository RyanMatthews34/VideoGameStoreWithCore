using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VideoGameStoreWithCore.Model
{
    [Table("VideoGameInfo")]
    public class VideoGames
    {
        public VideoGameInfo()
        {
            PlayerInfoes = new HashSet<PlayerInfo>();
        }

        [Key]
        public int VideoGameID { get; set; }

        [Required]
        [StringLength(50)]
        public string VideoGameName { get; set; }

        [Required]
        [StringLength(50)]
        public string VideoGameGenre { get; set; }

        [Required]
        [StringLength(50)]
        public string VideoGameRating { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PlayerInfo> PlayerInfoes { get; set; }
    }
}
