using System;

namespace XMainClient
{
	// Token: 0x02000F78 RID: 3960
	internal class XLoadEquipEventArgs : XEventArgs
	{
		// Token: 0x0600D08A RID: 53386 RVA: 0x00304991 File Offset: 0x00302B91
		public XLoadEquipEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_LoadEquip;
		}

		// Token: 0x0600D08B RID: 53387 RVA: 0x003049A3 File Offset: 0x00302BA3
		public override void Recycle()
		{
			base.Recycle();
			this.item = null;
			this.slot = 0;
			XEventPool<XLoadEquipEventArgs>.Recycle(this);
		}

		// Token: 0x04005E50 RID: 24144
		public XItem item;

		// Token: 0x04005E51 RID: 24145
		public int slot;
	}
}
