using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CampaignValidator : AbstractValidator<Campaign>
    {
        public CampaignValidator()
        {
            RuleFor(campaign => campaign.Name).NotEmpty();
            RuleFor(campaign => campaign.Name).MinimumLength(5);
        }
    }
}
