using FluentAssertions;
using FluentAssertions.Execution;
using Moq;
using TestPortalen.Application.Entities;
using TestPortalen.Application.Interfaces;
using TestPortalen.Entities;

namespace TestPortalen.Application.Tests.Entities;

public class IdGeneratorTests
{
    [Fact]
    public async Task GetNextId_ExistingEntities_ShouldReturnNextAvailableId()
    {
        // Arrange
        var repo = new Mock<IEntityRepository>();
        var entities = new List<Entity> { new() { Id = 2 }, new() { Id = 3 } };
        repo.Setup(r => r.GetAllEntities()).ReturnsAsync(entities);
        var generator = new IdGenerator(repo.Object);

        // Act
        var result = await generator.GetNextId();

        // Assert
        result.Should().Be(4);
    }

    [Fact]
    public async Task IncreaseIdByTen_CurrentId_ShouldUpdateIdWithCurrentIdPlusTen()
    {
        // Arrange
        var repo = new Mock<IEntityRepository>();
        var generator = new IdGenerator(repo.Object);

        // Act
        await generator.IncreaseIdByTen(25);

        // Assert
        using (new AssertionScope())
        {
            repo.Verify(r => r.UpdateId(25, 35), Times.Once);
            repo.Verify(r => r.UpdateId(It.IsAny<int>(), It.IsAny<int>()), Times.Once);
        }
    }
}