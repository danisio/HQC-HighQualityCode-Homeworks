namespace Cars.Tests.JustMock
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Cars.Contracts;
    using Cars.Controllers;
    using Cars.Models;
    using Cars.Tests.JustMock.Mocks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CarsControllerTests
    {
        private readonly ICarsRepository carsData;
        private CarsController controller;

        public CarsControllerTests()
            : this(new MoqCarsRepository())
        {
        }

        public CarsControllerTests(ICarsRepositoryMock carsDataMock)
        {
            this.carsData = carsDataMock.CarsData;
        }

        [TestInitialize]
        public void CreateController()
        {
            this.controller = new CarsController(this.carsData);
        }

        //// Demo Tests
        [TestMethod]
        public void IndexShouldReturnAllCars()
        {
            var model = (ICollection<Car>)this.GetModel(() => this.controller.Index());

            Assert.AreEqual(4, model.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarIsNull()
        {
            var model = (Car)this.GetModel(() => this.controller.Add(null));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarMakeIsNull()
        {
            var car = new Car
            {
                Id = 15,
                Make = string.Empty,
                Model = "330d",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddingCarShouldThrowArgumentNullExceptionIfCarModelIsNull()
        {
            var car = new Car
            {
                Id = 15,
                Make = "BMW",
                Model = string.Empty,
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));
        }

        [TestMethod]
        public void AddingCarShouldReturnADetail()
        {
            var car = new Car
            {
                Id = 15,
                Make = "BMW",
                Model = "330d",
                Year = 2014
            };

            var model = (Car)this.GetModel(() => this.controller.Add(car));

            Assert.AreEqual(1, model.Id);
            Assert.AreEqual("Audi", model.Make);
            Assert.AreEqual("A5", model.Model);
            Assert.AreEqual(2005, model.Year);
        }
        //// End of Demo tests

        [TestMethod]
        public void GettingDetailsShouldReturnProperCarWhenIdIsValid()
        {
            var matchedCar = (Car)this.GetModel(() => this.controller.Details(1));
            Assert.AreEqual("Audi", matchedCar.Make);
            Assert.AreEqual("A5", matchedCar.Model);
            Assert.AreEqual(2005, matchedCar.Year);
        }

        [TestMethod]
        public void GettingDetailShouldReturnFirstCarIfIdIsMisssing()
        {
            var matchedCar = (Car)this.GetModel(() => this.controller.Details(9));
            Assert.AreEqual(1, matchedCar.Id);
            Assert.AreEqual("Audi", matchedCar.Make);
            Assert.AreEqual("A5", matchedCar.Model);
            Assert.AreEqual(2005, matchedCar.Year);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void GettingCarByIdShouldThrowArgumentNullExceptionIfCarIsNull()
        {
            var nullCar = new Car();
            nullCar = null;

            var model = (Car)this.GetModel(() => this.controller.Details(nullCar.Id));
            Console.WriteLine(model.Id);
        }

        [TestMethod]
        public void SearchingShouldAlwaysReturnListOf2Cars()
        {
            var model = (ICollection<Car>)this.GetModel(() => this.controller.Search("Opel"));

            Assert.AreEqual(2, model.Count);
        }

        [TestMethod]
        public void SearchingShouldAlwaysReturnBmwCars()
        {
            var model = (ICollection<Car>)this.GetModel(() => this.controller.Search("Audi"));

            Assert.AreEqual("BMW", model.FirstOrDefault().Make);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SortingShouldThrowWhenParameterIsInvalid()
        {
            var model = (ICollection<Car>)this.GetModel(() => this.controller.Sort("invalid"));
        }

        [TestMethod]
        public void SortingShouldReturnCorrectListWhenSortByMake()
        {
            var model = (ICollection<Car>)this.GetModel(() => this.controller.Sort("make"));

            Assert.AreEqual("Audi", model.FirstOrDefault().Make);
            Assert.AreEqual("Opel", model.LastOrDefault().Make);
        }  
        
        [TestMethod]
        public void SortingShouldReturnCorrectListWhenSortByYear()
        {
            var model = (ICollection<Car>)this.GetModel(() => this.controller.Sort("year"));

            Assert.AreEqual(2005, model.FirstOrDefault().Year);
            Assert.AreEqual(2010, model.LastOrDefault().Year);
        }

         private object GetModel(Func<IView> funcView)
        {
            var view = funcView();
            return view.Model;
        }
    }
}
