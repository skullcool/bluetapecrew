﻿using System.Threading.Tasks;
using BlueTapeCrew.Models.Entities;
using BlueTapeCrew.Services;
using BlueTapeCrew.Services.Interfaces;
using Moq;
using Xunit;

namespace BlueTapeCrew.Tests.Unit
{

    public class ShippingServiceTests
    {
        private readonly Mock<ISiteSettingsService> _siteSettingsService = new Mock<ISiteSettingsService>();

        public ShippingServiceTests()
        {
            _siteSettingsService.Setup(x => x.Get()).Returns(Task.FromResult(new SiteSetting
            {
                FreeShippingThreshold = 5.00m,
                FlatShippingRate = 19.99m
            }));
        }

        [Fact]
        public async Task Calculate_Returns_FreeShipping_If_EqualToShippingThreshold()
        {
            //arrange
            var sut = new ShippingService(_siteSettingsService.Object);

            //act
            var actual = await sut.Caclulate(5.00m);

            //assert
            Assert.Equal(0.00m, actual);
        }

        [Fact]
        public async Task Calculate_Returns_FlatShipping_LessThanShippingThreshold()
        {
            //arrange
            var sut = new ShippingService(_siteSettingsService.Object);

            //act
            var actual = await sut.Caclulate(4.99m);

            //assert
            Assert.Equal(19.99m, actual);
        }

        [Fact]
        public async Task Calculate_Returns_FreeShipping_GreaterThanShippingThreshold()
        {
            //arrange
            var sut = new ShippingService(_siteSettingsService.Object);

            //act
            var actual = await sut.Caclulate(5.01m);

            //assert
            Assert.Equal(0.00m, actual);
        }

        [Fact]
        public async Task Calculate_Returns_FreeShipping_Given_ZeroSubtotal()
        {
            //arrange
            var sut = new ShippingService(_siteSettingsService.Object);

            //act
            var actual = await sut.Caclulate(0.00m);

            //assert
            Assert.Equal(0.00m, actual);
        }
    }
}
