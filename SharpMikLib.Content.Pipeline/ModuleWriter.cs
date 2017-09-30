using System;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;

namespace SharpMikLib.Content.Pipeline
{
	[ContentTypeWriter]
	public class ModuleWriter : ContentTypeWriter<ModuleData>
	{
		protected override void Write (ContentWriter output, ModuleData value)
		{
			output.Write (value.Data.Length);
			output.Write (value.Data);
		}

		public override string GetRuntimeType (TargetPlatform targetPlatform)
		{
			return typeof (SharpMik.Module).AssemblyQualifiedName;
		}
		public override string GetRuntimeReader (TargetPlatform targetPlatform)
		{
			return "SharpMikLib.MonoGame.ModuleReader, SharpMikLib.MonoGame, Version=1.0.0.0, Culture=neutral";
		}
	}
}
