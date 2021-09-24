using System;

namespace XMainClient
{

	internal class XCommandPureOverlay : XBaseCommand
	{

		public override bool Execute()
		{
			base.SetOverlay();
			base.publicModule();
			return true;
		}

		public override void Stop()
		{
			base.DestroyOverlay();
		}
	}
}
