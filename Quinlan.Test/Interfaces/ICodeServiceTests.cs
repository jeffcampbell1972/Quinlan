using System;
using System.Collections.Generic;
using System.Text;

namespace Quinlan.Data.Test
{
    public interface ICodeServiceTests
    {
        public void Select_Succeeds();
        public void Select_WithValidId_Succeeds();
        public void Select_WithInvalidId_Fails();
    }
}
