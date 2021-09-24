using System;

namespace XMainClient
{

	internal class XBuffBillboardAddEventArgs : XEventArgs
	{

		public XBuffBillboardAddEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_BuffBillboardAdd;
			this.xBuffID = 0;
			this.xBuffLevel = 0;
		}

		public override void Recycle()
		{
			base.Recycle();
			XEventPool<XBuffBillboardAddEventArgs>.Recycle(this);
		}

		public int xBuffID;

		public int xBuffLevel;
	}
}
