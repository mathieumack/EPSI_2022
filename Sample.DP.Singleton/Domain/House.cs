
namespace Sample.DP.Singleton.Domain
{
    internal class Room
    {
        public string Name { get; }

        public Room(string name)
        {
            Name = name;
        }
    }
    
    internal class Floor
    {
        public List<Room> Rooms { get; set; } = new ();
    }
    
    internal class House
    {
        internal static House SingletonHouse { get; } = new House();

        public List<Floor> Floors { get; } = new();
    }
}
