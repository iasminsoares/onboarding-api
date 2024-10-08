﻿using IntegraApi.Application.Persistence.Context;

namespace IntegraApi.Application.Persistence.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}
