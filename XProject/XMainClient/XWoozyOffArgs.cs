using System;

namespace XMainClient
{

	internal class XWoozyOffArgs : XEventArgs
	{

		public XWoozyOffArgs()
		{
			this._eDefine = XEventDefine.XEvent_WoozyOff;
		}

		public override void Recycle()
		{
			base.Recycle();
			this.Self = null;
			XEventPool<XWoozyOffArgs>.Recycle(this);
		}

		public XEntity Self;
	}
}
