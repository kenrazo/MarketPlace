using MarketPlace.Application.Abstractions.Messaging;

namespace MarketPlace.Application.WorkOut
{
    public record WorkOutCommand(
        DateTime WorkOutDate,
        IEnumerable<Excercise> Excercises) : ICommand<Guid>;

    public record Excercise(string Name,
        int Set,
        int Repetition);
}
