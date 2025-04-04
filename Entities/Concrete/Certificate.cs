﻿using Core.Entities.Abstract;
using Core.Entities.Concrete;

namespace Entities.Concrete;

public class Certificate : BaseEntity, IEntity
{
    public string Title { get; set; }
    public string Image { get; set; }
}