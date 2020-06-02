using Xunit;
using Quinlan.Data.Services;

namespace Quinlan.Data.Test.CodeServices
{
    public class CollectibleStatusCodeServiceTests : ICodeServiceTests
    {
        [Fact]
        public void Select_Succeeds()
        {
            // Run the test
            var collectibleStatuses = CollectibleStatusCodeService.Select();


            // Verify results match expected results
            Assert.NotNull(collectibleStatuses);
            Assert.True(collectibleStatuses.Count > 0);
        }
        [Fact]
        public void Select_WithValidId_Succeeds()
        {
            int availableId = CollectibleStatusCodeService.Available.Id;

            // Run test
            var collectibleStatus = CollectibleStatusCodeService.Select(availableId);

            // Verify that card was returned
            Assert.NotNull(collectibleStatus);
            Assert.Equal(collectibleStatus.Id, availableId);
        }
        [Fact]
        public void Select_WithInvalidId_Fails()
        {
            try
            {
                int invalidCollectibleStatusId = CollectibleStatusCodeService.Select().Count + 1;

                // Run test
                var collectibleStatus = CollectibleStatusCodeService.Select(invalidCollectibleStatusId);

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
