using System;

namespace XMainClient
{

	internal class XOnMountedEventArgs : XEventArgs
	{

		public XOnMountedEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_OnMounted;
		}

		public override void Recycle()
		{
			base.Recycle();
			XEventPool<XOnMountedEventArgs>.Recycle(this);
		}
	}
}
