using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository.Data;
using Repository.Models.Domain;
using System;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class BuyerFormDBTests
    {
        private DbContextOptions<AppDbContext> CreateInMemoryOptions()
        {
            return new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) 
                .Options;
        }

        [TestMethod]
        public void SaveAndCreateBuyerForm_OK()
        {
            // Arrange
            var options = CreateInMemoryOptions();
            using (var context = new AppDbContext(options))
            {
                var buyerForm = new BuyerForm
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Test",
                    LastName = "Test",
                    Email = "test@gmail.com",
                    Phone = "1234567890",
                    Address = "Lviv"
                };

                // Act
                context.BuyerForms.Add(buyerForm);
                context.SaveChanges();
            }

            // Assert
            using (var context = new AppDbContext(options))
            {
                var buyerForm = context.BuyerForms.FirstOrDefault();
                Assert.IsNotNull(buyerForm);
                Assert.AreEqual("Test", buyerForm.FirstName);
                Assert.AreEqual("Test", buyerForm.LastName);
                Assert.AreEqual("test@gmail.com", buyerForm.Email);
                Assert.AreEqual("1234567890", buyerForm.Phone);
                Assert.AreEqual("Lviv", buyerForm.Address);
            }
        }

    }
}
