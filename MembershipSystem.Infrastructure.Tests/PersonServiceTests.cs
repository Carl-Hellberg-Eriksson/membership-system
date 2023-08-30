using FakeItEasy;
using MembershipSystem.Core.DatabaseEntities;
using MembershipSystem.Core.Interfaces;
using MembershipSystem.Infrastructure.Services;

namespace MembershipSystem.WebService.Tests;
public class PersonServiceTests {

    private readonly IUnitOfWork fakeUnitOfWork;
    private readonly PersonService sut;
    private static IEnumerable<Person> emptyPersonList = new List<Person>();
    private static Person examplePerson = new Person {
        FirstName = "firstName",
        LastName = "lastName"
    };

    public PersonServiceTests() {
        fakeUnitOfWork = A.Fake<IUnitOfWork>();
        sut = new PersonService(fakeUnitOfWork);
    }

    [Fact]
    public async void GetPersonByIdAsync_DbReturnsPerson_ReturnsPerson() {
        //Arrange
        int capturedId = 0;
        int callingId = 3;
        A.CallTo(() => fakeUnitOfWork.Persons.GetByIdAsync(A<int>.Ignored))
            .Invokes((int id) => capturedId = id)
            .Returns(examplePerson);

        //Act
        var response = await sut.GetPersonByIdAsync(callingId);

        //Assert
        Assert.NotNull(response);
        Assert.Equal(callingId, capturedId);
        Assert.Equal(examplePerson, response);
    }

    [Fact]
    public async void GetPersonByIdAsync_DbReturnsNull_ThrowsException() {
        //Arrange
        int capturedId = 0;
        int callingId = 3;
        A.CallTo(() => fakeUnitOfWork.Persons.GetByIdAsync(A<int>.Ignored))
            .Invokes((int id) => capturedId = id)
            .Returns<Person?>(null);

        //Act
        var response = await Assert.ThrowsAsync<Exception>(() => sut.GetPersonByIdAsync(callingId));

        //Assert
        Assert.NotNull(response);
        Assert.Equal(callingId, capturedId);
    }
}
