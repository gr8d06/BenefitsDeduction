using Microsoft.VisualStudio.TestTools.UnitTesting;
using Benefits.Api.Controllers;
using Benefits.Api.Interfaces;
using Benefits.Api.Models;
using Benefits.Api.Validators;

namespace Benefits.Api.Test
{
    [TestClass]
    public class DtoValidatorTest
    {
       [TestMethod]
       void ShouldReturnPrimaryRateWithoutDiscount()
        {
            //Arange 
            string firstName = "Bryce";
            decimal primaryRate = 1000.00M;

            //Action
            var result = EnrolleeDtoValidator.CalculateRate(primaryRate, firstName);

            //Expected result: 38.46 = 1000 / 26
            //Assert
            Assert.Equals(result, 38.46M);
        }
    }
}