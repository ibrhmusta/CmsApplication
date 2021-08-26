using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCampaignDal : EfEntityRepositoryBase<Campaign, CmsContext>, ICampaignDal
    {
        public List<CampaignDetailDto> GetAllCampaignDetails(Expression<Func<Campaign, bool>> filter = null)
        {
            using (CmsContext context = new CmsContext())
            {
                var result = from campaign in filter == null ? context.Campaigns : context.Campaigns.Where(filter)
                             join campaignDay in context.CampaignDays
                                on campaign.Id equals campaignDay.CampaignId
                             join campaignHour in context.CampaignHours
                                on campaign.Id equals campaignHour.CampaignId
                             join campaignType in context.CampaignTypes
                                on campaign.TypeId equals campaignType.Id
                             join company in context.Companies
                                on campaign.CompanyId equals company.Id
                             join campaignRule in context.CampaignRules
                                on campaign.CampaignRuleId equals campaignRule.Id
                             join campaignReward in context.CampaignRewards
                                on campaign.CampaignRewardId equals campaignReward.Id
                             join campaignRuleType in context.CampaignRuleTypes
                                on campaignRule.CampaignRuleTypeId equals campaignRuleType.Id
                             join campaignRewardType in context.CampaignRewardTypes
                                on campaignReward.CampaignRewardTypeId equals campaignRewardType.Id
                             select new CampaignDetailDto
                             {
                                 Campaign = campaign,
                                 CampaignRuleType = campaignRuleType.Name,
                                 CampaignRuleValue = campaignRule.Value,
                                 CampaignRewardType = campaignRewardType.Name,
                                 CampaignRewardValue = campaignReward.Value,
                                 CompanyName = company.Name,
                                 CampaignType = campaignType.Name,
                                 CampaignDay = campaignDay,
                                 CampaignHour = campaignHour,
                                 CampaignReward = campaignReward,
                                 CampaignRule = campaignRule
                             };
                return result.ToList();
            }
        }
    }
}