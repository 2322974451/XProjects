using System;

namespace XMainClient
{
	// Token: 0x02000F62 RID: 3938
	internal class XBuffBillboardAddEventArgs : XEventArgs
	{
		// Token: 0x0600D033 RID: 53299 RVA: 0x0030423A File Offset: 0x0030243A
		public XBuffBillboardAddEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_BuffBillboardAdd;
			this.xBuffID = 0;
			this.xBuffLevel = 0;
		}

		// Token: 0x0600D034 RID: 53300 RVA: 0x0030425A File Offset: 0x0030245A
		public override void Recycle()
		{
			base.Recycle();
			XEventPool<XBuffBillboardAddEventArgs>.Recycle(this);
		}

		// Token: 0x04005E22 RID: 24098
		public int xBuffID;

		// Token: 0x04005E23 RID: 24099
		public int xBuffLevel;
	}
}
