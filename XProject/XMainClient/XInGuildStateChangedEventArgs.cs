using System;

namespace XMainClient
{
	// Token: 0x02000F8A RID: 3978
	internal class XInGuildStateChangedEventArgs : XEventArgs
	{
		// Token: 0x0600D0B2 RID: 53426 RVA: 0x00304EC4 File Offset: 0x003030C4
		public XInGuildStateChangedEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_InGuildStateChanged;
		}

		// Token: 0x0600D0B3 RID: 53427 RVA: 0x00304EE4 File Offset: 0x003030E4
		public override void Recycle()
		{
			base.Recycle();
			this.bIsEnter = true;
			this.bRoleInit = false;
			XEventPool<XInGuildStateChangedEventArgs>.Recycle(this);
		}

		// Token: 0x04005E72 RID: 24178
		public bool bIsEnter = true;

		// Token: 0x04005E73 RID: 24179
		public bool bRoleInit = false;
	}
}
