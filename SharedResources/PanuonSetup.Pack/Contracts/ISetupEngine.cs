using PanuonSetup.Core;

namespace PanuonSetup.Pack
{
    /// <summary>
    /// 定义打包引擎的核心接口。
    /// </summary>
    public interface ISetupEngine
    {
        /// <summary>
        /// 创建打包器。
        /// </summary>
        /// <returns></returns>
        ISetupPacker CreatePacker(SetupPackerConfigurations configurations);
    }
}
