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

        private Guid ShouldBeAbleToAddTestUser(int previousCount)
        {
            var newPerson = new Person
            {
                FirstName = "Test",
                LastName = "User"
            };
            AddTestPhoneNumbers(newPerson);
            AddTestAddresses(newPerson);
            var newId = _repository.AddPerson(newPerson);
            var count = _repository.GetCountOfAll();
            Assert.AreNotEqual(Guid.Empty, newId);
            Assert.AreEqual(previousCount + 1, count);
            return newId;
        }

        private static void AddTestPhoneNumbers(Person newPerson)
        {
            var newHomePhone = new Phone
                                   {
                                       PhoneNumber = "5551212",
                                       Type = PhoneType.Home
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
        }

        private static void AddTestAddresses(Person newPerson)
        {
            var newAddress = new Address
            {
                City = "testCity",
                PostalCode = "99999",
                State = "OH",
                StreetAddress = "555 anyplace lane",
                Type = AddressType.Mailing
            };
            newPerson.Addresses.Add(newAddress);
        }

        private void ShouldBeAbleToGetTestPerson(Guid newId)
        {
            var person = _repository.GetPerson(newId);
            Assert.AreEqual(newId,  person.Id);
            Assert.AreEqual("Test", person.FirstName);
            Assert.AreEqual("User", person.LastName);
            TestPhonesWereAddedSuccessfully(person);
            TestAddressesWereAddedSuccessfully(person);
        }

        private static void TestPhonesWereAddedSuccessfully(Person person)
        {
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

        private static void TestAddressesWereAddedSuccessfully(Person person)
        {
            Assert.AreEqual(1, person.Addresses.Count);
            var address = person.Addresses[0];
            Assert.AreEqual("testCity", address.City);
            Assert.AreEqual("99999", address.PostalCode);
            Assert.AreEqual("OH", address.State);
            Assert.AreEqual("555 anyplace lane", address.StreetAddress);
            Assert.AreEqual(AddressType.Mailing.Id, address.Type.Id);
        }

        private void ShouldBeAbleToUpdatePerson(Guid personId)
        {
            var person = _repository.GetPerson(personId);
            person.FirstName = "NewFirstName";
            person.LastName = "NewLastName";
            _repository.UpdatePerson(person);
        }


        private void ShouldBeAbleToGetPersonsAndCountOfPersons(int expectedCount)
        {
            var persons = _repository.GetAll();
            Assert.AreEqual(expectedCount, persons.Count);
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
    }
}
