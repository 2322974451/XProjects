using System;

namespace XMainClient
{

	internal class XOnUnMountedEventArgs : XEventArgs
	{

		public XOnUnMountedEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_OnUnMounted;
		}

		public override void Recycle()
		{
			base.Recycle();
			XEventPool<XOnUnMountedEventArgs>.Recycle(this);
		}
	}
}
