﻿using Domain.Entities.v1;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repository.Interfaces.v1
{
    public interface IClientRepository
    {
        Task InsertPerson(Person person);

        Task<JsonResult> GetClientById(int client);
    }
}
