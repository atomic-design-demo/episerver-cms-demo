using System;
using System.Collections.Generic;
using EPiServer.Framework.Localization;
using EPiServer.Shell.ObjectEditing;

namespace AtomicDesignDemo.Editor
{
    public class EnumSelectionFactory<TEnum> : ISelectionFactory
    {
        /// <summary>
        /// Gets the selections.
        /// </summary>
        /// <param name="metadata">The metadata.</param>
        /// <returns>IEnumerable&lt;ISelectItem&gt;.</returns>
        public IEnumerable<ISelectItem> GetSelections(ExtendedMetadata metadata)
        {
            var values = Enum.GetValues(typeof(TEnum));
            foreach (var value in values)
            {
                yield return new SelectItem
                {
                    Text = GetValueName(value),
                    Value = value
                };
            }
        }

        /// <summary>
        /// Gets the name of the value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.String.</returns>
        private string GetValueName(object value)
        {
            var staticName = Enum.GetName(typeof(TEnum), value);
            var localizationPath = $"/property/enum/{typeof(TEnum).Name.ToLowerInvariant()}/{staticName?.ToLowerInvariant()}";
            return LocalizationService.Current.TryGetString(localizationPath, out var localizedName)
                ? localizedName
                : staticName;
        }
    }
}
