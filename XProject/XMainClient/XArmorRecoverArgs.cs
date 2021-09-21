using System;

namespace XMainClient
{
	// Token: 0x02000F9A RID: 3994
	internal class XArmorRecoverArgs : XEventArgs
	{
		// Token: 0x0600D0DA RID: 53466 RVA: 0x003051FF File Offset: 0x003033FF
		public XArmorRecoverArgs()
		{
			this._eDefine = XEventDefine.XEvent_ArmorRecover;
		}

		// Token: 0x0600D0DB RID: 53467 RVA: 0x00305214 File Offset: 0x00303414
		public override void Recycle()
		{
			base.Recycle();
			this.Self = null;
			XEventPool<XArmorRecoverArgs>.Recycle(this);
		}

		// Token: 0x04005E82 RID: 24194
		public XEntity Self;
	}
}
