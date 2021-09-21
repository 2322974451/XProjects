using System;

namespace XMainClient
{
	// Token: 0x02000F6E RID: 3950
	internal class XHUDDoodadArgs : XEventArgs
	{
		// Token: 0x0600D06A RID: 53354 RVA: 0x003046EF File Offset: 0x003028EF
		public XHUDDoodadArgs()
		{
			this._eDefine = XEventDefine.XEvent_HUDDoodad;
		}

		// Token: 0x0600D06B RID: 53355 RVA: 0x00304701 File Offset: 0x00302901
		public override void Recycle()
		{
			this.count = 0;
			this.itemid = 0;
			base.Recycle();
			XEventPool<XHUDDoodadArgs>.Recycle(this);
		}

		// Token: 0x17003699 RID: 13977
		// (get) Token: 0x0600D06C RID: 53356 RVA: 0x00304722 File Offset: 0x00302922
		// (set) Token: 0x0600D06D RID: 53357 RVA: 0x0030472A File Offset: 0x0030292A
		public int count { get; set; }

		// Token: 0x1700369A RID: 13978
		// (get) Token: 0x0600D06E RID: 53358 RVA: 0x00304733 File Offset: 0x00302933
		// (set) Token: 0x0600D06F RID: 53359 RVA: 0x0030473B File Offset: 0x0030293B
		public int itemid { get; set; }
	}
}
