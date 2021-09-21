using System;
using KKSG;

namespace XMainClient
{
	// Token: 0x02000F84 RID: 3972
	internal class XReconnectedEventArgs : XEventArgs
	{
		// Token: 0x0600D0A6 RID: 53414 RVA: 0x00304D7D File Offset: 0x00302F7D
		public XReconnectedEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_OnReconnected;
		}

		// Token: 0x0600D0A7 RID: 53415 RVA: 0x00304D9D File Offset: 0x00302F9D
		public override void Recycle()
		{
			base.Recycle();
			XEventPool<XReconnectedEventArgs>.Recycle(this);
		}

		// Token: 0x04005E69 RID: 24169
		public RoleAllInfo PlayerInfo = null;

		// Token: 0x04005E6A RID: 24170
		public UnitAppearance PlayUnit = null;
	}
}
