using System;
using System.Collections.Generic;

namespace XMainClient
{
	// Token: 0x02000F7A RID: 3962
	internal class XAddItemEventArgs : XEventArgs
	{
		// Token: 0x0600D08E RID: 53390 RVA: 0x003049F3 File Offset: 0x00302BF3
		public XAddItemEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_AddItem;
		}

		// Token: 0x0600D08F RID: 53391 RVA: 0x00304A17 File Offset: 0x00302C17
		public override void Recycle()
		{
			base.Recycle();
			this.items.Clear();
			this.bNew = true;
			XEventPool<XAddItemEventArgs>.Recycle(this);
		}

		// Token: 0x0600D090 RID: 53392 RVA: 0x00304A3C File Offset: 0x00302C3C
		public override XEventArgs Clone()
		{
			XAddItemEventArgs @event = XEventPool<XAddItemEventArgs>.GetEvent();
			@event.bNew = this.bNew;
			for (int i = 0; i < this.items.Count; i++)
			{
				@event.items.Add(this.items[i]);
			}
			return @event;
		}

		// Token: 0x04005E55 RID: 24149
		public bool bNew = true;

		// Token: 0x04005E56 RID: 24150
		public List<XItem> items = new List<XItem>();
	}
}
