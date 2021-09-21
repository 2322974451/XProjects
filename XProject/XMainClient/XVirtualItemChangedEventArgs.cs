using System;

namespace XMainClient
{
	// Token: 0x02000F7F RID: 3967
	internal class XVirtualItemChangedEventArgs : XEventArgs
	{
		// Token: 0x0600D09B RID: 53403 RVA: 0x00304C53 File Offset: 0x00302E53
		public XVirtualItemChangedEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_VirtualItemChanged;
		}

		// Token: 0x0600D09C RID: 53404 RVA: 0x00304C6D File Offset: 0x00302E6D
		public override void Recycle()
		{
			base.Recycle();
			this.e = ItemEnum.VIRTUAL_ITEM_MAX;
			this.newValue = 0UL;
			this.oldValue = 0UL;
			XEventPool<XVirtualItemChangedEventArgs>.Recycle(this);
		}

		// Token: 0x0600D09D RID: 53405 RVA: 0x00304C98 File Offset: 0x00302E98
		public override XEventArgs Clone()
		{
			XVirtualItemChangedEventArgs @event = XEventPool<XVirtualItemChangedEventArgs>.GetEvent();
			@event.newValue = this.newValue;
			@event.oldValue = this.oldValue;
			@event.itemID = this.itemID;
			return @event;
		}

		// Token: 0x04005E61 RID: 24161
		public ItemEnum e = ItemEnum.VIRTUAL_ITEM_MAX;

		// Token: 0x04005E62 RID: 24162
		public ulong newValue;

		// Token: 0x04005E63 RID: 24163
		public ulong oldValue;

		// Token: 0x04005E64 RID: 24164
		public int itemID;
	}
}
