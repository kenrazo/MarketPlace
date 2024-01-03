using FluentValidation;

namespace MarketPlace.Application.WorkOut
{
    public class WorkOutCommandValidator : AbstractValidator<WorkOutCommand>
    {
        public WorkOutCommandValidator()
        {
            RuleFor(m => m.WorkOutDate)
                .NotNull();

            RuleFor(m => m.Excercises)
                .NotEmpty()
                .NotNull();
        }
    }

    public class ExcerciseValidator : AbstractValidator<Excercise>
    {
        public ExcerciseValidator()
        {
            RuleFor(m => m.Name)
                .NotEmpty()
                .NotNull()
                .MinimumLength(100);

            RuleFor(m => m.Set)
                .NotEmpty()
                .NotNull()
                .LessThan(1);

            RuleFor(m => m.Repetition)
                .NotEmpty()
                .NotNull()
                .LessThan(1);
        }
    }
}
