﻿using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using IntegrationTest.Infrastructure;
using Vuew;
using Vuew.ViewModels;
using Xunit;

namespace IntegrationTest.Controllers.Hotels
{
    public class GetHotels : TestBase
    {
        public GetHotels(TestFixture<Startup> fixture) : base(fixture) { }

        [Fact]
        public async Task Can_Get_Hotels()
        {
            // Action
            const string url = "api/hotels";
            var response = await Server.CreateRequest(url)
               .GetAsync();

            var values = await response.Content.ReadAsAsync<HotelViewModel[]>();

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            values.Length.Should().BeGreaterThan(0);
        }
    }
}
