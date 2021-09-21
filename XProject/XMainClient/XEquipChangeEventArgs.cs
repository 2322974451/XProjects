using System;
using System.Collections.Generic;

namespace XMainClient
{
	// Token: 0x02000F54 RID: 3924
	internal class XEquipChangeEventArgs : XEventArgs
	{
		// Token: 0x0600D00B RID: 53259 RVA: 0x00303D75 File Offset: 0x00301F75
		public XEquipChangeEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_EquipChange;
		}

		// Token: 0x0600D00C RID: 53260 RVA: 0x00303D87 File Offset: 0x00301F87
		public override void Recycle()
		{
			this.EquipPart = null;
			this.ItemID = null;
			base.Recycle();
			XEventPool<XEquipChangeEventArgs>.Recycle(this);
		}

		// Token: 0x17003684 RID: 13956
		// (get) Token: 0x0600D00D RID: 53261 RVA: 0x00303DA8 File Offset: 0x00301FA8
		// (set) Token: 0x0600D00E RID: 53262 RVA: 0x00303DB0 File Offset: 0x00301FB0
		public List<uint> EquipPart { get; set; }

		// Token: 0x17003685 RID: 13957
		// (get) Token: 0x0600D00F RID: 53263 RVA: 0x00303DB9 File Offset: 0x00301FB9
		// (set) Token: 0x0600D010 RID: 53264 RVA: 0x00303DC1 File Offset: 0x00301FC1
		public List<uint> ItemID { get; set; }
	}
}
