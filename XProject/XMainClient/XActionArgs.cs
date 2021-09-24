using System;

namespace XMainClient
{

	internal abstract class XActionArgs : XEventArgs
	{

		public override void Recycle()
		{
			base.Recycle();
		}
	}
}
