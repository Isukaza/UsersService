using DAL.Models;
using DAL.Models.Enums;
using DAL.Repositories.Interfaces;
using Moq;
using UsersService.Managers;
using UsersService.Models.Requests;

namespace Tests;

public class UserManagerTests
{
    private readonly Mock<IUserRepository> _repoMock;
    private readonly UserManager _manager;

    private readonly List<User> _users =
    [
        new()
        {
            Id = 1, Name = "John Doe", Email = "John@example.com",
            Subscription = new Subscription { Id = 2, Type = SubscriptionType.Super }
        },
        new()
        {
            Id = 2, Name = "Mark Shimko", Email = "Mark@example.com",
            Subscription = new Subscription { Id = 1, Type = SubscriptionType.Free }
        },
        new()
        {
            Id = 3, Name = "Taras Ovruch", Email = "Taras@example.com",
            Subscription = new Subscription { Id = 3, Type = SubscriptionType.Trial }
        }
    ];

    public UserManagerTests()
    {
        _repoMock = new Mock<IUserRepository>();
        _manager = new UserManager(_repoMock.Object);
    }


    [Fact]
    public async Task GetAllAsync_ShouldReturnAllUsers()
    {
        _repoMock.Setup(r => r.GetAllAsync()).ReturnsAsync(_users);

        var result = await _manager.GetAllAsync();

        Assert.NotNull(result);
        var list = new List<UsersService.Models.Responses.UserInfo>(result);
        Assert.Equal(3, list.Count);
        Assert.Contains(list, u => u.Name == "John Doe");
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnCorrectUser()
    {
        var user = _users[0];
        _repoMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(user);

        var result = await _manager.GetByIdAsync(1);

        Assert.NotNull(result);
        Assert.Equal("John Doe", result.Name);
        Assert.Equal(SubscriptionType.Super, result.SubscriptionType);
    }

    [Fact]
    public async Task GetUsersBySubscriptionTypeAsync_ShouldReturnFilteredUsers()
    {
        _repoMock.Setup(r => r.GetUsersBySubscriptionTypeAsync(SubscriptionType.Free))
            .ReturnsAsync(new List<User> { _users[1] });

        var result = await _manager.GetUsersBySubscriptionTypeAsync(SubscriptionType.Free);

        var list = new List<UsersService.Models.Responses.UserInfo>(result);
        Assert.Single(list);
        Assert.Equal(SubscriptionType.Free, list[0].SubscriptionType);
    }

    [Fact]
    public async Task CreateAsync_ShouldCreateAndReturnUser()
    {
        var create = new UserCreate { Name = "New User", Email = "new@example.com", SubscriptionId = 1 };
        var user = new User
            { Id = 4, Name = create.Name, Email = create.Email, SubscriptionId = create.SubscriptionId };

        _repoMock.Setup(r => r.CreateAsync(It.IsAny<User>())).ReturnsAsync(user);

        var result = await _manager.CreateAsync(create);

        Assert.NotNull(result);
        Assert.Equal("New User", result.Name);
        Assert.Equal("new@example.com", result.Email);
    }

    [Fact]
    public async Task UpdateAsync_ShouldUpdateExistingUser()
    {
        var existing = _users[0];
        _repoMock.Setup(r => r.GetByIdAsync(existing.Id)).ReturnsAsync(existing);
        _repoMock.Setup(r => r.UpdateAsync(existing)).ReturnsAsync(existing);

        var update = new UserUpdate { Id = existing.Id, Name = "Updated", Email = "updated@example.com" };

        var result = await _manager.UpdateAsync(update);

        Assert.NotNull(result);
        Assert.Equal("Updated", result.Name);
        Assert.Equal("updated@example.com", result.Email);
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnNull_WhenUserNotFound()
    {
        _repoMock.Setup(r => r.GetByIdAsync(999)).ReturnsAsync((User)null);

        var update = new UserUpdate { Id = 999, Name = "DoesNotExist" };

        var result = await _manager.UpdateAsync(update);

        Assert.Null(result);
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnTrue_WhenUserDeleted()
    {
        _repoMock.Setup(r => r.DeleteAsync(1)).ReturnsAsync(true);

        var result = await _manager.DeleteAsync(1);

        Assert.True(result);
    }
}