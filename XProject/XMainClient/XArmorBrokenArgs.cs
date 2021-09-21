using System;

namespace XMainClient
{
	// Token: 0x02000F99 RID: 3993
	internal class XArmorBrokenArgs : XEventArgs
	{
		// Token: 0x0600D0D8 RID: 53464 RVA: 0x003051D2 File Offset: 0x003033D2
		public XArmorBrokenArgs()
		{
			this._eDefine = XEventDefine.XEvent_ArmorBroken;
		}

		// Token: 0x0600D0D9 RID: 53465 RVA: 0x003051E7 File Offset: 0x003033E7
		public override void Recycle()
		{
			base.Recycle();
			this.Self = null;
			XEventPool<XArmorBrokenArgs>.Recycle(this);
		}

		// Token: 0x04005E81 RID: 24193
		public XEntity Self;
	}
}
