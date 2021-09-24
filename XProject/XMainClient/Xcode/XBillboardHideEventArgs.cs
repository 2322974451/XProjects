using System;

namespace XMainClient
{

	internal class XBillboardHideEventArgs : XEventArgs
	{

		public XBillboardHideEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_BillboardHide;
			this.hidetime = 0f;
		}

		public override void Recycle()
		{
			base.Recycle();
			XEventPool<XBillboardHideEventArgs>.Recycle(this);
		}

		public float hidetime;
	}
}
