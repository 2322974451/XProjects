using System;

namespace XMainClient
{

	internal class XIdleEventArgs : XActionArgs
	{

		public XIdleEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_Idle;
		}

		public override void Recycle()
		{
			base.Recycle();
			XEventPool<XIdleEventArgs>.Recycle(this);
		}
	}
}
