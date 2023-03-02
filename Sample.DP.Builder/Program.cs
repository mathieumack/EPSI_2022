using Sample.DP.Builder.Domain;
    
Console.WriteLine("Hello World!");


// Build a House with 2 floor and 3 rooms in each floor
var house = new House();

var floor1 = new Floor();
var room11 = new Room("Kitchen");
floor1.Rooms.Add(room11);
var room12 = new Room("Living Room");
floor1.Rooms.Add(room12);
var room13 = new Room("Bathroom");
floor1.Rooms.Add(room13);
house.Floors.Add(floor1);

var floor2 = new Floor();
var room21 = new Room("Bedroom");
floor1.Rooms.Add(room21);
var room22 = new Room("Bathroom");
floor1.Rooms.Add(room22);
var room23 = new Room("Balcony");
floor2.Rooms.Add(room23);
house.Floors.Add(floor2);

// Build a House with 2 floor and 3 rooms in each floor with the builder :
var houseBuilder = new HouseBuilder();
house = houseBuilder
    .AddFloor()
        .AddRoom("Kitchen")
        .AddRoom("Living Room")
        .AddRoom("Bathroom")
    .AddFloor()
        .AddRoom("Bedroom")
        .AddRoom("Bathroom")
        .AddRoom("Balcony")
    .Build();