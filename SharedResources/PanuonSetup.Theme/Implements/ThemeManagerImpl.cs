using PanuonSetup.Core;
using PanuonSetup.Themes;
using System;
using System.ComponentModel.Composition;
using System.Windows;

namespace Uniner.Theme.Implements
{
    [Export(typeof(IThemeManager))]
    class ThemeManagerImpl : IThemeManager
    {
        #region Fields
        #endregion

        #region Methods
        public void ChangeTheme(PresetTheme theme)
        {
            var mergedDictionaries = Application.Current.Resources.MergedDictionaries;

            for (int i = mergedDictionaries.Count - 1; i >= 0; i--)
            {
                var dictionary = mergedDictionaries[i];
                if (dictionary.Source != null && dictionary.Source.ToString().Contains("PanuonSetup.Themes;component/Themes"))
                {
                    mergedDictionaries.RemoveAt(i);
                    continue;
                }
            }

            mergedDictionaries.Add(new ResourceDictionary()
            {
                Source = new Uri($"pack://application:,,,/PanuonSetup.Themes;component/Themes/{theme}.xaml")
            });
        }
        #endregion
    }
}
