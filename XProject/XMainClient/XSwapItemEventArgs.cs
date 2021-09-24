using System;

namespace XMainClient
{

	internal class XSwapItemEventArgs : XEventArgs
	{

		public XSwapItemEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_SwapItem;
		}

		public override void Recycle()
		{
			base.Recycle();
			this.itemNowOnBody = null;
			this.itemNowInBag = null;
			this.slot = 0;
			XEventPool<XSwapItemEventArgs>.Recycle(this);
		}

		public XItem itemNowOnBody;

		public XItem itemNowInBag;

		public int slot;
	}
}
