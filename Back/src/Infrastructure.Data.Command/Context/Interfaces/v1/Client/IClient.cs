﻿using Domain.Entities.v1;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Infrastructure.Data.Command.Interfaces.v1.Client
{
    public interface IClient
    {
        Task InsertPerson(Person person);

        Task<JsonResult> GetClientById(int client);
    }
}