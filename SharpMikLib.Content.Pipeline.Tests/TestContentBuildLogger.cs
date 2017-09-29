using System;
using Microsoft.Xna.Framework.Content.Pipeline;

namespace SharpMikLib.Content.Pipeline.Tests
{
	class TestContentBuildLogger : ContentBuildLogger
	{
		public override void LogImportantMessage (string message, params object [] messageArgs)
		{
		}

		public override void LogMessage (string message, params object [] messageArgs)
		{
		}

		public override void LogWarning (string helpLink, ContentIdentity contentIdentity, string message, params object [] messageArgs)
		{
		}
	}
}
