using System;

namespace XMainClient
{

	internal class XTeamMemberCountChangedEventArgs : XEventArgs
	{

		public XTeamMemberCountChangedEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_TeamMemberCountChanged;
		}

		public override void Recycle()
		{
			base.Recycle();
			this.oldCount = 0U;
			this.newCount = 0U;
			XEventPool<XTeamMemberCountChangedEventArgs>.Recycle(this);
		}

		public uint oldCount;

		public uint newCount;
	}
}
