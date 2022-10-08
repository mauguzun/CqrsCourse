﻿using AutoMapper;
using Entities;
using Handlers.CqrsFramework;
using Infrastructure.Interfaces;
using System.Threading.Tasks;

namespace Handlers.UseCases.Order.Commands.CreateOrder
{
    public abstract class CreateEntityCommandHandler<TRequest, TEntity, TDto> : IRequestHandler<TRequest, int>
        where TEntity : Entity
        where TRequest : CreateEntityCommand<TDto>
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;

        protected CreateEntityCommandHandler(IDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public virtual async Task<int> HandleAsync(TRequest request)
        {
            var entity = _mapper.Map<TEntity>(request.Dto);
            InitializeNewEntity(entity);
            _dbContext.Set<TEntity>().Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity.Id;
        }

        protected virtual void InitializeNewEntity(TEntity entity)
        {
        }
    }
}
