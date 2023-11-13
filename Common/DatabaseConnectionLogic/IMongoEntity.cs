﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConnectionLogic
{
    public interface IMongoEntity<TId>
    {
        TId Id { get; set; }
    }
}
