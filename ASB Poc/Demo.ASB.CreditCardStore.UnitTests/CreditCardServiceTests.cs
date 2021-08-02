
using Moq;
using System;
using NUnit.Framework;
using System.Linq.Expressions;
using System.Threading.Tasks;

using Demo.ASB.CreditCardStore.Domain.Entities;
using Demo.ASB.CreditCardStore.Application.Services;
using Demo.ASB.CreditCardStore.Application.Interfaces;
using System.Collections.Generic;
using Demo.ASB.CreditCardStore.Application.Queries;

namespace Demo.ASB.CreditCardStore.UnitTests
{
    public class CreditCardServiceTests
    {
        private readonly CreditCardService _sut;
        private readonly Mock<ICreditCardRepository> _repo;

        public CreditCardServiceTests()
        {
            _repo = new Mock<ICreditCardRepository>();
            _sut = new CreditCardService(_repo.Object);
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task GetCreditCardById_ShouldReturnValidCreditCard_TestAsync()
        {
            var creditCard = 
                new CreditCard
                {
                    Id = Guid.Parse("bd54ab1c-adac-4e8c-b86b-1a5e4658541a"),
                    CreditCardNumber = "12341231231232",
                    CVC = "123",
                    ExpiryDate = new DateTime(2025, 11, 05),
                    CardHolderId = Guid.Parse("bd54ab1c-addd-4e8c-b86b-1a5e4658541a"),
                    CardHolder = new CardHolder { Id = Guid.Parse("bd54ab1c-addd-4e8c-b86b-1a5e4658541a"), CardHolderName = "Basit"}
                };

            _repo.Setup(s => s.GetByIdAsync(It.IsAny<Expression<Func<CreditCard, bool>>>())).ReturnsAsync(creditCard);
            var result = _sut.SearchCreditCardAsync(creditCard.Id).Result;

            Assert.AreEqual(creditCard.Id, result.Id);
            Assert.AreEqual(creditCard.CVC, result.CVC);
            Assert.AreEqual(2025, result.ExpiryDate.Year);
            Assert.AreEqual(11, result.ExpiryDate.Month);
            Assert.AreEqual(creditCard.CardHolderId, result.CardHolderId);
            Assert.AreEqual(creditCard.CardHolder.CardHolderName, result.CardHolder.CardHolderName);
        }

        [Test]
        public async Task CreateCreditCard_ShouldStoreCreditCard_TestAsync()
        {
            var creditCard = new CreditCard
            {
                Id = Guid.Parse("bd54ab1c-adac-4486-b86b-1a5e4658541a"),
                CreditCardNumber = "12341231231232",
                CVC = "123",
                ExpiryDate = new DateTime(2024, 10, 05),
                CardHolderId = Guid.Parse("bd54ab1c-addd-4e8c-b86b-1a5e4658541a"),
                CardHolder = new CardHolder { Id = Guid.Parse("bd54ab1c-addd-4e8c-b86b-1a5e4658541a"), CardHolderName = "Basit" }
            };

            _repo.Setup(s => s.Create(It.IsAny<CreditCard>()))
                .Returns(creditCard);

            var result = _sut.CreateCreditCard(creditCard);

            Assert.NotNull(result);
            Assert.AreEqual(creditCard.Id, result.Id);

        }

        [Test]
        public async Task GetAllCreditCards_ShouldReturnAllValidCreditCards_TestAsync()
        {
            var creditCards = new List<CreditCard>
            {
                new CreditCard
                {
                    Id = Guid.Parse("bd54ab1c-adac-4486-b86b-1a5e4658541a"),
                    CreditCardNumber = "4988721089897575",
                    CVC = "123",
                    ExpiryDate = new DateTime(2023, 10, 05),
                    CardHolderId = Guid.Parse("bd54ab1c-addd-4e8c-b86b-1a5e4658541a"),
                    CardHolder = new CardHolder { Id = Guid.Parse("bd54ab1c-addd-4e8c-b86b-1a5e4658541a"), CardHolderName = "Basit" }
                },
                new CreditCard
                {
                    Id = Guid.Parse("bd54ab1c-adac-4556-b86b-1a5e4658541a"),
                    CreditCardNumber = "4988721089899595",
                    CVC = "123",
                    ExpiryDate = new DateTime(2024, 10, 05),
                    CardHolderId = Guid.Parse("bd54ab1c-addd-4e8c-b86b-1a5e4658541a"),
                    CardHolder = new CardHolder { Id = Guid.Parse("bd54ab1c-addd-4e8c-b86b-1a5e4658541a"), CardHolderName = "Basit" }
                },
                new CreditCard
                {
                    Id = Guid.Parse("bd54ab1c-adac-4666-b86b-1a5e4658541a"),
                    CreditCardNumber = "4988721089893535",
                    CVC = "123",
                    ExpiryDate = new DateTime(2025, 10, 05),
                    CardHolderId = Guid.Parse("bd54ab1c-addd-4e8c-b86b-1a5e4658541a"),
                    CardHolder = new CardHolder { Id = Guid.Parse("bd54ab1c-addd-4e8c-b86b-1a5e4658541a"), CardHolderName = "Basit" }
                }
            };

            _repo.Setup(s => s.GetAllAsync(It.IsAny<GetAllCreditCardsQuery>()))
                .Returns(Task.FromResult(creditCards));

            var result = _sut.SearchCreditCardsAsync(new GetAllCreditCardsQuery()).Result;
            Assert.NotNull(result);
            Assert.AreEqual(3, result.Count);
        }
    }
}