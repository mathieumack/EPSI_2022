using Sample.DP.State.Domain;

var service = new MessageService();

service.StartWriting();
Console.WriteLine("Message state: {0}", service.State);

service.WriteLine("Hello World!");
Console.WriteLine("Message state: {0}", service.State);

service.Send();
Console.WriteLine("Message state: {0}", service.State);

Console.WriteLine("Message state: {0}", service.State);
