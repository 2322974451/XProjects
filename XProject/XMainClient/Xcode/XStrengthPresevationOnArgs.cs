using System;

namespace XMainClient
{

	internal class XStrengthPresevationOnArgs : XEventArgs
	{

		public XStrengthPresevationOnArgs()
		{
			this._eDefine = XEventDefine.XEvent_StrengthPresevedOn;
		}

		public override void Recycle()
		{
			this.Host = null;
			base.Recycle();
			XEventPool<XStrengthPresevationOnArgs>.Recycle(this);
		}

		public XEntity Host;
	}
}
