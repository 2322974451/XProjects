using System;

namespace XMainClient
{

	internal class XWoozyOnArgs : XEventArgs
	{

		public XWoozyOnArgs()
		{
			this._eDefine = XEventDefine.XEvent_WoozyOn;
		}

		public override void Recycle()
		{
			base.Recycle();
			this.Self = null;
			XEventPool<XWoozyOnArgs>.Recycle(this);
		}

		public XEntity Self;
	}
}
