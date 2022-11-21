using GameStore.Model;
using FluentValidation;

namespace GameStore.Validators
{
    public class GameValidator : AbstractValidator<Game>
    {
        public GameValidator()
        {
            RuleFor(game => game.Upc).Matches("^(?=.*0)[0-9]{12}$").WithMessage("Value was not valid UPC");
            RuleFor(game => game.Name).NotEmpty();
            RuleFor(game => game.ShortDescription).NotEmpty();
            RuleFor(game => game.Price).GreaterThan(0);
        }
    }
}
