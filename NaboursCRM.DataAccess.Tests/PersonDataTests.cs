using System;
using NaboursCRM.Model;
using NUnit.Framework;

namespace NaboursCRM.DataAccess.Tests
{
    [TestFixture]
    public class PersonDataTests
    {
        PersonData _repository;

        [SetUp]
        public void Setup()
        {
            _repository = new PersonData();
        }

        [Test]
        public void ShouldBeAbleToAddRetrieveUpdateAndDeletePersonData()
        {
            var count = _repository.GetCountOfAll();
            var addedId = ShouldBeAbleToAddTestUser(count);
            _repository.RenewSession();
            ShouldBeAbleToGetPersonsAndCountOfPersons(count + 1);
            ShouldBeAbleToGetTestPerson(addedId);
            ShouldBeAbleToUpdatePerson(addedId);
            ShouldBeAbleToGetUpdatedPerson(addedId);
            ShouldBeAbleToDeleteTestPerson(addedId);
            var endCount = _repository.GetCountOfAll();
            Assert.AreEqual(count, endCount);
        }

        private void ShouldBeAbleToGetUpdatedPerson(Guid personId)
        {
            var person = _repository.GetPerson(personId);
            Assert.AreEqual(personId, person.Id);
            Assert.AreEqual("NewFirstName", person.FirstName);
            Assert.AreEqual("NewLastName", person.LastName);
        }

        private void ShouldBeAbleToDeleteTestPerson(Guid idToDelete)
        {
            _repository.DeletePerson(idToDelete);
        }

        private void ShouldBeAbleToUpdatePerson(Guid personId)
        {
            var person = _repository.GetPerson(personId);
            person.FirstName = "NewFirstName";
            person.LastName = "NewLastName";
            _repository.UpdatePerson(person);
        }

        private void ShouldBeAbleToGetTestPerson(Guid newId)
        {
            var person = _repository.GetPerson(newId);
            Assert.AreEqual(newId,  person.Id);
            Assert.AreEqual("Test", person.FirstName);
            Assert.AreEqual("User", person.LastName);
            Assert.AreEqual(3, person.PhoneNumbers.Count);
            var typeCount = new int[3];
            foreach (var phone in person.PhoneNumbers)
            {
                Assert.AreEqual("5551212", phone.PhoneNumber);
                typeCount[phone.Type.Id - 1]++;
            }
            foreach (var count in typeCount)
            {
                Assert.AreEqual(1, count);
            }

        }

        private Guid ShouldBeAbleToAddTestUser(int previousCount)
        {
            var newPerson = new Person
                                {
                                    FirstName = "Test",
                                    LastName = "User"
                                };
            var newHomePhone = new Phone
                               {
                                   PhoneNumber = "5551212", Type = PhoneType.Home
                               };
            var newWorkPhone = new Phone
            {
                PhoneNumber = "5551212",
                Type = PhoneType.Work
            };
            var newCellPhone = new Phone
            {
                PhoneNumber = "5551212",
                Type = PhoneType.Cell
            };



            newPerson.PhoneNumbers.Add(newHomePhone);
            newPerson.PhoneNumbers.Add(newWorkPhone);
            newPerson.PhoneNumbers.Add(newCellPhone);
            var newId = _repository.AddPerson(newPerson);
            var count = _repository.GetCountOfAll();
            Assert.AreEqual(previousCount + 1, count);
            return newId;
        }

        private void ShouldBeAbleToGetPersonsAndCountOfPersons(int expectedCount)
        {
            var persons = _repository.GetAll();
            Assert.AreEqual(expectedCount, persons.Count);
        }

    }
}
