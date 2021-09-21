using System;

namespace XMainClient
{
	// Token: 0x02000F6A RID: 3946
	internal class XAttrChangeEventArgs : XEventArgs
	{
		// Token: 0x0600D04E RID: 53326 RVA: 0x003044FA File Offset: 0x003026FA
		public XAttrChangeEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_AttributeChange;
			this.AttrKey = XAttributeDefine.XAttr_Invalid;
			this.DeltaValue = 0.0;
			this.bShowHUD = false;
			this.CasterID = 0UL;
		}

		// Token: 0x0600D04F RID: 53327 RVA: 0x00304535 File Offset: 0x00302735
		public override void Recycle()
		{
			this.AttrKey = XAttributeDefine.XAttr_Invalid;
			this.DeltaValue = 0.0;
			this.bShowHUD = false;
			this.CasterID = 0UL;
			base.Recycle();
			XEventPool<XAttrChangeEventArgs>.Recycle(this);
		}

		// Token: 0x1700368F RID: 13967
		// (get) Token: 0x0600D050 RID: 53328 RVA: 0x0030456F File Offset: 0x0030276F
		// (set) Token: 0x0600D051 RID: 53329 RVA: 0x00304577 File Offset: 0x00302777
		public XAttributeDefine AttrKey { get; set; }

		// Token: 0x17003690 RID: 13968
		// (get) Token: 0x0600D052 RID: 53330 RVA: 0x00304580 File Offset: 0x00302780
		// (set) Token: 0x0600D053 RID: 53331 RVA: 0x00304588 File Offset: 0x00302788
		public double DeltaValue { get; set; }

		// Token: 0x17003691 RID: 13969
		// (get) Token: 0x0600D054 RID: 53332 RVA: 0x00304591 File Offset: 0x00302791
		// (set) Token: 0x0600D055 RID: 53333 RVA: 0x00304599 File Offset: 0x00302799
		public ulong CasterID { get; set; }

		// Token: 0x17003692 RID: 13970
		// (get) Token: 0x0600D056 RID: 53334 RVA: 0x003045A2 File Offset: 0x003027A2
		// (set) Token: 0x0600D057 RID: 53335 RVA: 0x003045AA File Offset: 0x003027AA
		public bool bShowHUD { get; set; }
	}
}
