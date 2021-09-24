using System;

namespace XMainClient
{

	internal class XBuffBillboardRemoveEventArgs : XEventArgs
	{

		public XBuffBillboardRemoveEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_BuffBillboardRemove;
			this.xBuffID = 0;
		}

		public override void Recycle()
		{
			base.Recycle();
			XEventPool<XBuffBillboardRemoveEventArgs>.Recycle(this);
		}

		public int xBuffID;
	}
}
