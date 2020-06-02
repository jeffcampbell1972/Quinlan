using Xunit;
using Quinlan.Data.Services;

namespace Quinlan.Data.Test.CodeServices
{
    public class ProductStatusCodeServiceTests : ICodeServiceTests
    {
        [Fact]
        public void Select_Succeeds()
        {
            // Run the test
            var productStatuses = ProductStatusCodeService.Select();


            // Verify results match expected results
            Assert.NotNull(productStatuses);
            Assert.True(productStatuses.Count > 0);
        }
        [Fact]
        public void Select_WithValidId_Succeeds()
        {
            int forSaleId = ProductStatusCodeService.ForSale.Id;

            // Run test
            var productStatus = ProductStatusCodeService.Select(forSaleId);

            // Verify that card was returned
            Assert.NotNull(productStatus);
            Assert.Equal(productStatus.Id, forSaleId);
        }
        [Fact]
        public void Select_WithInvalidId_Fails()
        {
            try
            {
                int invalidProductStatusId = ProductStatusCodeService.Select().Count + 1;

                // Run test
                var productStatus = ProductStatusCodeService.Select(invalidProductStatusId);

                // Fail test if exception is not thrown
                Assert.Equal(1, 0);
            }
            catch (InvalidIdException invalidIdException)
            {
                Assert.NotNull(invalidIdException);
            }
            catch
            {
                // Fail test if expected exception not thrown
                Assert.Equal(1, 0);
            }

        }

    }

}
