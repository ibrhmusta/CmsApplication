using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ChannelsController : ControllerBase
    {
        private readonly IChannelService _channelService;

        public ChannelsController(IChannelService channelService)
        {
            _channelService = channelService;
        }
    }
}
