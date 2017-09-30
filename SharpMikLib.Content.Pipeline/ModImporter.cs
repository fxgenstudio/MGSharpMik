using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;
using System.IO;
using SharpMik;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;
using Microsoft.Xna.Framework.Content;
using SharpMik.Player;
using Microsoft.Xna.Framework.Audio;
using SharpMik.Drivers;

namespace SharpMikLib.Content.Pipeline
{
	public class ModuleData
	{
		public byte [] Data;
	}

	[ContentImporter (".MOD", DisplayName = "ModImporter", DefaultProcessor = "ModuleProcessor")]
	public class ModImporter : ContentImporter<ModuleData>
	{
		public override ModuleData Import (string filename, ContentImporterContext context)
		{
			return new ModuleData () {
				Data = File.ReadAllBytes (filename),
			};
		}
	}
}
