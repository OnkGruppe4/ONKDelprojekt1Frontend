using F20ITONK.ASPNETCore.MicroService.ClassLib.Models;
using FluentValidation;
using ONKDelprojekt1Frontend.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ONKDelprojekt1Frontend.Validators
{
    public class ToolValidator : AbstractValidator<Vaerktoej>
    {
        public ToolValidator(IToolboxService toolboxService)
        {
            RuleFor(x => x.VTFabrikat).NotNull();
            RuleFor(x => x.LiggerIvtk)
                .NotEmpty()
                .Custom((toolBoxId, context) =>
                {
                    if(toolBoxId != null)
                    {
                        var toolbox = toolboxService.GetToolbox(toolBoxId.Value);

                        if (toolbox.Result != null)
                            context.AddFailure("You must specify an existing toolbox");
                    }
                
             });
        }
    }
}
