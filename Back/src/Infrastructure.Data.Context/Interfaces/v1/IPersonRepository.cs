﻿using Domain.Entities.v1;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repository.Interfaces.v1
{
    public interface IPersonRepository
    {
        Task<Person> InsertPersonAsync(Person person);
    }
}
