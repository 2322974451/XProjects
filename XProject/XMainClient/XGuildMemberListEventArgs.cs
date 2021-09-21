using System;

namespace XMainClient
{
	// Token: 0x02000F95 RID: 3989
	internal class XGuildMemberListEventArgs : XEventArgs
	{
		// Token: 0x0600D0C8 RID: 53448 RVA: 0x003050B2 File Offset: 0x003032B2
		public XGuildMemberListEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_GuildMemberList;
		}

		// Token: 0x0600D0C9 RID: 53449 RVA: 0x003050C4 File Offset: 0x003032C4
		public override void Recycle()
		{
			base.Recycle();
			XEventPool<XGuildMemberListEventArgs>.Recycle(this);
		}
	}
}
