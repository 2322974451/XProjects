using System;

namespace XMainClient
{
	// Token: 0x02000FAB RID: 4011
	internal class XManipulationOffEventArgs : XEventArgs
	{
		// Token: 0x0600D0FC RID: 53500 RVA: 0x00305526 File Offset: 0x00303726
		public XManipulationOffEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_Manipulation_Off;
		}

		// Token: 0x0600D0FD RID: 53501 RVA: 0x00305543 File Offset: 0x00303743
		public override void Recycle()
		{
			base.Recycle();
			this.DenyToken = 0L;
			XEventPool<XManipulationOffEventArgs>.Recycle(this);
		}

		// Token: 0x04005E92 RID: 24210
		public long DenyToken = 0L;
	}
}
