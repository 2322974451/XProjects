using System;

namespace XMainClient
{

	internal class XGuildPositionChangedEventArgs : XEventArgs
	{

		public XGuildPositionChangedEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_GuildPositionChanged;
		}

		public override void Recycle()
		{
			base.Recycle();
			XEventPool<XGuildPositionChangedEventArgs>.Recycle(this);
			this.position = GuildPosition.GPOS_COUNT;
		}

		public GuildPosition position = GuildPosition.GPOS_COUNT;
	}
}
