using FluentValidation;

namespace BowlingGame.API.Requests
{
    public class CreateGameRequest : Request
    {
        public string PlayerName { get; set; }

        protected sealed override void Validate()
        {
            var validator = new InlineValidator<CreateGameRequest>();
            validator.RuleFor(i => i.PlayerName).NotEmpty().NotNull().MaximumLength(250);

            foreach (var error in validator.Validate(this).Errors)
            {
                Errors.Add(error.ErrorMessage);
            }
        }
    }
}