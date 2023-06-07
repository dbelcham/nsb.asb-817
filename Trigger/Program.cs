using System;
using Contracts;
using NServiceBus;
using Secrets;

Console.WriteLine("Trigger");

var configuration = new EndpointConfiguration("trigger");
var transport = configuration.UseTransport<AzureServiceBusTransport>();
transport.Transactions(TransportTransactionMode.SendsAtomicWithReceive);
transport.ConnectionString(Connections.AzureServiceBus);

configuration.SendFailedMessagesTo("error");
configuration.Recoverability().Delayed(settings => settings.NumberOfRetries(0));
configuration.Recoverability().Immediate(settings => settings.NumberOfRetries(0));
configuration.EnableInstallers();

var endpoint = await Endpoint.Start(configuration);
await endpoint.SendLocal(new Kickoff());
Console.WriteLine("Kickoff message sent");
Console.ReadLine();