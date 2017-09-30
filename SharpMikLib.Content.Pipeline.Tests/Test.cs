using NUnit.Framework;
using System;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace SharpMikLib.Content.Pipeline.Tests
{
	[TestFixture ()]
	public class Test
	{
		[Test]
		public void TestModImporter () {
			Directory.SetCurrentDirectory (Path.GetDirectoryName (typeof (Test).Assembly.Location));
			var context = new TestProcessorContext (TargetPlatform.DesktopGL, "Stardust.xnb");
			var processor = new ModuleProcessor ();
			Directory.CreateDirectory ("obj");
			var importContext = new TestImporterContext ("obj", ".");
			var importer = new ModImporter ();

			var module = importer.Import ("Stardust.MOD", importContext);
			var output = processor.Process (module, context);

			var _compiler = new ContentCompiler ();
			using (var stream = new FileStream ("Stardust.xnb", FileMode.Create, FileAccess.Write, FileShare.None))
				_compiler.Compile (stream, output, TargetPlatform.DesktopGL, GraphicsProfile.HiDef, false, ".", ".");

		}
	}
}
