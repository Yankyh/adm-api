﻿namespace PeopleManagement.Domain.Interfaces.Services
{
    using PeopleManagement.Domain.Entities;

    public interface IUserService
    {
        Task<User> Authentication(User entity);
        Task<IEnumerable<User>> GetAll();
    }
}
