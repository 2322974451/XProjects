using System;

namespace XMainClient
{

	internal class XGuildMemberListEventArgs : XEventArgs
	{

		public XGuildMemberListEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_GuildMemberList;
		}

		public override void Recycle()
		{
			base.Recycle();
			XEventPool<XGuildMemberListEventArgs>.Recycle(this);
		}
	}
}
