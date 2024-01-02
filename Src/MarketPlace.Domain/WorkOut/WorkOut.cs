using MarketPlace.Domain.Abstractions;
using MarketPlace.Domain.WorkOut.ValueObjects;

namespace MarketPlace.Domain.WorkOut;

public class WorkOut : Entity<WorkOutId>
{
    public WorkOutDate WorkOutDate { get; private set; }
    public IEnumerable<Excercise> Excercises { get; private set; }

    private WorkOut() { }

    private WorkOut(WorkOutId workOutId, WorkOutDate workOutDate, IEnumerable<Excercise> excercises)
    {
        Id = workOutId;
        WorkOutDate = workOutDate;
        Excercises = excercises;
    }

    public static WorkOut Create(WorkOutDate workOutDate, IEnumerable<Excercise> excercises)
    {
        var workOut = new WorkOut(WorkOutId.New(), workOutDate, excercises);

        return workOut;
    }
}
