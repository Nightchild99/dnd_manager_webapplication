using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace dnd_manager_webapplication.Models
{
    public enum Races
    {
        dragonborn = 0,
        dwarf = 1,
        elf = 2,
        gnome = 3,
        halfling = 4,
        human = 5,
        orc = 6,
        tiefling = 7
    }

    public enum Classes
    {
        artificer = 0,
        barbarian = 1,
        bard = 2,
        cleric = 3,
        druid = 4,
        fighter = 5,
        monk = 6,
        paladin = 7,
        ranger = 8,
        rogue = 9,
        sorcerer = 10,
        warlock = 11,
        wizard = 12
    }

    public class Character
    {
        [Key]
        public string Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Name { get; set; }
        public string? Description { get; set; }

        [Required]
        public Races Race { get; set; }
        [Required]
        public Classes Class { get; set; }

        [Required]
        [Range(0, 20)]
        public int Level { get; set; }

        [ForeignKey(nameof (Owner))]
        public string OwnerId { get; set; }

        [NotMapped]
        [ValidateNever]
        public virtual SiteUser Owner { get; set; }

        [ForeignKey(nameof(BackgroundID))]
        public int BackgroundID { get; set; }

        [NotMapped]
        public virtual Background Background { get; set; }

        [NotMapped]
        public string BackGroundHelper { get; set; }

        [StringLength(200)]
        [JsonIgnore]
        public string? ImageFileName { get; set; }

        [JsonIgnore]
        public string? ContentType { get; set; }

        [JsonIgnore]
        public byte[]? Data { get; set; }

        public Character()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
