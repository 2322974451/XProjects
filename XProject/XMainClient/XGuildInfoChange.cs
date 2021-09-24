using System;

namespace XMainClient
{

	internal class XGuildInfoChange : XEventArgs
	{

		public XGuildInfoChange()
		{
			this._eDefine = XEventDefine.XEvent_GuildInfoChange;
		}

		public override void Recycle()
		{
			base.Recycle();
			XEventPool<XGuildInfoChange>.Recycle(this);
		}
	}
}
