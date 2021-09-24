using System;

namespace XMainClient
{

	internal class XBuffRemoveEventArgs : XEventArgs
	{

		public XBuffRemoveEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_BuffRemove;
			this.xBuffID = 0;
		}

		public override void Recycle()
		{
			base.Recycle();
			XEventPool<XBuffRemoveEventArgs>.Recycle(this);
		}

		public int xBuffID;
	}
}
