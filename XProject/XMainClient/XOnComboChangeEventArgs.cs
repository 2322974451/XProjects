using System;

namespace XMainClient
{
	// Token: 0x02000FA9 RID: 4009
	internal class XOnComboChangeEventArgs : XEventArgs
	{
		// Token: 0x0600D0F8 RID: 53496 RVA: 0x003054BE File Offset: 0x003036BE
		public XOnComboChangeEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_ComboChange;
		}

		// Token: 0x0600D0F9 RID: 53497 RVA: 0x003054DA File Offset: 0x003036DA
		public override void Recycle()
		{
			base.Recycle();
			this.ComboCount = 0U;
			XEventPool<XOnComboChangeEventArgs>.Recycle(this);
		}

		// Token: 0x04005E90 RID: 24208
		public uint ComboCount = 0U;
	}
}
