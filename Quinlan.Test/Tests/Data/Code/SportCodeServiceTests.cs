using Xunit;
using Quinlan.Data.Services;

namespace Quinlan.Data.Test.CodeServices
{
    public class SportCodeServiceTests : ICodeServiceTests
    {
        [Fact]
        public void Select_Succeeds()
        {
            // Run the test
            var sports = SportCodeService.Select();


            // Verify results match expected results
            Assert.NotNull(sports);
            Assert.True(sports.Count > 0);
        }
        [Fact]
        public void Select_WithValidId_Succeeds()
        {
            int footballId = SportCodeService.Football.Id;

            // Run test
            var sport = SportCodeService.Select(footballId);

            // Verify that card was returned
            Assert.NotNull(sport);
            Assert.Equal(sport.Id, footballId);
        }
        [Fact]
        public void Select_WithInvalidId_Fails()
        {
            try
            {
                int invalidSportId = SportCodeService.Select().Count + 1;

                // Run test
                var sport = SportCodeService.Select(invalidSportId);

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
