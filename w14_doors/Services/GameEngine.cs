using w13_containers.Models.Items;
using w13_containers.Data;
using w13_containers.Models;
using w13_containers.Models.Containers;
using w14_doors.Models.Containers;

namespace w13_containers.Services
{
    public class GameEngine
    {
        private readonly GameContext _context;
        public GameEngine(GameContext context)
        {
            _context = context;

            //SetupWorld();
        }

        public void Run()
        {
            var player = _context.Characters.FirstOrDefault();

            //PlayerLogin(player);

            // TESTING: Add a key to the player's home room and then try to move through a locked door that requires that key
            var keyId = "LAB_KEY_001";
            var playerRoom = player.HomeRoom;
            AddKeyToRoom(playerRoom, keyId);
            var keyInRoom = _context.Items.OfType<KeyItem>().FirstOrDefault(i => i.KeyId == keyId);
            player.PickUp(keyInRoom);

            Console.WriteLine("Press Enter to attempt to move through the locked door...");
            Console.ReadLine();

            MovePlayer(player, "E");
            MovePlayer(player, "E");
            MovePlayer(player, "E");
            MovePlayer(player, "N");

            //ShowPlayerInventory(player);
            //ListPlayerItemsByType(player);
            //InteractWithChest(player);
            //ListPlayerItemsByType(player);

            //Console.WriteLine("These items are still in the chest:");
            //ListChestItems();

            //EquipItem(player);

            //DropItem(player); // pass in the item
            //GiveItemtoPlayer(player);
            //DisplayCharacters();
            //CreateCharacter("Hero");
            //ListRooms();
            //ListMonstersInRooms();
            //CreateMonsters();
            //AddMonsterToRoom();
        }

        private void AddKeyToRoom(Room room, string keyId)
        {
            if (room != null)
            {
                var key = new KeyItem
                {
                    Name = "Rusty Key",
                    Description = "An old and rusty key. It looks like it could open something.",
                    Value = 1,
                    Weight = 0.1m,
                    KeyId = keyId // This should match the RequiredKeyId of the door we want to unlock
                };

                room.Items.Add(key);
                _context.SaveChanges();
            }
        }

        private void EquipItem(Character player)
        {
            foreach (var item in player.Equipment.EquipmentSlots)
            {
                if (item.EquippedItem != null)
                {
                    Console.WriteLine($"Slot: {item.slotType} - Equipped Item: {item.EquippedItem.Name}");
                }
                else
                {
                    Console.WriteLine($"Slot: {item.slotType} - Equipped Item: None");
                }
            }

            var weapon = player.Inventory.Items.OfType<Weapon>().FirstOrDefault();
            if (weapon != null)
            {
                player.EquipItem(weapon);
                _context.SaveChanges();
            }

            foreach (var item in player.Equipment.EquipmentSlots)
            {
                if (item.EquippedItem != null)
                {
                    Console.WriteLine($"Slot: {item.slotType} - Equipped Item: {item.EquippedItem.Name}");
                }
                else
                {
                    Console.WriteLine($"Slot: {item.slotType} - Equipped Item: None");
                }
            }

        }

        private void InteractWithChest(Character player)
        {
            var chest = _context.Containers.OfType<Chest>().FirstOrDefault();
            if (chest == null) return;

            if (chest.IsLocked)
            {
                Console.WriteLine("The chest is locked. You need a key to open it.");
                return;
            }

            Console.WriteLine("You open the chest and find:");
            foreach (var item in chest.Items)
            {
                Console.WriteLine($" - {item.Name} (Type: {item.ItemType})");
                Console.WriteLine($"\t\t{item.Description}");
                Console.WriteLine();

                player.PickUp(item);
            }

            _context.SaveChanges();

        }

        public void ListChestItems()
        {
            var chest = _context.Containers.OfType<Chest>().FirstOrDefault();
            foreach (var item in chest.Items)
            {
                Console.WriteLine($" - {item.Name} (Type: {item.ItemType})");
                Console.WriteLine($"\t\t{item.Description}");
                Console.WriteLine();

            }
        }

        private void ListPlayerItemsByType(Character player)
        {
            var items = player.Inventory.Items;

            var groupedItems = items.GroupBy(i => i.ItemType);

            foreach (var group in groupedItems)
            {
                Console.WriteLine($"{group.Key}\t\t{group.Count()}");
                foreach (var item in group)
                {
                    Console.WriteLine($" - {item.Name}");
                }
            }

        }

        private void DropItem(Character player)
        {
            var itemToDrop = player.Inventory.Items.FirstOrDefault(i => i.Name == "Sword of Testing");
            if (itemToDrop != null)
            {
                player.Drop(itemToDrop);
                _context.SaveChanges();
            }
        }

        private void ShowPlayerInventory(Character player)
        {
            var inventoryItems = player.Inventory.Items;

            Console.WriteLine("Your inventory contains:");
            foreach (var item in inventoryItems)
            {
                Console.WriteLine($" - {item.Name} (Type: {item.ItemType})");
                Console.WriteLine($"\t\t{item.Description}");
                Console.WriteLine();
            }
        }

        private void MovePlayer(Character player, string direction)
        {
            var roomId = player.HomeRoomId;
            var currentRoom = _context.Rooms.FirstOrDefault(r => r.Id == roomId);

            Room? nextRoom = null;
            switch (direction)
            {
                case "N":
                    nextRoom = currentRoom.NorthRoom;
                    break;
                case "S":
                    nextRoom = currentRoom.SouthRoom;
                    break;
                case "E":
                    nextRoom = currentRoom.EastRoom;
                    break;
                case "W":
                    nextRoom = currentRoom.WestRoom;
                    break;
                default:
                    Console.WriteLine("Invalid direction. Please enter N, S, E, or W.");
                    break;
            }

            if (nextRoom != null)
            {
                //=====================
                var door = _context.Doors.FirstOrDefault(d =>
                    (d.RoomAId == currentRoom.Id && d.RoomBId == nextRoom.Id) ||
                    (d.RoomAId == nextRoom.Id && d.RoomBId == currentRoom.Id));

                if (door != null && door.IsLocked)
                {
                    var hasKey = player.Inventory.Items.OfType<KeyItem>().Any(k => k.KeyId == door.RequiredKeyId);
                    if (hasKey)
                    {
                        Console.WriteLine($"You use the key to unlock the door to {nextRoom.Name}.");
                        door.IsLocked = false;
                    }
                    else
                    {
                        Console.WriteLine($"The door to {nextRoom.Name} is locked. You can't move {direction}.");

                        return;
                    }
                }
                //=====================

                player.HomeRoom = nextRoom;
                _context.SaveChanges();
                Console.WriteLine($"You moved {direction} to {nextRoom.Name}.");
                ShowRoomExits(nextRoom.Id);
            }
            else
            {
                Console.WriteLine($"You can't move {direction} from here.");
            }
        }

        private void SetupWorld()
        {
            // Set the room exits
            var room2 = _context.Rooms.FirstOrDefault(r => r.Id == 2);
            var room3 = _context.Rooms.FirstOrDefault(r => r.Id == 3);

            room2.EastRoom = room3;
            room3.WestRoom = room2;
            _context.SaveChanges();
        }

        private void GiveItemtoPlayer(Character player)
        {
            var sword = new Weapon
            {
                Name = "Sword of Testing",
                Attack = 10,
                Description = "A sword",
                Value = 2,
                Weight = 4.3m
            };

            player.Inventory?.AddItem(sword);

            _context.SaveChanges();

        }
        public void PlayerLogin(Character player)
        {
            Console.WriteLine($"Welcome to the game!");
            Console.WriteLine($"Welcome, {player.Name}! Your adventure begins now.");
            Console.WriteLine();
            DisplayCharacter(player);
            Console.WriteLine();
            ShowRoomExits(player.HomeRoomId);
        }

        private void ShowRoomExits(int? roomId)
        {
            var room = _context.Rooms.FirstOrDefault(r => r.Id == roomId);
            Console.WriteLine($"Exits from {room.Name}:");

            if (room.NorthRoom != null) Console.WriteLine($" - North: {room.NorthRoom.Name}");
            if (room.SouthRoom != null) Console.WriteLine($" - South: {room.SouthRoom.Name}");
            if (room.EastRoom != null) Console.WriteLine($" - East: {room.EastRoom.Name}");
            if (room.WestRoom != null) Console.WriteLine($" - West: {room.WestRoom.Name}");
        }

        private void AddMonsterToRoom()
        {
            // ask the user for the Room
            foreach (var room in _context.Rooms)
            {
                Console.WriteLine($"Id: {room.Id} Room: {room.Name}");
            }

            // WILL NOT WORK because the Room is not being tracked by the context,
            // so we need to find the Room in the database first and then add the Monster to that Room
            // IF WE TRY to add a Monster with a Room that is not being tracked,
            // it will create a new Room in the database instead of associating the Monster with the existing Room
            //var room = new Room       
            //{
            //    Id = 2,
            //    Name = "Goblin's Lair"
            //};

            // OPTION 1: ask for the Room Id and then find the Room in the database
            Console.WriteLine("Enter the Id of the Room you want to add a monster to:");
            var roomChoiceId = Console.ReadLine();
            var room1 = _context.Rooms.FirstOrDefault(r => r.Id == int.Parse(roomChoiceId));

            // OPTION 2: ask for the Room name and then find the Room in the database
            //Console.WriteLine("Enter the name of the Room you want to add a monster to:");
            //var roomChoiceName = Console.ReadLine();
            //var room2 = _context.Rooms.FirstOrDefault(r => r.Name == roomChoiceName);

            _context.Monsters.Add(new Goblin
            {
                Name = "Creepy Goblin",
                Sneakiness = 5,
                Room = room1 // or room2
            });
            _context.SaveChanges();
        }

        public void ListMonstersInRooms()
        {
            var rooms = _context.Rooms.ToList();
            foreach (var room in rooms)
            {
                Console.WriteLine($"Room: {room.Name}");
                Console.WriteLine($"Description: {room.Description}");

                foreach (var monster in room.Monsters)
                {
                    Console.WriteLine($" - Monster: {monster.Name} (Type: {monster.MonsterType})");
                }

                Console.WriteLine();
            }
        }

        public void ListRooms()
        {
            var rooms = _context.Rooms;
            foreach (var room in rooms)
            {
                Console.WriteLine($"Room: {room.Name}");
                Console.WriteLine($"Description: {room.Description}");
                Console.WriteLine();
            }
        }

        public void CreateMonsters()
        {
            var goblin = new Goblin
            {
                Name = "Sneaky Goblin",
                Sneakiness = 7,
                Room = new Room
                {
                    Name = "Goblin's Lair",
                    Description = "A dark and damp cave filled with goblin treasures."
                }
            };
            var troll = new Troll
            {
                Name = "Strong Troll",
                Strength = 10,
                Room = new Room
                {
                    Name = "Troll's Bridge",
                    Description = "A rickety bridge guarded by a fearsome troll."
                }
            };
            _context.Monsters.Add(goblin);
            _context.Monsters.Add(troll);

            _context.SaveChanges();
        }

        private void DisplayCharacter(Character character)
        {

            Console.WriteLine($"Character: {character.Name}");

            var stats = character.Stats;
            Console.WriteLine($"Stats: STR {character.Stats.Strength}, INT {character.Stats.Intelligence}, HP {character.Stats.Health}");

            var room = character.HomeRoom;
            if (room != null)
            {
                Console.WriteLine($"Home Room: {room.Name}");
                string description = room.Description != null ? $"Description: {room.Description}" : "No description available.";
                Console.WriteLine(description);
            }
            else
            {
                Console.WriteLine("Home Room: None");
            }
        }

        private void DisplayCharacters()
        {
            var characters = _context.Characters.ToList();

            foreach (var character in characters)
            {
                Console.WriteLine($"Character: {character.Name}");

                var stats = character.Stats;
                Console.WriteLine($"Stats: STR {character.Stats.Strength}, INT {character.Stats.Intelligence}, HP {character.Stats.Health}");

                var room = character.HomeRoom;
                if (room != null)
                {
                    Console.WriteLine($"Home Room: {room.Name}");
                    string description = room.Description != null ? $"Description: {room.Description}" : "No description available.";
                    Console.WriteLine(description);
                }
                else
                {
                    Console.WriteLine("Home Room: None");
                }
                Console.WriteLine();
            }
        }
        private void CreateCharacter(string name)
        {
            var character = new Character
            {
                Name = name,
                Stats = new CharacterStats
                {
                    Strength = 10,
                    Intelligence = 10,
                    Health = 100
                }
            };
            _context.Characters.Add(character);
            _context.SaveChanges();
        }
    }
}