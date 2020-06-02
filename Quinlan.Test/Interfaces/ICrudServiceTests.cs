using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quinlan.Domain.Test
{
    public interface ICrudServiceTests
    {
        public ServiceProvider BuildServiceProvider(string dbName);

        public void GetAll_Succeeds();

        public void Get_Succeeds();

        public void Get_WithInvalidId_Fails();

        public void Post_Succeeds();
        public void Put_Succeeds();
        public void Put_WithInvalidId_Fails();
        public void Delete_Succeeds();
        public void Delete_WithInvalidId_Fails();

    }
}
