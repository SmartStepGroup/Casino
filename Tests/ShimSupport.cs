using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.QualityTools.Testing.Fakes;
using TechTalk.SpecFlow;

namespace Tests
{
    [Binding]
    class ShimSupport
    {
        private IDisposable _shimContext;

        [BeforeScenario]
        public void InitializeShimContext()
        {
            _shimContext = ShimsContext.Create();
        }

        [AfterScenario]
        public void DeinitializeShimContext()
        {
            _shimContext.Dispose();
            _shimContext = null;
        }
    }
}
