using System;

namespace XMainClient
{
	// Token: 0x02000F83 RID: 3971
	internal class XLeaveTeamEventArgs : XEventArgs
	{
		// Token: 0x0600D0A4 RID: 53412 RVA: 0x00304D53 File Offset: 0x00302F53
		public XLeaveTeamEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_LeaveTeam;
		}

		// Token: 0x0600D0A5 RID: 53413 RVA: 0x00304D65 File Offset: 0x00302F65
		public override void Recycle()
		{
			base.Recycle();
			this.dungeonID = 0U;
			XEventPool<XLeaveTeamEventArgs>.Recycle(this);
		}

		// Token: 0x04005E68 RID: 24168
		public uint dungeonID;
	}
}
