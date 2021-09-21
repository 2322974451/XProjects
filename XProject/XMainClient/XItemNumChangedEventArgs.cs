using System;

namespace XMainClient
{
	// Token: 0x02000F7C RID: 3964
	internal class XItemNumChangedEventArgs : XEventArgs
	{
		// Token: 0x0600D094 RID: 53396 RVA: 0x00304B79 File Offset: 0x00302D79
		public XItemNumChangedEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_ItemNumChanged;
		}

		// Token: 0x0600D095 RID: 53397 RVA: 0x00304B92 File Offset: 0x00302D92
		public override void Recycle()
		{
			base.Recycle();
			this.item = null;
			this.bNew = true;
			XEventPool<XItemNumChangedEventArgs>.Recycle(this);
		}

		// Token: 0x0600D096 RID: 53398 RVA: 0x00304BB4 File Offset: 0x00302DB4
		public override XEventArgs Clone()
		{
			XItemNumChangedEventArgs @event = XEventPool<XItemNumChangedEventArgs>.GetEvent();
			@event.oldCount = this.oldCount;
			@event.item = this.item;
			@event.bNew = this.bNew;
			return @event;
		}

		// Token: 0x04005E5A RID: 24154
		public int oldCount;

		// Token: 0x04005E5B RID: 24155
		public XItem item;

		// Token: 0x04005E5C RID: 24156
		public bool bNew = true;
	}
}
