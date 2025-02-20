﻿using Comuclub.Entities;
using Comuclub.Views.Dtos;
using Comuclub.Views.Models;

namespace Comuclub.Service.Abstracts
{
    public interface IOrganizerService
    {
        Task<OrganizerDto> saveEvent(OrganizerModel model);
        Task<IEnumerable<OrganizerDto>> findAll();
    }
}
