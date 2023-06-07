using System;
using System.Threading.Tasks;
using Contracts;
using NServiceBus;

namespace Trigger;

public class ProcessingInstructionHandler : IHandleMessages<ProcessInstruction>
{
    public async Task Handle(ProcessInstruction message, IMessageHandlerContext context)
    {
        Console.WriteLine($"Processing ProcessInstruction message, ID {message.Id}");
        await Task.Delay(200);
        Console.WriteLine($"Done processInstruction message, ID {message.Id}");
    }
}