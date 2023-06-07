using NServiceBus;

namespace Contracts;

public class ProcessInstruction : ICommand
{
    public int Id { get; set; }
}