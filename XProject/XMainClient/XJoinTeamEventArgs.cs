using System;

namespace XMainClient
{
	// Token: 0x02000F82 RID: 3970
	internal class XJoinTeamEventArgs : XEventArgs
	{
		// Token: 0x0600D0A2 RID: 53410 RVA: 0x00304D29 File Offset: 0x00302F29
		public XJoinTeamEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_JoinTeam;
		}

		// Token: 0x0600D0A3 RID: 53411 RVA: 0x00304D3B File Offset: 0x00302F3B
		public override void Recycle()
		{
			base.Recycle();
			this.dungeonID = 0U;
			XEventPool<XJoinTeamEventArgs>.Recycle(this);
		}

		// Token: 0x04005E67 RID: 24167
		public uint dungeonID;
	}
}
