using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository.Data;
using Repository.Models.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class BuyerFormValidationTests
    {
        private List<ValidationResult> ValidateModel(object model)
        {
            var context = new ValidationContext(model, null, null);
            var results = new List<ValidationResult>();
            Validator.TryValidateObject(model, context, results, true);
            return results;
        }

        [TestMethod]
        public void ValidBuyerForm_Ok()
        {
            // Arrange
            var buyerForm = new BuyerForm
            {
                Id = Guid.NewGuid(),
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                Phone = "1234567890",
                Address = "123 Main St"
            };

            // Act
            var validationResults = ValidateModel(buyerForm);

            // Assert
            Assert.AreEqual(0, validationResults.Count, "Validation failed for a valid model.");
        }

        [TestMethod]
        public void InvalidEmail_Fail()
        {
            // Arrange
            var buyerForm = new BuyerForm
            {
                Id = Guid.NewGuid(),
                FirstName = "John",
                LastName = "Doe",
                Email = "invalid-email",
                Phone = "1234567890",
                Address = "123 Main St"
            };

            // Act
            var validationResults = ValidateModel(buyerForm);

            // Assert
            Assert.IsTrue(validationResults.Any(v => v.MemberNames.Contains("Email")), "Invalid email passed validation.");
        }

        [TestMethod]
        public void InvalidPhone_Fail()
        {
            // Arrange
            var buyerForm = new BuyerForm
            {
                Id = Guid.NewGuid(),
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                Phone = "12345", 
                Address = "123 Main St"
            };

            // Act
            var validationResults = ValidateModel(buyerForm);

            // Assert
            Assert.IsTrue(validationResults.Any(v => v.MemberNames.Contains("Phone")), "Invalid phone number passed validation.");
        }
    }
}