using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IChannelService
    {
        IDataResult<List<Channel>> GetAll();
        IResult Add(Channel channel);
        IResult Delete(Channel channel);
        IResult Update(Channel channel);
    }

}
