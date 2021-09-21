using System;

namespace XMainClient
{
	// Token: 0x02000F7D RID: 3965
	internal class XSwapItemEventArgs : XEventArgs
	{
		// Token: 0x0600D097 RID: 53399 RVA: 0x00304BF1 File Offset: 0x00302DF1
		public XSwapItemEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_SwapItem;
		}

		// Token: 0x0600D098 RID: 53400 RVA: 0x00304C03 File Offset: 0x00302E03
		public override void Recycle()
		{
			base.Recycle();
			this.itemNowOnBody = null;
			this.itemNowInBag = null;
			this.slot = 0;
			XEventPool<XSwapItemEventArgs>.Recycle(this);
		}

		// Token: 0x04005E5D RID: 24157
		public XItem itemNowOnBody;

		// Token: 0x04005E5E RID: 24158
		public XItem itemNowInBag;

		// Token: 0x04005E5F RID: 24159
		public int slot;
	}
}
