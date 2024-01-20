using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace dnd_manager_webapplication.Models
{
    public enum Settings { ForgottenRealms, Eberron, Dragonlance, Greyhawk, Ravenloft, Planescape, Spelljammer, DarkSun }
    public class Background
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [StringLength(20)]
        public string Name { get; set; }

        [JsonIgnore]
        [NotMapped]
        public virtual ICollection<Character> Characters { get; set; }

        public Background()
        {
           this.Characters = new HashSet<Character>();
        }
    }
}
