using System;
using System.Collections.Generic;
using System.Text;

namespace Quinlan.Data.Test
{
    public interface IQueryServiceTests
    {
        public void Execute_WithSportFilter_Succeeds();
        public void Execute_WithLeagueFilter_Succeeds();
        public void Execute_WithTeamFilter_Succeeds();
        public void Execute_WithPersonFilter_Succeeds();
        public void Execute_WithCollegeFilter_Succeeds();
        public void Execute_WithNotableFilter_Succeeds();
        public void Execute_WithHeismanFilter_Succeeds();
        public void Execute_WithHOFFilter_Succeeds();
        public void Execute_WithGradedFilter_Succeeds();
        public void Execute_WithRCFilter_Succeeds();
        public void Execute_WithRelicFilter_Succeeds();
    }
}
