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

        public async Task<List<ToDoListItemDto>> GetAllItem()
        {
            try
            {
                var entities = await _repository.GetAllItem();
                if (entities == null)
                {
                    _logger.LogWarning("Service: No to-do list items found.");
                    return new List<ToDoListItemDto>();
                }
                _logger.LogInformation("Service: Retrieved {Count} to-do list items.", entities.Count);
                return entities.Select(x => new ToDoListItemDto
                {
                    ItemId = x.ItemId,
                    ItemTitle = x.ItemTitle,
                    IsCompleted = x.IsCompleted
                }).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Service: Error occurred while retrieving to-do list items.");
                throw;
            }
        }

        
        public async Task<ToDoListItemDto?> GetItemById(Guid id)
        {
            try
            {
                var entity = await _repository.GetItemById(id);
                if (entity == null)
                {
                    _logger.LogInformation("Service: Unable to find item ID: {id}.", id);
                    return null;
                }
                _logger.LogInformation("Service: Item retrieved with item ID: {id}.", id);
                return new ToDoListItemDto
                {
                    ItemId = entity.ItemId,
                    ItemTitle = entity.ItemTitle,
                    IsCompleted = entity.IsCompleted
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Serivce: Error occured while retreiving item with item ID: {id}", id);
                throw;
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
                _logger.LogInformation("Service: Item added successfully.");
                return Result.Ok(entity.ItemId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Service: Error occurred while adding new item.");
                throw;
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
                _logger.LogInformation("Service: Successfully updated item.");
                return Result.Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Service: Error occured while updating item.");
                throw;
            }
        }

        public async Task DeleteItem(Guid id)
        {
            try
            {
                await _repository.DeleteItem(id);
                _logger.LogInformation("Service: Sucessfully deleted item with item ID: {itemId}", id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Service: Error occured while deleteing item with item ID: {itemId}", id);
                throw;
            }
        }
    }
}
