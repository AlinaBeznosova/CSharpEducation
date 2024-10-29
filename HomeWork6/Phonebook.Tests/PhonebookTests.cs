using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace Phonebook.Tests
{
  public class PhonebookTests
  {
    private Phonebook phonebook;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
      this.phonebook = new Phonebook();
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
      this.phonebook = null;
    }

    [TearDown]
    public void TearDown()
    {
      this.phonebook.ClearPhonebookList();
    }

    [Test]
    public void GetSubscriber_WithEmptyId_ThrowsException()
    {
      Guid guid = Guid.Empty;

      Assert.Throws<ArgumentException>(() => this.phonebook.GetSubscriber(guid));
    }

    [TestCase("E8802627-1423-4039-A737-106831058315")]
    public void GetSubscriber_WithNotFoundId_ThrowsException(string id)
    {
      Guid guid = Guid.Parse(id);

      Assert.Throws<InvalidOperationException>(() => this.phonebook.GetSubscriber(guid));
    }

    [Test]
    public void GetAll_ReturnsAllAddedSubscribers_Successfully()
    {
      var expectedCount = 5;

      for (int i = 0; i < expectedCount; i++)
      {
        var subscriber = new Subscriber(Guid.NewGuid(), $"Name {i}", new List<PhoneNumber>());
        phonebook.AddSubscriber(subscriber);
      }

      var allSubscribers = phonebook.GetAll();

      Assert.That(expectedCount, Is.EqualTo(allSubscribers.Count()));
    }

    [TestCase("E8802627-1423-4039-A737-106831058313", "Alina")]
    public void AddSubscriber_AddedExisting_ThrowsException(string id, string name)
    {
      Guid guid = Guid.Parse(id);
      Subscriber subscriber = new Subscriber(guid,name, new List<PhoneNumber>());
      var expectedSubscriber = new Subscriber(guid, name, new List<PhoneNumber>());

      this.phonebook.AddSubscriber(expectedSubscriber);

      Assert.Throws<InvalidOperationException>(() =>  this.phonebook.AddSubscriber(expectedSubscriber));
    }

    [TestCase("E8802627-1423-4039-A737-106831058313", "Alina")]
    public void AddSubscriber_NewSubscriber_AddedSuccessfully(string id, string name)
    {
      Guid guid = Guid.Parse(id);
      var expectedSubscriber = new Subscriber(guid, name, new List<PhoneNumber>());

      this.phonebook.AddSubscriber(expectedSubscriber);

      Assert.That(this.phonebook.GetSubscriber(guid), Is.EqualTo(expectedSubscriber));
    }

    [Test]
    public void CreateSubscriber_WithEmptyId_ThrowsException()
    {
      Guid subscriberId = Guid.Empty;
      string subscriberName = "Alina";

      Assert.Throws<ArgumentException>(() => new Subscriber(subscriberId, subscriberName, new List<PhoneNumber>()));
    }

    [TestCase("+1 (123) 456-7890")]
    [TestCase("")]
    public void AddNumberToSubscriber_IdenticalOrEmptyNumbers_ThrowsException(string number)
    {
      string id = "2B16A89D-F1D3-4A0D-AE28-45CF0C83B18A";
      Guid subscriberId = Guid.Parse(id);
      string name = "Alina";
      var initialPhoneNumbers = new List<PhoneNumber>
        {
            new PhoneNumber("+1 (123) 456-7890",new PhoneNumberType())
        };
      var subscriber = new Subscriber(subscriberId, name , initialPhoneNumbers);
      phonebook.AddSubscriber(subscriber);

      var existingPhoneNumber = new PhoneNumber(number, new PhoneNumberType());

      Assert.Throws<ArgumentException>(() => phonebook.AddNumberToSubscriber(subscriber, existingPhoneNumber));
    }

    [TestCase("+7 (123) 456-1234")]
    [TestCase("+7 (999) 456-1234")]
    public void AddNumberToSubscriber_NewNumber_AddedSuccessfully(string number)
    {
      string id = "2B16A89D-F1D3-4A0D-AE28-45CF0C83B1AA";
      Guid subscriberId = Guid.Parse(id);
      var initialPhoneNumbers = new List<PhoneNumber>
        {
            new PhoneNumber("+1 (123) 456-7890",new PhoneNumberType())
        };
      var subscriber = new Subscriber(subscriberId,"Alina", initialPhoneNumbers);
      phonebook.AddSubscriber(subscriber);

      var newPhoneNumber = new PhoneNumber(number, new PhoneNumberType());

      phonebook.AddNumberToSubscriber(subscriber, newPhoneNumber);

      var updatedSubscriber = phonebook.GetSubscriber(subscriberId);
 
     Assert.That(updatedSubscriber.PhoneNumbers, Has.Member(newPhoneNumber));
    }

    [TestCase("Alena")]
    [TestCase("Sasha")]
    public void RenameSubscriber_NewName_Successfully(string newName)
    {
      string id = "2B16A89D-F1D3-4A0D-AE28-45CF0C83B18A";
      Guid subscriberId = Guid.Parse(id);
      string name = "Alina";
      
      Subscriber subscriber = new Subscriber(subscriberId, name, new List<PhoneNumber>());
      phonebook.AddSubscriber(subscriber);

      phonebook.RenameSubscriber(subscriber, newName);

      var updateSubscriber = phonebook.GetSubscriber(subscriberId);
      Assert.That(updateSubscriber.Name, Is.EqualTo(newName));
    }

    [TestCase("Alina")]
    [TestCase("")]
    public void RenameSubscriber_IdenticalOrEmptyName_ThrowsException(string newName)
    {
      string id = "2B16A89D-F1D3-4A0D-AE28-45CF0C83B18A";
      Guid subscriberId = Guid.Parse(id);
      string name = "Alina";

      Subscriber subscriber = new Subscriber(subscriberId, name, new List<PhoneNumber>());
      phonebook.AddSubscriber(subscriber);

      string id1 = "2B14A89D-F1D3-4A0D-AE28-45CF0C83B18A";
      Guid subscriberId1 = Guid.Parse(id1);
      string name1 = "Sasha";

      Subscriber subscriber1 = new Subscriber(subscriberId1, name1, new List<PhoneNumber>());

      Assert.Throws<ArgumentException>(() => phonebook.RenameSubscriber(subscriber, newName));
      Assert.Throws<ArgumentException>(() => phonebook.RenameSubscriber(subscriber1, newName));
    }

    [Test]
    public void UpdateSubscriber_NewSubscriber_Successfully()
    {
      string id1 = "FCA92915-B991-4310-B26C-A514AB81BB9C";
      string id2 = "B0417A6E-AF8F-4C9B-BB43-2AE65E194836";
      Guid guid1 = Guid.Parse(id1);
      Guid guid2 = Guid.Parse(id2);
      
      Subscriber oldSubscriber = new Subscriber(guid1, "Alina", new List<PhoneNumber>());
      Subscriber newSubscriber = new Subscriber( guid2, "Sasha", new List<PhoneNumber>());
      phonebook.AddSubscriber(oldSubscriber);
     
      phonebook.UpdateSubscriber(oldSubscriber, newSubscriber);

      var updateSubscriber = phonebook.GetSubscriber(guid2);

      Assert.That(newSubscriber, Is.EqualTo(updateSubscriber));
    }

    [Test]
    public void DeleteSubscriber_Delete_Successfully()
    {
      string id = "FCA92915-B991-4310-B26C-A514AB81BB9C";
      Guid guid = Guid.Parse(id);
      Subscriber subscriber = new Subscriber(guid, "Alina", new List<PhoneNumber>());
     
      phonebook.AddSubscriber(subscriber);

      phonebook.DeleteSubscriber(subscriber);

      var listSubscribers = phonebook.GetAll();

      Assert.That(listSubscribers, Does.Not.Contains(subscriber));
    }

    [Test]
    public void DeleteSubscriber_NotFoundSubscriber_ThrowException()
    {
      string id = "FCA92915-B991-4310-B26C-A514AB81BB9C";
      Guid guid = Guid.Parse(id);
      Subscriber subscriber = new Subscriber(guid, "Alina", new List<PhoneNumber>());

      Assert.Throws<ArgumentException>(() => phonebook.DeleteSubscriber(subscriber));
    }

    [Test]
    public void ClearPhonebookList_Clear_Successfully()
    {
      for (int i = 0; i < 5; i++)
      {
        var subscriber = new Subscriber(Guid.NewGuid(), $"Name {i}", new List<PhoneNumber>());
        phonebook.AddSubscriber(subscriber);
      }

      phonebook.ClearPhonebookList();

      Assert.That(phonebook.GetAll(), Is.Empty);
    }
  }
}
