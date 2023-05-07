﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intotech.Common.Database.Interfaces.DbSetup
{
    public interface ISeedService
    {
        bool AcceptManager(ISeedManager<DbContext> seedManager);

        bool RunSeed();
    }
}
