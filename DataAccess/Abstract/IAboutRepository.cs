﻿using Core.DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IAboutRepository : IEntityRepository<About>
    {
        string Test();
    }
}