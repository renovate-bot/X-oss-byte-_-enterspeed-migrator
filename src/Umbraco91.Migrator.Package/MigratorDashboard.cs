﻿using Umbraco.Cms.Core.Dashboards;
using Umbraco.Cms.Core;

namespace Umbraco91.Migrator.Package
{
    public class MigratorDashboard : IDashboard
    {
        public string Alias => "MigratorDashboard";
        public string View => "/App_Plugins/Umbraco91.Migrator.Package/dashboard.html";
        public string[] Sections => new[]
        {
            Constants.Applications.Settings
        };

        public IAccessRule[] AccessRules
        {
            get
            {
                var rules = new IAccessRule[]
                {
                    new AccessRule {Type = AccessRuleType.Grant, Value = Constants.Security.AdminGroupAlias}
                };
                return rules;
            }
        }
    }
}
