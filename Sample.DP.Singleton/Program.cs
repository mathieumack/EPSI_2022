using Sample.DP.Singleton.Domain;

var myHouse = House.SingletonHouse;
// Only one instance of House is created and shared by all consumers.
myHouse.Floors.Add(new Floor()
{
    Rooms = new List<Room>()
    {
        new Room("Living Room"),
        new Room("Kitchen")
    }
});

Console.WriteLine("House has {0} floors", myHouse.Floors.Count);

var myOtherHouse = House.SingletonHouse;
myOtherHouse.Floors.Add(new Floor()
{
    Rooms = new List<Room>()
    {
        new Room("Bedroom"),
        new Room("Bathroom")
    }
});

Console.WriteLine("House has {0} floors", myOtherHouse.Floors.Count);