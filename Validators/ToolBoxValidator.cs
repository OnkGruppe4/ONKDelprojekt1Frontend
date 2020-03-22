using F20ITONK.ASPNETCore.MicroService.ClassLib.Models;
using FluentValidation;
using ONKDelprojekt1Frontend.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ONKDelprojekt1Frontend.Validators
{
    public class ToolBoxValidator : AbstractValidator<Vaerktoejskasse>
    {
        public ToolBoxValidator(ICraftsManService craftsManService)
        {
            RuleFor(x => x.VTKEjesAf).NotEmpty().Custom((ownerId, context) =>
            {
                if (!ownerId.HasValue)
                    context.AddFailure("You must specify a owner");

                var craftsman = craftsManService.GetCraftsman(ownerId.Value);

                if (craftsman != null)
                    context.AddFailure("You must specify an existing owner");
            });
        }
    }
}
