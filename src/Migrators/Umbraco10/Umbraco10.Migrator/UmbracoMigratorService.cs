﻿using System;
using System.Threading.Tasks;
using Enterspeed.Migrator.Enterspeed.Contracts;
using Microsoft.Extensions.Logging;
using Umbraco10.Migrator.DocumentTypes;

namespace Umbraco10.Migrator
{
    public class UmbracoMigratorService : IUmbracoMigratorService
    {
        private readonly IPagesResolver _pagesResolver;
        private readonly IDocumentTypeBuilder _documentTypeBuilder;
        private readonly IApiService _apiService;
        private readonly ILogger<UmbracoMigratorService> _logger;
        private readonly ISchemaBuilder _schemaBuilder;

        public UmbracoMigratorService(
            ILogger<UmbracoMigratorService> logger,
            IPagesResolver pagesResolver,
            IApiService apiService,
            ISchemaBuilder schemaBuilder,
            IDocumentTypeBuilder documentTypeBuilder)
        {
            _logger = logger;
            _pagesResolver = pagesResolver;
            _apiService = apiService;
            _schemaBuilder = schemaBuilder;
            _documentTypeBuilder = documentTypeBuilder;
        }

        public async Task ImportDocumentTypesAsync()
        {
            try
            {
                var navigation = await _apiService.GetNavigationAsync();
                var rootLevelResponse = await _apiService.GetPageResponsesAsync(navigation);
                var pages = _pagesResolver.ResolveFromRoot(rootLevelResponse);
                var pageSchemas = _schemaBuilder.BuildPageSchemas(pages);
                _documentTypeBuilder.BuildPageDocTypes(pageSchemas);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "something went wrong when building document types");
                throw;
            }
        }

        public async Task ImportDataAsync()
        {
            try
            {
                // var data = await _sourceImporter.ImportDataAsync();
                // _contentBuilder.BuildContentPages(data);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "something went wrong when importing data");
                throw;
            }
        }
    }
}