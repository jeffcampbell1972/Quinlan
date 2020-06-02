using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quinlan.Data.Test
{
    public interface IDataServiceTests
    {
        public ServiceProvider BuildServiceProvider(string dbName);

        public void SelectAll_Succeeds();
        public void Select_Succeeds();
        public void Select_WithInvalidId_Fails();
        public void Insert_Succeeds();
        public void Update_Succeeds();
        public void Update_WithInvalidId_Fails();
        public void Delete_Succeeds();
        public void Delete_WithInvalidId_Fails();

    }
}
