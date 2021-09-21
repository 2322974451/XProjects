using System;

namespace XMainClient
{
	// Token: 0x02000F69 RID: 3945
	internal class XEntityAttrChangeEventArgs : XEventArgs
	{
		// Token: 0x0600D042 RID: 53314 RVA: 0x003043F4 File Offset: 0x003025F4
		public XEntityAttrChangeEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_EntityAttributeChange;
			this.AttrKey = XAttributeDefine.XAttr_Invalid;
			this.Value = 0.0;
			this.Delta = 0.0;
			this.CasterID = 0UL;
			this.Entity = null;
		}

		// Token: 0x0600D043 RID: 53315 RVA: 0x00304450 File Offset: 0x00302650
		public override void Recycle()
		{
			this.AttrKey = XAttributeDefine.XAttr_Invalid;
			this.Value = 0.0;
			this.Delta = 0.0;
			this.CasterID = 0UL;
			this.Entity = null;
			base.Recycle();
			XEventPool<XEntityAttrChangeEventArgs>.Recycle(this);
		}

		// Token: 0x1700368A RID: 13962
		// (get) Token: 0x0600D044 RID: 53316 RVA: 0x003044A5 File Offset: 0x003026A5
		// (set) Token: 0x0600D045 RID: 53317 RVA: 0x003044AD File Offset: 0x003026AD
		public XAttributeDefine AttrKey { get; set; }

		// Token: 0x1700368B RID: 13963
		// (get) Token: 0x0600D046 RID: 53318 RVA: 0x003044B6 File Offset: 0x003026B6
		// (set) Token: 0x0600D047 RID: 53319 RVA: 0x003044BE File Offset: 0x003026BE
		public double Value { get; set; }

		// Token: 0x1700368C RID: 13964
		// (get) Token: 0x0600D048 RID: 53320 RVA: 0x003044C7 File Offset: 0x003026C7
		// (set) Token: 0x0600D049 RID: 53321 RVA: 0x003044CF File Offset: 0x003026CF
		public double Delta { get; set; }

		// Token: 0x1700368D RID: 13965
		// (get) Token: 0x0600D04A RID: 53322 RVA: 0x003044D8 File Offset: 0x003026D8
		// (set) Token: 0x0600D04B RID: 53323 RVA: 0x003044E0 File Offset: 0x003026E0
		public ulong CasterID { get; set; }

		// Token: 0x1700368E RID: 13966
		// (get) Token: 0x0600D04C RID: 53324 RVA: 0x003044E9 File Offset: 0x003026E9
		// (set) Token: 0x0600D04D RID: 53325 RVA: 0x003044F1 File Offset: 0x003026F1
		public XEntity Entity { get; set; }
	}
}
