using PanuonSetup.Core;

namespace PanuonSetup.Themes
{
    /// <summary>
    /// 提供主题的切换功能。
    /// </summary>
    public interface IThemeManager
    {
        /// <summary>
        /// 切换主题。
        /// </summary>
        /// <param name="theme">要切换的主题。</param>
        /// <param name="isNightMode">是否为夜间模式。</param>
        void ChangeTheme(PresetTheme theme);
    }
}
