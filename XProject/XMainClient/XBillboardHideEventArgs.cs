using System;

namespace XMainClient
{
	// Token: 0x02000F63 RID: 3939
	internal class XBillboardHideEventArgs : XEventArgs
	{
		// Token: 0x0600D035 RID: 53301 RVA: 0x0030426B File Offset: 0x0030246B
		public XBillboardHideEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_BillboardHide;
			this.hidetime = 0f;
		}

		// Token: 0x0600D036 RID: 53302 RVA: 0x00304288 File Offset: 0x00302488
		public override void Recycle()
		{
			base.Recycle();
			XEventPool<XBillboardHideEventArgs>.Recycle(this);
		}

		// Token: 0x04005E24 RID: 24100
		public float hidetime;
	}
}
