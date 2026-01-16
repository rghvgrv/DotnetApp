using RabbitMQ.Client;
using System.Text;

//Connect to RabbitMQ Server
var factory = new ConnectionFactory() { HostName = "localhost" };

//Create a TCP connection to the RabbitMQ Server
using var connection = await factory.CreateConnectionAsync();

//Create a channel inside TCP Connection
// 1 Connection can have multiple channels
using var channel = await connection.CreateChannelAsync();

//Declare a queue to send message
// Need to call this method in both sender and reciever to ensure the queue exists
await channel.QueueDeclareAsync(
    queue: "hello", //Queue Name
    durable: false, //Messages are not persisted
    exclusive: false,  //Usable by other connections
    autoDelete: false, //Queue won't be deleted when last consumer disconnects
    arguments: null //No extra arguments generally used for TTL, DLQ etc
    );

// Define message to send
const string message = "Hello World! How are you and all";

// RabbitMQ only send byte array
var body = Encoding.UTF8.GetBytes(message);

await channel.BasicPublishAsync(
    exchange: string.Empty, //Default exchange
    routingKey: "hello", //Queue name
    body:body
    );
Console.WriteLine(" [x] Sent {0}", message);

Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();