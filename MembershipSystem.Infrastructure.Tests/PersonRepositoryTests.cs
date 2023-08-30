using MembershipSystem.Core.DatabaseEntities;
using MembershipSystem.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using MockQueryable.FakeItEasy;

namespace MembershipSystem.Infrastructure.Tests;
public class PersonRepositoryTests {

    private readonly PersonRepository sut;
    private readonly DbSet<Person> persons;

    public PersonRepositoryTests() {
        var data = new[] {
            new Person {
                FirstName = "FirstName1",
                LastName = "LastName1",

            }
        };
        persons = data.AsQueryable().BuildMockDbSet();
        sut = new PersonRepository(persons);
    }

    [Fact]
    public async void GetAsync_ReturnsResonable() {
        //Arrange
        //Todo: Fix a dataset to test on instead of "Fact"
        //Act
        var response = await sut.GetAsync("first", "");

        //Assert
        Assert.NotNull(response);
    }
}
