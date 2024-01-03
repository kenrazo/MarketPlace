using MarketPlace.Application.Abstractions.Messaging;
using MarketPlace.Domain.Abstractions;
using MarketPlace.Domain.WorkOut;
using MarketPlace.Domain.WorkOut.ValueObjects;

namespace MarketPlace.Application.WorkOut
{
    public class WorkOutCommandHandler : ICommandHandler<WorkOutCommand, Guid>
    {
        private readonly IWorkOutRepository _repository;

        public WorkOutCommandHandler(IWorkOutRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<Guid>> Handle(WorkOutCommand request, CancellationToken cancellationToken)
        {
            var excercises = (from excercise in request.Excercises
                              let data = Domain.WorkOut.ValueObjects.Excercise.Create(new Name(excercise.Name), new Set(excercise.Set),
                    new Repetition(excercise.Repetition))
                              select data).ToList();


            var workOut = Domain.WorkOut.WorkOut.Create(new WorkOutDate(request.WorkOutDate), excercises);

            var result = await _repository.Create(workOut);

            return result.Id.Value;
        }
    }
}
