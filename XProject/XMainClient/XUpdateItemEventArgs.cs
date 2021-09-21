using System;

namespace XMainClient
{
	// Token: 0x02000F7E RID: 3966
	internal class XUpdateItemEventArgs : XEventArgs
	{
		// Token: 0x0600D099 RID: 53401 RVA: 0x00304C29 File Offset: 0x00302E29
		public XUpdateItemEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_UpdateItem;
		}

		// Token: 0x0600D09A RID: 53402 RVA: 0x00304C3B File Offset: 0x00302E3B
		public override void Recycle()
		{
			base.Recycle();
			this.item = null;
			XEventPool<XUpdateItemEventArgs>.Recycle(this);
		}

		// Token: 0x04005E60 RID: 24160
		public XItem item;
	}
}
