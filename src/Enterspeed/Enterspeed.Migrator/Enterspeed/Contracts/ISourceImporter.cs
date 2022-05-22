﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace Enterspeed.Migrator.Enterspeed.Contracts
{
    public interface ISourceImporter
    {
        Task<List<object>> ImportAllDataSourcesAsync(Dictionary<string, object> views);
    }
}