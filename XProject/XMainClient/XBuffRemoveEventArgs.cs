using System;

namespace XMainClient
{
	// Token: 0x02000F65 RID: 3941
	internal class XBuffRemoveEventArgs : XEventArgs
	{
		// Token: 0x0600D039 RID: 53305 RVA: 0x003042C3 File Offset: 0x003024C3
		public XBuffRemoveEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_BuffRemove;
			this.xBuffID = 0;
		}

		// Token: 0x0600D03A RID: 53306 RVA: 0x003042DC File Offset: 0x003024DC
		public override void Recycle()
		{
			base.Recycle();
			XEventPool<XBuffRemoveEventArgs>.Recycle(this);
		}

		// Token: 0x04005E27 RID: 24103
		public int xBuffID;
	}
}
