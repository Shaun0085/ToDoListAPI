using FluentResults;
using Microsoft.Extensions.Logging;
using ToDoListApplication.Dtos;
using ToDoListApplication.Interfaces;
using ToDoListDomain.Entities;
using ToDoListDomain.Interfaces;

namespace ToDoListApplication.Services
{
    public class ToDoListService : IToDoListService
    {
        private readonly IToDoListRepository _repository;
        private readonly ILogger<ToDoListService> _logger;

        public ToDoListService(IToDoListRepository repository, ILogger<ToDoListService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<Result<List<ToDoListItemDto>>> GetAllItem()
        {
            try
            {
                var entities = await _repository.GetAllItem();
                if (entities == null)
                {
                    return new List<ToDoListItemDto>();
                }
                return entities.Select(x => new ToDoListItemDto
                {
                    ItemId = x.ItemId,
                    ItemTitle = x.ItemTitle,
                    IsCompleted = x.IsCompleted
                }).ToList();
            }
            catch (Exception ex)
            {
                return Result.Fail<List<ToDoListItemDto>>($"Error: {ex.Message}");
            }
        }

        
        public async Task<Result<ToDoListItemDto?>> GetItemById(Guid id)
        {
            try
            {
                var entity = await _repository.GetItemById(id);
                if (entity == null)
                {
                    return null;
                }
                return new ToDoListItemDto
                {
                    ItemId = entity.ItemId,
                    ItemTitle = entity.ItemTitle,
                    IsCompleted = entity.IsCompleted
                };
            }
            catch (Exception ex)
            {
                return Result.Fail<ToDoListItemDto?>($"Error: {ex.Message}");
            }
        }

        
        public async Task<Result<Guid>> AddItem(ToDoListItemDto dto)
        {
            var entity = new ToDoListItem
            {
                ItemId = Guid.NewGuid(),
                ItemTitle = dto.ItemTitle,
                IsCompleted = dto.IsCompleted
            };
            try
            {
                await _repository.AddItem(entity);
                return Result.Ok(entity.ItemId);
            }
            catch (Exception ex)
            {
                return Result.Fail($"Error: {ex.Message}");
            }
        }
        public async Task<Result> UpdateItem(ToDoListItemDto dto)
        {
            try
            {
                var entity = new ToDoListItem
                {
                    ItemId = dto.ItemId,
                    ItemTitle = dto.ItemTitle,
                    IsCompleted = dto.IsCompleted
                };
                await _repository.UpdateItem(entity);
                return Result.Ok();
            }
            catch (Exception ex)
            {
                return Result.Fail($"Error: {ex.Message}");
            }
        }

        public async Task<Result> DeleteItem(Guid id)
        {
            try
            {
                await _repository.DeleteItem(id);
                return Result.Ok();
            }
            catch (Exception ex)
            {
                return Result.Fail($"Error: {ex.Message}");
            }
        }
    }
}
