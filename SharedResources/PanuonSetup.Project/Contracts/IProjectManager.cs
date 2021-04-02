using PanuonSetup.Core;

namespace PanuonSetup.Project
{
    /// <summary>
    /// 定义项目管理器的核心接口。
    /// </summary>
    public interface IProjectManager
    {
        /// <summary>
        /// 创建新项目。
        /// </summary>
        /// <param name="projectType">项目类型。</param>
        /// <param name="name">项目名称。</param>
        /// <param name="sourcePath">项目路径。</param>
        void CreateProject(PackType projectType, string name, string sourcePath);
    }
}
