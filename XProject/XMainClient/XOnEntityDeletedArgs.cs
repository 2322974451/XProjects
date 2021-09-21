using System;

namespace XMainClient
{
	// Token: 0x02000FA4 RID: 4004
	internal class XOnEntityDeletedArgs : XEventArgs
	{
		// Token: 0x0600D0EE RID: 53486 RVA: 0x003053D3 File Offset: 0x003035D3
		public XOnEntityDeletedArgs()
		{
			this._eDefine = XEventDefine.XEvent_OnEntityDeleted;
			this.Id = 0UL;
		}

		// Token: 0x0600D0EF RID: 53487 RVA: 0x003053ED File Offset: 0x003035ED
		public override void Recycle()
		{
			base.Recycle();
			this.Id = 0UL;
			XEventPool<XOnEntityDeletedArgs>.Recycle(this);
		}

		// Token: 0x04005E8B RID: 24203
		public ulong Id;
	}
}
