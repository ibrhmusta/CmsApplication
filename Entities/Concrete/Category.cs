﻿using Entities.Abstract;
using System;
using System.Collections.Generic;

#nullable disable

namespace Entities.Concrete
{
    public partial class Category : IEntity
    {

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
