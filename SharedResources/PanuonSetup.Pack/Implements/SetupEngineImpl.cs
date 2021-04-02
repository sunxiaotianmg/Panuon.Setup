using PanuonSetup.Core;
using PanuonSetup.Pack.Models.Internals;
using System.ComponentModel.Composition;

namespace PanuonSetup.Pack.Implements
{
    /// <summary>
    /// IInnoSetupEngine的内部实现。
    /// </summary>
    [Export(typeof(ISetupEngine))]
    class SetupEngineImpl : ISetupEngine
    {
        public ISetupPacker CreatePacker(SetupPackerConfigurations configurations)
        {
            return new InnoSetupPacker();
        }
    }
}
