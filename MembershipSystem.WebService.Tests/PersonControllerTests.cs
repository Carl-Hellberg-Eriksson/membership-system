using FakeItEasy;
using MembershipSystem.Core.DatabaseEntities;
using MembershipSystem.Core.Interfaces;
using MembershipSystem.WebService.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace MembershipSystem.WebService.Tests;
public class PersonControllerTests {

    private readonly IPersonService fakePersonService;
    private readonly PersonController sut;
    private static IEnumerable<Person> emptyPersonList = new List<Person>();
    private static Person examplePerson = new Person {
        FirstName = "firstName",
        LastName = "lastName"
    };

    public PersonControllerTests() {
        fakePersonService = A.Fake<IPersonService>();
        sut = new PersonController(fakePersonService);
    }

    [Fact]
    public async void Get_Without_Parameters_ServiceReturnsNoError_ReturnsOKIEnumerablePersons() {
        //Arrange
        A.CallTo(() => fakePersonService.GetAllPersonsAsync()).Returns(emptyPersonList);
        //Act
        var response = (await sut.Get()).Result as OkObjectResult;
        //Assert
        var responseValue = response?.Value;
        Assert.NotNull(responseValue);
        Assert.Equal(emptyPersonList, responseValue);
    }

    [Fact]
    public async void Get_Without_Parameters_ServiceReturnsError_ReturnsError() {
        //Arrange
        A.CallTo(() => fakePersonService.GetAllPersonsAsync()).Throws<Exception>();
        //Act
        var response = (await sut.Get()).Result as ObjectResult;

        //Assert
        Assert.NotNull(response);
        Assert.Equal(500, response.StatusCode);
    }

    [Fact]
    public async void Get_Wit_Parameter_ServiceReturnsNoError_ReturnsOKPerson() {
        //Arrange
        var callingId = 3;
        int capturedId = 0;
        A.CallTo(() => fakePersonService.GetPersonByIdAsync(A<int>.Ignored))
            .Invokes((int Id) => capturedId = Id)
            .Returns(examplePerson);

        var response = (await sut.Get(callingId)).Result as OkObjectResult;
        //Assert
        var responseValue = response?.Value;
        Assert.NotNull(responseValue);
        Assert.Equal(examplePerson, responseValue);
        Assert.Equal(callingId, capturedId);
    }

    [Fact]
    public async void Get_With_Parameter_ServiceReturnsError_ReturnsError() {
        //Arrange
        var callingId = 3;
        int capturedId = 0;
        A.CallTo(() => fakePersonService.GetPersonByIdAsync(A<int>.Ignored))
            .Invokes((int Id) => capturedId = Id)
            .Throws<Exception>();
        //Act
        var response = (await sut.Get(callingId)).Result as ObjectResult;

        //Assert
        Assert.NotNull(response);
        Assert.Equal(500, response.StatusCode);
        Assert.Equal(callingId, capturedId);
    }

    [Fact]
    public async void Post_ServiceReturnsNoError_ReturnsOK() {
        //Arrange
        Person capturedPerson = new Person();
        A.CallTo(() => fakePersonService.AddPersonAsync(A<Person>.Ignored))
            .Invokes((Person p) => capturedPerson = p);

        //Act
        var response = (await sut.Post(examplePerson)) as OkResult;

        //Assert
        Assert.NotNull(response);
        Assert.Equal(200, response.StatusCode);
        Assert.Equal(capturedPerson, examplePerson);
    }

    [Fact]
    public async void Post_ServiceReturnsError_ReturnsError() {
        //Arrange
        Person capturedPerson = new Person();
        A.CallTo(() => fakePersonService.AddPersonAsync(A<Person>.Ignored))
            .Invokes((Person p) => capturedPerson = p)
            .Throws<Exception>();

        //Act
        var response = (await sut.Post(examplePerson)) as ObjectResult;

        //Assert
        Assert.NotNull(response);
        Assert.Equal(500, response.StatusCode);
        Assert.Equal(capturedPerson, examplePerson);
    }

    [Fact]
    public async void Put_ServiceReturnsNoError_ReturnsOK() {
        //Arrange
        Person capturedPerson = new Person();
        A.CallTo(() => fakePersonService.UpdatePersonAsync(A<Person>.Ignored))
            .Invokes((Person p) => capturedPerson = p);

        //Act
        var response = (await sut.Put(examplePerson)) as OkResult;

        //Assert
        Assert.NotNull(response);
        Assert.Equal(200, response.StatusCode);
        Assert.Equal(capturedPerson, examplePerson);
    }

    [Fact]
    public async void Put_ServiceReturnsError_ReturnsError() {
        //Arrange
        Person capturedPerson = new Person();
        A.CallTo(() => fakePersonService.UpdatePersonAsync(A<Person>.Ignored))
            .Invokes((Person p) => capturedPerson = p)
            .Throws<Exception>();

        //Act
        var response = (await sut.Put(examplePerson)) as ObjectResult;

        //Assert
        Assert.NotNull(response);
        Assert.Equal(500, response.StatusCode);
        Assert.Equal(capturedPerson, examplePerson);
    }

    [Fact]
    public async void Delete_ServiceReturnsNoError_ReturnsOK() {
        //Arrange
        var callingId = 3;
        int capturedId = 0;
        A.CallTo(() => fakePersonService.DeletePersonAsync(A<int>.Ignored))
            .Invokes((int id) => capturedId = id);

        //Act
        var response = (await sut.Delete(callingId)) as OkResult;

        //Assert
        Assert.NotNull(response);
        Assert.Equal(200, response.StatusCode);
        Assert.Equal(callingId, capturedId);
    }

    [Fact]
    public async void Delete_ServiceReturnsError_ReturnsError() {
        //Arrange
        var callingId = 3;
        int capturedId = 0;
        A.CallTo(() => fakePersonService.DeletePersonAsync(A<int>.Ignored))
            .Invokes((int id) => capturedId = id)
            .Throws<Exception>();

        //Act
        var response = (await sut.Delete(callingId)) as ObjectResult;

        //Assert
        Assert.NotNull(response);
        Assert.Equal(500, response.StatusCode);
        Assert.Equal(callingId, capturedId);
    }
}
