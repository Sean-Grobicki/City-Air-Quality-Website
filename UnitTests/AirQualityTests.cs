using NUnit.Framework;
using Dept_Test.Controllers;
using Dept_Test.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;


namespace UnitTests
{
    public class AirQualityTests
    {

        public AirQualityTests()
        {
            Environment.SetEnvironmentVariable("SERVER_ADDRESS", $"https://u50g7n0cbj.execute-api.us-east-1.amazonaws.com");
        }


        [Test]
        // Tests that when the Index method is called the index view is returned.
        public void IndexViewTest()
        {
            var controller = new HomeController();
            var result = controller.Index() as ViewResult;
            Assert.AreEqual(null, result.ViewName);
        }

        [Test]
        // Tests that when a valid result is searched the search view is returned.
        public async Task SearchViewTest()
        {
            LatestResult sp = new LatestResult();
            
            sp.cityName = "Aberdeen";
            var controller = new HomeController();
            var result = await controller.Search(sp) as ViewResult;
            Assert.AreEqual("Search", result.ViewName);
        }

        [Test]
        // Tests that when the search paramter is empty that the error view will be returned.
        public async Task EmptyErrorViewTest()
        {
            LatestResult sp = new LatestResult();
            sp.cityName = "";
            var controller = new HomeController();
            var result = await controller.Search(sp) as ViewResult;
            Assert.AreEqual("Error", result.ViewName);
        }

        [Test]
        // Tests that a non valid city name returns error view
        public async Task WrongErrorViewTest()
        {
            LatestResult sp = new LatestResult();
            sp.cityName = "Aber";
            var controller = new HomeController();
            var result = await controller.Search(sp) as ViewResult;
            Assert.AreEqual("Error", result.ViewName);
        }


        [Test]
        // Tests search params with 1 letter returns error view
        public async Task OneLetterErrorViewTest()
        {
            LatestResult sp = new LatestResult();
            sp.cityName = "A";
            var controller = new HomeController();
            var result = await controller.Search(sp) as ViewResult;
            Assert.AreEqual("Error", result.ViewName);
        }


        [Test]
        // Test the search param with all capital letters will return search view
        public async Task CapitalSearchViewTest()
        {
            LatestResult sp = new LatestResult();
            sp.cityName = "MANCHESTER";
            var controller = new HomeController();
            var result = await controller.Search(sp) as ViewResult;
            Assert.AreEqual("Search", result.ViewName);
        }


        [Test]
        // Test the search param with all lowercase letters will return search view
        public async Task LowerSearchViewTest()
        {
            LatestResult sp = new LatestResult();
            sp.cityName = "boston";
            var controller = new HomeController();
            var result = await controller.Search(sp) as ViewResult;
            Assert.AreEqual("Search", result.ViewName);
        }

        [Test]
        // Test search param with all lowercase on two word cityto check it  returns results.
        public async Task TwoWordLowerSearchViewTest()
        {
            LatestResult sp = new LatestResult();
            sp.cityName = "abu dhabi";
            var controller = new HomeController();
            var result = await controller.Search(sp) as ViewResult;
            Assert.AreEqual("Search", result.ViewName);
        }


        [Test]
        // Test search parma with all capitalised on two word city to check it returns results.
        public async Task TwoWordUpperSearchViewTest()
        {
            LatestResult sp = new LatestResult();
            sp.cityName = "ABU DHABI";
            var controller = new HomeController();
            var result = await controller.Search(sp) as ViewResult;
            Assert.AreEqual("Search", result.ViewName);
        }

        [Test]
        // Test search param when it is null to check it returns error view.
        public async Task NullErrorViewTest()
        {
            LatestResult sp = new LatestResult();
            sp.cityName = null;
            var controller = new HomeController();
            var result = await controller.Search(sp) as ViewResult;
            Assert.AreEqual("Error", result.ViewName);
        }
    }
}