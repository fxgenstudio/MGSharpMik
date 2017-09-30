using System;
using Microsoft.Xna.Framework.Content.Pipeline;

namespace SharpMikLib.Content.Pipeline
{
	[ContentProcessor (DisplayName = "ModuleProcessor")]
	public class ModuleProcessor : ContentProcessor<ModuleData, ModuleData>
	{
		public override ModuleData Process (ModuleData input, ContentProcessorContext context)
		{
			return input;
		}
	}
}
