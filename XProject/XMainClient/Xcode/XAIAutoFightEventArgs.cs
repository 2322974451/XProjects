using System;

namespace XMainClient
{

	internal class XAIAutoFightEventArgs : XEventArgs
	{

		public XAIAutoFightEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_AIAutoFight;
		}

		public override void Recycle()
		{
			base.Recycle();
			XEventPool<XAIAutoFightEventArgs>.Recycle(this);
		}
	}
}
