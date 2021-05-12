﻿using System;
using Avalonia.Markup.Xaml;

namespace Avalonia.Svg.Skia
{
    /// <summary>
    /// Svg image markup extension.
    /// </summary>
    public class SvgImageExtension : MarkupExtension
    {
        /// <summary>
        /// Initialises a new instance of an <see cref="SvgContentExtension"/>.
        /// </summary>
        /// <param name="path">The resource or file path</param>
        public SvgImageExtension(string path) => Path = path;

        /// <summary>
        /// Gets or sets resource or file path.
        /// </summary>
        public string Path { get; }

        /// <inheritdoc/>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var path = Path;
            var context = (IUriContext)serviceProvider.GetService(typeof(IUriContext))!;
            var baseUri = context.BaseUri;
            var source = SvgSource.Load(path, baseUri);
            return new SvgImage {Source = source};
        }


    }
}
