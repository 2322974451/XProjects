using System;

namespace XMainClient
{

	internal class XJoinTeamEventArgs : XEventArgs
	{

		public XJoinTeamEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_JoinTeam;
		}

		public override void Recycle()
		{
			base.Recycle();
			this.dungeonID = 0U;
			XEventPool<XJoinTeamEventArgs>.Recycle(this);
		}

		public uint dungeonID;
	}
}
