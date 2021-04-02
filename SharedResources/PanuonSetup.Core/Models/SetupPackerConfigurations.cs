namespace PanuonSetup.Core
{
    /// <summary>
    /// 安装打包器的配置。
    /// </summary>
    public class SetupPackerConfigurations
    {
        #region Ctor
        public SetupPackerConfigurations(PackType packType)
        {
            PackType = packType;
        }
        #endregion

        #region Properties
        PackType PackType { get; set; }
        #endregion
    }
}
