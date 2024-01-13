using dnd_manager_webapplication.Models;
using Microsoft.AspNetCore.Identity;

namespace dnd_manager_webapplication.Data
{
    public class PartyRepository : IPartyRepository
    {
        ApplicationDbContext context;

        public PartyRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Create(Character character)
        {
            context.Characters.Add(character);
            context.SaveChanges();
        }

        public IEnumerable<Character> Read()
        {
            return context.Characters;
        }

        public Character? Read(string name)
        {
            return context.Characters.FirstOrDefault(t => t.Name == name);
        }

        public Character? ReadFromId(string id)
        {
            return context.Characters.FirstOrDefault(t => t.Id == id);
        }

        public void LevelUp(string name)
        {
            var character = Read(name);
            character.Level++;
            character.Description = $"{character.Name} is a level {character.Level} {character.Race} {character.Class}.";
            context.SaveChanges();
        }

        public void Update(Character character)
        {
            var old = Read(character.Name);
            old.Race = character.Race;
            old.Class = character.Class;
            old.Description = $"{character.Name} is a level {old.Level} {character.Race} {character.Class}.";
            context.SaveChanges();
        }

        public void Delete(string name)
        {
            var character = Read(name);
            context.Characters.Remove(character);
            context.SaveChanges();
        }
    }
}
