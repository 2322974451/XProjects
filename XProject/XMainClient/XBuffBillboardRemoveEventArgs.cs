using System;

namespace XMainClient
{
	// Token: 0x02000F67 RID: 3943
	internal class XBuffBillboardRemoveEventArgs : XEventArgs
	{
		// Token: 0x0600D03E RID: 53310 RVA: 0x003043A1 File Offset: 0x003025A1
		public XBuffBillboardRemoveEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_BuffBillboardRemove;
			this.xBuffID = 0;
		}

		// Token: 0x0600D03F RID: 53311 RVA: 0x003043BA File Offset: 0x003025BA
		public override void Recycle()
		{
			base.Recycle();
			XEventPool<XBuffBillboardRemoveEventArgs>.Recycle(this);
		}

		// Token: 0x04005E2C RID: 24108
		public int xBuffID;
	}
}
