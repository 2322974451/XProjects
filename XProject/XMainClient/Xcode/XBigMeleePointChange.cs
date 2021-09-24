using System;

namespace XMainClient
{

	internal class XBigMeleePointChange : XEventArgs
	{

		public XBigMeleePointChange()
		{
			this._eDefine = XEventDefine.XEvent_BigMeleePointChange;
		}

		public override void Recycle()
		{
			base.Recycle();
			this.point = 0U;
			XEventPool<XBigMeleePointChange>.Recycle(this);
		}

		public uint point = 0U;
	}
}
