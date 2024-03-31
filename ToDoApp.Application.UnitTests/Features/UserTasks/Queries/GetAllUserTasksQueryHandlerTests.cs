using AutoMapper;
using Moq;
using Shouldly;
using ToDoApp.Application.Contracts.Logging;
using ToDoApp.Application.Features.UserTask.Queries.GetAllUserTasks;
using ToDoApp.Application.MappingProfiles;
using ToDoApp.Application.UnitTests.Mocks;
using ToDoApp.Domain.Contracts.Repositories;

namespace ToDoApp.Application.UnitTests.Features.UserTasks.Queries
{
    public class GetAllUserTasksQueryHandlerTests
    {
        private readonly Mock<IUserTaskRepository> mockRepo;
        private IMapper mapper;
        private Mock<IAppLogger<GetAllUserTasksQueryHandler>> mockApplogger;

        public GetAllUserTasksQueryHandlerTests()
        {
            this.mockRepo = MockUserTaskRepository.GetMockUserTaskRepository();
            var mapperConfig = new MapperConfiguration(c => {

                c.AddProfile<UserTaskMappingProfile>();
            });

            mapper = mapperConfig.CreateMapper();
            mockApplogger = new Mock<IAppLogger<GetAllUserTasksQueryHandler>>();
        }

        [Fact]
        public async Task GetAllUserTasksTest()
        {
            var handler = new GetAllUserTasksQueryHandler(mapper, mockRepo.Object, mockApplogger.Object);

            var result = await handler.Handle(new GetAllUserTasksQuery(),CancellationToken.None);

            result.ShouldBeOfType<List<GetAllUserTasksDto>>();
            result.Count.ShouldBe(3);
        }
    

    }
}
