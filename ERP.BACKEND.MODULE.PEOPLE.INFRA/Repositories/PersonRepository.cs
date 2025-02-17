﻿using PeopleManagement.Domain.Entities;
using PeopleManagement.Domain.Interfaces.Repositories;
using PeopleManagement.Infra.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleManagement.Infra.Repositories
{
    public class PersonRepository : RepositoryBase<Person>, IPersonRepository
    {
        public PersonRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public async Task<Person?> GetByName(string user) => await appDbContext.Set<Person>().AsNoTracking().FirstOrDefaultAsync(x => x.Name.Equals(user));

        public async Task<Person?> GetByCpfCnpj(string cpfCnpj) => await appDbContext.Set<Person>().AsNoTracking().FirstOrDefaultAsync(x => x.CpfCnpj.Equals(cpfCnpj));
    }
}
