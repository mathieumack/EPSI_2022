namespace Sample.DP.Builder.Domain
{
    internal class HouseBuilder
    {
        private House house = new();

        public HouseBuilder AddFloor()
        {
            house.Floors.Add(new Floor());
            return this;
        }

        public HouseBuilder AddRoom(string name)
        {
            house.Floors[^1].Rooms.Add(new Room(name));
            return this;
        }

        public House Build()
        {
            return house;
        }
    }
}
