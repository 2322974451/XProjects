using System;

namespace XMainClient
{

	internal class XLeaveTeamEventArgs : XEventArgs
	{

		public XLeaveTeamEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_LeaveTeam;
		}

		public override void Recycle()
		{
			base.Recycle();
			this.dungeonID = 0U;
			XEventPool<XLeaveTeamEventArgs>.Recycle(this);
		}

		public uint dungeonID;
	}
}
