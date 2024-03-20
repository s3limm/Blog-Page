﻿using Blog_Page.API.Core.Domain;
using Blog_Page.Models;
using System.Linq.Expressions;

namespace Blog_Page.Repositories.Interfaces
{
    public interface IRepositoryUI<T> where T : BaseEntity, new()
    {
        Task<List<T>> GetListAsync();

        Task<T> GetByIDAsync(int id);

    }
}
