using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook.Tests
{
  public class PhoneNumberValidatorTests
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

    [TestCase("+7 (123) 456-1234")]
    [TestCase("+7 (999) 456-1234")]
    public void Validate_ValidNumber_DoseNotThrowsException(string number)
    {
      var phoneNumber = new PhoneNumber(number, new PhoneNumberType());

      Assert.DoesNotThrow(() => PhoneNumberValidator.Validate(phoneNumber));
    }

    [TestCase("(123) 456-1234")]
    [TestCase("456-1234")]
    [TestCase("")]
    public void Validate_InValidNumber_ThrowsException(string number)
    {
      var phoneNumber = new PhoneNumber(number, new PhoneNumberType());

      Assert.Throws<ArgumentException>(() => PhoneNumberValidator.Validate(phoneNumber));
    }
  }
}
