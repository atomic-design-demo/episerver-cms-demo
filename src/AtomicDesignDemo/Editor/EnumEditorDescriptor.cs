using System;
using System.Collections.Generic;
using EPiServer.Shell.ObjectEditing;
using EPiServer.Shell.ObjectEditing.EditorDescriptors;

namespace AtomicDesignDemo.Editor
{
    public class EnumEditorDescriptor<TEnum> : EditorDescriptor
    {
        /// <summary>
        /// Modifies the metadata.
        /// </summary>
        /// <param name="metadata">The metadata.</param>
        /// <param name="attributes">The attributes.</param>
        public override void ModifyMetadata(ExtendedMetadata metadata, IEnumerable<Attribute> attributes)
        {
            SelectionFactoryType = typeof(EnumSelectionFactory<TEnum>);
            // ReSharper disable once StringLiteralTypo
            ClientEditingClass = "epi-cms/contentediting/editors/SelectionEditor";
            base.ModifyMetadata(metadata, attributes);
        }
    }
}
