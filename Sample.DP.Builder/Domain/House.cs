
namespace Sample.DP.Builder.Domain
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
        public List<Room> Rooms { get; } = new ();
    }
    
    internal class House
    {
        public List<Floor> Floors { get; } = new();
    }
}
