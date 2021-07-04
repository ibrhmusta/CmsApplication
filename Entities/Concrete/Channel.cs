using Entities.Abstract;
using System;
using System.Collections.Generic;

#nullable disable

namespace Entities.Concrete
{
    public partial class Channel : IEntity
    {

        public int Id { get; set; }
        public string Name { get; set; }

    }
}
