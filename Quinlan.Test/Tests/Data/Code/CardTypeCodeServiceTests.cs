using Xunit;
using Quinlan.Data.Services;

namespace Quinlan.Data.Test.CodeServices
{
    public class CardTypeCodeServiceTests : ICodeServiceTests
    {
        [Fact]
        public void Select_Succeeds()
        {
            // Run the test
            var cardTypes = CardTypeCodeService.Select();


            // Verify results match expected results
            Assert.NotNull(cardTypes);
            Assert.True(cardTypes.Count > 0);
        }
        [Fact]
        public void Select_WithValidId_Succeeds()
        {
            int playerId = CardTypeCodeService.Player.Id;

            // Run test
            var cardType = CardTypeCodeService.Select(playerId);

            // Verify that card was returned
            Assert.NotNull(cardType);
            Assert.Equal(cardType.Id, playerId);
        }
        [Fact]
        public void Select_WithInvalidId_Fails()
        {
            try
            {
                int invalidCardTypeId = CardTypeCodeService.Select().Count + 1;

                // Run test
                var cardType = CardTypeCodeService.Select(invalidCardTypeId);

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
