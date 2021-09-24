using System;

namespace XMainClient
{

	internal class XHitEventArgs : XEventArgs
	{

		public XHitEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_Hit;
		}

		public override void Recycle()
		{
			base.Recycle();
			XEventPool<XHitEventArgs>.Recycle(this);
		}
	}
}
