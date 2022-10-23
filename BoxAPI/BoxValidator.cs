using Entities;
using FluentValidation;

namespace BoxAPI;

public class BoxValidator : AbstractValidator<Boxes>
{
    public BoxValidator()
    {   
        // when creating the box, it should follow these rules.
        
        RuleFor(b => b.Length).GreaterThan(0);
        RuleFor(b => b.Width).GreaterThan(0);
        RuleFor(b => b.Type).NotEmpty();
    }
}