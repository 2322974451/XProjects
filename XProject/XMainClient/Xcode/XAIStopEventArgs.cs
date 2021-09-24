using System;

namespace XMainClient
{

	internal class XAIStopEventArgs : XEventArgs
	{

		public XAIStopEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_AIStop;
		}

		public override void Recycle()
		{
			base.Recycle();
			XEventPool<XAIStopEventArgs>.Recycle(this);
		}
	}
}
