using System;

namespace XMainClient
{
	// Token: 0x02000F8D RID: 3981
	internal class XBigMeleePointChange : XEventArgs
	{
		// Token: 0x0600D0B8 RID: 53432 RVA: 0x00304F4C File Offset: 0x0030314C
		public XBigMeleePointChange()
		{
			this._eDefine = XEventDefine.XEvent_BigMeleePointChange;
		}

		// Token: 0x0600D0B9 RID: 53433 RVA: 0x00304F68 File Offset: 0x00303168
		public override void Recycle()
		{
			base.Recycle();
			this.point = 0U;
			XEventPool<XBigMeleePointChange>.Recycle(this);
		}

		// Token: 0x04005E74 RID: 24180
		public uint point = 0U;
	}
}
