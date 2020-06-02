using Xunit;
using Quinlan.Data.Services;

namespace Quinlan.Data.Test.CodeServices
{
    public class CollectibleTypeCodeServiceTests : ICodeServiceTests
    {
        [Fact]
        public void Select_Succeeds()
        {
            // Run the test
            var collectibleTypes = CollectibleTypeCodeService.Select();


            // Verify results match expected results
            Assert.NotNull(collectibleTypes);
            Assert.True(collectibleTypes.Count > 0);
        }
        [Fact]
        public void Select_WithValidId_Succeeds()
        {
            int cardId = CollectibleTypeCodeService.Card.Id;

            // Run test
            var collectibleType = CollectibleTypeCodeService.Select(cardId);

            // Verify that card was returned
            Assert.NotNull(collectibleType);
            Assert.Equal(collectibleType.Id, cardId);
        }
        [Fact]
        public void Select_WithInvalidId_Fails()
        {
            try
            {
                int invalidCollectibleTypeId = CollectibleTypeCodeService.Select().Count + 1;

                // Run test
                var collectibleType = CollectibleTypeCodeService.Select(invalidCollectibleTypeId);

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
