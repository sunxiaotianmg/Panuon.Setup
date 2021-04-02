using PanuonSetup.Core;

namespace PanuonSetup.Pack
{
    /// <summary>
    /// 定义打包器的核心接口。
    /// </summary>
    public interface ISetupPacker
    {
        /// <summary>
        /// 开始执行打包。
        /// </summary>
        /// <returns></returns>
        PackResult Pack();
    }
}
