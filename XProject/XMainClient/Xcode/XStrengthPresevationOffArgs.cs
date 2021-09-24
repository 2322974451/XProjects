using System;

namespace XMainClient
{

	internal class XStrengthPresevationOffArgs : XEventArgs
	{

		public XStrengthPresevationOffArgs()
		{
			this._eDefine = XEventDefine.XEvent_StrengthPresevedOff;
		}

		public override void Recycle()
		{
			this.Host = null;
			base.Recycle();
			XEventPool<XStrengthPresevationOffArgs>.Recycle(this);
		}

		public XEntity Host;
	}
}
