using AutoFixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using UnitTestingExample.Controllers;
using UnitTestingExample.Models;
using UnitTestingExample.Repository.IRepository;
using Assert = Xunit.Assert;

namespace UnitTestingExampleTest
{
    [TestClass]
    public class PersonTest
    {
        Mock<IPersonRepository> _personRepositoryMock = new Mock<IPersonRepository>();

        [Fact]
        public void PersonDataTest()
        {
            var fixture = new Fixture();
            fixture.RepeatCount = 1;
            var personFixture = fixture.CreateMany<Person>();

            var person = personFixture.Single();
            var expectedResult = new List<Person>();
            expectedResult.Add(person);

            Assert.Equal(expectedResult, personFixture);
        }

        [Fact]
        public async void PersonDataInsertAsyncTest()
        {
            var fixture = new Fixture();
            fixture.RepeatCount = 1;
            var personFixture = fixture.Create<Person>();
            var personListFixture = fixture.CreateMany<Person>();

            _personRepositoryMock.Setup(x => x.AddPersonAsync(It.IsAny<Person>())).Returns(Task.FromResult(personFixture));

            PersonController personController = new PersonController(_personRepositoryMock.Object);
            var result = personController.Create(personFixture).Result;

            Assert.NotNull(result);
        }

        [Theory]
        [InlineData("", 1)]
        public void PersonDataFail(string name, int age)
        {
            var fixture = new Fixture();

            var personFixture = fixture.CreateMany<Person>();

            var person = new Person
            {
                Id = Guid.NewGuid(),
                Age = 1,
                Name = "Teste"

            };

            var personList = new List<Person>();
            personList.Add(person);

            Assert.Equal(personFixture, personList);
        }
    }
}
