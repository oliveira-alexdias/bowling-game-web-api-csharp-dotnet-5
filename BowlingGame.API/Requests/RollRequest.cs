using System;
using System.Collections.Generic;
using FluentValidation;

namespace BowlingGame.API.Requests
{
    public class RollRequest : Request
    {
        public string GameId { get; set; }
        public string Score { get; set; }

        protected sealed override void Validate()
        {
            var validator = new InlineValidator<RollRequest>();
            validator.RuleFor(i => i.GameId).NotEmpty().NotNull();

            var allowed = new List<string>() { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "X", "x", "/", "-", "f", "F" };
            validator.RuleFor(i => i.Score).Must(x => allowed.Contains(x))
                                           .WithMessage("The allowed inputs for score are: " + string.Join(", ", allowed));

            foreach (var error in validator.Validate(this).Errors)
            {
                Errors.Add(error.ErrorMessage);
            }
        }
    }
}