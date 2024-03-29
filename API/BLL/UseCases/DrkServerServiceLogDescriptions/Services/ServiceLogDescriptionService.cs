﻿using System.Collections.Generic;
using API.BLL.Base;
using API.BLL.UseCases.DrkServerServiceLogDescriptions.Daos;
using API.BLL.UseCases.DrkServerServiceLogDescriptions.Entities;

namespace API.BLL.UseCases.DrkServerServiceLogDescriptions.Services
{
    public interface IServiceLogDescriptionService
    {
        DataTableSearchResult<ServiceLogDescription> FindBySearchValue(ServiceLogDescriptionSearchOptions search);
        List<ServiceLogDescription> Autocomplete(string searchValue);
    }

    public class ServiceLogDescriptionService : IServiceLogDescriptionService
    {
        private readonly IServiceLogDescriptionDao descriptionDao;

        public ServiceLogDescriptionService(IServiceLogDescriptionDao descriptionDao)
        {
            this.descriptionDao = descriptionDao;
        }

        public List<ServiceLogDescription> Autocomplete(string searchValue) =>
            descriptionDao.GetAllForAutocomplete(searchValue);

        public DataTableSearchResult<ServiceLogDescription> FindBySearchValue(ServiceLogDescriptionSearchOptions search)
            => descriptionDao.FindBySearchValue(search);
    }
}