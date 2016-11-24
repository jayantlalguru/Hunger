using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hunger.DependencyEngine.Engine.MEF
{
    public interface IBootstrapper
    {
        void InitializeApplication();
    }
}
