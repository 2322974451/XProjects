using System;

namespace XMainClient
{

	internal class XUpdateItemEventArgs : XEventArgs
	{

		public XUpdateItemEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_UpdateItem;
		}

		public override void Recycle()
		{
			base.Recycle();
			this.item = null;
			XEventPool<XUpdateItemEventArgs>.Recycle(this);
		}

		public XItem item;
	}
}
