using w5_lsp_isp.Models;

namespace w5_lsp_isp.Examples
{
    public class Program2
    {
        public static void Main3()
        {
            Character character = new Character()
            {
                Name = "Aragorn",
                Profession = "Ranger",
                Level = 20,
                Health = 150,
                Equipment = new List<string> { "Sword", "Bow", "Dagger" }
            };


            // Base Class reference to a derived class object
            Monster monster = new Goblin();

            if (monster is Goblin goblin)
            {
                // 1. casting the monster to a Goblin to call the Sneak method
                ((Goblin)monster).Sneak();

                // 2. using pattern matching to check if the monster is a Goblin and call the Sneak method
                goblin.Sneak();
            }

            // Behavior interface check
            if (monster is IAttackable attackableMonster)
            {
                character.Attack();
            }

            monster.Attack();

            Monster ghost = new Ghost();
            ghost.Attack();


            Staff staff = new Staff();
            staff.Name = "Wizard's Staff";
            staff.Break();

            Item potion = new Potion();
            potion.Name = "Health Potion";
            if (potion is IOpenable openablePotion)
            {
                //openablePotion.Open();
            }
        }
        public static void Main2()
        {
            Sparrow bird = new Sparrow { Name = "Sparrow" };
            bird.Fly();
            bird.Walk();

            Ostrich aBird = new Ostrich { Name = "Ostrich" };
            //aBird.Fly();
            aBird.Walk();

            Chicken anotherBird = new Chicken { Name = "Chicken" };
            //anotherBird.Fly();
            anotherBird.Walk();
        }

        //public interface IBird 
        //{
        //    void Fly();
        //}

        public interface ICookable { }
        public interface IFlyable
        {
            void Fly();
        }

        public class Bird
        {
            public string Name { get; set; }

            public void Walk()
            {
                Console.WriteLine($"Bird {Name} is walking.");
            }
        }

        public class Sparrow : Bird, IFlyable
        {
            public void Fly()
            {
                Console.WriteLine($"Bird {Name} is flying.");
            }
        } 
        public class Ostrich : Bird { } // inheritance from Bird
        public class Penguin : Bird { } // inheritance from Bird
        public class Chicken : Bird, ICookable { } // inheritance from Bird

    }
}
