using System;

namespace XMainClient
{
	// Token: 0x02000F79 RID: 3961
	internal class XUnloadEquipEventArgs : XEventArgs
	{
		// Token: 0x0600D08C RID: 53388 RVA: 0x003049C2 File Offset: 0x00302BC2
		public XUnloadEquipEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_UnloadEquip;
		}

		// Token: 0x0600D08D RID: 53389 RVA: 0x003049D4 File Offset: 0x00302BD4
		public override void Recycle()
		{
			base.Recycle();
			this.slot = 0;
			this.item = null;
			XEventPool<XUnloadEquipEventArgs>.Recycle(this);
		}

		// Token: 0x04005E52 RID: 24146
		public int slot;

		// Token: 0x04005E53 RID: 24147
		public XItem item;

		// Token: 0x04005E54 RID: 24148
		public ItemType type;
	}
}
