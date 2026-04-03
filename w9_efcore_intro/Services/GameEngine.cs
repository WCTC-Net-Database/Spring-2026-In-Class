using w9_efcore_intro.Data;
using w9_efcore_intro.Models;

namespace w9_efcore_intro.Services
{
    public class GameEngine
    {
        private readonly GameContext _context;
        public GameEngine(GameContext context)
        {
            _context = context;
        }

        public void Run()
        {
            _context.Characters.Add(new Character
            {
                Name = "Test Character",
                Stats = new CharacterStats
                {
                    Strength = 10,
                    Intelligence = 10,
                    Health = 100
                }
            });

            _context.SaveChanges();
        }
    }
}