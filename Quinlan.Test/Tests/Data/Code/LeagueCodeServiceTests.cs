using Xunit;
using Quinlan.Data.Services;

namespace Quinlan.Data.Test.CodeServices
{
    public class LeagueCodeServiceTests : ICodeServiceTests
    {
        [Fact]
        public void Select_Succeeds()
        {
            // Run the test
            var leagues = LeagueCodeService.Select();


            // Verify results match expected results
            Assert.NotNull(leagues);
            Assert.True(leagues.Count > 0);
        }
        [Fact]
        public void Select_WithValidId_Succeeds()
        {
            int nflId = LeagueCodeService.NFL.Id;

            // Run test
            var league = LeagueCodeService.Select(nflId);

            // Verify that card was returned
            Assert.NotNull(league);
            Assert.Equal(league.Id, nflId);
        }
        [Fact]
        public void Select_WithInvalidId_Fails()
        {
            try
            {
                int invalidLeagueId = LeagueCodeService.Select().Count + 1;

                // Run test
                var league = LeagueCodeService.Select(invalidLeagueId);

                // Fail test if exception is not thrown
                Assert.Equal(1,0);
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
