using AutoFixture;
using FluentAssertions;
using MarketPlace.Application.WorkOut;
using MarketPlace.Domain.WorkOut;
using NSubstitute;

namespace MarketPlace.Application.Tests.WorkOut
{
    public class WorkOutCommandHandlerTests
    {
        private Fixture _fixture;
        private WorkOutCommandHandler _workOutCommandHandler;

        private readonly IWorkOutRepository _workOutRepository;


        public WorkOutCommandHandlerTests()
        {
            _fixture = new Fixture();
            _workOutRepository = Substitute.For<IWorkOutRepository>();
            _workOutCommandHandler = new WorkOutCommandHandler(_workOutRepository);
        }

        [Fact]
        public async Task WorkOutCommandHandler_Create_Success()
        {
            var command = _fixture.Build<WorkOutCommand>().Create();

            var excercises = new List<Domain.WorkOut.ValueObjects.Excercise>()
            {
                Domain.WorkOut.ValueObjects.Excercise.Create(new Domain.WorkOut.ValueObjects.Name("test"),
                new Domain.WorkOut.ValueObjects.Set(4), new Domain.WorkOut.ValueObjects.Repetition(8))
            };

            var workOut = Domain.WorkOut.WorkOut.Create(new Domain.WorkOut.ValueObjects.WorkOutDate(DateTime.Now), excercises);

            _workOutRepository.Create(Arg.Any<Domain.WorkOut.WorkOut>())
                    .Returns(workOut);

            var result = await _workOutCommandHandler.Handle(command, default);

            result.Value.Should().NotBeEmpty();
            result.Value.Should().Be(workOut.Id.Value);
        }
    }
}
