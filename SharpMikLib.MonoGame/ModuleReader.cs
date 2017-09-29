using System;
using System.IO;
using Microsoft.Xna.Framework.Content;
using SharpMik;

namespace SharpMikLib.MonoGame
{
	public class ModuleReader : ContentTypeReader<Module>
	{
		protected override Module Read (ContentReader input, Module existingInstance)
		{
			var len = input.ReadInt32 ();
			var data = input.ReadBytes (len);
			using (var ms = new MemoryStream (data)) {
				return ModuleLoader.Load (ms, 64, 0);
			}
		}
	}
}
