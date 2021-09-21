using System;
using System.Collections.Generic;

namespace XMainClient
{
	// Token: 0x02000F7B RID: 3963
	internal class XRemoveItemEventArgs : XEventArgs
	{
		// Token: 0x0600D091 RID: 53393 RVA: 0x00304A93 File Offset: 0x00302C93
		public XRemoveItemEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_RemoveItem;
		}

		// Token: 0x0600D092 RID: 53394 RVA: 0x00304AC6 File Offset: 0x00302CC6
		public override void Recycle()
		{
			base.Recycle();
			this.uids.Clear();
			this.types.Clear();
			this.ids.Clear();
			XEventPool<XRemoveItemEventArgs>.Recycle(this);
		}

		// Token: 0x0600D093 RID: 53395 RVA: 0x00304AFC File Offset: 0x00302CFC
		public override XEventArgs Clone()
		{
			XRemoveItemEventArgs @event = XEventPool<XRemoveItemEventArgs>.GetEvent();
			for (int i = 0; i < this.uids.Count; i++)
			{
				@event.uids.Add(this.uids[i]);
				@event.types.Add(this.types[i]);
				@event.ids.Add(this.ids[i]);
			}
			return @event;
		}

		// Token: 0x04005E57 RID: 24151
		public List<ulong> uids = new List<ulong>();

		// Token: 0x04005E58 RID: 24152
		public List<ItemType> types = new List<ItemType>();

		// Token: 0x04005E59 RID: 24153
		public List<int> ids = new List<int>();
	}
}
