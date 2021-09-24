using System;

namespace XMainClient
{

	internal class XAIRestartEventArgs : XEventArgs
	{

		public XAIRestartEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_AIRestart;
		}

		public override void Recycle()
		{
			base.Recycle();
			XEventPool<XAIRestartEventArgs>.Recycle(this);
		}
	}
}
