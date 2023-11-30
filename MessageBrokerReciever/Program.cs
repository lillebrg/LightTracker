using HiveMQtt.Client;
using HiveMQtt.Client.Options;
using HiveMQtt.MQTT5.ReasonCodes;
using HiveMQtt.MQTT5.Types;
using System.Text.Json;
using Models;

var options = new HiveMQClientOptions
{
    Host = "7bcfe2b0a4e14297a88120d2ceebe0d3.s2.eu.hivemq.cloud",
    Port = 8883,
    UseTLS = true,
    UserName = "Chulmoo",
    Password = "Hero34dkl",
};
var client = new HiveMQClient(options);

Console.WriteLine($"Connecting to {options.Host} on port {options.Port} ...");

// Connect
HiveMQtt.Client.Results.ConnectResult connectResult;
try
{
    connectResult = await client.ConnectAsync().ConfigureAwait(false);
    if (connectResult.ReasonCode == ConnAckReasonCode.Success)
    {
        Console.WriteLine($"Connect successful: {connectResult}");
    }
    else
    {
        // FIXME: Add ToString
        Console.WriteLine($"Connect failed: {connectResult}");

    }
}
catch (System.Net.Sockets.SocketException e)
{
    Console.WriteLine($"Error connecting to the MQTT Broker with the following socket error: {e.Message}");

}
catch (Exception e)
{
    Console.WriteLine($"Error connecting to the MQTT Broker with the following message: {e.Message}");

}

// Subscribe
await client.SubscribeAsync("test");

// Message Handler
client.OnMessageReceived += (sender, args) =>
{
    string received_message = args.PublishMessage.PayloadAsString;
    Console.WriteLine(received_message);
    try
    {
        LightLog lightlog = JsonSerializer.Deserialize<LightLog>(received_message);
        Console.WriteLine(lightlog.TimeOnly);
    }
    catch (JsonException ex)
    {
        Console.WriteLine($"Error deserializing JSON: {ex.Message}");
    }
};
while (true)
{
    await Task.Delay(1000);
}






