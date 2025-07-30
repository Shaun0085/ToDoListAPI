//using Microsoft.Extensions.Logging;
//using Moq;
//using ToDoListApplication.Interfaces;
//using ToDoListApplication.Services;
//using ToDoListDomain.Entities;
//using ToDoListDomain.Interfaces;
//using ToDoListApplication.Dtos;

//namespace ToDoListTest
//{
//    public class AllToDoListTest
//    {
//        private Mock<IToDoListRepository> _repoMock;
//        private IToDoListService _service;
//        private ILogger<ToDoListService> _logger;
//        public Guid mockItemId = new Guid("78BB9918-B834-4FCD-BF5C-C6E1C5C60987");
//        public Guid mockItemId_2 = new Guid("26E48CDE-2498-4A9C-9B8C-B8D00F5F412F");

//        [SetUp]
//        public void Setup()
//        {
//            _repoMock = new Mock<IToDoListRepository>();
//            var loggerMock = new Mock<ILogger<ToDoListService>>();
//            _logger = loggerMock.Object;
//            _service = new ToDoListService(_repoMock.Object, _logger);
//        }

//        [Test]
//        public async Task GetAllItem_Should_Return_All_ToDoItems()
//        {
//            var dummyData = new List<ToDoListItem>
//            {
//                new ToDoListItem { ItemId = mockItemId, ItemTitle = "Item A", IsCompleted = false },
//                new ToDoListItem { ItemId = mockItemId_2, ItemTitle = "Item B", IsCompleted = true }
//            };
//            _repoMock.Setup(r => r.GetAllItem()).ReturnsAsync(dummyData);

//            var result = await _service.GetAllItem();

//            Assert.That(result.Count, Is.EqualTo(2));
//            Assert.That(result[0].ItemTitle, Is.EqualTo("Item A"));
//        }

//        [Test]
//        public async Task GetItemById_Should_Return_Single_ToDoItem()
//        {
//            var dummyItem = new ToDoListItem { ItemId = mockItemId, ItemTitle = "Target Item", IsCompleted = true };
//            _repoMock.Setup(r => r.GetItemById(mockItemId)).ReturnsAsync(dummyItem);

//            var result = await _service.GetItemById(mockItemId);

//            Assert.IsNotNull(result);
//            Assert.That(result.ItemTitle, Is.EqualTo("Target Item"));
//        }

//        [Test]
//        public async Task AddItem_Should_Add_New_ToDoItem()
//        {
//            var newItemDto = new ToDoListItemDto { ItemTitle = "New Item", IsCompleted = false };
//            _repoMock.Setup(r => r.AddItem(It.IsAny<ToDoListItem>()))
//                     .Returns((ToDoListItem item) =>
//                     {
//                         item.ItemId = mockItemId;
//                         return Task.FromResult(item);
//                     });
//            await _service.AddItem(newItemDto);

//            _repoMock.Verify(r => r.AddItem(It.Is<ToDoListItem>(i =>
//                i.ItemTitle == "New Item" && i.IsCompleted == false)), Times.Once);

//            Assert.That(newItemDto.ItemTitle, Is.EqualTo("New Item"));
//            Assert.That(newItemDto.IsCompleted, Is.EqualTo(false));
//        }

//        [Test]
//        public async Task UpdateItem_Should_Updated_Existing_ToDoItem()
//        {
//            var updateItemDto = new ToDoListItemDto { ItemId = mockItemId, ItemTitle = "Updated Title", IsCompleted = true };
//            _repoMock.Setup(r => r.UpdateItem(It.IsAny<ToDoListItem>())).Returns(Task.CompletedTask);
//            await _service.UpdateItem(updateItemDto);

//            _repoMock.Verify(r => r.UpdateItem(It.Is<ToDoListItem>(i =>
//                i.ItemId == mockItemId && i.ItemTitle == "Updated Title" && i.IsCompleted == true)), Times.Once);
//        }

//        [Test]
//        public async Task DeleteItem_Should_Delete_Existing_ToDoItem()
//        {
//            Guid deleteId = mockItemId;
//            _repoMock.Setup(r => r.DeleteItem(deleteId)).Returns(Task.CompletedTask);
//            await _service.DeleteItem(deleteId);

//            _repoMock.Verify(r => r.DeleteItem(deleteId), Times.Once);
//        }
//    }
//}
