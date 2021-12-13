using Benefits.Api.Validators;
using Xunit;

namespace BenefitsTest
{
    public class EnrolleeDtoValidatorTest
    {
        [Fact]
        public void PrimaryNonDiscountRate()
        {
            //Arange 
            string firstName = "Dane";
            decimal primaryRate = 1000.00M;

            //Action
            var result = EnrolleeDtoValidator.CalculateRate(primaryRate, firstName);

            //Expected result: 38.46 = 1000 / 26

            Assert.Equal(38.46M, result);
        }

        [Fact]
        public void PrimaryDiscountRate()
        {
            //Arange 
            string firstName = "Alex";
            decimal primaryRate = 1000.00M;

            //Action
            var result = EnrolleeDtoValidator.CalculateRate(primaryRate, firstName);

            //Expected result: 34.62 = (1000 / 26) * .9

            Assert.Equal(34.62M, result);
        }

        [Fact]
        public void DependantNonDiscountRate()
        {
            //Arange 
            string firstName = "Dane";
            decimal dependantRate = 500.00M;

            //Action
            var result = EnrolleeDtoValidator.CalculateRate(dependantRate, firstName);

            //Expected result: 19.23 = 500 / 26
            Assert.Equal(19.23M, result);
        }

        [Fact]
        public void DependantDiscountRate()
        {
            //Arange 
            string firstName = "A-Aron";
            decimal dependantRate = 500.00M;

            //Action
            var result = EnrolleeDtoValidator.CalculateRate(dependantRate, firstName);

            //Expected result: 17.31 = (500 / 26) * .9
            Assert.Equal(17.31M, result);
        }
    }
}